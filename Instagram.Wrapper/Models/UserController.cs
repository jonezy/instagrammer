using System.Collections.Generic;

namespace Instagram.Wrapper.Models {
    public class UserController : ControllerBase {
        public UserController(string token) : base(token) { }

        public InstagramUser User(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiSingleResponse<InstagramUser> response = Deserialize<ApiSingleResponse<InstagramUser>>(json);

            return response.data;
        }

        public List<UserFeed> SelfFeed() {
            string json = GetJSON(string.Format(ApiUrls.USER_FEED_URL, base._token), null);
            ApiResponse<UserFeed> response = Deserialize<ApiResponse<UserFeed>>(json);

            return response.data;
        }

        public List<UserFeed> RecentMedia(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_MEDIA_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<UserFeed> response = Deserialize<ApiResponse<UserFeed>>(json);

            return response.data;
        }
    }
}
