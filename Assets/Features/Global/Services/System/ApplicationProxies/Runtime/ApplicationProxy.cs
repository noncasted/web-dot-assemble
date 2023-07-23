using UnityEngine;

namespace Global.Services.System.ApplicationProxies.Runtime
{
    [DisallowMultipleComponent]
    public class ApplicationProxy : IApplicationFlow
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}