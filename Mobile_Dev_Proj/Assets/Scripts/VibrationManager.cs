using CandyCoded.HapticFeedback;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationManager : ScriptableObject
{
    public void Light()
    {
        HapticFeedback.LightFeedback();
        Debug.Log("Light");
    }

    public void Medium()
    {
        HapticFeedback.MediumFeedback();
        Debug.Log("Medium");
    }

    public void Heavy()
    {
        HapticFeedback.HeavyFeedback();
        Debug.Log("Heavy");
    }
}
