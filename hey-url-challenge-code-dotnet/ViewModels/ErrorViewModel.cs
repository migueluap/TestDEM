namespace HeyUrlChallengeCodeDotnet.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string requestId = null, string messageError = null)
        {
            RequestId = requestId;
            MessageError = messageError;
        }
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string MessageError { get; set; }
    }
}
