using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dash.Draw.Gameplay
{
    public class ColoringComponent : MonoBehaviour
    {
        private Material _material;
        private static readonly int Color1 = Shader.PropertyToID("_Color");
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        public void Paint(PaletteItemView.PaletteItem paletteItem)
        {
            _material = GetComponent<Renderer>().material;
            _material.SetColor(Color1, paletteItem.Color);
            if (null != paletteItem.Texture)
            {
                _material.SetTexture(MainTex, paletteItem.Texture);
            }
            else
            {
                _material.SetTexture(MainTex, null);
            }
        }
    }
}
