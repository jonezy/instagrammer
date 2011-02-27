﻿using System.Collections.Generic;

namespace instagrammer {
    public class RelationshipsController : ControllerBase {
        public RelationshipsController(string token) : base(token) { }

        public List<InstagramUser> Follows(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWS_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response.data;
        }

        public List<InstagramUser> FollowedBy(string userId) {
            string json = GetJSON(string.Format(ApiUrls.FOLLOWEDBY_URL, !string.IsNullOrEmpty(userId) ? userId : "self", base._token), null);
            ApiResponse<InstagramUser> response = json.Deserialize<ApiResponse<InstagramUser>>();

            return response.data;
        }
    }
}