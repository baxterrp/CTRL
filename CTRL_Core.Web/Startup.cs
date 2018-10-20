using CTRL_Core.Backbone.Database;
using CTRL_Core.Backbone.Interfaces;
using CTRL_Core.BackboneDatabase;
using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Interfaces;
using CTRL_Core.Domain.Repositories;
using CTRL_Core.Login;
using CTRL_Core.Login.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CTRL_Core.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IPasswordEncryption, PasswordEncryption>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IDatabaseConnection>(db => new DatabaseConnection(ConfigurationExtensions.GetConnectionString(Configuration, "CTRL")));
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ISetupsConfiguration, SetupsConfiguration>();
            services.AddTransient<ISetupsRepository, SetupsRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IRegistrationService, RegistrationService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
