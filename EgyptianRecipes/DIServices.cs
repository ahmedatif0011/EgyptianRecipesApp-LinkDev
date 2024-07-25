using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace EgyptianRecipes
{
    public static class DIServices
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection Services)
        {
            Services.AddHttpClient();

            Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            Services.AddFluentValidation();
            Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

            return Services;
        }
    }
}
