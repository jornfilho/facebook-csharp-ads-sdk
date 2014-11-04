namespace facebook_csharp_ads_sdk_ui_test
{
    public class PersonalData
    {
        #region App data
        public string AppToken { get; private set; }
        public long AppId { get; private set; }
        public string AppSecret { get; private set; } 
        #endregion

        public string UserToken { get; private set; }
        public long AccountId { get; private set; }
        public long CampaignGroupId { get; private set; }
        public long CampaignId { get; private set; }
        public long AdId { get; private set; }

        public PersonalData()
        {
            AppToken = null;
            AppId = 0;
            AppSecret = null;

            UserToken = null;
            AccountId = 0;
            CampaignGroupId = 0;
            CampaignId = 0;
            AdId = 0;
        }
    }
}
