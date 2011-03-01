
namespace instagrammer {
    public class MediaController : ControllerBase {
        public MediaController(string token) : base(token) { }

        public ApiSingleResponse<UserFeed> Media(string mediaId) {
            string json = GetJSON(string.Format(ApiUrls.MEDIA_URL, mediaId, base._token), null);
            ApiSingleResponse<UserFeed> response = json.Deserialize<ApiSingleResponse<UserFeed>>();

            return response;
        }
    }
}
