using System.Collections.Generic;
using System.Runtime.Serialization;

namespace instagrammer {

    [DataContract]
    public class ItemComments {
        [DataMember]
        public string count { get; set; }
        [DataMember]
        public IList<Comment> data { get; set; }
    }
}
