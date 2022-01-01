using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            RaycastHit hit;
            Ray raydirection = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(raydirection, out hit))
            {
                if (hit.collider.tag == "Device")
                {
                    hit.collider.gameObject.GetComponent<DisplayDeviceName>().ShowName();
                }

            }
            Debug.DrawRay(transform.position, transform.forward, Color.black, 1);
        }
    }
    }

