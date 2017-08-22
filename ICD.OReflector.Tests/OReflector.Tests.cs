using System.Linq;
using ICD.OReflector.Abstract;
using ICD.OReflector.Tests.Models.Abstract;
using NUnit.Framework;
using ICD.OReflector.Tests.Models.Attributes;
using ICD.OReflector.Tests.Models.Implementation;

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
            Assert.Greater(ctors.Count(), 0);
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
        public void TestGetGenericCustomAttributes()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var customAttributes = reflector.GetCustomAttributes<CustomAttribute>(model.GetType());
            //Assert
            Assert.Greater(customAttributes.Count(), 0);
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

        [Test]
        public void TestGetGenericMemberCustomAttributes()
        {
            //Arange
            var model = NinjectConfigurator.Get<IModel>();
            var reflector = NinjectConfigurator.Get<IReflector>();
            var idMember = reflector.GetProperties(model.GetType()).ToList().FirstOrDefault(item => item.Name == "Id");
            //Act
            var customAttributes = reflector.GetCustomAttributes<CustomAttribute>(idMember);
            //Assert
            Assert.Greater(customAttributes.Count(), 0);
        }

		[Test]
		public void TestGetTypeMemberCustomAttributes()
		{
			//Arange
			var model = NinjectConfigurator.Get<IModel>();
			var reflector = NinjectConfigurator.Get<IReflector>();
			//Act
			var customAttributes = reflector.GetTypePropertyCustomAttributes(model.GetType());
			//Assert
			Assert.Greater(customAttributes.Count(), 0);
		}

		[Test]
		public void TestGetTypeGenericMemberCustomAttributes()
		{
			//Arange
			var model = NinjectConfigurator.Get<IModel>();
			var reflector = NinjectConfigurator.Get<IReflector>();
			//Act
			var customAttributes = reflector.GetTypePropertyCustomAttributes<CustomAttribute>(model.GetType());
			//Assert
			Assert.Greater(customAttributes.Count(), 0);
		}

		[Test]
        public void TestGenericInstantiate()
        {
            //Arange
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var model = reflector.Instantiate<Model>();
            //Assert
            Assert.IsNotNull(model);
        }

        [Test]
        public void TestGenericInstantiateWithParameters()
        {
            //Arange
            var reflector = NinjectConfigurator.Get<IReflector>();
            //Act
            var model = reflector.Instantiate<Model>(100);
            //Assert
            Assert.IsNotNull(model);
        }
    }
}
