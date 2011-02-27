﻿using System.Collections.Generic;

namespace instagrammer {
    public class UsersController : ControllerBase {
        public UsersController(string token) : base(token) { }

        public InstagramUser User(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiSingleResponse<InstagramUser> response = json.Deserialize<ApiSingleResponse<InstagramUser>>();

            return response.data;
        }

        public List<UserFeed> SelfFeed() {
            string json = GetJSON(string.Format(ApiUrls.USER_FEED_URL, base._token), null);
            ApiResponse<UserFeed> response = json.Deserialize<ApiResponse<UserFeed>>();

            return response.data;
        }

        public List<UserFeed> RecentMedia(string userId) {
            string json = GetJSON(string.Format(ApiUrls.USER_MEDIA_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<UserFeed> response = json.Deserialize<ApiResponse<UserFeed>>();

            return response.data;
        }
    }
}