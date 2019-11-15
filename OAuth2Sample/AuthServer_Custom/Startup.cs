using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthServer_Custom
{
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //7. OAuth2 미들웨어(IdentityServer) 설정
            //AddCustomUserStore : 앞에서 만든 확장메소드를 추가
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddSigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddCustomUserStore();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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

            //09. OAuth2 미들웨어(IdentityServer) CROS 접근 권한 문제
            app.UseCors(options =>
            {
                //전체 허용
                options.AllowAnyOrigin();
            });
            //OAuth2 미들웨어(IdentityServer) 설정
            app.UseIdentityServer();


            //8. 프로젝트 미들웨어 기능 설정
            //웹사이트 기본파일 읽기 설정
            app.UseDefaultFiles();
            //wwwroot 파일읽기
            app.UseStaticFiles();
            //http요청을 https로 리디렉션합니다.
            //https를 허용하지 않았다면 제거 합니다.
            //https://docs.microsoft.com/ko-kr/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.0&tabs=visual-studio
            app.UseHttpsRedirection();
            //app.UseMvc();
        }
    }
}
