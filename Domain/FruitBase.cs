namespace Bytz.Samples.RuntimePolicymorphicOverloading.Domain
{
    public abstract class FruitBase
    {
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}