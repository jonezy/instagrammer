
namespace instagrammer {
    public class LocationClient : BaseClient {
        public LocationClient(string token) : base(token) { }

        /// <summary>
        /// Get information about a location
        /// http://instagram.com/developer/endpoints/locations/#get_locations
        /// </summary>
        /// <param name="name">The name of the location</param>
        /// <returns>ApiSingleReponse with a Location record on the data node.</returns>
        public ApiSingleResponse<Location> Locations(string name) {
            string json = GetJSON(string.Format(ApiUrls.LOCATIONS_URL, name, base._token), null);
            ApiSingleResponse<Location> response = json.Deserialize<ApiSingleResponse<Location>>();

            return response;
        }

        /// <summary>
        /// Get a list of recent media from the given location
        /// http://instagram.com/developer/endpoints/locations/#get_locations_media_recent
        /// </summary>
        /// <param name="locationId">Location to find media</param>
        /// <returns>An ApiResponse containing a list of FeedItem's on the data node.</returns>
        public ApiResponse<FeedItem> RecentMedia(string locationId) {
            string json = GetJSON(string.Format(ApiUrls.LOCATIONS_RECENT_URL, locationId, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }

        /// <summary>
        /// Search for a location by name and geographic coordinate.
        /// </summary>
        /// <param name="query">The name of the location</param>
        /// <returns>An ApiResponse containing a list of Locations's on the data node.</returns>
        /// TODO: Search needs to support lat, lng and foursquare_id
        public ApiResponse<FeedItem> Search(string query) {
            string json = GetJSON(string.Format(ApiUrls.LOCATIONS_SEARCH_URL, query, base._token), null);
            ApiResponse<FeedItem> response = json.Deserialize<ApiResponse<FeedItem>>();

            return response;
        }
    }
}
