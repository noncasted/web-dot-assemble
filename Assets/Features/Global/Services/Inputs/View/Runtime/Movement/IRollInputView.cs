using System;

namespace Global.Services.Inputs.View.Runtime.Movement
{
    public interface IRollInputView
    {
        event Action Performed;
        event Action Canceled;
    }
}