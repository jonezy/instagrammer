using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {

    [DataContract]
    public class Counts {
        [DataMember]
        public string media { get; set; }
        [DataMember]
        public string follows { get; set; }
        [DataMember]
        public string followed_by { get; set; }
    }


}
