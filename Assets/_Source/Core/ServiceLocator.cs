using System;
using System.Collections.Generic;

namespace Core
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, IService> _services;
        
        public ServiceLocator(IService[] services)
        {
            _services = new Dictionary<Type, IService>();
            foreach (var obj in services)
            {
                _services.Add(obj.GetType(),obj);
            }
        }
        
        public T GetService<T>() where T: IService
        {
            return (T)_services[typeof(T)];
        }
        
        public bool TryGetService<T>(out T service) where T : IService
        {
            try
            {
                service = GetService<T>();
                return true;
            }
            catch
            {
                service = default;
                return false;
            }
        }
    }
}