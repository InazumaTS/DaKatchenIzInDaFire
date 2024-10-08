using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField]
    private ContainerCounter containerCounter;
    private Animator animator;
    const string OPEN_CLOSE = "OpenClose";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnPlayerGrabbed += ContainerCounter_OnPlayerGrabbed;
    }

    private void ContainerCounter_OnPlayerGrabbed(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
