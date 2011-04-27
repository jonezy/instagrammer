using System.Collections.Generic;

namespace instagrammer {
    public class UsersClient : BaseClient {
        public UsersClient(string token) : base(token) { }

        /// <summary>
        /// Get basic information about the currently authenticated user
        /// http://instagram.com/developer/endpoints/users/#get_users
        /// </summary>
        /// <param name="userId">the id of the user to get information for (self if null)</param>
        /// <returns>An ApiSingleReponse containing a single Instagram user record on the data node.</returns>
        public ApiSingleResponse<InstagramUser> User(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiSingleResponse<InstagramUser> response = json.Deserialize<ApiSingleResponse<InstagramUser>>();

            return response;
        }

        /// <summary>
        /// Get basic information about the currently authenticated user
        /// http://instagram.com/developer/endpoints/users/#get_users
        /// </summary>
        /// <param name="userId">the id of the user to get information for (self if null)</param>
        /// <returns>An ApiSingleReponse containing a single Instagram user record on the data node.</returns>
        public ApiSingleResponse<InstagramUser> User() {
            return User(null);
        }

        /// <summary>
        /// Show the currently authenticated users feed
        /// </summary>
        /// <returns>An ApiResponse containing a list of FeedItem's on the data node</returns>
        public ApiResponse<FeedItem> SelfFeed() {
            return SelfFeed(null, null);
        }

        /// <summary>
        /// Show the currently authenticated users feed
        /// </summary>
        /// <returns>An ApiResponse containing a list of FeedItem's on the data node</returns>
        public ApiResponse<FeedItem> SelfFeed(string next_max_id, string prev_max_id) {
            string requestUrl = string.Format(ApiUrls.USER_FEED_URL, base._token, null);

            if (!string.IsNullOrEmpty(next_max_id))
                requestUrl = string.Format("{0}&max_id={1}", requestUrl, next_max_id);
            if (!string.IsNullOrEmpty(prev_max_id))
                requestUrl = string.Format("{0}&max_id={1}", requestUrl, prev_max_id);

            string json = GetJSON(string.Format(ApiUrls.USER_FEED_URL, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        /// <summary>
        /// Get the most recent media published by a user
        /// http://instagram.com/developer/endpoints/users/#get_users_media_recent
        /// </summary>
        /// <param name="userId">the id of the user (self if null)</param>
        /// <param name="next_max_id"></param>
        /// <param name="prev_max_id"></param>
        /// <returns>An ApiResponse with a list of FeedItem's on the data node</returns>
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

        /// <summary>
        /// Search for a user by name
        /// http://instagram.com/developer/endpoints/users/#get_users_search
        /// </summary>
        /// <param name="query">The name of the user to search form</param>
        /// <returns>An ApiResponse with a ist of users that match the query</returns>
        public ApiResponse<InstagramUser> Search(string query) {
            string json = GetJSON(string.Format(ApiUrls.USER_SEARCH_URL, query, base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        /// <summary>
        /// Get a list of users this user follows
        /// http://instagram.com/developer/endpoints/relationships/#get_users_follows
        /// </summary>
        /// <param name="userId">The id of the user (self if null)</param>
        /// <returns>An ApiResponse with a ist of users that this user follows</returns>
        public ApiResponse<InstagramUser> Follows(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWS_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        /// <summary>
        /// Get a list of users the currently authenticated user is followed by
        /// http://instagram.com/developer/endpoints/relationships/#get_users_followed_by   
        /// </summary>
        /// <param name="userId">The id of the user (self if null)</param>
        /// <returns>An ApiResponse with a ist of users that this user follows</returns>
        public ApiResponse<InstagramUser> FollowedBy(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWEDBY_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        /// <summary>
        /// Get a list of users who have requested to follow the currently authenticated user
        /// http://instagram.com/developer/endpoints/relationships/#get_incoming_requests 
        /// </summary>
        /// <param name="userId">The id of the user (self if null)</param>
        /// <returns>An ApiResponse with a ist of users that follow this user</returns>
        public ApiResponse<InstagramUser> RequestedBy() {
            string json = GetJSON(string.Format(ApiUrls.REQUESTEDBY_URL, base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        /// <summary>
        /// Get information about the currently authenticated users relationship with another user
        /// http://instagram.com/developer/endpoints/relationships/#get_relationship  
        /// </summary>
        /// <param name="foreignUserId">The id of the user to get the current users relationship status with</param>
        /// <returns>An ApiSingleResponse with a RelationshipStatus record</returns>
        public ApiSingleResponse<RelationshipStatus> Relationship(string foreignUserId) {
            string json = GetJSON(string.Format(ApiUrls.RELATIONSHIP_URL, foreignUserId, base._token), null);
            ApiSingleResponse<RelationshipStatus> response = json.Deserialize<ApiSingleResponse<RelationshipStatus>>();

            return response;
        }

        // TODO: UpdateRelationship endpoint
    }
}