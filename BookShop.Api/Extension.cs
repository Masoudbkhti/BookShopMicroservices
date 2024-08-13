using Microsoft.OpenApi.Models;

namespace BookShop.Api;

public static class Extension
{
    
    public static void AddMySwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(o =>
        {
            o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                           Enter 'Bearer' [space] and then your token in the next input below.
                           Example: 'Bearer 123ssddwr'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            o.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                    {

                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
            o.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title ="Book Shop Api"
            });
        });
    }
}