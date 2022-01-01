using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAlarmToggle : MonoBehaviour
{
    public GameObject otherAlarms;

    public GameObject toggleLight;

    private bool alarmsOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHandRight" || other.tag == "PlayerHandLeft")
        {
            if (alarmsOn)
            {
                otherAlarms.SetActive(false);
                toggleLight.SetActive(false);

                alarmsOn = false;
            }

            else if (!alarmsOn)
            {
                otherAlarms.SetActive(true);
                toggleLight.SetActive(true);

                alarmsOn = true;
            }
        }
    }
}
