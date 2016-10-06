using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICD.OReflector.Abstract;

namespace ICD.OReflector.Implementation
{
    public class BaseReflector : IReflector
    {
        public virtual IEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type?.GetTypeInfo().GetConstructors() ?? Enumerable.Empty<ConstructorInfo>();
        }

        public virtual IEnumerable<object> GetCustomAttributes(Type type, bool inherit = false)
        {
            return type?.GetTypeInfo().GetCustomAttributes(inherit) ?? Enumerable.Empty<object>();
        }

        //return (IEnumerable<PropertyInfo>) type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        //return (IEnumerable<EventInfo>) type.GetEvents(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        //return (IEnumerable<MethodInfo>) type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        //return (IEnumerable<FieldInfo>) type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
    
    }
}
