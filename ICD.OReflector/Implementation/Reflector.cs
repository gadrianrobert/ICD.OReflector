using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICD.OReflector.Abstract;

namespace ICD.OReflector.Implementation
{
    public class Reflector : BaseReflector
    {
        private ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>> _publicConstructorsDictionary = new ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>>();

        public override IEnumerable<ConstructorInfo> GetPublicConstructors(Type type)
        {
            if (type == null) return base.GetPublicConstructors(null);

            return _publicConstructorsDictionary.GetOrAdd(type, base.GetPublicConstructors(type));
        }
    }
}
