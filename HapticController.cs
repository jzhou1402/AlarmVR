using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticController : MonoBehaviour
{

    public bool isRightHand;

    private bool isVibrating = false;

    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isVibrating)
        {
            timer += Time.deltaTime;

            if (timer >= 0.15f)
            {
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);


                isVibrating = false;
            }
        }
    }

    public void VibrateController(float strength)
    {
        timer = 0f;

        if (isRightHand)
        {
            OVRInput.SetControllerVibration(0.1f, strength, OVRInput.Controller.RTouch);
        }

        else
        {
            OVRInput.SetControllerVibration(0.1f, strength, OVRInput.Controller.LTouch);
        }

        isVibrating = true;
    }
}
