
namespace instagrammer {
    public class LocationController : ControllerBase {
        public LocationController(string token) : base(token) { }

        public ApiSingleResponse<Location> Locations(string name) {
            string json = GetJSON(string.Format(ApiUrls.LOCATIONS_URL, name, base._token), null);
            ApiSingleResponse<Location> response = json.Deserialize<ApiSingleResponse<Location>>();

            return response;
        }

        public ApiResponse<FeedItem> RecentMedia(string locationId) {
            string json = GetJSON(string.Format(ApiUrls.LOCATIONS_RECENT_URL, locationId, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        public ApiResponse<FeedItem> Search(string query) {
            string json = GetJSON(string.Format(ApiUrls.LOCATIONS_SEARCH_URL, query, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }
    }
}
