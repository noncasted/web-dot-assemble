﻿using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Global.Inputs.View.Runtime;
using IngameDebugConsole;
using UnityEngine;
using VContainer;

namespace Global.Debugs.Console.Runtime
{
    [DisallowMultipleComponent]
    public class DebugConsole : MonoBehaviour, IScopeAwakeListener
    {
        [Inject]
        private void Construct(IInputView inputView)
        {
            _inputView = inputView;
        }

        [SerializeField] private DebugLogManager _console;
        [SerializeField] private GameObject _body;

        private IInputView _inputView;

        private void OnDestroy()
        {
            _inputView.DebugConsolePreformed -= OnDebugConsolePerformed;
        }

        public void OnAwake()
        {
            _inputView.DebugConsolePreformed += OnDebugConsolePerformed;
        }

        private void OnDebugConsolePerformed()
        {
            if (_console.gameObject.activeSelf == true)
                Disable();
            else
                Enable();
        }

        private void Disable()
        {
            _console.HideLogWindow();
            _body.SetActive(false);
        }

        private void Enable()
        {
            _body.SetActive(true);
            _console.ShowLogWindow();
        }
    }
}