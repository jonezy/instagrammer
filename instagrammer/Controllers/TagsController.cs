
namespace instagrammer {
    public class TagsController : ControllerBase {
        public TagsController(string token) : base(token) { }

        public ApiSingleResponse<Tag> Tags(string name) {
            string json = GetJSON(string.Format(ApiUrls.TAGS_URL, name, base._token), null);
            ApiSingleResponse<Tag> response = json.Deserialize<ApiSingleResponse<Tag>>();

            return response;
        }

        public ApiResponse<FeedItem> RecentMedia(string tagname) {
            string json = GetJSON(string.Format(ApiUrls.TAGS_RECENT_URL, tagname, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<FeedItem> Search(string query) {
            string json = GetJSON(string.Format(ApiUrls.TAGS_SEARCH_URL, query, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }


    }
}
