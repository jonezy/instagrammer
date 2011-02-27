using System.Collections.Generic;
using System.Runtime.Serialization;

namespace instagrammer {
    // self feed
    [DataContract(Namespace = "root")]
    public class FeedItems {
        [DataMember(Name = "pagination")]
        public Pagination pagination { get; set; }
        [DataMember(Name = "meta")]
        public Meta meta { get; set; }
        [DataMember(Name = "data")]
        public List<UserFeed> data { get; set; }
    }

}
