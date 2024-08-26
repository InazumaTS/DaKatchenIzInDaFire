using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, I_HasProgress
{
    public event EventHandler<I_HasProgress.OnProgressBarChangedEvent> onProgressBarChanged;

    public event EventHandler OnCutAnimation;
    
    [SerializeField]
    private CuttingSCO[] cuttingRecipeSCOArray;

    private int cuttingCount;
    public override void interact(PlayerMovement player)
    {
        if(!HasFoodObject())
        {
            if (player.HasFoodObject())
            {
                if (HasRecipeInput(player.GetFoodIteam().GetFoodSco()))
                {
                    player.GetFoodIteam().SetFoodParent(this);
                    cuttingCount = 0;
                    onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                    {
                        progress = (float)cuttingCount / GetCuttingSCOwithInput(GetFoodIteam().GetFoodSco()).cutMaxim
                    });
                }
            }
            else
            {

            }
        }
        else
        {
            if (player.HasFoodObject())
            {
                if (player.GetFoodIteam().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetFoodIteam().GetFoodSco()))
                        GetFoodIteam().DestroyMeself();
                }
            }
            else
            {
                GetFoodIteam().SetFoodParent(player);
            }
        }
    }

    public override void interactAlt(PlayerMovement player)
    {

        if(HasFoodObject() && HasRecipeInput(GetFoodIteam().GetFoodSco()))
        {
            cuttingCount++;
            OnCutAnimation?.Invoke(this, EventArgs.Empty);
            onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
            {
                progress = (float)cuttingCount / GetCuttingSCOwithInput(GetFoodIteam().GetFoodSco()).cutMaxim
            });

            CuttingSCO cuttingSco = GetCuttingSCOwithInput(GetFoodIteam().GetFoodSco());
            if (cuttingCount >= cuttingSco.cutMaxim)
            {
                FoodSCO OutputFood = GetOutputForInput(GetFoodIteam().GetFoodSco());
                GetFoodIteam().DestroyMeself();
                Food.SpawnFoodItem(OutputFood, this);
            }
        }
    }

    private bool HasRecipeInput(FoodSCO inputFoodSCO)
    {
        CuttingSCO cuttingSco = GetCuttingSCOwithInput(inputFoodSCO);
        return cuttingSco != null;
    }
    private FoodSCO GetOutputForInput(FoodSCO inputFood)
    {
        CuttingSCO cuttingSco = GetCuttingSCOwithInput(inputFood);
        if (cuttingSco != null)
            return cuttingSco.output;
        else
            return null;
    }

    private CuttingSCO GetCuttingSCOwithInput(FoodSCO inputfoodsco)
    {
        foreach (CuttingSCO cuttingSCO in cuttingRecipeSCOArray)
        {
            if (cuttingSCO.input == inputfoodsco)
                return cuttingSCO;
        }
        return null;
    }
}
