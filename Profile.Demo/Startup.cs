using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Profile.API.Demo.Services;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

namespace Profile.API.Demo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddAuthorization();
                
            services.AddSingleton<ICustomerService, CustomerService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Customer Profile API",
                        Version = "v1",
                        Description = "Customer Profile REST API Demo.",
                        TermsOfService = "None"
                    }
                );

                foreach (string filePath in GetXmlCommentsFilePaths(Assembly.GetEntryAssembly()))
                {
                    options.IncludeXmlComments(filePath);
                }

                options.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,

                ApiName = "CustomerProfileAPI"
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            app.UseMvc();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            // When hosted under IIS as a child application we need to know what our base path is
            // thus determine the base path for use as the prefix
            string appPath = Environment.GetEnvironmentVariable("ASPNETCORE_APPL_PATH") ?? "/";
            appPath = !appPath.EndsWith("/") ? appPath + "/" : appPath;

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
                c.RouteTemplate = "docs/{documentName}/swagger";

            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{appPath}docs/v1/swagger", "v1 Docs");
            });
        }

        /// <summary>
        /// Gets the list of xml comment files for the assembly
        /// </summary>
        /// <param name="assembly">The assembly the xml comment files will be returned.</param>
        /// <returns></returns>
        internal static IEnumerable<string> GetXmlCommentsFilePaths(Assembly assembly)
        {
            UriBuilder uri = new UriBuilder(assembly.CodeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dir = Path.GetDirectoryName(path);

            return new DirectoryInfo(dir).GetFiles("*.xml").Select(info => info.FullName);
        }
    }
}
