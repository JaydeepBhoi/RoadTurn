using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManage : MonoBehaviour
{
    #region Variables
    public Slider slider; 
    [SerializeField]
    float sliderValue;
   public bool isCallFirst = false;
    #endregion

    #region Singleton Instance
    public static LevelManage instance;
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        instance = this;
        if (slider == null)
        {
            sliderValue = slider.value;
        }
    }
    #endregion

    #region Public Methods
    public void LevelProgressSlider(float totalcars)
    {

        float sliderData = 1 / totalcars;
        slider.value += sliderData;
    }
    #endregion
}
