using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThresholdButtonBehavior : MonoBehaviour
{
    public ThresholdController thresholdController;

    public float value;

    private bool isIncrementing;

    private float holdTimer;

    private float triggerTimer;

    private float maxValue;

    private GameObject touchController;


    // Start is called before the first frame update
    void Start()
    {
        maxValue = thresholdController.GetThresholdMax();

    }

    // Update is called once per frame
    void Update()
    {
        if (isIncrementing)
        {
            holdTimer += Time.deltaTime;

            if (thresholdController.GetThresholdValue() < maxValue && holdTimer >= triggerTimer)
            {
                GetComponent<AudioSource>().Play();
  
                thresholdController.ChangeValue(value);

                holdTimer = 0f;

                if (triggerTimer > 0.01)
                {
                    touchController.GetComponent<HapticController>().VibrateController(0.2f);

                    triggerTimer *= 0.85f;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        touchController = other.gameObject;

        touchController.GetComponent<HapticController>().VibrateController(0.4f);

        GetComponent<AudioSource>().Play();

        thresholdController.ChangeValue(value);

        holdTimer = 0f;

        triggerTimer = 0.3f;

        isIncrementing = true;

    }

    private void OnTriggerExit(Collider other)
    {
        holdTimer = 0f;

        triggerTimer = 0.3f;

        isIncrementing = false;
    }
}
