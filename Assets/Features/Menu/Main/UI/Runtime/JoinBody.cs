using Common.UI.UniversalPlates.Buttons;
using Global.Services.System.MessageBrokers.Runtime;
using TMPro;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [DisallowMultipleComponent]
    public class JoinBody : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private UniversalButton _joinButton;
        [SerializeField] private UniversalButton _backButton;
        [SerializeField] private TMP_InputField _input;
        [SerializeField] private TMP_Text _errorMessage;
        [SerializeField] private PlayBody _previous;

        private void OnEnable()
        {
            _joinButton.Clicked += OnJoinClicked;
            _backButton.Clicked += OnBackClicked;
        }
        
        private void OnDisable()
        {
            _joinButton.Clicked += OnJoinClicked;
            _backButton.Clicked += OnBackClicked;
        }

        public void Transit()
        {
            _body.SetActive(true);
        }

        public void Close()
        {
            _body.SetActive(false);
        }
        
        private void OnJoinClicked()
        {
            _errorMessage.gameObject.SetActive(false);

            var request = new JoinRequestEvent(_input.text, OnError);
            Msg.Publish(request);
        }

        private void OnBackClicked()
        {
            _body.SetActive(false);
            _previous.Transit();
        }

        private void OnError(string errorMessage)
        {
            _errorMessage.gameObject.SetActive(true);
            _errorMessage.text = errorMessage;
        }
    }
}