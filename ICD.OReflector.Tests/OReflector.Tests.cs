using System.Linq;
using ICD.OReflector.Abstract;
using ICD.OReflector.Tests.Models.Abstract;
using NUnit.Framework;
using ICD.OReflector.Tests.Models.Attributes;

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

		[Test]
		public void TestGetCustomAttribute()
		{
			//Arange
			var model = NinjectConfigurator.Get<IModel>();
			var reflector = NinjectConfigurator.Get<IReflector>();
			//Act
			var customAttribute = reflector.GetCustomAttribute<CustomAttribute>(model.GetType());
			//Assert
			Assert.IsTrue(typeof(CustomAttribute) == customAttribute.GetType());
		}

		[Test]
        public void TestGetProperties()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var properties = reflector.GetProperties(model.GetType());
            //Assert
            Assert.Greater(properties.Count(), 0);
        }

        [Test]
        public void TestGetEvents()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var events = reflector.GetEvents(model.GetType());
            //Assert
            Assert.Greater(events.Count(), 0);
        }

        [Test]
        public void TestGetMethods()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var methods = reflector.GetMethods(model.GetType());
            //Assert
            Assert.Greater(methods.Count(), 0);
        }

        [Test]
        public void TestGetFields()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var fields = reflector.GetFields(model.GetType());
            //Assert
            Assert.Greater(fields.Count(), 0);
        }

        [Test]
        public void TestGetMemberCustomAttributes()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            var idMember = reflector.GetProperties(model.GetType()).ToList().FirstOrDefault(item => item.Name == "Id");
            //Act
            var customAttributes = reflector.GetCustomAttributes(idMember);
            //Assert
            Assert.Greater(customAttributes.Count(), 0);
        }

        //RuntimeReflectionExtensions
    }
}
