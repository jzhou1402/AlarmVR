using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ThresholdController : MonoBehaviour
{
    public float initialThreshold = 50f;

    public float thresholdMaximum = 100f;

    public float thresholdMinimum = 0f;

    public Text thresholdUnitText;

    private string textString;

    private float thresholdValue;

    // Start is called before the first frame update
    void Start()
    {
        ChangeValue(initialThreshold);
    }


    public void ChangeValue(float addValue)
    {
        if (thresholdValue + addValue <= thresholdMaximum && thresholdValue + addValue >= thresholdMinimum)
        {
            thresholdValue += addValue;

            textString = thresholdValue + " U";
            thresholdUnitText.text = textString;
        }
    }

    public float GetInitialValue()
    {

        return initialThreshold;
    }

    public float GetThresholdMax()
    {
        return thresholdMaximum;
    }

    public float GetThresholdMin()
    {
        return thresholdMinimum;
    }

    public float GetThresholdValue()
    {
        return thresholdValue;
    }
}
