using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VROnsetSlider : MonoBehaviour
{
    public Slider uiSlider;

    public SawControl soundSource;

    public Rigidbody parent;

    public float valueMin;

    public float valueMax;

    public AnimationCurve curve;

    private ConfigurableJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();

        curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;

        valueMax = soundSource.rateValue * 2;

        uiSlider.maxValue = valueMax;
    }

    // Update is called once per frame
    void Update()
    {
        valueMax = soundSource.rateValue * 2;

        if (transform.localPosition.z > 0.085f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.085f);
        }

        else if (transform.localPosition.z < -0.085f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.085f);

        }

        uiSlider.maxValue = valueMax;

        uiSlider.value = Mathf.Lerp(valueMin, valueMax, ((transform.localPosition.z + 0.085f) * 5.8823f));

        soundSource.SetOnsetValue(InterpolateOverCurve(curve, valueMin, valueMax, ((transform.localPosition.z + 0.085f) * 5.8823f)));

    }


    private void FingerOnTriggerEnter(Collider other)
    {
        joint.autoConfigureConnectedAnchor = false;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, other.transform.InverseTransformPoint(other.transform.position).z);

        joint.connectedBody = other.GetComponent<Rigidbody>();

        joint.connectedAnchor = Vector3.zero;

        joint.targetPosition = other.transform.position;

        other.GetComponent<HapticController>().VibrateController(0.4f);

        GetComponent<AudioSource>().pitch = 1.2f;

        GetComponent<AudioSource>().Play();
    }

    private void FingerOnTriggerExit(Collider other)
    {
        joint.autoConfigureConnectedAnchor = true;

        joint.connectedBody = parent;

        other.GetComponent<HapticController>().VibrateController(0.1f);

        GetComponent<AudioSource>().pitch = 1f;

        GetComponent<AudioSource>().Play();
    }

    private static float InterpolateOverCurve(AnimationCurve curve, float from, float to, float t)
    {
        return from + curve.Evaluate(t) * (to - from);
    }
}