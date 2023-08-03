using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;

namespace FinanceOperation.Api.Interaction.WebApi.Features.UserOperations.OData;

public class EnableODataAttribute : EnableQueryAttribute
{
    public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOptions)
    {
        queryOptions.Validate(new ODataValidationSettings
        {
            MaxExpansionDepth = 0
        });
    }
}
