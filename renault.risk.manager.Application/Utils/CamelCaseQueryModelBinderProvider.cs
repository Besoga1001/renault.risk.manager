using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace renault.risk.manager.Application.Utils;

public class CamelCaseQueryModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        // Aplica apenas para os parâmetros de string e FromQuery
        if (context.BindingInfo.BindingSource == BindingSource.Query && context.Metadata.ModelType == typeof(string))
        {
            return new CamelCaseQueryModelBinder();
        }
        return null;
    }
}