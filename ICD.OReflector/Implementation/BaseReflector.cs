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
            return type == null ? Enumerable.Empty<ConstructorInfo>()
                                : type.GetTypeInfo().GetConstructors() ?? Enumerable.Empty<ConstructorInfo>();
        }
    }
}
