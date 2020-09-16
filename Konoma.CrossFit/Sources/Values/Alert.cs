namespace Konoma.CrossFit
{
    public class AlertPromptConfig
    {
        #region Init

        public string Title { get; set; }
        public string Message { get; set; }
        public string Placeholder { get; set; }
        public string OkText { get; set; }
        public string CancelText { get; set; }
        public string? Text { get; set; }

        public AlertPromptConfig(string title, string message, string placeholder, string okText, string cancelText, string? existingText)
        {
            Title = title;
            Message = message;
            Placeholder = placeholder;
            OkText = okText;
            CancelText = cancelText;
            Text = existingText;
        }

        #endregion
    }

    public struct AlertPromptResult
    {
        private AlertPromptResult(bool cancelled, string? text)
        {
            WasCancelled = cancelled;
            Text = text;
        }

        public static AlertPromptResult Cancelled() => new AlertPromptResult(cancelled: true, text: null);
        public static AlertPromptResult Result(string? text) => new AlertPromptResult(cancelled: false, text);

        public bool WasCancelled { get; }
        public string? Text { get; }
    }

    public class AlertConfirmationConfig
    {
        #region Init

        public string Title { get; set; }
        public string Message { get; set; }
        public string OkText { get; set; }
        public string CancelText { get; set; }

        public AlertConfirmationConfig(string title, string message, string okText, string cancelText)
        {
            Title = title;
            Message = message;
            OkText = okText;
            CancelText = cancelText;
        }

        #endregion
    }

    public struct AlertConfirmationResult
    {
        private AlertConfirmationResult(bool cancelled, bool hasConfirmed)
        {
            WasCancelled = cancelled;
            HasConfirmed = hasConfirmed;
        }

        public static AlertConfirmationResult Reject() => new AlertConfirmationResult(cancelled: true, hasConfirmed: false);
        public static AlertConfirmationResult Confirm() => new AlertConfirmationResult(cancelled: false, hasConfirmed: true);

        public bool WasCancelled { get; }
        public bool HasConfirmed { get; }
    }

    public class AlertMessageConfig
    {
        #region Init

        public string Title { get; set; }
        public string Message { get; set; }
        public string OkText { get; set; }

        public AlertMessageConfig(string title, string message, string okText)
        {
            Title = title;
            Message = message;
            OkText = okText;
        }

        #endregion
    }
}
