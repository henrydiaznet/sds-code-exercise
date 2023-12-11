using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly List<ServiceDesc> _descriptorsCollection = new();
        
        public void Bind(Type interfaceType, Type implementationType)
        {
            _descriptorsCollection.Add(new ServiceDesc { ServiceType = interfaceType, ImplementationType = implementationType});
        }

        public T Get<T>()
        {
            var serviceDescription = _descriptorsCollection.FirstOrDefault(x => x.ServiceType == typeof(T));
            if (serviceDescription is null)
            {
                throw new InvalidOperationException($"Implementation for {typeof(T)} was not found");
            }            
            
            return (T)Activator.CreateInstance(serviceDescription.ImplementationType);
        }
    }

    public class ServiceDesc
    {
        public Type ServiceType { get; set; }
        public Type ImplementationType { get; set; }
    }
}