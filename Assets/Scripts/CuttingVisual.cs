using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingVisual : MonoBehaviour
{
    [SerializeField]
    private Image imageSlider;
    [SerializeField]
    private CuttingCounter counter;

    private void Start()
    {
        counter.onProgressBarChanged += Counter_onProgressBarChanged;
        imageSlider.fillAmount = 0;
        Hide();
    }

    private void Counter_onProgressBarChanged(object sender, CuttingCounter.OnProgressBarChangedEvent e)
    {
        imageSlider.fillAmount = e.progress;
        if (e.progress == 0f || e.progress == 1f)
        {
            Hide();
        }
        else
            Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
