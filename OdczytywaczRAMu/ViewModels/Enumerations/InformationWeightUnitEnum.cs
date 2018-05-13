using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdczytywaczRAMu.ViewModels.Enumerations
{
    public enum InformationWeightUnitEnum
    {
        Bytes = 0,
        KiloBytes = 1,
        MegaBytes = 2
    }

    public static class InfomrationWeightUnitEnumExtender
    {
        public static string GetUnitName(this InformationWeightUnitEnum e)
        {
            switch(e)
            {
                case InformationWeightUnitEnum.Bytes: return "B";
                case InformationWeightUnitEnum.KiloBytes: return "KB";
                case InformationWeightUnitEnum.MegaBytes: return "MB";
            }
            return "";
        }
    }
}
