using UnityEngine;

public class Au : MonoBehaviour
{
    
    float[] spectrum = new float[64];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        var mx = 0.1f;
        var dx = -3.1f;
        var my = 0.1f;
        var dy = 0.1f;
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3((i - 1) * mx + dx, Mathf.Log(spectrum[i - 1]) * my + dy, 2),
                new Vector3(i * mx + dx, Mathf.Log(spectrum[i]) * my + dy, 2), Color.cyan);
        }
    }
}
