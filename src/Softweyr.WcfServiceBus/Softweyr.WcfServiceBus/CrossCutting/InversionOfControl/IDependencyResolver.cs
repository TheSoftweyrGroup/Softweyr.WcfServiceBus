using System;
using System.Collections.Generic;

namespace Softweyr.CrossCutting.InversionOfControl
{
    public interface IDependencyResolver : IDisposable
    {

        void RegisterRequestScope<TBindFrom>(Type to);

        void RegisterTransient<TBindFrom>(Type to);

        void RegisterSingleton<TBindFrom>(Type toType);

        void RegisterSingleton<TBindFrom>(TBindFrom toInstance);

        void RegisterSingleton<TBindFrom>(Func<TBindFrom> initialization);

        void Inject<T>(T existing);

        T Resolve<T>();

        T Resolve<T>(string name);

        T Resolve<T>(Type type);

        T Resolve<T>(Type type, string name);

        object Resolve(string name);

        object Resolve(Type type);

        object Resolve(Type type, string name);

        IEnumerable<T> ResolveAll<T>();

        void Register<TBindFrom, TBindTo>()
            where TBindTo : TBindFrom;
    }
}