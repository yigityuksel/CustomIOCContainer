using System;
using System.Collections.Generic;

namespace CustomIOCContainer.CustomContainer
{
    public class DependencyContainer
    {

        public static DependencyContainer Instance => Container._dependencyContainer;

        private DependencyContainer() { }

        private class Container
        {
            static Container() { }
            internal static readonly DependencyContainer _dependencyContainer = new DependencyContainer();
        }

        private static readonly Dictionary<Type, Type> _types = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Func<object>> _typeCtors = new Dictionary<Type, Func<object>>();
        private static readonly Dictionary<Type, object> _typeValues = new Dictionary<Type, object>();

        /// <summary>
        /// Register Types
        /// </summary>
        /// <typeparam name="TContract"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public static void Register<TContract, TImplementation>() where TImplementation : TContract
        {
            _types[typeof(TContract)] = typeof(TImplementation);
        }

        /// <summary>
        /// Register Ctors
        /// </summary>
        /// <typeparam name="TContract"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="ctor"></param>
        public static void Register<TContract, TImplementation>(Func<TImplementation> ctor) where TImplementation : TContract
        {
            _typeCtors[typeof(TContract)] = () => ctor;
        }

        /// <summary>
        /// Register Values
        /// </summary>
        /// <typeparam name="TContract"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="implementationValue"></param>
        public static void Register<TContract, TImplementation>(TImplementation implementationValue)
            where TImplementation : TContract
        {
            _typeValues[typeof(TContract)] = implementationValue;
        }

        private static object Resolve(Type tContract)
        {
            if (_typeValues.ContainsKey(tContract))
                return _typeValues[tContract];
            if (_typeCtors.ContainsKey(tContract))
                return _typeCtors[tContract];
            if (_types.ContainsKey(tContract))
                return Activator.CreateInstance(_types[tContract]);

            throw new ArgumentOutOfRangeException(nameof(tContract));
        }

        public static T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

    }
}