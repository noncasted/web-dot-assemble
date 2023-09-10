﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Calendar.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Calendar.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CalendarRoutes.ControllerName,
        menuName = CalendarRoutes.ControllerPath)]
    public class CalendarUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<CalendarController>()
                .As<ICalendarController>()
                .AsTab<CalendarController>(_tabDefinition);
        }
    }
}