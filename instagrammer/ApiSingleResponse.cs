namespace instagrammer {
    public class ApiSingleResponse<T> {
        public Meta meta { get; set; }
        public T data { get; set; }
    }
}
