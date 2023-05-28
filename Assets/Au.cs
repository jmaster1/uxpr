using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Au : MonoBehaviour
{
    private static int n = 64;
    
    private static int avgn = 15;
        
    float[] spectrum = new float[n];

    private List<float[]> history = new List<float[]>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        spectrum = new float[n];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        history.Add(spectrum);
        
        var avg = new float[n];
        int hn = history.Count;
        int processed = 0;
        for (int i = 0; i < avgn; i++)
        {
            int hi = hn - i - 1;
            if (hi < 0)
            {
                break;
            }

            var hd = history[hi];
            for (int j = 0; j < n; j++)
            {
                avg[j] += hd[j];
            }

            processed++;
        }
        for (int j = 0; j < n; j++)
        {
            avg[j] /= (float)processed;
        }
        Draw(avg);
    }

    private void Draw(float[] spectrum)
    {
        var mx = 0.1f;
        var dx = -3.1f;
        var my = 0.5f;
        var dy = -1.1f;
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3((i - 1) * mx + dx, Mathf.Log(spectrum[i - 1]) * my + dy, 2),
                new Vector3(i * mx + dx, Mathf.Log(spectrum[i]) * my + dy, 2), Color.cyan);
            /*
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
            */
        }
    }
}
