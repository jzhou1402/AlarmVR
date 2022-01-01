using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : MonoBehaviour
{
    public float toneBlend = 0.5f;

    public float rateValue = 2.5f;

    public float attackValue = 1f;

    public float sustainValue = 1f;

    private int noteNumber = 0;

    private float timer = 0f;

    private int scaleNote1 = 79;
    private int scaleNote2 = 72;
    private int scaleNote3 = 79;
    private int scaleNote4 = 72;
    private int scaleNote5 = -1;
    private int scaleNote6 = -1;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer == 0f)
        {
            GetComponent<ChuckSubInstance>().RunCode(string.Format(@"

// patch
SqrOsc sqrOsc => LPF sqrFilter => Dyno sqrCompressor => Gain sqrGain => ADSR envelope => HPF hpfFilter => dac;
SinOsc sinOsc => Dyno sinCompressor => Gain sinGain => envelope;

// scale
[{5}, {6}, {7}, {8}, {9}, {10}] @=> int scale[];

float filterMIDI;
float filterFrequency;

{1} => float toneBlend;

2 => sqrFilter.Q;
300 => hpfFilter.freq;

{2} => float rateValue;
{3} => float attackValue;
{4} * 0.4 => float sustainValue;

0.05 * rateValue * attackValue => float durationValue;
durationValue::second => dur duration;
rateValue * sustainValue => float sustainTime;
sustainValue::second => dur sustain;

        //Set Filter freq
        scale[{0}] => Std.mtof => filterMIDI;
        filterMIDI + ((20000 - filterMIDI) * Math.pow({1}, 5)) => filterFrequency;
        filterFrequency => sqrFilter.freq;

        //Set compressor to be a compressor
        sqrCompressor.compress();
        sinCompressor.compress();

        //Turn up output volume
        toneBlend * 0.45 => sqrGain.gain;
        (1.0 - toneBlend) * 1.55 => sinGain.gain;
       

        //Set the ADSR
        envelope.set(duration, duration, 1, duration);
     

        // set freq
        scale[{0}] => Std.mtof => sqrOsc.freq;
        scale[{0}] => Std.mtof => sinOsc.freq;

        //Begin the attack
        envelope.keyOn();

        duration => now;

        // advance time
        sustain => now;

        //End the Note
        envelope.keyOff();
        duration => now;

    ", noteNumber, toneBlend, rateValue, attackValue, sustainValue, scaleNote1, scaleNote2, scaleNote3, scaleNote4, scaleNote5, scaleNote6));
        }



        timer += Time.fixedDeltaTime;
        if (sustainValue > rateValue)
        {
            sustainValue = rateValue;
        }

        if (timer >= 2 * (0.05f * rateValue * attackValue) + (rateValue * 0.4))
        {
            ++noteNumber;
            timer = 0f;
        }

        if (noteNumber == 6)
        {
            noteNumber = 0;
        }
    }

    public void SetToneBlend(float value)
    {
        toneBlend = value * 0.1f;
    }

    public void SetSustainLength(float value)
    {
        sustainValue = value;
    }

    public void SetRateValue(float value)
    {
        rateValue = value;
    }

    public void SetOnsetValue(float value)
    {
        attackValue = value;
    }

    public void SetScaleValues(float values)
    {
        if (Mathf.Floor(values) == 0)
        {
            scaleNote1 = 79;
            scaleNote2 = 79;
            scaleNote3 = 79;
            scaleNote4 = 79;
            scaleNote5 = 79;
            scaleNote6 = 79;
        }

        else if (Mathf.Floor(values) == 1)
        {
            scaleNote1 = 79;
            scaleNote2 = 79;
            scaleNote3 = 79;
            scaleNote4 = 79;
            scaleNote5 = -100;
            scaleNote6 = -100;
        }

        else if (Mathf.Floor(values) == 2)
        {
            scaleNote1 = 79;
            scaleNote2 = 72;
            scaleNote3 = 79;
            scaleNote4 = 72;
            scaleNote5 = -100;
            scaleNote6 = -100;
        }

        else if (Mathf.Floor(values) == 3)
        {
            scaleNote1 = 79;
            scaleNote2 = 72;
            scaleNote3 = 76;
            scaleNote4 = 76;
            scaleNote5 = -100;
            scaleNote6 = -100;
        }

        else if (Mathf.Floor(values) == 4)
        {
            scaleNote1 = 79;
            scaleNote2 = 72;
            scaleNote3 = 76;
            scaleNote4 = 81;
            scaleNote5 = -100;
            scaleNote6 = -100;
        }
    }
}