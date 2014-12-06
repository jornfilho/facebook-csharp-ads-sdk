using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Utils
{
    internal static class FacebookParser
    {
        public static object GetValue(this JToken jsonObject, string fieldName, FacebookFieldType fieldType, object defaultValue)
        {
            switch (fieldType)
            {
                case FacebookFieldType.Int32:
                    return GetIntValue(jsonObject, fieldName, defaultValue);
                case FacebookFieldType.Int64:
                    return GetLongValue(jsonObject, fieldName, defaultValue);
                case FacebookFieldType.String:
                    return GetStringValue(jsonObject, fieldName, defaultValue);
                
                case FacebookFieldType.AdAccountGroupsStatusEnum:
                    return GetAdAccountGroupsStatusEnumValue(jsonObject, fieldName, defaultValue);
            }

            return null;
        }

        private static object GetIntValue(this JToken jsonObject, string fieldName, object defaultValue)
        {
            var result = defaultValue;
            var tempResult = int.MinValue;

            if (jsonObject[fieldName] != null &&
                (jsonObject[fieldName].Type == JTokenType.Integer || jsonObject[fieldName].Type == JTokenType.String))
                tempResult = jsonObject[fieldName].ToString().TryParseInt(tempResult);

            
            return tempResult.Equals(int.MinValue) 
                ? result 
                : tempResult;
        }

        private static object GetLongValue(this JToken jsonObject, string fieldName, object defaultValue)
        {
            var result = defaultValue;
            var tempResult = long.MinValue;

            if (jsonObject[fieldName] != null &&
                (jsonObject[fieldName].Type == JTokenType.Integer || jsonObject[fieldName].Type == JTokenType.String))
                tempResult = jsonObject[fieldName].ToString().TryParseLong(tempResult);


            return tempResult.Equals(long.MinValue)
                ? result
                : tempResult;
        }

        private static object GetStringValue(this JToken jsonObject, string fieldName, object defaultValue)
        {
            string tempResult = null;

            if (jsonObject[fieldName] != null && jsonObject[fieldName].Type == JTokenType.String)
                tempResult = jsonObject[fieldName].ToString();


            return tempResult ?? defaultValue;
        }

        private static object GetAdAccountGroupsStatusEnumValue(JToken jsonObject, string fieldName, object defaultValue)
        {
            return GetIntValue(jsonObject, fieldName, defaultValue)
                .TryParseInt((int) AdAccountGroupsStatusEnum.Undefined)
                .GetAdAccountGroupsStatusEnum();
        }
    }
}
