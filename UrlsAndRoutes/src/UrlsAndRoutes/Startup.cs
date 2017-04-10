using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "NewRoute",
                //    template: "App/Do{action}",
                //    defaults: new { controller = "Home" });

                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.Routes.Add(new LegacyRoute(
                    app.ApplicationServices, 
                    "/articles/Windows_3.1_Overview.html",
                    "/old/.NET_1.0_Class_Library"));

                routes.MapRoute(name: "Default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "out", template: "outbound/{controller=Home}/{action=Index}");

                //routes.MapRoute(name: "MyRoute", 
                //    template: "{controller=Home}/{action=Index}/{id:weekday?}");
                //routes.MapRoute(name: "MyRoute", 
                //    template: "{controller}/{action}/{id?}", 
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new WeekDayConstraint() });
                //routes.MapRoute(name: "MyRoute",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new
                //    {
                //        id = new CompositeRouteConstraint(new IRouteConstraint[] {
                //            new AlphaRouteConstraint(),
                //            new MinLengthRouteConstraint(6)
                //        })
                //    });
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id:range(10,20)?}");
                //routes.MapRoute(name: "MyRoute", 
                //    template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");
                //routes.MapRoute(name: "MyRoute", template: "{controller:regex(^H.*)=Home}/{action=Index}/{id?}");
                //routes.MapRoute(name: "MyRoute",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new IntRouteConstraint() }
                //);
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id:int?}");
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
            });
        }
    }
}
