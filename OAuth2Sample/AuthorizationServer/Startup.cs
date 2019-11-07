using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizationServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //AddInMemoryApiResources   : OAuth2 미들웨어(IdentityServer) 설정
            //AddInMemoryClients        : OAuth2 미들웨어(IdentityServer) 설정
            services.AddIdentityServer()
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddInMemoryClients(Config.GetClients());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //OAuth2 미들웨어(IdentityServer) 설정
            app.UseIdentityServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            //웹사이트 기본파일 읽기 설정
            app.UseDefaultFiles();
            //wwwroot 파일읽기
            app.UseStaticFiles();
            //WebAPI 설정
            app.UseMvc();
        }


    }
}
