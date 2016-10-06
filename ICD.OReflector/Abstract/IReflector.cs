using System;
using System.Collections.Generic;
using System.Reflection;

namespace ICD.OReflector.Abstract
{
    public interface IReflector
    {
        IEnumerable<ConstructorInfo> GetConstructors(Type type);

        IEnumerable<object> GetCustomAttributes(Type type, bool inherit = false);
    }
}
