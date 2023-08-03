using System.Text.Json;
using FinanceOperation.Api.Core.Features.UserData.GetUserData;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace FinanceOperation.Api.Interaction.WebApi.Features.UserOperations.OData;

public static class ODataConfiguration
{
    public static void AddCustomOData(this IServiceCollection services)
    {
        services
            .AddMvcCore()
            .AddOData(opt =>
            {
                opt.Conventions.Remove(opt.Conventions.OfType<MetadataRoutingConvention>().FirstOrDefault());
                opt.AddRouteComponents(string.Empty, GetEdmModel()).Select().Expand();
            })
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            });
    }

    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();

        EntitySetConfiguration<UserDataDto> userDto = builder.EntitySet<UserDataDto>(nameof(UserDataDto));
        userDto.EntityType.HasKey(key => new { key.Id });

        return builder.GetEdmModel();
    }
}

