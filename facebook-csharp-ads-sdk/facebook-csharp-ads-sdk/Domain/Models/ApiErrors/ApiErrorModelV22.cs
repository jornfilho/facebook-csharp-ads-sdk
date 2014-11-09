using DevUtils.PrimitivesExtensions;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.ApiErrors
{
    /// <summary>
    /// <para>Requests made to our APIs can result in a number of different error responses, and there are a few basic recovery tactics.</para>
    /// <para>The following topic describes the recovery tactics, and provides a list of error values with a map to the most common recovery tactic to use.</para>
    /// <para>Facebook reference: https://developers.facebook.com/docs/graph-api/using-graph-api/v2.2#errors </para>
    /// </summary>
    public class ApiErrorModelV22
    {
        #region Properties
        /// <summary>
        /// A description of the error intended for the developer.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// When you encounter this you should show the message directly to the user. It will be correctly translated per the locale of the API request
        /// </summary>
        public string ErrorUserTitle { get; private set; }

        /// <summary>
        /// If you are showing an error dialog, this should be the title of the dialog. Again it will be correctly translated per the locale of the API request
        /// </summary>
        public string ErrorUserMessage { get; private set; }

        /// <summary>
        /// Type of error
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// An error code, some common values for which are listed below, along with common recovery tactics should you detect them.
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Used to further classify an error, common values are shown below.
        /// </summary>
        public int Subcode { get; private set; } 
        #endregion

        /// <summary>
        /// Set error data
        /// </summary>
        public virtual ApiErrorModelV22 SetData(string message, string errorUserTitle, string errorUserMessage, string type, int code, int subcode)
        {
            Message = message;
            ErrorUserTitle = errorUserTitle;
            ErrorUserMessage = errorUserMessage;
            Type = type;
            Code = code;
            Subcode = subcode;

            return this;
        }

        /// <summary>
        /// Paser Facebook Api errors version 2.2
        /// </summary>
        public virtual ApiErrorModelV22 ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            if (jsonResult["error"] == null || jsonResult["error"].Type != JTokenType.Object)
                return this;

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

            return this.SetData(message, errorUserTitle, errorUserMsg, type, code, errorSubcode);
        }
    }
}
