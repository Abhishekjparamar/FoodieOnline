namespace FoodieOnline.Model
{
    public class APIResult
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string CurrentId { get; set; }
    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public RegisterModel registerModel { get; set; }
    }
}
