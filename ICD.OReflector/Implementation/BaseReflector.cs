using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICD.OReflector.Abstract;

namespace ICD.OReflector.Implementation
{
    public abstract class BaseReflector : IReflector
    {
        private static BindingFlags allBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        public virtual IEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type?.GetConstructors() ?? Enumerable.Empty<ConstructorInfo>();
        }

        public virtual IEnumerable<Attribute> GetCustomAttributes(Type type, bool inherit = false)
        {
            return type?.GetCustomAttributes(inherit).ToList().ConvertAll(item => item as Attribute) ?? Enumerable.Empty<Attribute>();
        }

	    public virtual IEnumerable<T> GetCustomAttributes<T>(Type type, bool inherit = false) where T : class
		{
			var customAttributes = GetCustomAttributes(type, inherit);

			return customAttributes?.Where(item => item is T).ToList().ConvertAll(item=>item as T) ?? Enumerable.Empty<T>();
		}

		public virtual IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return type?.GetProperties(allBindingFlags) ?? Enumerable.Empty<PropertyInfo>();
        }

        public virtual IEnumerable<EventInfo> GetEvents(Type type)
        {
            return type?.GetEvents(allBindingFlags) ?? Enumerable.Empty<EventInfo>();
        }

        public virtual IEnumerable<MethodInfo> GetMethods(Type type)
        {
            return type?.GetMethods(allBindingFlags) ?? Enumerable.Empty<MethodInfo>();
        }

        public virtual IEnumerable<FieldInfo> GetFields(Type type)
        {
            return type?.GetFields(allBindingFlags) ?? Enumerable.Empty<FieldInfo>();
        }

        public virtual IEnumerable<Attribute> GetCustomAttributes(MemberInfo member)
        {
            return member?.GetCustomAttributes(true).ToList().ConvertAll(item => item as Attribute) ?? Enumerable.Empty<Attribute>();
        }

	    public virtual IEnumerable<T> GetCustomAttributes<T>(MemberInfo member) where T : class
		{
			var customAttributes = GetCustomAttributes(member);

			return customAttributes?.Where(item => item is T).ToList().ConvertAll(item => item as T) ?? Enumerable.Empty<T>();
		}

		public abstract IEnumerable<Attribute> GetTypePropertyCustomAttributes(Type type);

		public abstract IEnumerable<T> GetTypePropertyCustomAttributes<T>(Type type) where T : class;

		public virtual T Instantiate<T>() where T : class
        {
            return Activator.CreateInstance<T>();
        }

        public virtual T Instantiate<T>(params object[] parameters) where T : class
        {
            return Activator.CreateInstance(typeof(T), parameters) as T;
        }
        
    }
}
