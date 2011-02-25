using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instagram.Wrapper.Models {
    public class InstagramUserController : ActiveRecordBase {
        private string accessToken;
        
        public InstagramUserController(string token) : base(token) { }

        public InstagramUser Single(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_URL, userId != null ? userId : "self", base._token), null);
            InstagramSingleResponse response = Deserialize<InstagramSingleResponse>(json);

            return response.data;
        }

        public List<UserFeed> Feed() {
            string json = GetJSON(string.Format(ApiUrls.USER_FEED_URL, base._token), null);
            FeedItems response = Deserialize<FeedItems>(json);

            return response.data;
        }
    }
}
