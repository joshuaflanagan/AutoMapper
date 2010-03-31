using System;

namespace AutoMapper
{
	internal class DeferredInstantiatedResolver : IValueResolver
	{
		private readonly Func<IValueResolver> _constructor;

		public DeferredInstantiatedResolver(Func<IValueResolver> constructor)
		{
			_constructor = constructor;
		}

		public ResolutionResult Resolve(ResolutionResult source)
		{
		    var resolver = _constructor();

		    return resolver.Resolve(source);
		}
	}

    internal class FactoryBuiltResolver : IValueResolver
    {
        private readonly Type _resolverType;

        public FactoryBuiltResolver(Type resolverType)
        {
            _resolverType = resolverType;
        }

        public ResolutionResult Resolve(ResolutionResult source)
        {
            var resolver = (IValueResolver) source.Context.ServiceFactory.GetInstance(_resolverType);
		    return resolver.Resolve(source);

        }
    }
}