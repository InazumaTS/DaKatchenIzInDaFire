using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter , I_HasProgress
{
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

    public event EventHandler<I_HasProgress.OnProgressBarChangedEvent> onProgressBarChanged;

    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    [SerializeField]
    private FrySCO[] pattySCOArray;

    private FrySCO fryingSCO;
    private float fryTimer;
    private float burnTimer;
    public enum State
    {
        Idle,
        Cooking,
        Cooked,
        Burnt
    }
    private State currentState;

    private void Start()
    {
        currentState = State.Idle;
    }

    private void Update()
    {
        
        if(HasFoodObject())
        {
            switch (currentState)
            {
                case State.Idle:
                    break;
                case State.Cooking:
                    fryTimer += Time.deltaTime;
                    onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                    {
                        progress = fryTimer / fryingSCO.fryingTimerMax
                    });
                    if (fryTimer > fryingSCO.fryingTimerMax)
                    {
                        fryTimer = 0;
                        GetFoodIteam().DestroyMeself();
                        Food.SpawnFoodItem(fryingSCO.output, this);
                        currentState = State.Cooked;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = currentState
                        });
                        fryingSCO = GetFryingSCOwithInput(GetFoodIteam().GetFoodSco());
                        burnTimer = 0;
                    }
                    break;
                case State.Cooked:
                    burnTimer += Time.deltaTime;
                    onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                    {
                        progress = burnTimer / fryingSCO.fryingTimerMax
                    });
                    if (burnTimer > fryingSCO.fryingTimerMax)
                    {
                        burnTimer = 0;

                        GetFoodIteam().DestroyMeself();
                        Food.SpawnFoodItem(fryingSCO.output, this);
                        currentState = State.Burnt;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = currentState
                        });
                        onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                        {
                            progress = 0f
                        });
                    }
                    break;
                case State.Burnt:
                    break;
            }
        }
    }

    public override void interact(PlayerMovement player)
    {
        if (!HasFoodObject())
        {
            if (player.HasFoodObject())
            {
                if (HasRecipeInput(player.GetFoodIteam().GetFoodSco()))
                {
                    player.GetFoodIteam().SetFoodParent(this);
                    
                    fryingSCO = GetFryingSCOwithInput(GetFoodIteam().GetFoodSco());
                    currentState = State.Cooking;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = currentState
                    });
                    fryTimer = 0f;
                    onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                    {
                        progress = fryTimer / fryingSCO.fryingTimerMax
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

                    currentState = State.Idle;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = currentState
                    });
                    onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                    {
                        progress = 0f
                    });
                }
            }
            else
            {
                GetFoodIteam().SetFoodParent(player);
                currentState = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = currentState
                });
                onProgressBarChanged?.Invoke(this, new I_HasProgress.OnProgressBarChangedEvent
                {
                    progress = 0f
                });
            }
        }
    }
    private bool HasRecipeInput(FoodSCO inputFoodSCO)
    {
        FrySCO frySco = GetFryingSCOwithInput(inputFoodSCO);
        return frySco != null;
    }
    private FoodSCO GetOutputForInput(FoodSCO inputFood)
    {
        FrySCO frySco = GetFryingSCOwithInput(inputFood);
        if (frySco != null)
            return frySco.output;
        else
            return null;
    }

    private FrySCO GetFryingSCOwithInput(FoodSCO inputfoodsco)
    {
        foreach (FrySCO frySCO in pattySCOArray)
        {
            if (frySCO.input == inputfoodsco)
            {
                
                return frySCO;
            }
        }
        return null;
    }
}
