using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {

    [DataContract]
    public class Images {
        [DataMember]
        public InstagramImage low_resolution { get; set; }
        [DataMember]
        public InstagramImage thumbnail { get; set; }
        [DataMember]
        public InstagramImage standard_resolution { get; set; }
    }

}
