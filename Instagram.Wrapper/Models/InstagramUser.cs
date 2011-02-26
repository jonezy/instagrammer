using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public partial class InstagramUser {
        [DataMember]
        public int id { get; set; }
        
        [DataMember]
        public string username { get; set; }
        
        [DataMember]
        public string first_name { get; set; }
        
        [DataMember]
        public string last_name { get; set; }

        [DataMember]
        public string full_name { get; set; }
        
        [DataMember]
        public string profile_picture { get; set; }
        
        [DataMember]
        public Counts counts { get; set; } 
    }

}
