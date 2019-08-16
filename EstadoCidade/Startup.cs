using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstadoCidade.Context;
using EstadoCidade.Interfaces;
using EstadoCidade.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace EstadoCidade
{
    public class Startup
    {
        public static void ConfigureSwagger(IServiceCollection services)
        {

            services.ConfigureSwaggerGen(x =>
            {
                x.IncludeXmlComments(@"EstadoCidade.xml");
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Middleware",
                    Version = "v1",
                    Description = "Middleware",
                    TermsOfService = "-",
                    Contact = new Contact()
                    {
                        Name = "Carlos Soares"
                    }
                });

            });
        }
        public void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IEstadosServices, EstadosServices>();
            services.AddScoped<ICidadesService, CidadeServices>();
            services.AddScoped<ICepServices, CepServices>();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(builder =>
            {
                builder.AddPolicy("AllowAllPolicy",
                options => options.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials());
            });
            DependencyInjection(services);
            ConfigureSwagger(services);
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
                app.UseHsts();
            }
            app.UseCors("AllowAllPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstadoCidade API V1");
            });

            MongoDbContext.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoDbContext.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            MongoDbContext.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
