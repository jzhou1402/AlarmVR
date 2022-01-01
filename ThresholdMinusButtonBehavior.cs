using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdMinusButtonBehavior : MonoBehaviour
{
    public ThresholdController thresholdController;

    public float value;

    private bool isIncrementing;

    private float holdTimer;

    private float triggerTimer;

    private float minValue;

    private GameObject touchController;

    // Start is called before the first frame update
    void Start()
    {
        minValue = thresholdController.GetThresholdMin();

    }

    // Update is called once per frame
    void Update()
    {
        if (isIncrementing)
        {
            holdTimer += Time.deltaTime;

            if (thresholdController.GetThresholdValue() > minValue && holdTimer >= triggerTimer)
            {
                GetComponent<AudioSource>().Play();

                thresholdController.ChangeValue(value);

                holdTimer = 0f;

                if (triggerTimer > 0.01)
                {
                    touchController.GetComponent<HapticController>().VibrateController(0.4f);

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

