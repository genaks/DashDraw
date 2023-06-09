using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dash.Draw.Core
{
    [DefaultExecutionOrder(-10000)]
    public class InputProvider : MonoBehaviour, IGameService
    {
        public event Action<InputKey> OnButtonAction;
        public event Action<InputKey> OnButtonRelease;

        private readonly List<IInputSource> _inputSources = new();
        
        
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        private void OnDestroy()
        {
            foreach (IInputSource inputSource in _inputSources)
            {
                inputSource.OnButtonAction -= RaiseButtonAction;
                inputSource.OnButtonRelease -= RaiseButtonRelease;
            }

            ServiceLocator.Instance.Unregister<InputProvider>();
        }

        public void AddInputSource(IInputSource inputSource)
        {
            if (!_inputSources.Contains(inputSource))
            {
                _inputSources.Add(inputSource);
                inputSource.OnButtonAction += RaiseButtonAction;
                inputSource.OnButtonRelease += RaiseButtonRelease;
            }
        }

        public void RemoveInputSource(IInputSource inputSource)
        {
            if (_inputSources.Contains(inputSource))
            {
                _inputSources.Remove(inputSource);
                inputSource.OnButtonAction -= RaiseButtonAction;
                inputSource.OnButtonRelease -= RaiseButtonRelease;
            }
        }

        public T GetInputSource<T>() where T : IInputSource
        {
            foreach (IInputSource source in _inputSources)
            {
                if (source is T inputSource)
                {
                    return inputSource;
                }
            }

            return default;
        }

        private void RaiseButtonAction(InputKey inputKey)
        {
            if (!enabled)
                return;
            
            OnButtonAction?.Invoke(inputKey);
        }

        private void RaiseButtonRelease(InputKey inputKey)
        {
            if (!enabled)
                return;
            
            OnButtonRelease?.Invoke(inputKey);
        }
    }
}