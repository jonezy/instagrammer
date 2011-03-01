
namespace instagrammer {
    public class TagsController : ControllerBase {
        public TagsController(string token) : base(token) { }

        /// <summary>
        /// Get information about a tag
        /// http://instagram.com/developer/endpoints/tags/#get_tags
        /// </summary>
        /// <param name="name">The tag to lookup</param>
        /// <returns>An ApiSingleResponse with a single Tag object on the data node</returns>
        public ApiSingleResponse<Tag> Tag(string name) {
            string json = GetJSON(string.Format(ApiUrls.TAGS_URL, name, base._token), null);
            ApiSingleResponse<Tag> response = json.Deserialize<ApiSingleResponse<Tag>>();

            return response;
        }

        /// <summary>
        /// Get a list of media tagged with this tag
        /// http://instagram.com/developer/endpoints/tags/#get_tags_media_recent
        /// </summary>
        /// <param name="tagname">The name of the tag to match.</param>
        /// <returns>An ApiResponse with a list of FeedItem's on the data node.</returns>
        public ApiResponse<FeedItem> RecentMedia(string tagname) {
            string json = GetJSON(string.Format(ApiUrls.TAGS_RECENT_URL, tagname, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        /// <summary>
        /// Search for tags by tagname
        /// http://instagram.com/developer/endpoints/tags/#get_tags_search
        /// </summary>
        /// <param name="query">A valid tagname (no leading #)</param>
        /// <returns>An ApiResponse with a list of tags on the data node (NOTE: results are ordered first as an exact match, then by popularity.)</returns>
        public ApiResponse<Tag> Search(string query) {
            string json = GetJSON(string.Format(ApiUrls.TAGS_SEARCH_URL, query, base._token), null);
            ApiResponse<Tag> response = json.Deserialize<ApiResponse<Tag>>();

            return response;
        }

    }
}
