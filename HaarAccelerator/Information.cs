using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HaarAccelerator
{
    public class Images
    {
        public string SourceImage { get; set; }
        public string SourceImageName => Path.GetFileName(SourceImage);
    }
    public enum SaveChoose
    {
        pos,
        neg,
        skip
    }
    class Information
    {
        #region 数据
        public static List<string> LoadPath = new List<string>();

        public static List<string> TempImagePath = new List<string>();

        public static List<string> TempBlockPath = new List<string>();
        public static int NowImage { get; set; } = 1;
        public static int NowBlock { get; set; } = 0;
        public static bool IsSave { get; set; } = false;
        public static ClassifierChoose? ClassifierChoose { get; set; } = null;
        public static string HaarAcceleratorTempFolder => Path.Combine(Environment.GetEnvironmentVariable("temp"), "HaarAccelerator");
        public static string HaarAcceleratorFolder => AppDomain.CurrentDomain.BaseDirectory;
        public static string TempBlock => Path.Combine(HaarAcceleratorTempFolder, "TempBlock");
        public static string TempNeg => Path.Combine(HaarAcceleratorTempFolder, "TempNeg");
        public static string TempPos => Path.Combine(HaarAcceleratorTempFolder, "TempPos");
        public static string TempSkip => Path.Combine(HaarAcceleratorTempFolder, "TempSkip");
        public static string Neg => Path.Combine(HaarAcceleratorFolder, "neg");
        public static string Pos => Path.Combine(HaarAcceleratorFolder, "pos");
        public static string Skip => Path.Combine(HaarAcceleratorFolder, "skip");
        public static string Xml => Path.Combine(HaarAcceleratorFolder, "xml");
        public static string Log => Path.Combine(HaarAcceleratorFolder, "log");
        public static string DefaultImage => Path.Combine(HaarAcceleratorFolder, "defaultImage\\defaultimage.jpg");
        #endregion
    }
}
