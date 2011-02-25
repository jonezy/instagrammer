using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public class Meta {

        [DataMember]
        public string status { get; set; }
 
    }
}
