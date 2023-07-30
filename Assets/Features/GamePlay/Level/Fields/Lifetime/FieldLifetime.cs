using Global.Services.System.MessageBrokers.Runtime;

namespace GamePlay.Level.Fields.Lifetime
{
    public class FieldLifetime : IFieldLifetime
    {
        public void OnStep()
        {
            Msg.Publish(new FieldStepEvent());
        }
    }
}