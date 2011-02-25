using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Instagram.Wrapper.Models {
    // 
    [DataContract]
    public class InstagramSingleResponse {
        [DataMember]
        public Meta meta { get; set; }

        [DataMember]
        public InstagramUser data { get; set; }
    }

    [DataContract]
    public partial class InstagramUser {
        public InstagramUser() : base("") { }
        [DataMember]
        public int id { get; set; }
        
        [DataMember]
        public string username { get; set; }
        
        [DataMember]
        public string first_name { get; set; }
        
        [DataMember]
        public string last_name { get; set; }

        [DataMember]
        public string full_name { get; set; }
        
        [DataMember]
        public string profile_picture { get; set; }
        
        [DataMember]
        public Counts counts { get; set; } 
    }

    [DataContract]
    public class Counts {
        [DataMember]
        public string media { get; set; }
        [DataMember]
        public string follows { get; set; }
        [DataMember]
        public string followed_by { get; set; }
    }

    // self feed
    [DataContract(Namespace="root")]
    public class FeedItems {
        [DataMember(Name="pagination")]
        public Pagination pagination { get; set; }
        [DataMember(Name="meta")]
        public Meta meta { get; set; }
        [DataMember(Name="data")]
        public List<UserFeed> data { get; set; }
    }

    [DataContract(Namespace="data")]
    public class UserFeed {
        [DataMember]
        public Location location { get; set; }
        [DataMember]
        public ItemComments comments { get; set; }
        [DataMember]
        public string link { get; set; }
        [DataMember]
        public Likes likes { get; set; }
        [DataMember]
        public string created_time { get; set; }
        [DataMember]
        public IList<Image> images { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string filter { get; set; }
        [DataMember]
        public string[] tags { get; set; }
        [DataMember]
        public string user_has_liked { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public InstagramUser user { get; set; }
    }

    [DataContract]
    public class ItemComments {
        [DataMember]
        public string count { get; set; }
        [DataMember]
        public IList<Comment> data { get; set; }
    }

    [DataContract]
    public class Likes {
        [DataMember]
        public string count { get; set; }
        [DataMember]
        public IList<InstagramUser> data { get; set; }
    }
 
    public partial class InstagramUser:ActiveRecordBase {
        public InstagramUser(string token) : base(token) { }

        public static InstagramUser Single(string token, string userId) {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("You must provide an instragram token");

            string json = GetJSON(string.Format(ApiUrls.USER_URL, userId != null ? userId : "self", token), null);
            InstagramSingleResponse response = Deserialize<InstagramSingleResponse>(json);

            return response.data;
        }

        public static List<UserFeed> Feed(string token) {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("You must provide an instragram token");

            string tempJson = Serialize<FeedItems>(new FeedItems());

            string json = GetJSON(string.Format(ApiUrls.USER_FEED_URL, token), null);
            FeedItems response = Deserialize<FeedItems>(json);

            return response.data;
        }

        private static FeedItems GetFeedItem() {
            FeedItems item = new FeedItems();
            item.pagination = new Pagination { next_max_id = "1234", next_url = "http://next", prev_max_id = "1234", prev_url = "http://prev" };
            item.meta = new Meta { status = "200" };


            return item;
        }
    }
}
