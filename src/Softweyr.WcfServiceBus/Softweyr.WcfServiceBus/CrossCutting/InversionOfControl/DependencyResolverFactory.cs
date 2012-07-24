namespace Softweyr.CrossCutting.InversionOfControl
{
    using System;

    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type _resolverType;

        public DependencyResolverFactory(string resolverTypeName)
        {
            this._resolverType = Type.GetType(resolverTypeName, true, true);
        }

        #region IDependencyResolverFactory Members

        public IDependencyResolver CreateInstance()
        {
            return Activator.CreateInstance(this._resolverType) as IDependencyResolver;
        }

        #endregion
    }
}