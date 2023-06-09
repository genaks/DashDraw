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
            public Color Color;
            public Texture2D Texture;

            public PaletteItem(Color color, Texture2D texture = null)
            {
                Color = color;
                Texture = texture;
            }
        }
        
        [SerializeField] private Image _colorImage;
        [SerializeField] private Image _textureImage;
        [SerializeField] private Image _selectionImage;

        private PaletteItem _paletteItem;
        private int _index;
        
        public event Action<int, PaletteItem> OnPaletteItemSelected;

        public void Select()
        {
            _selectionImage.enabled = true;
            OnPaletteItemSelected?.Invoke(_index, _paletteItem);
        }

        public void Unselect()
        {
            _selectionImage.enabled = false;
        }

        public void Init(int index, Color color, Texture2D texture = null)
        {
            _index = index;
            _paletteItem = new PaletteItem(color, texture);
            SetItem(_paletteItem);
        }

        private void SetItem(PaletteItem paletteItem)
        {
            _colorImage.color = paletteItem.Color;
            if (null != paletteItem.Texture)
            {
                Rect rect = new Rect(0, 0, paletteItem.Texture.width, paletteItem.Texture.height);
                _textureImage.sprite = Sprite.Create(paletteItem.Texture, rect, new Vector2(0.5f,0.5f),1);
            }
            else
            {
                _textureImage.enabled = false;
            }
        }
    }
}
