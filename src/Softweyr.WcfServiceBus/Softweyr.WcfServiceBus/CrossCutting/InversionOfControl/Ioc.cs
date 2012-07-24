namespace Softweyr.CrossCutting.InversionOfControl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Softweyr.CrossCutting.Helpers;

    public static class Ioc
    {
        private static IDependencyResolver _resolver = null;

        [DebuggerStepThrough]
        public static void InitializeWith(IDependencyResolver resolver, params IocModule[] modules)
        {
            Check.Argument.IsNotNull(resolver, "resolver");

            foreach (IocModule module in modules)
            {
                module.Load(resolver);
            }

            _resolver = resolver;
        }

        [DebuggerStepThrough]
        public static void Inject<T>(T existing)
        {
            Check.Argument.IsNotNull(existing, "existing");
            Check.Field.IsNotNull(_resolver, "resolver");

            _resolver.Inject(existing);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(Type type)
        {
            Check.Argument.IsNotNull(type, "type");
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve<T>(type);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(Type type, string name)
        {
            Check.Argument.IsNotNull(type, "type");
            Check.Argument.IsNotEmpty(name, "name");
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve<T>(type, name);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>()
        {
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve<T>();
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(string name)
        {
            Check.Argument.IsNotEmpty(name, "name");
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve<T>(name);
        }

        [DebuggerStepThrough]
        public static object Resolve(string name)
        {
            Check.Argument.IsNotEmpty(name, "name");
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve(name);
        }

        [DebuggerStepThrough]
        public static object Resolve(Type type)
        {
            Check.Argument.IsNotNull(type, "type");
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve(type);
        }

        [DebuggerStepThrough]
        public static object Resolve(Type type, string name)
        {
            Check.Argument.IsNotNull(type, "type");
            Check.Argument.IsNotEmpty(name, "name");
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.Resolve(type, name);
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> ResolveAll<T>()
        {
            Check.Field.IsNotNull(_resolver, "resolver");

            return _resolver.ResolveAll<T>();
        }

        [DebuggerStepThrough]
        public static void Reset()
        {
            if (_resolver != null)
            {
                _resolver.Dispose();
                _resolver = null;
            }
        }
    }
}