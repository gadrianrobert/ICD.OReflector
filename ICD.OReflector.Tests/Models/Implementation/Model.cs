using System.ComponentModel;
using ICD.OReflector.Tests.Models.Abstract;
using ICD.OReflector.Tests.Models.Attributes;

namespace ICD.OReflector.Tests.Models.Implementation
{
	[Custom]
	public class Model : AbstractModel
	{
		public Model()
		{
		    Id = 1;
		}

        public Model(int id)
        {
            Id = id;
        }
        
        public event PropertyChangedEventHandler OnPropertyChanged;

		[Custom]
		public override int Id { get; set; }
	}

}
