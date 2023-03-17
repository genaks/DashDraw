using System;
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

        private void Start()
        {
            if (!TryGetComponent(out Collider _))
            {
                gameObject.AddComponent<BoxCollider>();
            }
        }

        public void Paint(PaletteItemView.PaletteItem paletteItem)
        {
            _material = GetComponent<Renderer>().material;
            _material.SetColor(Color1, paletteItem.Color);
            _material.SetTexture(MainTex, null != paletteItem.Texture ? paletteItem.Texture : null);
        }
    }
}
