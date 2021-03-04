using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HaarAccelerator
{
    class Information
    {
        public List<string> loadPath = new List<string>();

        public List<string> tempImagePath = new List<string>();

        public List<string> imageblockPath = new List<string>();
        public ClassifierChoose? ClassifierChoose { get; set; } = null;
        public string HaarAcceleratorTempFolder => Path.Combine(Environment.GetEnvironmentVariable("temp"), "HaarAccelerator");
        public string HaarAcceleratorFolder => AppDomain.CurrentDomain.BaseDirectory;
        public string TempImage => Path.Combine(HaarAcceleratorTempFolder, "TempImage");
        public string TempBlock => Path.Combine(HaarAcceleratorTempFolder, "TempBlock");
        public string TempNeg => Path.Combine(HaarAcceleratorTempFolder, "TempNeg");
        public string TempPos => Path.Combine(HaarAcceleratorTempFolder, "TempPos");
        public string TempSkip => Path.Combine(HaarAcceleratorTempFolder, "TempSkip");
        public string Neg => Path.Combine(HaarAcceleratorFolder, "neg");
        public string Pos => Path.Combine(HaarAcceleratorFolder, "pos");
        public string Skip => Path.Combine(HaarAcceleratorFolder, "skip");
        public string Xml => Path.Combine(HaarAcceleratorFolder, "xml");
        public string DefaultImage => Path.Combine(HaarAcceleratorFolder, "defaultImage\\defaultimage.jpg");

    }
}
