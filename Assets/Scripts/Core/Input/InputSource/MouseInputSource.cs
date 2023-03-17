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
        public event Action<Vector2, InputKey> OnMoveAction;
        public event Action<InputKey> OnButtonAction;
        public event Action<InputKey> OnButtonRelease;

        [Range(0, 1)]
        [SerializeField] private int _playerIndex;
		
        private InputProvider _inputProvider;
        private Vector2 _currentInput = Vector2.zero;
        private bool _modified = false;
		
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
                OnButtonAction?.Invoke(InputKey.MouseLeftKey);
        }

        public void ButtonRelease(InputAction.CallbackContext context)
        {
            if ((context.interaction is PressInteraction) && context.performed)
                OnButtonRelease?.Invoke(InputKey.MouseLeftKey);
        }
    }
}
