using Common.UI.UniversalPlates.Buttons;
using Global.Services.System.MessageBrokers.Runtime;
using TMPro;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{       
    [DisallowMultipleComponent]
    public class PlayBody : MonoBehaviour
    {   
        [SerializeField] private UniversalButton _createButton;
        [SerializeField] private UniversalButton _joinButton;
        [SerializeField] private UniversalButton _backButton;
        [SerializeField] private TMP_Text _errorMessage;

        [SerializeField] private GameObject _body;
        [SerializeField] private MenuView _previous;

        [SerializeField] private JoinBody _join;
        
        private void OnEnable()
        {
            _createButton.Clicked += OnCreateClicked;
            _joinButton.Clicked += OnJoinClicked;
            _backButton.Clicked += OnBackClicked;
        }
        
        private void OnDisable()
        {
            _createButton.Clicked -= OnCreateClicked;
            _joinButton.Clicked -= OnJoinClicked;
            _backButton.Clicked -= OnBackClicked;
        }
        
        public void Transit()
        {
            _body.SetActive(true);
        }

        public void Close()
        {
            _body.SetActive(false);
        }
        
        private void OnCreateClicked()
        {
            var request = new CreateRequestEvent(OnError);

            Msg.Publish(request);
        }
        
        private void OnJoinClicked()
        {
            _body.SetActive(false);
            _join.Transit();
        }
        
        private void OnBackClicked()
        {
            _body.SetActive(false);
            _previous.Open();
        }
        
        private void OnError(string errorMessage)
        {
            _errorMessage.gameObject.SetActive(true);
            _errorMessage.text = errorMessage;
        }
    }   
}       