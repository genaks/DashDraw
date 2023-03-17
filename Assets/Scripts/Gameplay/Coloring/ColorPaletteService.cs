using System;
using System.Collections;
using System.Collections.Generic;
using Dash.Draw.Core;
using UnityEngine;

namespace Dash.Draw.Gameplay
{
    public class ColorPaletteService : MonoBehaviour, IGameService
    {
        [SerializeField] private PaletteScriptableObject _paletteScriptableObject;
        [SerializeField] private PaletteItemView _paletteItemView;

        private List<PaletteItemView> _paletteItemViews = new();
        private PaletteItemView.PaletteItem _paletteItem;
        
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        private void Start()
        {
            foreach (var color in _paletteScriptableObject.Colors)
            {
                PaletteItemView paletteItemView = Instantiate(_paletteItemView, transform);
                paletteItemView.Init(_paletteItemViews.Count, color);
                paletteItemView.OnPaletteItemSelected += UpdateSelectedPaletteItem;
                _paletteItemViews.Add(paletteItemView);
            }
            foreach (var texture in _paletteScriptableObject.Textures)
            {
                if (null == texture)
                {
                    Debug.LogError("[ColorPaletteService::Start] Found a null texture in palette data. " +
                                   "Please make sure all the textures have been assigned properly in the inspector.");
                    return;
                }
                PaletteItemView paletteItemView = Instantiate(_paletteItemView, transform);
                paletteItemView.Init(_paletteItemViews.Count, Color.white, texture);
                paletteItemView.OnPaletteItemSelected += UpdateSelectedPaletteItem;
                _paletteItemViews.Add(paletteItemView);
            }
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Unregister<ColorPaletteService>();
            foreach (var paletteItemView in _paletteItemViews)
            {
                paletteItemView.OnPaletteItemSelected -= UpdateSelectedPaletteItem;
            }
        }

        private void UpdateSelectedPaletteItem(int index, PaletteItemView.PaletteItem paletteItem)
        {
            for (int i = 0; i < _paletteItemViews.Count; i++)
            {
                if (i != index)
                {
                    _paletteItemViews[i].Unselect();
                }
            }
        }
    }
}