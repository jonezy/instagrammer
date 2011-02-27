using System.Runtime.Serialization;

namespace instagrammer {
    [DataContract]
    public partial  class Comment {
        [DataMember]
        public string created_time { get; set; }
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public InstagramUser from { get; set; }
    }
}
