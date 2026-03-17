using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "API for Point of Sale system",
                TermsOfService = new Uri("https://opensource.org/licences/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "DevOphs POS",
                    Email = "fransuacordero@gmail.com",
                    Url = new Uri("https://fransuacordero.com.ec")
                },
                License = new OpenApiLicense
                {
                    Name = "DevOphs MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name= "Jwt Authentication",
                    Description= "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type= SecuritySchemeType.Http,
                    Scheme= "Bearer",
                    BearerFormat= "JWT",
                    Reference= new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[]{ } }
                });
            });

            return services;
        }
    } 
}
