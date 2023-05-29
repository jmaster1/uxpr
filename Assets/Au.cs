using Unity;
using UnityEngine;

public class Au : MonoBehaviour
{
    public int samples = 64;
    
    public int avgHistory = 16;
    
    public int freqHistorySamples = 256;
    
    public int freqHistoryIndex = 32;

    private FloatArrayHistory _history = new();

    public Plotter spectrumPlotter;
    
    public Plotter freqHistoryPlotter;
    
    
    void Start()
    {
        spectrumPlotter.Provider = _history.CreateAverageProvider(avgHistory);
        freqHistoryPlotter.Provider = _history.CreateHistoryProvider(freqHistoryIndex, freqHistorySamples);
    }

    private void FixedUpdate()
    {
        var spectrum = new float[samples];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        _history.Add(spectrum);
    }
}
