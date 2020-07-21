using BrightCare.Persistence;
using BrightCare.Repository.Agency;
using BrightCare.Repository.Agency.Organizations;
using BrightCare.Repository.Interface.Agency;
using BrightCare.Repository.Interface.Agency.Organizations;
using BrightCare.Repository.Interface.SuperAdmin;
using BrightCare.Repository.Interface.SuperAdmin.Organizations;
using BrightCare.Repository.SuperAdmin;
using BrightCare.Repository.SuperAdmin.Organizations;
using BrightCare.Service.Agency.Organizations;
using BrightCare.Service.Interface.Agency.Organizations;
using BrightCare.Service.Interface.SuperAdmin.Organizations;
using BrightCare.Service.SuperAdmin.Organizations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightCare.Web.Api.Dependency
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            #region Others
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          //  services.AddScoped<DbContext, HCOrganizationContext>();
            #endregion



            #region SuperAdmin
            /////////////Repository///////////////
            services.AddScoped(typeof(IMasterRepositoryBase<>), typeof(MasterRepositoryBase<>));
            //organization
            services.AddScoped<IMasterOrganizationRepository, MasterOrganizationRepository>();


            /////////////services///////////////
            services.AddTransient<IMasterOrganizationService, MasterOrganizationService>();
            
            #endregion

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            

            #region Agency
            /////////////Repository///////////////
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //organization
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();


            /////////////services///////////////
            services.AddTransient<IOrganizationService, OrganizationService>();
            #endregion

            

        }
    }
}
