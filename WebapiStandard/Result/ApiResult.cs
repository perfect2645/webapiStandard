namespace WebapiStandard.Result
{
    public class ApiStringResult : IApiResult<string>
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public string? Data { get; set; }
    }
}
