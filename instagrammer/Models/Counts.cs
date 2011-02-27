using System.Runtime.Serialization;

namespace instagrammer {

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
