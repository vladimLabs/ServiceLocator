namespace Core
{
    public interface IServiceLocator
    {
        T GetService<T>() where T: IService;
        bool TryGetService<T>(out T service) where T: IService;
    }
    
    public interface IService { }
}