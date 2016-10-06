using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace ICD.OReflector.Implementation
{
    public class Reflector : BaseReflector
    {
        private ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>> _constructorsDictionary = new ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>>();
        private ConcurrentDictionary<Type, IEnumerable<object>> _typeCustomAttributesDictionary = new ConcurrentDictionary<Type, IEnumerable<object>>();
        
        public override IEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type == null ? base.GetConstructors(null) : _constructorsDictionary.GetOrAdd(type, base.GetConstructors(type));
        }

        public override IEnumerable<object> GetCustomAttributes(Type type, bool inherit = false)
        {
            return type == null ? base.GetCustomAttributes(null, inherit) : _typeCustomAttributesDictionary.GetOrAdd(type, base.GetCustomAttributes(type, inherit));
        }

    }
}
