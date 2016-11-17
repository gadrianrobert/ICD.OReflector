using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICD.OReflector.Implementation
{
    public class IntPointerPair 
    {
        public IntPtr first;
        public IntPtr second;

        public override bool Equals(object obj)
        {
            var convertedObject = obj as IntPointerPair;
            return convertedObject != null && this.first.Equals(convertedObject.first) && second.Equals(convertedObject.second);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = first.GetHashCode();

                result = result*397 + second.GetHashCode();

                return result;
            }
        }
    }
}
