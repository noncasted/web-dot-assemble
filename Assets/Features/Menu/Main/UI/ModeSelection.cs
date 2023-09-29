using System;
using Common.UI.Buttons;
using GamePlay.Loop.Modes;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Main.UI
{
    [DisallowMultipleComponent]
    public class ModeSelection : MonoBehaviour, IModeSelection
    {
        [SerializeField] private ModeButton _quads;
        [SerializeField] private ModeButton _forward;
        [SerializeField] private ModeButton _diagonal;
        [SerializeField] private ModeButton _boss;

        private ModeButton[] _buttons;

        public event Action<GameMode> Selected;
        
        public void SetMode(GameMode mode)
        {
            switch (mode)
            {
                case GameMode.Forward:
                    _forward.OnSelected();
                    break;
                case GameMode.Diagonal:
                    _diagonal.OnSelected();
                    break;
                case GameMode.Quads:
                    _quads.OnSelected();
                    break;
                case GameMode.Boss:
                    _boss.OnSelected();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }    
        }

        private void OnEnable()
        {
            _buttons = new[] { _quads, _forward, _diagonal, _boss };

            _quads.Button.Clicked += () => OnClicked(_quads, GameMode.Quads);
            _forward.Button.Clicked += () => OnClicked(_forward, GameMode.Forward);
            _diagonal.Button.Clicked += () => OnClicked(_diagonal, GameMode.Diagonal);
            _boss.Button.Clicked += () => OnClicked(_boss, GameMode.Boss);
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
                button.Button.UnsubscribeAll();
        }

        private void OnClicked(ModeButton target, GameMode mode)
        {
            foreach (var button in _buttons)
                button.OnDeselected();

            target.OnSelected();
            
            Selected?.Invoke(mode);
        }
    }

    [Serializable]
    public class ModeButton
    {
        [SerializeField] private Image _image;
        [SerializeField] private ExtendedButton _button;
        [SerializeField] private Sprite _active;
        [SerializeField] private Sprite _inactive;

        public ExtendedButton Button => _button;

        public void OnSelected()
        {
            _button.Lock();
            _image.sprite = _active;
        }

        public void OnDeselected()
        {
            _button.Unlock();
            _image.sprite = _inactive;
        }
    }
}