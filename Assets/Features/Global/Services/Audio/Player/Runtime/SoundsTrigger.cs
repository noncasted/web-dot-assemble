﻿using System;
using Common.UI.UiTools.ButtonEventTriggers;
using Global.Services.Setup.Service.Callbacks;
using Global.Services.System.MessageBrokers.Runtime;
using UnityEngine;

namespace Global.Services.Audio.Player.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsTrigger : MonoBehaviour, IGlobalAwakeListener
    {
        [SerializeField] private AudioClip _buttonTouched;
        [SerializeField] private AudioClip _buttonClicked;

        [SerializeField] private AudioClip _ambient;

        [SerializeField] private SoundsPlayer _player;

        private IDisposable _buttonClickListener;

        private IDisposable _buttonTouchListener;
        private IDisposable _correctAnswerListener;
        private IDisposable _finalEnterListener;
        private IDisposable _newQuestionListener;

        private void OnDestroy()
        {
            _buttonTouchListener?.Dispose();
            _buttonClickListener?.Dispose();
            _newQuestionListener?.Dispose();
            _correctAnswerListener?.Dispose();
            _finalEnterListener?.Dispose();
        }

        public void OnAwake()
        {
            _player.PlayLoopMusic(_ambient);

            _buttonTouchListener = Msg.Listen<ButtonTouchEvent>(OnButtonTouched);
            _buttonClickListener = Msg.Listen<ButtonClickEvent>(OnButtonClicked);
        }

        private void OnButtonTouched(ButtonTouchEvent data)
        {
            _player.PlaySound(_buttonTouched);
        }

        private void OnButtonClicked(ButtonClickEvent data)
        {
            _player.PlaySound(_buttonClicked);
        }
    }
}