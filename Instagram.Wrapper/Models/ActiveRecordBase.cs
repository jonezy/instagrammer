using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public abstract class ActiveRecordBase {
        protected string _token;

        public ActiveRecordBase(string token) {
            _token = token;
        }
    }
}
