using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public class Image {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string width { get; set; }
        [DataMember]
        public string height { get; set; }
    }

}
