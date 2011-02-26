using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {
    [DataContract(Namespace = "data")]
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
}
