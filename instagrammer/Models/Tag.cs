using System.Runtime.Serialization;

namespace instagrammer {
    [DataContract]
    public class Tag {
        [DataMember]
        public string media_count { get; set; }
        [DataMember]
        public string name { get; set; }
    }
}
