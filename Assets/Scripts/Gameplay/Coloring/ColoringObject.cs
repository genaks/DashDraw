using System.Collections;
using System.Collections.Generic;
using Dash.Draw.Core;
using UnityEngine;

namespace Dash.Draw.Gameplay
{
    public class ColoringObject : MonoBehaviour
    {
        private InputProvider _inputProvider;
        private ColorPaletteService _colorPaletteService;
        
        private void Start()
        {
            if (ServiceLocator.Instance.TryGet(out InputProvider inputProvider))
            {
                _inputProvider = inputProvider;
                _inputProvider.OnButtonAction += OnButtonAction;
            }
            else
            {
                Debug.LogError("[ColorComponent::Start] Couldn't retrieve the input provider");
            }

            if (ServiceLocator.Instance.TryGet(out ColorPaletteService colorPaletteService))
            {
                _colorPaletteService = colorPaletteService;
            }
            else
            {
                Debug.LogError("[ColorComponent::Start] Couldn't retrieve the color palette service");
            }

            foreach (Transform child in transform)
            {
                if (!child.gameObject.TryGetComponent(out ColoringComponent _))
                {
                    child.gameObject.AddComponent<ColoringComponent>();
                }
            }
        }
        
        private void OnDestroy()
        {
            if (null != _inputProvider)
            {
                _inputProvider.OnButtonAction -= OnButtonAction;
            }   
        }
        
        private void OnButtonAction(InputKey inputKey)
        {
            if (inputKey == InputKey.MouseLeftKey)
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var raycastHit, 100f))
                    {
                        if (raycastHit.collider.gameObject.TryGetComponent(out ColoringComponent coloringComponent))
                        {
                            coloringComponent.Paint(_colorPaletteService.PaletteItem);
                        }
                    }
                }
            }
        }
    }
}