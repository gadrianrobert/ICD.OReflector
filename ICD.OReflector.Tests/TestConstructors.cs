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
        public void TestGetConstructors()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var ctors = reflector.GetConstructors(model.GetType());
            //Assert
            Assert.Greater(ctors.Count() , 0);
        }
    }
}
