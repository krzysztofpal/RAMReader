using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;

namespace OdczytywaczRAMu.Services
{
    public class RAMReader : IRAMReader
    {
        public RAMReader() { }

        public Tuple<ulong, ulong> SprawdzRAM()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            ComputerInfo info = new ComputerInfo();
            return new Tuple<ulong, ulong>(info.TotalPhysicalMemory, info.AvailablePhysicalMemory);
        }
    }

    
}
