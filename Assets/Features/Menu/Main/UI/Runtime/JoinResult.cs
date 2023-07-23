namespace Menu.Main.UI.Runtime
{
    public readonly struct JoinResult
    {
        public JoinResult(JoinResultType resultType)
        {
            ResultType = resultType;
            Message = string.Empty;
        }

        public JoinResult(JoinResultType resultType, string message)
        {
            ResultType = resultType;
            Message = message;
        }
        
        public readonly JoinResultType ResultType;
        public readonly string Message;
    }
}