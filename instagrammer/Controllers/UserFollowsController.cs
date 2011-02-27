using System.Collections.Generic;

namespace instagrammer {
    public class UserFollowsController : ControllerBase {
        public UserFollowsController(string token) : base(token) { }

        public List<InstagramUser> Follows(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWS_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = Deserialize<ApiResponse<InstagramUser>>(json);

            return response.data;
        }

        public List<InstagramUser> FollowedBy(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWEDBY_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = Deserialize<ApiResponse<InstagramUser>>(json);

            return response.data;
        }
    }
}
