using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject dots;
    public GameObject flashLight;
    public void ShowDots(bool isShowDots)
    {
        if(dots != null)
        {
            dots.SetActive(isShowDots);
        }
    }
    public void ShowFlashLight(bool isShowFL)
    {
        if(flashLight != null)
        {
            flashLight.SetActive(isShowFL);
        }
    }

}
