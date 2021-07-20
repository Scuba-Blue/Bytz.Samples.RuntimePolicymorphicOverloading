using Bytz.Samples.RuntimePolicymorphicOverloading.Contracts;
using Bytz.Samples.RuntimePolicymorphicOverloading.Domain;
using System;

namespace Bytz.Samples.RuntimePolicymorphicOverloading
{
    class Program
    {
        /// <summary>
        /// examples for dynamic runtime polymorphism.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ShowTitle();

            BaseTypeCompiletimeOverloading();
            SpecificTypeCompiletimeOverloading();

            //  leverage dynamic for runtime overloading
            BaseTypeRuntimeOverloading();

            //  contract examples
            BaseContractTypeCompiletimeOverloading();
            SpecificContractTypeCompiletimeOverloading();

            //  leverage dynamic for runtime overloading
            BaseTypeContractRuntimeOverloading();
        }

        static void ShowTitle()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
            Console.WriteLine("Bytz.Samples.RuntimePolicymorphicOverloading.");
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        /// <summary>
        /// policymorphism will not work since the
        /// determination is made at compiletime.
        /// </summary>
        private static void BaseTypeCompiletimeOverloading()
        {
            Console.WriteLine();
            Console.WriteLine("Compiletime basetype overloading - calls FruitBase overload only since the declaring type is FruitBase.");
            Console.WriteLine();

            //  all will call the Fruitbase overload 
            //  since the declaring type is FruitBase
            FruitBase fruit = null;

            fruit = new Pear();
            DisplayType(fruit);

            fruit = new Apple();
            DisplayType(fruit);

            fruit = new Coconut();
            DisplayType(fruit);
        }

        private static void DisplayType(FruitBase fruit)
        {
            Console.WriteLine($"FruitBase overload - Instance type is {fruit}");
        }

        private static void DisplayType(Apple fruit)
        {
            Console.WriteLine($"Apple overload - Instance type is {fruit}");
        }

        private static void DisplayType(Coconut fruit)
        {
            Console.WriteLine($"Coconut overload - Instance type is {fruit}");
        }

        /// <summary>
        /// compiletime type overloading will call the 
        /// appropriate overload when defined, since
        /// the type of instance is known at compile time.
        /// </summary>
        private static void SpecificTypeCompiletimeOverloading()
        {
            Console.WriteLine();
            Console.WriteLine("Compiletime specific type overloading - calls appropriate overload since the declaring type is a specific type.");
            Console.WriteLine();

            Pear pear = new Pear();
            DisplayType(pear);

            Apple apple = new Apple();
            DisplayType(apple);

            Coconut coconut = new Coconut();
            DisplayType(coconut);
        }

        /// <summary>
        /// dynamic overloading calls the appropriate overload
        /// since the determination is made at runtime.
        /// 
        /// this determination incurs an overhead.
        /// </summary>
        private static void BaseTypeRuntimeOverloading()
        {
            Console.WriteLine();
            Console.WriteLine("Runtime dynamic overloading - calls appropriate overload by casting as dynamic.");
            Console.WriteLine();

            FruitBase fruit = null;

            fruit = new Pear();
            DisplayType(fruit as dynamic);

            fruit = new Apple();
            DisplayType(fruit as dynamic);

            fruit = new Coconut();
            DisplayType(fruit as dynamic);
        }

        //  contract-oriented

        private static void BaseContractTypeCompiletimeOverloading()
        {
            Console.WriteLine();
            Console.WriteLine("Compiletime base contract overloading - calls IFruit overload only since the declaring type is IFruit.");
            Console.WriteLine();

            IFruit fruit = null;

            fruit = new Pear();
            DisplayContractType(fruit);

            fruit = new Apple();
            DisplayContractType(fruit);

            fruit = new Coconut();
            DisplayContractType(fruit);
        }

        private static void DisplayContractType(IFruit fruit)
        {
            Console.WriteLine($"IFruit contract overload - Instance type is {fruit}");
        }

        private static void DisplayContractType(IApple fruit)
        {
            Console.WriteLine($"IApple contract overload - Instance type is {fruit}");
        }

        private static void DisplayContractType(ICoconut fruit)
        {
            Console.WriteLine($"ICoconut contract overload - Instance type is {fruit}");
        }

        private static void SpecificContractTypeCompiletimeOverloading()
        {
            Console.WriteLine();
            Console.WriteLine("Compiletime specific contract overloading - calls IFruit overload since the declaring type is IFruit.");
            Console.WriteLine();

            //  calls IFruit since no IPear overload.
            IPear pear = new Pear();
            DisplayContractType(pear);

            IApple apple = new Apple();
            DisplayContractType(apple);

            ICoconut coconut = new Coconut();
            DisplayContractType(coconut);
        }

        private static void BaseTypeContractRuntimeOverloading()
        {
            Console.WriteLine();
            Console.WriteLine("Base contract runtime overloading - calls appropriate contract overload by casting as dynamic.");
            Console.WriteLine();

            IFruit fruit = null;

            fruit = new Pear();
            DisplayContractType(fruit as dynamic);

            fruit = new Apple();
            DisplayContractType(fruit as dynamic);

            fruit = new Coconut();
            DisplayContractType(fruit as dynamic);
        }
    }
}