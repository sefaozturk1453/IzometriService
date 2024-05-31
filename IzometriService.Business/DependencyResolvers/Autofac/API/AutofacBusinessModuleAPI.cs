using IzometriService.Business.Abstract.API;
using IzometriService.Business.Concrete.API;
using IzometriService.Business.DependencyResolvers.Autofac.Base;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using IzometriService.Core.Utilities.Interceptors;

namespace IzometriService.Business.DependencyResolvers.Autofac.API
{
    public class AutofacBusinessModuleAPI : AutofacBusinessModuleBase
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region API BUSINESS

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
  
            #endregion

            #region ASSEMBLY

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerDependency();

            #endregion

            #region HELPERS


            #endregion
        }
    }
}
