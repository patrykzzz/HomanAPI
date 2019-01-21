namespace Homan.BLL.Utilities
{
    public abstract class CacheDecoratorBase<T>
    {
        protected readonly T _target;

        protected CacheDecoratorBase()
        {
            
        }

        protected CacheDecoratorBase(T target)
        {
            _target = target;
        }
    }
}