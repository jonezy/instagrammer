using System.Runtime.Serialization;

namespace instagrammer {
    [DataContract]
    public class InstagramImage {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string width { get; set; }
        [DataMember]
        public string height { get; set; }
    }

}
