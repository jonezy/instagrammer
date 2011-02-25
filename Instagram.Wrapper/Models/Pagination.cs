using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {

    [DataContract]
    public class Pagination {
        [DataMember]
        public string next_url { get; set; }
        [DataMember]
        public string next_max_id { get; set; }
        [DataMember]
        public string prev_url { get; set; }
        [DataMember]
        public string prev_max_id { get; set; }
    }
}
