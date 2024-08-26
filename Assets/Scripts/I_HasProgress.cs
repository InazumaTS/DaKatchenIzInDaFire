using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_HasProgress 
{
    public event EventHandler<OnProgressBarChangedEvent> onProgressBarChanged;
    public class OnProgressBarChangedEvent : EventArgs
    {
        public float progress;
    }
}
