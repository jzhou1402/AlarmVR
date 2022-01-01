using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class UserActionTracker : MonoBehaviour
{
    public string fileNameCustom;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        /* TextAsset logFile = new TextAsset();

        AssetDatabase.CreateAsset(logFile, "Assets/LogFiles/logFile" + fileNameCustom + ".txt");
        */

        string path = Application.persistentDataPath;

        File.CreateText(path + "/" + fileNameCustom + ".txt");


    }


    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }

    public void PrintAction(string deviceName, string action)
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + fileNameCustom
            + ".txt", true);


        

        writer.WriteLine(deviceName + ", " + action + ", " + timer);
        writer.Close();
       
    }
}

