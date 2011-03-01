
namespace instagrammer {
    public class MediaController : ControllerBase {
        public MediaController(string token) : base(token) { }

        public ApiSingleResponse<FeedItem> Media(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.MEDIA_URL, mediaId, base._token), null);
            ApiSingleResponse<FeedItem> response = json.Deserialize<ApiSingleResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<FeedItem> Search(string lat, string lng, string distance) {
            string requestUrl = string.Format(ApiUrls.MEDIA_SEARCH_URL, base._token);

            if (!string.IsNullOrEmpty(lat))
                requestUrl = string.Format("{0}&lat={1}", requestUrl, lat);
            
            if (!string.IsNullOrEmpty(lng))
                requestUrl = string.Format("{0}&lng={1}", requestUrl, lng);

            if (!string.IsNullOrEmpty(distance))
                requestUrl = string.Format("{0}&distance={1}", requestUrl, lng);

            string json = GetJSON(requestUrl, null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<FeedItem> Popular() {
            string json = GetJSON(string.Format(ApiUrls.MEDIA_POPULAR_URL, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<Comment> Comments(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.COMMENTS_URL, mediaId, base._token), null);
            ApiResponse<Comment> response = json.Deserialize<ApiResponse<Comment>>();

            return response;
        }

        public ApiResponse<InstagramUser> Likes(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.LIKES_URL, mediaId, base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }
    }
}
