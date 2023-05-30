using Unity;
using UnityEngine;
using xpr.Util.Math;

public class Au : MonoBehaviour
{
    public int samples = 64;
    
    public int avgHistory = 16;
    
    public int freqHistorySamples = 256;
    
    public int freqHistoryIndex = 32;

    public readonly FloatArrayHistory History = new();

    public Plotter spectrumPlotter;
    
    public Plotter freqHistoryPlotter;
    
    
    void Start()
    {
        spectrumPlotter.Provider = History.CreateAverageProvider(avgHistory);
        freqHistoryPlotter.Provider = History.CreateHistoryProvider(freqHistoryIndex, freqHistorySamples);
    }

    private void FixedUpdate()
    {
        var spectrum = new float[samples];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        History.Add(spectrum);
    }
}
