using System.Linq;
using System.Reflection;
using ICD.OReflector.Abstract;
using ICD.OReflector.Tests.Models.Abstract;
using NUnit.Framework;

namespace ICD.OReflector.Tests
{

    [TestFixture]
    public class TestConstructors
    {
        [Test]
        public void TestPublicProperties()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
         //   var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            //var ctors = reflector.GetPublicConstructors(model.GetType());
            //Assert
           // Assert.Greater(Enumerable.Count<ConstructorInfo>(ctors) , 0);
        }
    }
}
