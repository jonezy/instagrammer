using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
        public Images images { get; set; }
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
        [DataMember]
        public Comment caption { get; set; }
    }

    [DataContract]
    public class Images {
        [DataMember]
        public InstagramImage low_resolution { get; set; }
        [DataMember]
        public InstagramImage thumbnail { get; set; }
        [DataMember]
        public InstagramImage standard_resolution { get; set; }
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
}
