using Newtonsoft.Json;
using Dinglo.Domain.Commands.Contracts;

namespace Dinglo.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data, int statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
    }
}
