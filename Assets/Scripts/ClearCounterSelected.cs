using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounterSelected : MonoBehaviour
{
    [SerializeField]
    ClearCounter clearCounter;
    [SerializeField]
    GameObject counterVisual;
    private void Start()
    {
        PlayerMovement.Instance.onSelectedCounterChanged += Player_onSelectedCounterChanged;
    }

    private void Player_onSelectedCounterChanged(object sender, PlayerMovement.OnSelectedCounterEventArgs e)
    {
        if(e.SelectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        counterVisual.SetActive(true);
    }
    private void Hide()
    {
        counterVisual.SetActive(false);
    }
}
