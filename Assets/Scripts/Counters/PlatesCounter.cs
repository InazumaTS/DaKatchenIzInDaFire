using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    
    
    
    [SerializeField]
    private FoodSCO plateKitchenObject;
    [SerializeField]
    private float spawnTimerMax =4f;
    private float spawnPlateTimer;
    private int platesSpawnedAmount;
    [SerializeField]
    private int platesSpawnedMax =4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer>spawnTimerMax && platesSpawnedAmount<platesSpawnedMax)
        {
            spawnPlateTimer = 0;
            platesSpawnedAmount++;

            OnPlateSpawned?.Invoke(this, EventArgs.Empty);
        }
    }

    public override void interact(PlayerMovement player)
    {
        if(!player.HasFoodObject())
        {
            if(platesSpawnedAmount!=0)
            {
                platesSpawnedAmount--;
                Food.SpawnFoodItem(plateKitchenObject, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
