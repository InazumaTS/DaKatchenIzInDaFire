using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private FoodSCO foodItem;
    [SerializeField]
    private Transform counterTopPrefab;
    public void interact()
    {
        Debug.Log("Interact");
        GameObject FoodGameobject = Instantiate(foodItem.prefab, counterTopPrefab);
        FoodGameobject.transform.localPosition = Vector3.zero;

        Debug.Log(FoodGameobject.GetComponent<Food>().GetFoodSco().objName);
    }
}
