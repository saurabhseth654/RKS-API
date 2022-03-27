using Autofac;
using RKS.Core.Interface;
using RKS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKS.WebAPI
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            RegisterType<AuthService, IAuthService>(builder);            
            RegisterType<AppSettings, IAppSettings>(builder);          
        }

        static void RegisterType<T1, T2>(ContainerBuilder builderAutofac)
        {
            builderAutofac
                .RegisterType<T1>()
                .As<T2>();                
        }
    }
}
