using System;

namespace OdczytywaczRAMu.Services
{
    public interface ITimeMeasuring
    {
        void Start(int milisecounds, Action onTimerElapsed);
    }
}