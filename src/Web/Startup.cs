
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;
using System.Linq;
using Core.Services;
//using UomoMacchina.Hubs;
using UomoMacchina.Infrastructure;
using UomoMacchina.SignalR.Hubs;

namespace UomoMacchina
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<TemplateDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // SERVICES FOR AUTHENTICATION
            services.AddSession();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/Login";
                options.LogoutPath = "/Login/Logout";
            });

            var builder = services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {                        // Enable loading SharedResource for ModelLocalizer
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });

#if DEBUG
            builder.AddRazorRuntimeCompilation();
#endif

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Features/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/Shared/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            // SIGNALR FOR COLLABORATIVE PAGES
            services.AddSignalR();

            // CONTAINER FOR ALL EXTRA CUSTOM SERVICES
            Container.RegisterTypes(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                // Https redirection only in production
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            // Localization support if you want to
            app.UseRequestLocalization(SupportedCultures.CultureNames);

            app.UseRouting();

            // Adding authentication to pipeline
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            var node_modules = new CompositePhysicalFileProvider(Directory.GetCurrentDirectory(), "node_modules");
            var areas = new CompositePhysicalFileProvider(Directory.GetCurrentDirectory(), "Areas");
            var compositeFp = new CustomCompositeFileProvider(env.WebRootFileProvider, node_modules, areas);
            env.WebRootFileProvider = compositeFp;
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                // ROUTING PER HUB
                endpoints.MapHub<TemplateHub>("/templateHub");

                // Route per le Rendicontazioni, Elimina, Salvataggio dati
                endpoints.MapAreaControllerRoute("TestR", "Rendicontazioni", "Rendicontazioni/{controller=Rendicontazioni}/{action=Index}");
                endpoints.MapAreaControllerRoute("Elimina Rendicontazioni", "Rendicontazioni", "Rendicontazioni/Delete/{controller=Rendicontazioni}/{action=Delete}/{id?}");
                endpoints.MapAreaControllerRoute("Modifica Rendicontazioni", "Rendicontazioni", "Rendicontazioni/SaveEdit/{controller=Rendicontazioni}/{action=SaveEdit}/{id?}");
                endpoints.MapAreaControllerRoute("ReturnMain", "Rendicontazioni", "Rendicontazioni/{controller=Rendicontazioni}/{action=Main}");


                // Route per le Permessi, Elimina, Salvataggio dati
                endpoints.MapAreaControllerRoute("TestP", "Permessi", "Permessi/{controller=Permessi}/{action=Index}");
                endpoints.MapAreaControllerRoute("Elimina Permessi", "Permessi", "Permessi/Delete/{controller=Permessi}/{action=Delete}/{id?}");
                endpoints.MapAreaControllerRoute("Modifica Permessi", "Permessi", "Permessi/SaveEdit/{controller=Permessi}/{action=SaveEdit}/{id?}");
                endpoints.MapAreaControllerRoute("ReturnMain", "Permessi", "Permessi/{controller=Permessi}/{action=Main}");


                // Route per le Ferie, Elimina, Salvataggio dati
                endpoints.MapAreaControllerRoute("TestF", "Ferie", "Ferie/{controller=Ferie}/{action=Index}");
                endpoints.MapAreaControllerRoute("Elimina Ferie", "Ferie", "Ferie/Delete/{controller=Ferie}/{action=Delete}/{id?}");
                endpoints.MapAreaControllerRoute("Modifica Ferie", "Ferie", "Ferie/SaveEdit/{controller=Ferie}/{action=SaveEdit}/{id?}");
                endpoints.MapAreaControllerRoute("ReturnMain", "Ferie", "Ferie/{controller=Ferie}/{action=Main}");


                // Route per le NottiFuori, Elimina, Salvataggio dati
                endpoints.MapAreaControllerRoute("TestN", "NottiFuori", "NottiFuori/{controller=NottiFuori}/{action=Index}");
                endpoints.MapAreaControllerRoute("Elimina NottiFuori", "NottiFuori", "NottiFuori/Delete/{controller=NottiFuori}/{action=Delete}/{id?}");
                endpoints.MapAreaControllerRoute("Modifica NottiFuori", "NottiFuori", "NottiFuori/SaveEdit/{controller=NottiFuori}/{action=SaveEdit}/{id?}");
                endpoints.MapAreaControllerRoute("ReturnMain", "NottiFuori", "NottiFuori/{controller=NottiFuori}/{action=Main}");


                // Route per le Trasferte, Elimina, Salvataggio dati
                endpoints.MapAreaControllerRoute("TestT", "Trasferte", "Trasferte/{controller=Trasferte}/{action=Index}");
                endpoints.MapAreaControllerRoute("Elimina Trasferte", "Trasferte", "Trasferte/Delete/{controller=Trasferte}/{action=Delete}/{id?}");
                endpoints.MapAreaControllerRoute("Modifica Trasferte", "Trasferte", "Trasferte/SaveEdit/{controller=Trasferte}/{action=SaveEdit}/{id?}");
                endpoints.MapAreaControllerRoute("ReturnMain", "Trasferte", "Trasferte/{controller=Trasferte}/{action=Main}");


                // Route per i Rimborsi, Elimina, Salvataggio dati
                endpoints.MapAreaControllerRoute("TestP", "Rimborsi", "Rimborsi/{controller=Rimborsi}/{action=Index}");
                endpoints.MapAreaControllerRoute("Elimina Rimborsi", "Rimborsi", "Rimborsi/Delete/{controller=Rimborsi}/{action=Delete}/{id?}");
                endpoints.MapAreaControllerRoute("Modifica Rimborsi", "Rimborsi", "Rimborsi/SaveEdit/{controller=Rimborsi}/{action=SaveEdit}/{id?}");
                endpoints.MapAreaControllerRoute("ReturnMain", "Rimborsi", "Rimborsi/{controller=Rimborsi}/{action=Main}");


                endpoints.MapAreaControllerRoute("Example", "Example", "Example/{controller=Users}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("Main", "Main", "Main/{controller=Main}/{action=Main}/{id?}");
                endpoints.MapAreaControllerRoute("SingleDay", "Main", "Main/SingleDay/{controller=Main}/{action=SingleDay}");
                endpoints.MapAreaControllerRoute("getData", "Main", "Main/{controller=Main}/{action=GetData}"); //endpoint per recuperare i dati
                endpoints.MapAreaControllerRoute("default", "Login", "{controller=Login}/{action=Login}");
            });
        }
    }

    public static class SupportedCultures
    {
        public readonly static string[] CultureNames;
        public readonly static CultureInfo[] Cultures;

        static SupportedCultures()
        {
            CultureNames = new[] { "it-it" };
            Cultures = CultureNames.Select(c => new CultureInfo(c)).ToArray();

            //NB: attenzione nel progetto a settare correttamente <NeutralLanguage>it-IT</NeutralLanguage>
        }
    }
}
