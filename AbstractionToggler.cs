using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractionToggler : MonoBehaviour
{
    public Material highlightMat;

    public MeshRenderer patientMonitor;
    public GameObject patientMonitorDisplay;
    public MeshRenderer IVStand;
    public MeshRenderer centralMonitor;
    public GameObject centralMonitorDisplay;
    public MeshRenderer ventilator;
    public GameObject ventilatorDisplay;
    public MeshRenderer difibrulator;
    public GameObject feedingPump;
    public GameObject balloonPump;
    public GameObject balloonPumpDisplay;
    public GameObject sequentialCompressor;

    public GameObject patientMonitorAbstract;
    public GameObject IVStandAbstract;
    public GameObject centralMonitorAbstract;
    public GameObject ventilatorAbstract;
    public GameObject difibrulatorAbstract;
    public GameObject feedingPumpAbstract;
    public GameObject balloonPumpAbstract;
    public GameObject sequentialCompressorAbstract;

    private bool isAbstracted = false;
    // Start is called before the first frame update
    void Start()
    {
        highlightMat.color = new Color(1, 0, 0, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (!isAbstracted)
            {
                patientMonitor.enabled = false;
                patientMonitorDisplay.SetActive(false);
                IVStand.enabled = false;
                centralMonitor.enabled = false;
                centralMonitorDisplay.SetActive(false);
                ventilator.enabled = false;
                ventilatorDisplay.SetActive(false);
                difibrulator.enabled = false;
                feedingPump.SetActive(false);
                balloonPump.SetActive(false);
                balloonPumpDisplay.SetActive(false);
                sequentialCompressor.SetActive(false);

                patientMonitorAbstract.SetActive(true);
                IVStandAbstract.SetActive(true);
                centralMonitorAbstract.SetActive(true);
                ventilatorAbstract.SetActive(true);
                difibrulatorAbstract.SetActive(true);
                feedingPumpAbstract.SetActive(true);
                balloonPumpAbstract.SetActive(true);
                sequentialCompressorAbstract.SetActive(true);

                highlightMat.color = new Color(1, 0, 0, 0);

                isAbstracted = true;
            }
            else
            {
                patientMonitor.enabled = true;
                patientMonitorDisplay.SetActive(true);
                IVStand.enabled = true;
                centralMonitor.enabled = true;
                centralMonitorDisplay.SetActive(true);
                ventilator.enabled = true;
                ventilatorDisplay.SetActive(true);
                difibrulator.enabled = true;
                feedingPump.SetActive(true);
                balloonPump.SetActive(true);
                balloonPumpDisplay.SetActive(true);
                sequentialCompressor.SetActive(true);

                patientMonitorAbstract.SetActive(false);
                IVStandAbstract.SetActive(false);
                centralMonitorAbstract.SetActive(false);
                ventilatorAbstract.SetActive(false);
                difibrulatorAbstract.SetActive(false);
                feedingPumpAbstract.SetActive(false);
                balloonPumpAbstract.SetActive(false);
                sequentialCompressorAbstract.SetActive(false);

                highlightMat.color = new Color(1, 0, 0, 0.25f);

                isAbstracted = false;
            }
        }
    }
}
