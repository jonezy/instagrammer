namespace instagrammer {
    public static class ApiUrls {
        public static string OAUTHTOKEN_REQUEST_URL = "https://api.instagram.com/oauth/access_token";
        
        // Users
        // TODO: fill in querystring params
        public static string USER_URL = "https://api.instagram.com/v1/users/{0}?access_token={1}";
        public static string USER_FEED_URL = "https://api.instagram.com/v1/users/self/feed?access_token={0}";
        public static string USER_MEDIA_URL = "https://api.instagram.com/v1/users/{0}/media/recent/?access_token={1}";
        
        // follows
        public static string FOLLOWS_URL = "https://api.instagram.com/v1/users/{0}/follows/?access_token={1}";
        public static string FOLLOWEDBY_URL = "https://api.instagram.com/v1/users/{0}/followed-by?access_token={1}";
    }
}
