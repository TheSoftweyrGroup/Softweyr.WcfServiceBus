namespace Softweyr.CrossCutting.InversionOfControl
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}