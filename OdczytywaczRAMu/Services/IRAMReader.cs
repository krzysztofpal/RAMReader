using System;

namespace OdczytywaczRAMu.Services
{
    public interface IRAMReader
    {
        Tuple<ulong, ulong> SprawdzRAM();
    }
}