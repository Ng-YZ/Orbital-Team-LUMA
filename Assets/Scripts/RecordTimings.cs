using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordTimings : MonoBehaviour
{
    public TextMeshProUGUI L1_text, L2_text, L3_text, L4_text;
    float L1time, L2time, L3time, L4time;
    // Start is called before the first frame update
    void Start()
    {
    //     PlayerPrefs.DeleteKey("Timing L4");
    //     PlayerPrefs.DeleteKey("Timing L2");
    //     PlayerPrefs.DeleteKey("Timing L3");
    //     PlayerPrefs.DeleteKey("Timing L1");
        L1time = PlayerPrefs.GetFloat("Timing L1");
        L2time = PlayerPrefs.GetFloat("Timing L2");
        L3time = PlayerPrefs.GetFloat("Timing L3");
        L4time = PlayerPrefs.GetFloat("Timing L4");

        L1_text.text = L1time.ToString();
        L2_text.text = L2time.ToString();
        L3_text.text = L3time.ToString();
        L4_text.text = L4time.ToString();
    }
}
