using UnityEditor;

namespace Global.Options.Editor
{
    public class WebGlSettings
    {
        public WebGlSettings()
        {
            PlayerSettings.WebGL.emscriptenArgs = "-Wl,--trace-symbol=sendfile";
        }
    }
}