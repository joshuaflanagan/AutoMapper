using System;

namespace AutoMapper
{
    public interface IServiceFactory
    {
        object GetInstance(Type type);
    }

    public class LambdaServiceFactory : IServiceFactory
    {
        private readonly Func<Type, object> _serviceCtor;

        public LambdaServiceFactory(Func<Type, object> serviceCtor)
        {
            _serviceCtor = serviceCtor;
        }

        public object GetInstance(Type type)
        {
            return _serviceCtor(type);
        }
    }
}