namespace Konoma.CrossFit
{
    public class ConfirmationConfig
    {
        #region Init

        public string Title { get; set; }
        public string Message { get; set; }
        public string OkText { get; set; }
        public string CancelText { get; set; }

        public ConfirmationConfig(string title, string message, string okText, string cancelText)
        {
            Title = title;
            Message = message;
            OkText = okText;
            CancelText = cancelText;
        }

        #endregion
    }

    public struct ConfirmationResult
    {
        private ConfirmationResult(bool cancelled, bool hasConfirmed)
        {
            WasCancelled = cancelled;
            HasConfirmed = hasConfirmed;
        }

        public static ConfirmationResult Reject() => new ConfirmationResult(cancelled: true, hasConfirmed: false);
        public static ConfirmationResult Confirm() => new ConfirmationResult(cancelled: false, hasConfirmed: true);

        public bool WasCancelled { get; }
        public bool HasConfirmed { get; }
    }
}
