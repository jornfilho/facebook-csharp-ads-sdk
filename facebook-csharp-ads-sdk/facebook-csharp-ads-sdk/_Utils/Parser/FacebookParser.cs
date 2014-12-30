using System;
using System.Collections.Generic;
using System.Linq;
using DevUtils.DateTimeExtensions;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
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
                case FacebookFieldType.StringArray:
                    return GetStringArrayValue(jsonObject, fieldName, defaultValue);
                case FacebookFieldType.DateTime:
                    return GetDatetimeValue(jsonObject, fieldName, defaultValue);
                case FacebookFieldType.UnixTimestamp:
                    return GetDatetimeValueFromUnixTimestamp(jsonObject, fieldName, defaultValue);
                #endregion
                    
                #region Ad account group types
                case FacebookFieldType.AdAccountGroupsStatusEnum:
                    return GetAdAccountGroupsStatusEnumValue(jsonObject, fieldName, defaultValue); 
                #endregion

                #region Ad campaign

                case FacebookFieldType.AdCampaignObjectiveEnum:
                    object stringValue = GetStringValue(jsonObject, fieldName, defaultValue);
                    return  stringValue != null ? (object) stringValue.ToString().GetCampaignObjective() : null;

                case FacebookFieldType.AdCampaignStatusEnum:
                    object status = GetStringValue(jsonObject, fieldName, defaultValue);
                    return status != null ? (object) status.ToString().GetCampaignStatus() : null;

                case FacebookFieldType.AdCampaignBuyingTypeEnum:
                    object buyingType = GetStringValue(jsonObject, fieldName, defaultValue);
                    return buyingType != null ? (object) buyingType.ToString().GetBuyingTypeEnum() : null;

                #endregion Ad campaign
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

        /// <summary>
        ///     Get the string array value from JToken
        /// </summary>
        /// <param name="jsonObject"> JToken object </param>
        /// <param name="fieldName"> Field name </param>
        /// <param name="defaultValue"> Default value </param>
        /// <returns> Array of strings </returns>
        private static object GetStringArrayValue(this JToken jsonObject, string fieldName, object defaultValue)
        {
            if (jsonObject[fieldName] == null || jsonObject[fieldName].Type != JTokenType.Array)
            {
                return defaultValue;
            }

            var stringList = jsonObject[fieldName];
            List<string> result = (from strValue in stringList where strValue != null select strValue.ToString()).ToList();

            return result;
        }

        /// <summary>
        ///     Get the datetime value from JToken
        /// </summary>
        /// <param name="jsonObject"> JToken object </param>
        /// <param name="fieldName"> Field name </param>
        /// <param name="defaultValue"> Default value </param>
        /// <returns> Date </returns>
        private static object GetDatetimeValue(this JToken jsonObject, string fieldName, object defaultValue)
        {
            if (jsonObject[fieldName] == null || jsonObject[fieldName].Type != JTokenType.Date)
            {
                return defaultValue;
            }

            DateTime? tempResult = jsonObject[fieldName].ToString().TryParseDate();
            return tempResult;
        }

        /// <summary>
        ///     Get the datetime value from JToken
        /// </summary>
        /// <param name="jsonObject"> JToken object </param>
        /// <param name="fieldName"> Field name </param>
        /// <param name="defaultValue"> Default value </param>
        /// <returns> Date </returns>
        private static object GetDatetimeValueFromUnixTimestamp(this JToken jsonObject, string fieldName, object defaultValue)
        {
            if (jsonObject[fieldName] == null || jsonObject[fieldName].Type != JTokenType.Integer)
            {
                return defaultValue;
            }

            DateTime? tempResult = jsonObject[fieldName].TryParseLong().FromUnixTimestamp();
            return tempResult;
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
