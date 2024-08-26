using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    // Start is called before the first frame update
    public override void interact(PlayerMovement player)
    {
        if(player.HasFoodObject())
        {
            player.GetFoodIteam().DestroyMeself();
        }
    }
}
