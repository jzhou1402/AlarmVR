using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDeviceName : MonoBehaviour
{

    public Canvas deviceName;

    public void ShowName()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            deviceName.enabled = true;
        }
    }

    public void HideName()
    {
        deviceName.enabled = false;
    }
}
