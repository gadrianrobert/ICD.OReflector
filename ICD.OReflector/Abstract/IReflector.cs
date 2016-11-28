using System;
using System.Collections.Generic;
using System.Reflection;

namespace ICD.OReflector.Abstract
{
    public interface IReflector
    {
        IEnumerable<ConstructorInfo> GetConstructors(Type type);

        IEnumerable<Attribute> GetCustomAttributes(Type type, bool inherit = false);

		IEnumerable<T> GetCustomAttributes<T>(Type type, bool inherit = false) where T : class;

		IEnumerable<PropertyInfo> GetProperties(Type type);

        IEnumerable<EventInfo> GetEvents(Type type);

        IEnumerable<MethodInfo> GetMethods(Type type);

        IEnumerable<FieldInfo> GetFields(Type type);

        IEnumerable<Attribute> GetCustomAttributes(MemberInfo member);

		IEnumerable<T> GetCustomAttributes<T>(MemberInfo member) where T : class;

        T Instantiate<T>() where T : class;

        T Instantiate<T>(params object[] parameters) where T : class;
    }
}
