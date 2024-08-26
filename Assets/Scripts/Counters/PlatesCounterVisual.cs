using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField]
    private PlatesCounter platesCounter;
    [SerializeField]
    private Transform counterTopPoint;
    [SerializeField]
    private GameObject plateVisual;

    private List<GameObject> plateVisualList;

    private void Awake()
    {
        plateVisualList = new List<GameObject>();
    }

    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = plateVisualList[plateVisualList.Count - 1];
        plateVisualList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
       Transform plateVisualTransform = Instantiate(plateVisual.transform, counterTopPoint);

        float plateOffsetY = .1f;

        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualList.Count, 0);

        plateVisualList.Add(plateVisualTransform.gameObject);
    }
}
