using Unity;
using UnityEngine;

public class Au : MonoBehaviour
{
    public int samples = 64;
    
    public int avgHistory = 16;

    private FloatArrayHistory _history = new();

    public Plotter spectrumPlotter;
    
    void Start()
    {
        spectrumPlotter.Provider = _history.CreateAverageProvider(avgHistory);
    }

    private void FixedUpdate()
    {
        var spectrum = new float[samples];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        _history.Add(spectrum);
    }
}
