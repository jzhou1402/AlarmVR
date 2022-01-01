using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVisualizer : MonoBehaviour
{
    public Material originalDotMat;

    public AudioSource soundSource;

    public float scalar;

    private Material thisDotMat;

    private float RmsValue;

    private const int QSamples = 4096;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float _fSample;

    // Start is called before the first frame update
    void Start()
    {
        thisDotMat = new Material(originalDotMat);

        GetComponent<MeshRenderer>().material = thisDotMat;

        _samples = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
    }

    // Update is called once per frame
    void Update()
    {
        AnalyzeSound();

        thisDotMat.color = new Color(1f, 0f, 0f, RmsValue * scalar);
    }

    private void AnalyzeSound()
    {
        soundSource.GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
    }
}
