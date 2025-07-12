namespace WebapiStandard.Result
{
    public class ApiJsonResult : IApiResult<string>
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public string? Data { get; set; }
    }
}
