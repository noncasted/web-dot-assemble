using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.MessageBrokers.Common;
using Global.Services.System.MessageBrokers.Logs;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Global.Services.System.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessageBrokerRouter.ServiceName,
        menuName = MessageBrokerRouter.ServicePath)]
    public class MessageBrokerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private MessageBrokerLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<MessageBrokerLogger>()
                .WithParameter(_logSettings);

            var messageBroker = new MessageBroker();
            var asyncMessageBroker = new AsyncMessageBroker();

            builder.Register<MessageBrokerProxy>()
                .WithParameter(messageBroker)
                .WithParameter(asyncMessageBroker)
                .AsSelfResolvable();
        }
    }
}