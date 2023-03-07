namespace Assignment.Api.ServiceCollectionConfigurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", 
                    corsPolicyBuilder => corsPolicyBuilder.WithOrigins(builder.Configuration.GetValue<string>("FrontEndDomain"))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true));
            });
            return services;
        }
    }
}
