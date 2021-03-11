using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace HaarAccelerator
{
    class FileOperate
    {
        public static bool Loading()
        {
            var openfiles = new OpenFileDialog()
            {
                Multiselect = true,
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "图像文件(*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png"
            };
            if (openfiles.ShowDialog() == true)
            {
                Information.LoadPath.AddRange(openfiles.FileNames);
            }


            if (Information.LoadPath.Count + Information.TempBlockPath.Count > 30)
            {
                MessageBox.Show("文件大于30个，请删除后重新选择！");
                Information.LoadPath.Clear();
                return false;
            }
            else
            {
                return true;
            }
        }
        #region 临时保存
        public static void TempPosSave()
        {
            if (File.Exists(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Information.ClassifierChoose}.jpg"))
            {
                var imageHandler = new ThumbImage(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Information.ClassifierChoose}.jpg");
                if (imageHandler.GetPosImage(Information.TempPos + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Utility.GetTimeStamp()}.jpg"))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("PosTempSaveError!");
                    Logger logger = new Logger(Information.Log);
                    logger.Write("PosTempSaveError!", Logger.LogType.Error);
                }
            }
        }
        public static void TempNegSave()
        {
            if (File.Exists(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Information.ClassifierChoose}.jpg"))
            {
                var imageHandler = new ThumbImage(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Information.ClassifierChoose}.jpg");
                if (imageHandler.GetNegImage(Information.TempNeg + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Utility.GetTimeStamp()}.jpg"))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("NegTempSaveError!");
                    Logger logger = new Logger(Information.Log);
                    logger.Write("NegTempSaveError!", Logger.LogType.Error);
                }
            }
        }
        public static void TempSkipSave()
        {
            if (File.Exists(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Information.ClassifierChoose}.jpg"))
            {
                File.Copy(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Information.ClassifierChoose}.jpg", Information.TempSkip + $"\\image-{Information.NowImage}_block-{Information.NowBlock}_{Utility.GetTimeStamp()}.jpg");
            }
        }
        #endregion
        public static void DeleteTempFolder()
        {
            try
            {
                Directory.Delete(Information.HaarAcceleratorTempFolder, true);
            }
            catch
            {
                MessageBox.Show("is using...");
            }
        }
        public static void CreatTempFolder()
        {
            if (!Directory.Exists(Information.HaarAcceleratorTempFolder))
            {
                Directory.CreateDirectory(Information.HaarAcceleratorTempFolder);
            }
            if (!Directory.Exists(Information.TempBlock))
            {
                Directory.CreateDirectory(Information.TempBlock);
            }
            if (!Directory.Exists(Information.TempPos))
            {
                Directory.CreateDirectory(Information.TempPos);
            }
            if (!Directory.Exists(Information.TempNeg))
            {
                Directory.CreateDirectory(Information.TempNeg);
            }
            if (!Directory.Exists(Information.TempSkip))
            {
                Directory.CreateDirectory(Information.TempSkip);
            }
        }
        public static void CreatFolder()
        {
            if (!Directory.Exists(Information.Xml))
            {
                Directory.CreateDirectory(Information.Xml);
            }
            if (!Directory.Exists(Information.Neg))
            {
                Directory.CreateDirectory(Information.Neg);
            }
            if (!Directory.Exists(Information.Pos))
            {
                Directory.CreateDirectory(Information.Pos);
            }
            if (!Directory.Exists(Information.Skip))
            {
                Directory.CreateDirectory(Information.Skip);
            }
            if(!Directory.Exists(Information.HaarAcceleratorFolder + "\\defaultImage"))
            {
                Directory.CreateDirectory(Information.HaarAcceleratorFolder + "\\defaultImage");
            }
        }
        public static void Save()
        {
            try
            {
                var pos = Directory.GetFiles(Information.TempPos);
                var neg = Directory.GetFiles(Information.TempNeg);
                var skip = Directory.GetFiles(Information.TempSkip);
                int savecount = 1;
                foreach (var item in pos)
                {
                    File.Copy(item, Information.Pos + $"\\{savecount}_{Utility.GetTimeStamp()}.jpg");
                    savecount++;
                }
                foreach (var item in neg)
                {
                    File.Copy(item, Information.Neg + $"\\{savecount}_{Utility.GetTimeStamp()}.jpg");
                    savecount++;
                }
                foreach (var item in skip)
                {
                    File.Copy(item, Information.Skip + $"\\{savecount}_{Utility.GetTimeStamp()}.jpg");
                    savecount++;
                }
                Information.IsSave = true;
                MessageBox.Show("保存成功！");
            }
            catch
            {
                MessageBox.Show("保存失败！");
            }
        }
        public static void ReStart()
        {
            Information.NowBlock = 0;
            Information.NowImage = 1;
            Information.IsStart = false;
            Information.IsSave = false;
            Information.LoadPath.Clear();
            Information.TempBlockPath.Clear();
            Information.TempImagePath.Clear();
            DeleteTempFolder();
            CreatTempFolder();
        }
    }
}
