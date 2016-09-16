using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ICD.OReflector.Tests
{
    public static class NinjectConfigurator
    {
        private static IKernel kernel = new StandardKernel();

        static NinjectConfigurator()
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses() 
                 .BindDefaultInterface(); 
            });

            
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
