using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ICD.OReflector.Abstract
{
    public interface IReflector
    {
        IEnumerable<ConstructorInfo> GetPublicConstructors(Type type);
    }
}
