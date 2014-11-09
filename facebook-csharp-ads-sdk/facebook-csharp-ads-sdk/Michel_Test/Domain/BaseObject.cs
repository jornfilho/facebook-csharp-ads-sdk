namespace facebook_csharp_ads_sdk.Michel_Test.Domain
{
    public abstract class BaseObject<T>
    {
        public abstract T Read(long id);

        public abstract T ParseFacebookResponse(string response);
    }
}
