using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Windows;

namespace HaarAccelerator
{
    class HaarClassifier
    {
        public void Start()
        {
            try
            {
                #region 处理未选择的错误
                if (Information.ClassifierChoose == null)
                {
                    MessageBox.Show("请选择分类器！");
                    return;
                }
                if (Information.TempImagePath.Count == 0)
                {
                    MessageBox.Show("请选择图片！");
                    return;
                }
                #endregion
                int imagecount = 1;
                List<string> tempblock = new List<string>();
                #region 切割
                foreach (var image in Information.TempImagePath)
                {
                    int blockcount = 1;
                    Mat srcimage = new Mat(image, ImreadModes.AnyColor);
                    CascadeClassifier classifier = new CascadeClassifier(Information.Xml + $"\\{Information.ClassifierChoose}.xml");
                    OpenCvSharp.Rect[] blockrect = classifier.DetectMultiScale(srcimage, 1.1, 0, 0, new OpenCvSharp.Size(20, 20), new OpenCvSharp.Size(50, 50));
                    foreach (var block in blockrect)
                    {
                        string savepath = Information.TempBlock + $"\\image-{imagecount}_block-{blockcount}_{Information.ClassifierChoose}.jpg";
                        Mat mat = new Mat(srcimage, block);
                        mat.ImWrite(savepath);
                        tempblock.Add(savepath);
                        blockcount++;
                    }
                    imagecount++;
                }
                #endregion
                Information.TempBlockPath.AddRange(tempblock);
            }
            catch
            {
                ErrorHandler.UnKnownError();
            }
        } 
    }
    public enum ClassifierChoose
    {
        EyesClassifier,
        EarsClassifier,
        NoseClassifier,
        MouthClassifier
    }
}
