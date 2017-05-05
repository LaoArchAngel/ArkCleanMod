namespace ArkCleanMod.Specifications
{
    public interface ISpecifcation<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}