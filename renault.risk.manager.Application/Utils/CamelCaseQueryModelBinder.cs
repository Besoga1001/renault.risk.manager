// using System.Text.Json;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
//
// namespace renault.risk.manager.Application.Utils;
//
// public class CamelCaseQueryModelBinder : IModelBinder
// {
//     public Task BindModelAsync(ModelBindingContext bindingContext)
//     {
//         ArgumentNullException.ThrowIfNull(bindingContext);
//
//         var queryValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;
//
//         if (queryValue == null)
//         {
//             var camelCaseName = JsonNamingPolicy.CamelCase.ConvertName(bindingContext.ModelName);
//             queryValue = bindingContext.ValueProvider.GetValue(camelCaseName).FirstValue;
//         }
//
//         if (queryValue != null)
//         {
//             bindingContext.Result = ModelBindingResult.Success(queryValue);
//         }
//
//         return Task.CompletedTask;
//     }
// }