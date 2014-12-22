using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global
{
    /// <summary>
    ///     Extension for the ExecutionOptionsEnum
    /// </summary>
    public static class ExecutionOptionsEnumExtension
    {
        /// <summary>
        ///     Get Facebook name of the execution options
        /// </summary>
        /// <param name="executionOptionsEnum"> Execution options enum </param>
        /// <returns> Facebook name </returns>
        public static string GetExecutionOptionsFacebookName(this ExecutionOptionsEnum executionOptionsEnum)
        {
            return executionOptionsEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }
    }
}