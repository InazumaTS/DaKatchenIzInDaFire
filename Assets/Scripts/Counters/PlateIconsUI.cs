using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField]
    private PlateKitchenObject platekitchenObject;
    [SerializeField]
    private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        platekitchenObject.OnIngredientsAdded += PlatekitchenObject_OnIngredientsAdded;
    }

    private void PlatekitchenObject_OnIngredientsAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach (FoodSCO foodSco in platekitchenObject.GetKitchenObjectSO())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetFoodSCO(foodSco);
        }
    }
}
