using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OdczytywaczRAMu
{
    public class RAMReader
    {
        public Tuple<int, int> SprawdzRAM()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "getram.bat";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            output = output.Replace('ÿ', ' ');
            string freeRam = "";
            string allRam = "";
            Regex regex = new Regex("Total Physical Memory:[^\\d]*([^M]*)");
            Match m = regex.Match(output);
            allRam = m.Groups[1].Value.Replace(" ", "");
            Regex r = new Regex("Available Physical Memory:[^\\d]*([^M]*)");
            Match mm = r.Match(output);
            freeRam = mm.Groups[1].Value.Replace(" ", "");
            return new Tuple<int, int>(int.Parse(allRam), int.Parse(freeRam));
            p.WaitForExit();
            
        }
    }

    
}
