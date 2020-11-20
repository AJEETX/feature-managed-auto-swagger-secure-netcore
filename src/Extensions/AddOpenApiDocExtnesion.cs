﻿using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace FeaturesEnabled.ClaimBased.AutoSwagger.Api.Extensions
{
    public static partial class AddOpenApiDocExtnesion
    {
        public static IServiceCollection AddOpenApiDoc(this IServiceCollection services)
        {
            services.AddOpenApiDocument(document =>
            {
                document.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "FeaturesEnabled Claim-based Autogenerated Swagger REST Api";
                    document.Info.Description = "Autogenerated swagger json file with Nswag for REST API.";
                };
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the text box: Bearer {your JWT token}."
                });

                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            return services;
        }
    }
}