using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField]
    private CuttingCounter cuttingCounter;
    private Animator animator;
    const string CUT = "Cut";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCutAnimation += CuttingCounter_OnCutAnimation;
    }

    private void CuttingCounter_OnCutAnimation(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
