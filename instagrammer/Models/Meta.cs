using System.Runtime.Serialization;

namespace instagrammer {
    [DataContract]
    public class Meta {

        [DataMember]
        public string status { get; set; }
 
    }
}
