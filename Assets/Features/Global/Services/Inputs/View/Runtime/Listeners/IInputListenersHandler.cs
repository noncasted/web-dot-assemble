﻿namespace Global.Services.Inputs.View.Runtime.Listeners
{
    public interface IInputListenersHandler
    {
        void AddListener(IInputListener listener);
        
        void InvokeListen();
        void InvokeUnlisten();
    }
}