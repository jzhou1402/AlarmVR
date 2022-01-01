using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TogglePowerButtonActive : MonoBehaviour
{

    public GameObject powerButton;

    public GameObject eventSystem;

    private bool leftIsActive = false;
    private bool hasEntered = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PlayerHandLeft" && !hasEntered)
        {
            powerButton.SetActive(true);

            eventSystem.SetActive(false);

            leftIsActive = true;

            hasEntered = true;
        }

        else if (other.tag == "PlayerHandRight" && !hasEntered)
        {
            powerButton.SetActive(true);

            eventSystem.SetActive(false);

            leftIsActive = false;

            hasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (leftIsActive && other.tag == "PlayerHandLeft" && hasEntered)
        {
            eventSystem.SetActive(true);

            powerButton.SetActive(false);

            hasEntered = false;
        }

        else if (!leftIsActive && other.tag == "PlayerHandRight" && hasEntered)
        {

            powerButton.SetActive(false);

            eventSystem.SetActive(true);

            hasEntered = false;
        }
    }
}
