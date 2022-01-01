using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using UnityEngine.UI;

public class ToggleDevicePowerDisplay : MonoBehaviour
{

    public GameObject object1;

    public UserActionTracker logger;

    public string deviceName;

    public Button powerButton;
    public Text powerButtonText;

    private Color mint;
    private ColorBlock mintBlock;
    private ColorBlock blackBlock;

    private bool isOn = true;

    private float leftTimer = 2f;
    private float rightTimer = 2f;

    private void Start()
    {
        mint = new Color(0.5607843f, 1f, 0.627451f);

        mintBlock.colorMultiplier = 1;
        mintBlock.disabledColor = mint;

        blackBlock.colorMultiplier = 1;
        blackBlock.disabledColor = Color.black;
    }

    private void FixedUpdate()
    {
        leftTimer += Time.fixedDeltaTime;
        rightTimer += Time.fixedDeltaTime;

        if (leftTimer <= 0.03f)
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
        }

        else if (leftTimer > 0.03f)
        {
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
        }

        if (rightTimer <= 0.03f)
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
        }

        else if (rightTimer > 0.03f)
        {
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
        }
    }


    private void OnTriggerEnter(Collider control)
    {
        if (isOn && (control.tag == "PlayerHandLeft" || control.tag == "PlayerHandRight") && (leftTimer >= 0.3f && rightTimer >= 0.3f))
        {
            object1.SetActive(false);
            GetComponent<AudioSource>().Play();

            powerButton.colors = blackBlock;
            powerButtonText.color = mint;

            if (control.tag == "PlayerHandLeft")
            {
                leftTimer = 0f;
            }

            else if (control.tag == "PlayerHandRight")
            {
                rightTimer = 0f;
            }

            logger.PrintAction(deviceName, "Off");

            isOn = false;
        }

        else if (!isOn && (control.tag == "PlayerHandLeft" || control.tag == "PlayerHandRight") && (leftTimer >= 0.3f && rightTimer >= 0.3f))
        {
            GetComponent<AudioSource>().Play();

            object1.SetActive(true);

            powerButton.colors = mintBlock;
            powerButtonText.color = Color.black;

            if (control.tag == "PlayerHandLeft")
            {
                leftTimer = 0f;
            }

            else if (control.tag == "PlayerHandRight")
            {
                rightTimer = 0f;
            }

            logger.PrintAction(deviceName, "On");

            isOn = true;
        }
    }

    public void DistanceActivation()
    {
        if (isOn)
        {
            object1.SetActive(false);
            GetComponent<AudioSource>().Play();
            isOn = false;
        }

        else if (!isOn)
        {
            GetComponent<AudioSource>().Play();
            object1.SetActive(true);
            isOn = true;
        }
    }
}
