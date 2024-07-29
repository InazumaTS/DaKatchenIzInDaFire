using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Animate;
    const string IsWalking = "IsWalking";
    [SerializeField]
    private PlayerMovement Player;
    void Awake()
    {
        Animate = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Animate.SetBool(IsWalking, Player.isWalking());
    }
}
