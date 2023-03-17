using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Interactions;

namespace Dash.Draw.Core
{
    [RequireComponent(typeof(InputProvider))]
    public class MouseInputSource : MonoBehaviour, IInputSource
    {
        public event Action<InputKey> OnButtonAction;
        public event Action<InputKey> OnButtonRelease;

        private InputProvider _inputProvider;
		
        public void Awake()
        {
            _inputProvider = GetComponent<InputProvider>();
            _inputProvider.AddInputSource(this);
        }
		
        public void OnDestroy()
        {
            _inputProvider.RemoveInputSource(this);
        }
        
        public void ButtonAction(InputAction.CallbackContext context)
        {
            if ((context.interaction is PressInteraction) && context.performed)
                OnButtonAction?.Invoke(GetInputKey(context.control.name));
        }

        public void ButtonRelease(InputAction.CallbackContext context)
        {
            if ((context.interaction is PressInteraction) && context.performed)
                OnButtonRelease?.Invoke(GetInputKey(context.control.name));
        }

        private InputKey GetInputKey(string inputKeyName)
        {
            InputKey inputKey = InputKey.MouseLeftKey;
            switch (inputKeyName)
            {
                case "leftButton" :
                    inputKey = InputKey.MouseLeftKey;
                    break;
                case "middleButton" :
                    inputKey = InputKey.MiddleKey;
                    break;
            }
            return inputKey;
        }
    }
}