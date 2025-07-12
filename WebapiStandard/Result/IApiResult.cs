namespace WebapiStandard.Result
{
    public interface IApiResult<T> where T : class
    {
        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        T? Data { get; set; }
        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        string? Message { get; set; }
        /// <summary>
        ///     Gets or sets the status code.
        /// </summary>
        int StatusCode { get; set; }
    }
}
