namespace VideoStreamingService
{
    public static class BusinessSettings
    {
        public static readonly string s_name = "VideoStreamingService";
        public static readonly TimeSpan s_tokenExpiration = TimeSpan.FromHours(2);
        public static readonly int s_maxNicknameLength = 100;
        public static readonly int s_maxChatNameLength = 100;
        public static readonly int s_maxMessageContentLength = 20000;
    }
}
