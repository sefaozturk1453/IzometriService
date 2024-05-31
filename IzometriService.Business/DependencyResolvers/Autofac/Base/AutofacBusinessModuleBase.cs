using Autofac;
using IzometriService.DataAccess.EntityFramework.Context;
using IzometriService.DataAccess.EntityFramework.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Business.DependencyResolvers.Autofac.Base
{
    public class AutofacBusinessModuleBase : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region DATA ACCESS

            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<UowBBL>().As<IUowBBL>()
                   .AsSelf()
                   .InstancePerLifetimeScope();

            #endregion
        }
    }
}
