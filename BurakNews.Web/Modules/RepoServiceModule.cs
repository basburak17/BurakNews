﻿using Autofac;
using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using BurakNews.Core.UnitOfWorks;
using BurakNews.Repository.Repositories;
using BurakNews.Repository.UnitOfWorks;
using BurakNews.Service.Mapping;
using BurakNews.Service.Services;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using Module = Autofac.Module;

namespace BurakNews.Web.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(Service<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<IdentityRole>>().As<RoleManager<IdentityRole>>();

        }
    }
}
