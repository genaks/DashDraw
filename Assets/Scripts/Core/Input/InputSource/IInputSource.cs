using System;
using UnityEngine;

namespace Dash.Draw.Core
{
    public interface IInputSource
    {
        event Action<InputKey> OnButtonAction;
        event Action<InputKey> OnButtonRelease;
    }
}