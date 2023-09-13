using System.Threading;
using Common.Architecture.Local.Abstract.Callbacks;
using Menu.Achievements.Global;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Achievements.UI
{
    public class AchievementsController : IAchievementsController, ITab, ILocalAwakeListener
    {
        public AchievementsController(IAchievementsView view, IAchievements achievements)
        {
            _view = view;
            _achievements = achievements;
        }

        private readonly IAchievementsView _view;
        private readonly IAchievements _achievements;

        private CancellationTokenSource _cancellation; 

        public RectTransform Transform => _view.Transform;
        
        public void OnAwake()
        {
            _view.Construct(_achievements.GetAll());   
        }
        
        public void Activate()
        {
            _view.Navigation.Enable();
            _view.Enable();
            _view.Open();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            _view.Disable();
        }
    }
}