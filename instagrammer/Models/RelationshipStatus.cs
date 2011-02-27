using System.Runtime.Serialization;

namespace instagrammer {
    [DataContract]
    public class RelationshipStatus {
        [DataMember]
        public string outgoing_status { get; set; }
        [DataMember]
        public string incoming_status { get; set; }
    }
}
