using System.Collections.Generic;

namespace instagrammer {
    public class UsersController : ControllerBase {
        public UsersController(string token) : base(token) { }

        public ApiSingleResponse<InstagramUser> User(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiSingleResponse<InstagramUser> response = json.Deserialize<ApiSingleResponse<InstagramUser>>();

            return response;
        }

        public ApiResponse<FeedItem> SelfFeed() {
            string json = GetJSON(string.Format(ApiUrls.USER_FEED_URL, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<FeedItem> RecentMedia(string userId, string next_max_id, string prev_max_id) {
            string requestUrl = string.Format(ApiUrls.USER_MEDIA_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token);
            
            if (!string.IsNullOrEmpty(next_max_id))
                requestUrl = string.Format("{0}&max_id={1}", requestUrl, next_max_id);
            if (!string.IsNullOrEmpty(prev_max_id))
                requestUrl = string.Format("{0}&max_id={1}", requestUrl, prev_max_id);

            string json = GetJSON(requestUrl, null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<FeedItem> Search(string query) {
            string json = GetJSON(string.Format(ApiUrls.USER_SEARCH_URL, query, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<InstagramUser> Follows(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWS_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        public ApiResponse<InstagramUser> FollowedBy(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWEDBY_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        public ApiResponse<InstagramUser> RequestedBy() {
            string json = GetJSON(string.Format(ApiUrls.REQUESTEDBY_URL, base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        public ApiResponse<RelationshipStatus> Relationship(string foreignUserId) {
            string json = GetJSON(string.Format(ApiUrls.RELATIONSHIP_URL, foreignUserId, base._token), null);
            ApiResponse<RelationshipStatus> response = json.Deserialize<ApiResponse<RelationshipStatus>>();

            return response;
        }
    }
}