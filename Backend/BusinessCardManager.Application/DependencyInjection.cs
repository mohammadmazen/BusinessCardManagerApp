using BusinessCardManager.Application.Interfaces;
using BusinessCardManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessCardManager.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBusinessCardService, BusinessCardService>();
        return services;
    }
}