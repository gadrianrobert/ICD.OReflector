using System;
using System.Collections.Generic;
using System.Reflection;

namespace ICD.OReflector.Abstract
{
    public interface IReflector
    {
        IEnumerable<ConstructorInfo> GetConstructors(Type type);

        IEnumerable<object> GetCustomAttributes(Type type, bool inherit = false);

        IEnumerable<PropertyInfo> GetProperties(Type type);

        IEnumerable<EventInfo> GetEvents(Type type);

        IEnumerable<MethodInfo> GetMethods(Type type);

        IEnumerable<FieldInfo> GetFields(Type type);
    }
}
