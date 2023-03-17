using System;
using System.Collections;
using System.Collections.Generic;
using Dash.Draw.Core;
using UnityEngine;

namespace Dash.Draw.Gameplay
{
    public class Inspectable : MonoBehaviour
    {
        private InputProvider _inputProvider;

        private bool _dragEnabled;
        private float _initialMousePositionX;
        private float _initialRotationY;
        
        private void Start()
        {
            if (ServiceLocator.Instance.TryGet(out InputProvider inputProvider))
            {
                _inputProvider = inputProvider;
                _inputProvider.OnButtonAction += OnButtonAction;
                _inputProvider.OnButtonRelease += OnButtonRelease;
            }
            else
            {
                Debug.LogError("[Inspectable::Start] Couldn't retrieve the input provider");
            }
        }

        private void OnDestroy()
        {
            if (null != _inputProvider)
            {
                _inputProvider.OnButtonAction -= OnButtonAction;
                _inputProvider.OnButtonRelease -= OnButtonRelease;
            }   
        }

        private void Update()
        {
            if (_dragEnabled)
            {
                HandleRotation();
            }
        }

        private void OnButtonAction(InputKey inputKey)
        {
            if (inputKey == InputKey.MiddleKey)
            {
                EnableDrag();
            }
        }

        private void OnButtonRelease(InputKey inputKey)
        {
            if (inputKey == InputKey.MiddleKey)
            {
                _dragEnabled = false;
            }
        }
        
        private void HandleRotation()
        {
            var currentMouseX = Input.mousePosition.x;
            var mouseXDiff = currentMouseX - _initialMousePositionX;
			
            if (Math.Abs(mouseXDiff) < 1)
                return;

            var rotationChange = mouseXDiff;

            var rotation = transform.rotation;
            rotation = Quaternion.Euler(rotation.x, _initialRotationY - rotationChange, rotation.z);
            transform.rotation = rotation;
        }

        private void EnableDrag()
        {
            _initialMousePositionX = Input.mousePosition.x;
            _initialRotationY = transform.rotation.eulerAngles.y;
            _dragEnabled = true;
        }
    }
}