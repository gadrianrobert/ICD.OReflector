using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICD.OReflector.Abstract;
using ICD.OReflector.Implementation;
using ICD.OReflector.Tests.Models.Abstract;
using ICD.OReflector.Tests.Models.Implementation;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ICD.OReflector.Tests
{
    public static class NinjectConfigurator
    {
        private static IKernel kernel = new StandardKernel();

        static NinjectConfigurator()
        {
            //kernel.Bind(x =>
            //{
            //    x.FromThisAssembly()
            //     .SelectAllClasses() 
            //     .BindDefaultInterface(); 
            //});

            kernel.Bind<IModel>().To<Model>();

            kernel.Bind<IReflector>().To<Reflector>().InSingletonScope();
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
