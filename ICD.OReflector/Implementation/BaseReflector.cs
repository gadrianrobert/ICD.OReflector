using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICD.OReflector.Abstract;

namespace ICD.OReflector.Implementation
{
    public class BaseReflector : IReflector
    {
        private static BindingFlags allBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        public virtual IEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type?.GetConstructors() ?? Enumerable.Empty<ConstructorInfo>();
        }

        public virtual IEnumerable<object> GetCustomAttributes(Type type, bool inherit = false)
        {
            return type?.GetCustomAttributes(inherit) ?? Enumerable.Empty<object>();
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
    }
}
