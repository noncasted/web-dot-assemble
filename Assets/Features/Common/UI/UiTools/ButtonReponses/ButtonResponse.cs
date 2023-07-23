﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.UiTools.ButtonReponses
{
    [DisallowMultipleComponent]
    public class ButtonResponse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ButtonResponseConfig _config;
        [SerializeField] private Transform _target;

        private bool _isLocked;

        private void OnEnable()
        {
            _target.localScale = Vector3.one;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_target.DOScale(_config.OverSize, _config.SwitchTime));
            sequence.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_target.DOScale(1f, _config.SwitchTime));
            sequence.Play();
        }
    }
}