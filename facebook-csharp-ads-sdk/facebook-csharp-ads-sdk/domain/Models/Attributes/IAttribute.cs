namespace facebook_csharp_ads_sdk.domain.Models.Attributes
{
    /// <summary>
    /// Interface for custom attributes
    /// </summary>
    /// <typeparam name="T">Attibute type</typeparam>
    public interface IAttribute<out T>
    {
        /// <summary>
        /// Attribute value
        /// </summary>
        T Value { get; }
    }
}
