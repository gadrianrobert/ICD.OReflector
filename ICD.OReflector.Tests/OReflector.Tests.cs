using System.Linq;
using ICD.OReflector.Abstract;
using ICD.OReflector.Tests.Models.Abstract;
using NUnit.Framework;

namespace ICD.OReflector.Tests
{
    [TestFixture]
    public class OReflectorTests
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

        [Test]
        public void TestGetCustomAttributes()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var customAttributes = reflector.GetCustomAttributes(model.GetType());
            //Assert
            Assert.Greater(customAttributes.Count(), 0);
        }


       // RuntimeReflectionExtensions
    }
}
