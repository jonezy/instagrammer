using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {

    [DataContract]
    public class ItemComments {
        [DataMember]
        public string count { get; set; }
        [DataMember]
        public IList<Comment> data { get; set; }
    }
}
