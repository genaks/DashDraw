using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dash.Draw.Gameplay
{
    [CreateAssetMenu(fileName = "Palette_", menuName = "Data/Palette", order = 0)]
    public class PaletteScriptableObject : ScriptableObject
    {
        [SerializeField] private Color[] _colors;
        [SerializeField] private Texture[] _textures;

        public Color[] Colors => _colors;
        public Texture[] Textures => _textures;
    }
}
