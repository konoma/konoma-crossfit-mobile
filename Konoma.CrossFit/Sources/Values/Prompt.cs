namespace Konoma.CrossFit
{
    public class PromptConfig
    {
        #region Init

        public string Title { get; set; }
        public string Message { get; set; }
        public string Placeholder { get; set; }
        public string OkText { get; set; }
        public string CancelText { get; set; }
        public string? Text { get; set; }

        public PromptConfig(string title, string message, string placeholder, string okText, string cancelText, string? existingText)
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

    public struct PromptResult
    {
        private PromptResult(bool cancelled, string? text)
        {
            WasCancelled = cancelled;
            Text = text;
        }

        public static PromptResult Cancelled() => new PromptResult(cancelled: true, text: null);
        public static PromptResult Result(string? text) => new PromptResult(cancelled: false, text);

        public bool WasCancelled { get; }
        public string? Text { get; }
    }
}
