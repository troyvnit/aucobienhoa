namespace TroyLeeMVCEF.CommandProcessor.Commands
{
    public class ValidationResult
    {
        public string MemberName { get; set; }
        public string Message { get; set; }
        public ValidationResult(string memberName, string message)
        {
            this.MemberName = memberName;
            this.Message = message;
        }
        public ValidationResult(string message)
        {
            this.Message = message;
        }
        public ValidationResult() { }
    }
}
