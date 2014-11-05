using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Infrastructure.Parsers.ApiErrors
{
    /// <summary>
    /// Paser Facebook Api errors
    /// </summary>
    public static class ErrorData
    {
        /// <summary>
        /// Paser Facebook Api errors version 2.2
        /// </summary>
        public static ApiErrorModelV22 ParseV22(ref JObject jsonResult)
        {
            var result = new ApiErrorModelV22();

            if (jsonResult == null)
                return result;

            if (jsonResult["error"] == null || jsonResult["error"].Type != JTokenType.Object)
                return result;

            var errorObject = jsonResult["error"];

            string message = null, type = null, errorUserTitle = null, errorUserMsg = null;
            int code = 0, errorSubcode = 0;

            if (errorObject["message"] != null && errorObject["message"].Type == JTokenType.String)
                message = errorObject["message"].ToString();

            if (errorObject["type"] != null && errorObject["type"].Type == JTokenType.String)
                type = errorObject["type"].ToString();

            if (errorObject["error_user_title"] != null && errorObject["error_user_title"].Type == JTokenType.String)
                errorUserTitle = errorObject["error_user_title"].ToString();

            if (errorObject["error_user_msg"] != null && errorObject["error_user_msg"].Type == JTokenType.String)
                errorUserMsg = errorObject["error_user_msg"].ToString();

            if (errorObject["code"] != null)
                code = errorObject["code"].ToString().TryParseInt();

            if (errorObject["error_subcode"] != null)
                errorSubcode = errorObject["error_subcode"].ToString().TryParseInt();

            return result.SetData(message, errorUserTitle, errorUserMsg, type, code, errorSubcode);
        }
    }
}
