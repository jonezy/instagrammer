using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {

    [DataContract]
    public class Likes {
        [DataMember]
        public string count { get; set; }
        [DataMember]
        public IList<InstagramUser> data { get; set; }
    }
}
