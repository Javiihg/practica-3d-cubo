using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texto : MonoBehaviour
{
    public Text counterText;
    private int collectibleCount = 0;

    public void IncrementCount()
    {
        collectibleCount++;
        UpdateCounter();
    }

    public void DecrementCount()
    {
        collectibleCount--;
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        counterText.text = "Coleccionables: " + collectibleCount.ToString();
    }


}
