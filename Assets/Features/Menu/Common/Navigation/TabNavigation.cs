﻿using Cysharp.Threading.Tasks;
using Menu.StateMachine.Runtime;
using UnityEngine;

namespace Features.Menu.Common.Navigation
{
    [DisallowMultipleComponent]
    public class TabNavigation : MonoBehaviour, ITabNavigation
    {
        [SerializeField] private NavigationDictionary _navigations;
        
        private IStateMachine _stateMachine;

        public void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enable()
        {
            foreach (var (button, entry) in _navigations)
                button.onClick.AddListener(() => OnClicked(entry));
        }

        public void Disable()
        {
            foreach (var (button, _) in _navigations)
                button.onClick.RemoveAllListeners();
        }

        private void OnClicked(NavigationEntry entry)
        {
            _stateMachine.Select(entry.Definition, entry.Type).Forget();
        }
    }
}