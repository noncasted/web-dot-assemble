using System;

namespace Global.Services.Inputs.View.Runtime
{
    public interface IInputView
    {
        event Action DebugConsolePreformed;
    }
}