using System.Collections.Generic;

namespace Instagram.Wrapper.Models {
    public class ApiResponse<T> {
        public Pagination pagination { get; set; }
        public Meta meta { get; set; }
        public List<T> data { get; set; }
    }
}
