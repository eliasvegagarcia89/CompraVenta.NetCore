using CompraVenta.Datos.IModelo;
using CompraVenta.Datos.Modelo.Northwind;
using CompraVenta.Web.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CompraVenta.Web
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
            services.AddSingleton<IUnitOfWork>(new NorthwindUnitOfWork(Configuration.GetConnectionString("Northwind")));

            #region Configurar Cors
            var valuesSection = Configuration
                .GetSection("Cors:AllowSpecificOrigins")
                .GetChildren()
                .ToList()
                .Select(x => (x.GetValue<string>("origin"))).ToList();

            services.AddCors(options =>
            {
                options.AddPolicy("_AllowSpecificOrigins",
                    builder => builder.WithOrigins(valuesSection.ToArray())
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        );
                options.AddPolicy("_AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });
            #endregion

            // configurar servicio de autenticación
            var tokenProvider = new CompraVentaTokenProvider("issuer", "audience", "token-CompraVenta");

            // servicio para luego poder generar los tokens
            services.AddSingleton<ITokenProvider>(tokenProvider);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; // en producción debería ser habilitado
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });

            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("_AllowSpecificOrigins");

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
