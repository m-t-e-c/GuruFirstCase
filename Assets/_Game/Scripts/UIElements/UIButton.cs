﻿using GuruFirstCase.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GuruFirstCase.UIElements
{
    public class UIButton : Button
    {
        UIButtonAnimations _uiButtonAnimations;
        
        protected override void Awake()
        {
            base.Awake();
            _uiButtonAnimations = GetComponent<UIButtonAnimations>();
        }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable)
            {
                return;
            }
            base.OnPointerDown(eventData);
            _uiButtonAnimations?.PlayOnPointerDownAnimation();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            
            if (!interactable)
            {
                return;
            }
            base.OnPointerUp(eventData);
            _uiButtonAnimations?.PlayOnPointerUpAnimation();
        }
    }
}