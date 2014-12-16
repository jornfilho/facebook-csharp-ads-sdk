using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.Targetings
{
    /// <summary>
    ///     Options of the mobile operating systems
    /// </summary>
    public enum OsOptionsEnum
    {
        /// <summary>
        ///     Undefined
        /// </summary>
        [FacebookName("")]
        Undefined = 0,

        #region iOS options

        /// <summary>
        ///     iOS devices, including iPhone, iPad, and iPod
        /// </summary>
        [FacebookName("iOS")]
        Ios = 1,

        /// <summary>
        ///     iOS devices running OS versions 2.0 and above
        /// </summary>
        [FacebookName("iOS_ver_2.0_and_above")]
        Ios20 = 2,

        /// <summary>
        ///     iOS devices running OS versions 3.0 and above
        /// </summary>
        [FacebookName("iOS_ver_3.0_and_above")]
        Ios30 = 3,

        /// <summary>
        ///     iOS devices running OS versions 4.0 and above
        /// </summary>
        [FacebookName("iOS_ver_4.0_and_above")]
        Ios40 = 4,

        /// <summary>
        ///     iOS devices running OS versions 4.3 and above
        /// </summary>
        [FacebookName("iOS_ver_4.3_and_above")]
        Ios43 = 5,

        /// <summary>
        ///     iOS devices running OS versions 5.0 and above
        /// </summary>
        [FacebookName("iOS_ver_5.0_and_above")]
        Ios50 = 6,

        /// <summary>
        ///     iOS devices running OS versions 6.0 and above
        /// </summary>
        [FacebookName("iOS_ver_6.0_and_above")]
        Ios60 = 7,

        /// <summary>
        ///     iOS devices running OS versions 7.0 and above
        /// </summary>
        [FacebookName("iOS_ver_7.0_and_above")]
        Ios70 = 8,

        /// <summary>
        ///     iOS devices running OS versions 8.0 and above
        /// </summary>
        [FacebookName("iOS_ver_8.0_and_above")]
        Ios80 = 9,

        #endregion iOS options

        #region Android options

        /// <summary>
        ///     Android devices
        /// </summary>
        [FacebookName("Android")]
        Android = 10,

        /// <summary>
        ///     Android devices running Android versions 2.0 and above
        /// </summary>
        [FacebookName("Android_ver_2.0_and_above")]
        Android20 = 11,

        /// <summary>
        ///     Android devices running Android versions 2.1 and above
        /// </summary>
        [FacebookName("Android_ver_2.1_and_above")]
        Android21 = 12,

        /// <summary>
        ///     Android devices running Android versions 2.2 and above
        /// </summary>
        [FacebookName("Android_ver_2.2_and_above")]
        Android22 = 13,

        /// <summary>
        ///     Android devices running Android versions 2.3 and above
        /// </summary>
        [FacebookName("Android_ver_2.3_and_above")]
        Android23 = 14,

        /// <summary>
        ///     Android devices running Android versions 3.0 and above
        /// </summary>
        [FacebookName("Android_ver_3.0_and_above")]
        Android30 = 15,

        /// <summary>
        ///     Android devices running Android versions 3.1 and above
        /// </summary>
        [FacebookName("Android_ver_3.1_and_above")]
        Android31 = 16,

        /// <summary>
        ///     Android devices running Android versions 3.2 and above
        /// </summary>
        [FacebookName("Android_ver_3.2_and_above")]
        Android32 = 17,

        /// <summary>
        ///     Android devices running Android versions 4.0 and above
        /// </summary>
        [FacebookName("Android_ver_4.0_and_above")]
        Android40 = 18,

        /// <summary>
        ///     Android devices running Android versions 4.1 and above
        /// </summary>
        [FacebookName("Android_ver_4.1_and_above")]
        Android41 = 19,

        /// <summary>
        ///     Android devices running Android versions 4.2 and above
        /// </summary>
        [FacebookName("Android_ver_4.2_and_above")]
        Android42 = 20,

        /// <summary>
        ///     Android devices running Android versions 4.3 and above
        /// </summary>
        [FacebookName("Android_ver_4.3_and_above")]
        Android43 = 21,

        /// <summary>
        ///     Android devices running Android versions 4.4 and above
        /// </summary>
        [FacebookName("Android_ver_4.4_and_above")]
        Android44 = 22,

        /// <summary>
        ///     Android devices running Android versions 5.0 and above
        /// </summary>
        [FacebookName("Android_ver_5.0_and_above")]
        Android50 = 23

        #endregion Android options
    }
}