namespace instagrammer {
    public static class ApiUrls {
        public static string OAUTHTOKEN_REQUEST_URL = "https://api.instagram.com/oauth/access_token";
        private static string API_BASE = "https://api.instagram.com/v1";
        // Users
        // TODO: fill in querystring params
        public static string USER_URL = API_BASE + "/users/{0}?access_token={1}";
        public static string USER_FEED_URL = API_BASE + "/users/self/feed?access_token={0}";
        public static string USER_MEDIA_URL = API_BASE + "/users/{0}/media/recent/?access_token={1}";
        public static string USER_SEARCH_URL = API_BASE + "/users/search?q={0}&access_token={1}";
        public static string FOLLOWS_URL = API_BASE + "/users/{0}/follows/?access_token={1}";
        public static string FOLLOWEDBY_URL = API_BASE + "/users/{0}/followed-by?access_token={1}";
        public static string REQUESTEDBY_URL = API_BASE + "/users/self/requested-by?access_token={0}";
        public static string RELATIONSHIP_URL = API_BASE + "/users/{0}/relationship?{1}";

        // media
        public static string MEDIA_URL = API_BASE + "/media/{0}?access_token={1}";
        public static string MEDIA_SEARCH_URL = API_BASE + "/media/search?access_token={0}";
        public static string MEDIA_POPULAR_URL = API_BASE + "/media/popular?access_token={0}";
        public static string COMMENTS_URL = API_BASE + "/media/{0}/comments?access_token={1}";
        public static string LIKES_URL = API_BASE + "/media/{0}/likes?access_token={1}";

        //tags
        public static string TAGS_URL = API_BASE + "/tags/{0}?access_token={1}";
        public static string TAGS_RECENT_URL = API_BASE + "/tags/{0}/media/recent?access_token={1}";
        public static string TAGS_SEARCH_URL = API_BASE + "/tags/search?q={0}&access_token={1}";

        //locations
        public static string LOCATIONS_URL = API_BASE + "/locations/{0}?access_token={1}";
        public static string LOCATIONS_RECENT_URL = API_BASE + "/locations/{0}/media/recent?access_token={1}";
        public static string LOCATIONS_SEARCH_URL = API_BASE + "/locations/search?q={0}&access_token={1}";
    }
}
