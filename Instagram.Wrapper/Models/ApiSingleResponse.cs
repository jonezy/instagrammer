using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instagram.Wrapper.Models {
    public class ApiSingleResponse<T> {
        public Meta meta { get; set; }
        public T data { get; set; }
    }
}
