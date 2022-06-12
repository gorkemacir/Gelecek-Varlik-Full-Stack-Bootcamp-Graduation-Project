using BillingManagementSystem.Bll;
using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Dal.Concrete.Context;
using BillingManagementSystem.Dal.Concrete.EntityFramework.UnitOfWork;
using BillingManagementSystem.Dal.Concrete.Repository;
using BillingManagementSystem.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.WebApi
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
            #region JwtTokenService
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.SaveToken = true;
                cfg.RequireHttpsMetadata = false;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                    RequireSignedTokens = true,
                    RequireExpirationTime = true //ExpirationTime kontrol etmesi zorunlu mu ? 
                };
            });

            #endregion

            #region ApplicationContext
            services.AddDbContext<BillingManagementSystemContext>();

            services.AddScoped<DbContext, BillingManagementSystemContext>();
            #endregion

            #region ServiceSection
            services.AddScoped<IApartmentService, ApartmentManager>();
            services.AddScoped<IDebtService, DebtManager>();
            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IUserLoginService, UserLoginManager>();

            #endregion

            #region RepositorySection
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region UnitOfWork

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillingManagementSystem.WebApi", Version = "v1" });
                //Authorization giriþ bloðu.
                #region TokenEntryBlock
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    //Token alma özellikleri
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                  {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string [] { }
                  }
                });
                #endregion
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillingManagementSystem.WebApi v1"));
            }
            #region Authorization
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillingManagementSystem.WebApi v1");
            });
            #endregion
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
