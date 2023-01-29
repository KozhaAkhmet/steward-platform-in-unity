using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] public Actuator[] actuators;

    [Header("UI")]
    public Slider[] sliders;
    public TMP_Text[] texts;

    private void Start()
    {
        // Defining slider values
        sliders[0].minValue = -1;   sliders[0].maxValue = 1;
        sliders[1].minValue = 0;    sliders[1].maxValue = 5;
        sliders[2].minValue = -1;   sliders[2].maxValue = 1;
        sliders[3].minValue = -100; sliders[3].maxValue = 100;
        sliders[4].minValue = -100; sliders[4].maxValue = 100;
        sliders[5].minValue = -100; sliders[5].maxValue = 100;

        for (int i = 0; i< sliders.Length; i++) { sliders[i].value = 0; }

        // Positioning platform to middle
        sliders[1].value = 2.22f;
    }

    public void UpdateValues()
    {
        for (int i = 0; i < 6; i++)
        {
            actuators[i].translation = new Vector3(sliders[0].value,
                                                    sliders[1].value,
                                                    sliders[2].value);
            actuators[i].Yaw = sliders[3].value;
            actuators[i].Pitch = sliders[4].value;
            actuators[i].Roll = sliders[5].value;

            texts[i].text = sliders[i].value.ToString();
        }
        
    }
}

