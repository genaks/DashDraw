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
        
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        private void Start()
        {
            foreach (var color in _paletteScriptableObject.Colors)
            {
                PaletteItemView paletteItemView = Instantiate(_paletteItemView, transform);
                paletteItemView.Init(color);
            }
            foreach (var texture in _paletteScriptableObject.Textures)
            {
                PaletteItemView paletteItemView = Instantiate(_paletteItemView, transform);
                paletteItemView.Init(Color.white, texture);
            }
        }
    }
}