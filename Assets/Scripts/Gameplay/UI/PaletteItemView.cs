using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dash.Draw.Gameplay
{
    public class PaletteItemView : MonoBehaviour
    {
        public struct PaletteItem {
            private Color _color;
            private Texture _texture;

            public PaletteItem(Color color, Texture texture = null)
            {
                _color = color;
                _texture = texture;
            }
        }
        
        [SerializeField] private Image _colorImage;
        [SerializeField] private Image _textureImage;

        private PaletteItem _paletteItem;
        
        public static event Action<PaletteItem> OnPaletteItemSelected;

        public void Select()
        {
            OnPaletteItemSelected?.Invoke(_paletteItem);
        }

        public void Unselect()
        {
            
        }

        public void Init(Color color, Texture texture = null)
        {
            _paletteItem = new PaletteItem(color, texture);
        }
    }
}
