using System.ComponentModel;
using System.Runtime.Serialization;
using ICD.OReflector.Tests.Models.Abstract;
using ICD.OReflector.Tests.Models.Attributes;

namespace ICD.OReflector.Tests.Models.Implementation
{
    [Custom]
    public class Model : AbstractModel
    {
        public Model()
        {
            var test = false;
        }

	    public event PropertyChangedEventHandler OnPropertyChanged;

		public int Id { get; set; }
    }
}
