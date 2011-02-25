namespace Instagram.Wrapper.Models {
    public static class ApiUrls {
        public static string OAUTHTOKEN_REQUEST_URL = "https://api.instagram.com/oauth/access_token";
        public static string USER_URL = "https://api.instagram.com/v1/users/{0}?access_token={1}";
        public static string USER_FEED_URL = "https://api.instagram.com/v1/users/self/feed?access_token={0}";

        
    }
}
