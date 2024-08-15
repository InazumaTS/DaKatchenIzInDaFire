using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingSCO : ScriptableObject
{
    public FoodSCO input;
    public FoodSCO output;
    public int cutMaxim;
}
