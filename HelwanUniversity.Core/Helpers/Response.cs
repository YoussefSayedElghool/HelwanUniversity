

namespace HelwanUniversity.Core.Helpers
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public Error Message { get; set; }
        public T Data { get; set; }
    }
}
