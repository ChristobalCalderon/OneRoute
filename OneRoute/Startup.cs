using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Neleus.DependencyInjection.Extensions;
using OneRoute.Handlers;
using OneRoute.Events;
using OneRoute.Swagger;
using Swashbuckle.AspNetCore.Filters;

namespace OneRoute
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.DocumentFilter<EventDocumentFilter>();
                c.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblyOf<EventDownExample>();

            services.AddTransient<EventUpHandler>();
            services.AddTransient<EventDownHandler>();

            services.AddByName<IEventHandler>()
                .Add<EventUpHandler>(nameof(EventUp))
                .Add<EventDownHandler>(nameof(EventDown)).Build();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger(c => c.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
