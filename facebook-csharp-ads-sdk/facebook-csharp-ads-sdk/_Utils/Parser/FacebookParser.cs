using System;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk._Utils.Parser
{
    internal static class FacebookParser
    {
        public static object GetValue(this JToken jsonObject, string fieldName, FacebookFieldType fieldType, object defaultValue)
        {
            switch (fieldType)
            {
                #region Primitive types
                case FacebookFieldType.Int32:
                    return GetIntValue(jsonObject, fieldName, defaultValue);
                case FacebookFieldType.Int64:
                    return GetLongValue(jsonObject, fieldName, defaultValue);
                case FacebookFieldType.String:
                    return GetStringValue(jsonObject, fieldName, defaultValue); 
                #endregion
                    
                #region Ad account group types
                case FacebookFieldType.AdAccountGroupsStatusEnum:
                    return GetAdAccountGroupsStatusEnumValue(jsonObject, fieldName, defaultValue); 
                #endregion
            }

            return null;
        }

        #region Primitive types
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
        #endregion

        #region Ad account group types
        private static object GetAdAccountGroupsStatusEnumValue(JToken jsonObject, string fieldName, object defaultValue)
        {
            return GetIntValue(jsonObject, fieldName, defaultValue)
                .TryParseInt((int)AdAccountGroupsStatusEnum.Undefined)
                .GetAdAccountGroupsStatusEnum();
        } 
        #endregion

        /// <summary>
        /// Pegar url da próxima página caso exista
        /// </summary>
        public static string GetNextPage(this string facebookResponse)
        {
            if (String.IsNullOrEmpty(facebookResponse))
                return null;

            var jsonObject = JObject.Parse(facebookResponse);
            if (jsonObject == null)
                return null;

            if (jsonObject.Type != JTokenType.Object ||
                jsonObject["paging"] == null || jsonObject["paging"].Type != JTokenType.Object ||
                jsonObject["paging"]["next"] == null || jsonObject["paging"]["next"].Type != JTokenType.String ||
                String.IsNullOrEmpty(jsonObject["paging"]["next"].ToString()))
                return null;

            return jsonObject["paging"]["next"].ToString();
        }

        /// <summary>
        /// Pegar url da página anterior caso exista
        /// </summary>
        public static string GetPreviousPage(this string facebookResponse)
        {
            if (String.IsNullOrEmpty(facebookResponse))
                return null;

            var jsonObject = JObject.Parse(facebookResponse);
            if (jsonObject == null)
                return null;

            if (jsonObject.Type != JTokenType.Object ||
                jsonObject["paging"] == null || jsonObject["paging"].Type != JTokenType.Object ||
                jsonObject["paging"]["previous"] == null || jsonObject["paging"]["previous"].Type != JTokenType.String ||
                String.IsNullOrEmpty(jsonObject["paging"]["previous"].ToString()))
                return null;

            return jsonObject["paging"]["previous"].ToString();
        }
    }
}
