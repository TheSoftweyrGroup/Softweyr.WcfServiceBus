namespace Softweyr.CrossCutting.InversionOfControl
{
    /// <summary>
    /// The base class for inversion of control modules to inherit from.
    /// </summary>
    public abstract class IocModule
    {
        /// <summary>
        /// Loads all the bindings required to a specific service/group of services into the given dependency resolver.
        /// </summary>
        /// <param name="resolver">The dependency resolve to add bindings to.</param>
        public abstract void Load(IDependencyResolver resolver);
    }
}