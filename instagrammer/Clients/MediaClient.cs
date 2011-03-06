
namespace instagrammer {
    public class MediaClient : BaseClient {
        public MediaClient(string token) : base(token) { }

        /// <summary>
        /// Get the details (full record) of the specified media
        /// http://instagram.com/developer/endpoints/media/#get_media
        /// </summary>
        /// <param name="mediaId">The id of the media object to get the details for</param>
        /// <returns>An ApiSingleResponse<FeedItem> item object with single FeedItem on data node.</returns>
        public ApiSingleResponse<FeedItem> Media(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.MEDIA_URL, mediaId, base._token), null);
            ApiSingleResponse<FeedItem> response = json.Deserialize<ApiSingleResponse<FeedItem>>();

            return response;
        }

        /// <summary>
        /// Search for media by longitude, latitude and distance
        /// http://instagram.com/developer/endpoints/media/#get_media_search
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="distance"></param>
        /// <returns>An ApiResponse<FeedItem> item object with a list of FeedItems on data node.</returns>
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

        /// <summary>
        /// Finds the most popular media on instagram right now.
        /// http://instagram.com/developer/endpoints/media/#get_media_popular
        /// </summary>
        /// <returns>An ApiResponse<FeedItem> item object with a list of feeditems on data node.</returns>
        public ApiResponse<FeedItem> Popular(string clientId) {
            string json = GetJSON(string.Format(ApiUrls.MEDIA_POPULAR_URL, clientId), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        /// <summary>
        /// Get the full list of comments on the media
        /// http://instagram.com/developer/endpoints/comments/#get_media_comments
        /// </summary>
        /// <param name="mediaId">The id of the media object to get the details for</param>
        /// <returns>An ApiResponse<Comment> item object with a list of Comments the data node.</returns>
        public ApiResponse<Comment> Comments(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.COMMENTS_URL, mediaId, base._token), null);
            ApiResponse<Comment> response = json.Deserialize<ApiResponse<Comment>>();

            return response;
        }

        /// <summary>
        /// Add's the comment to the media item
        /// http://instagram.com/developer/endpoints/comments/#post_media_comments
        /// </summary>
        /// <param name="mediaId">The id of the media object to add the comment to</param>
        /// <param name="text">The text of the comment</param>
        /// <returns>An ApiResponse<Comment> item object with a list of Comments the data node.</returns>
        public ApiSingleResponse<Comment> Comment(string mediaId, string text) {
            string json = GetJSON(string.Format(ApiUrls.COMMENTS_ADD_URL, mediaId, base._token, text), string.Format("text={0}",text), "POST");
            ApiSingleResponse<Comment> response = json.Deserialize<ApiSingleResponse<Comment>>();

            return response;
        }

        /// <summary>
        /// Removes the specified comment from the media
        /// http://instagram.com/developer/endpoints/comments/#delete_media_comments
        /// </summary>
        /// <param name="mediaId">The id of the media to remove the comment from</param>
        /// <param name="commentId">The id of the comment to rememove</param>
        /// <returns>ApiSingleResponse<string> containing a meta node (with http status) and a null data node</returns>
        public ApiSingleResponse<string> UnComment(string mediaId, string commentId) {
            string json = GetJSON(string.Format(ApiUrls.COMMENTS_DELETE_URL, mediaId, commentId, base._token), null, "DELETE");
            ApiSingleResponse<string> response = json.Deserialize<ApiSingleResponse<string>>();

            return response;
        }

        /// <summary>
        /// Return a list of users who have liked this media
        /// http://instagram.com/developer/endpoints/likes/#get_media_likes
        /// </summary>
        /// <param name="mediaId">The id of the media to get the list of liking users for.</param>
        /// <returns>ApiResponse<InstagramUser> containing a list of <InstagramUser> that have liked this media.</returns>
        public ApiResponse<InstagramUser> Likes(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.LIKES_URL, mediaId, base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response;
        }

        /// <summary>
        /// Set a like of the media by the currently authenticated user
        /// http://instagram.com/developer/endpoints/likes/#post_media_likes
        /// </summary>
        /// <param name="mediaId">The id of the media to like</param>
        /// <returns>ApiSingleResponse<string> containing a meta node (with http status) and a null data node</returns>
        public ApiSingleResponse<string> Like(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.LIKES_URL, mediaId, base._token), mediaId, "POST");
            ApiSingleResponse<string> response = json.Deserialize<ApiSingleResponse<string>>();

            return response;
        }

        /// <summary>
        /// Remove a like on the media by the currently authenticated user
        /// http://instagram.com/developer/endpoints/likes/#delete_media_likes
        /// </summary>
        /// <param name="mediaId">The id of the media to remove the like from</param>
        /// <returns>ApiSingleResponse<string> containing a meta node (with http status) and a null data node</returns>
        public ApiSingleResponse<string> UnLike(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.LIKES_URL, mediaId, base._token), null, "DELETE");
            ApiSingleResponse<string> response = json.Deserialize<ApiSingleResponse<string>>();

            return response;
        }
    }
}
