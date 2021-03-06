using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;

namespace HaarAccelerator
{
    class MainWindowOperate
    {
        public static (int, int) ReplaceImage(Image image)
        {
            if (File.Exists(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock + 1}_{Information.ClassifierChoose}.jpg"))
            {
                image.Source = new BitmapImage(new Uri(Information.TempBlock + $"\\image-{Information.NowImage}_block-{Information.NowBlock + 1}_{Information.ClassifierChoose}.jpg"));
                return (Information.NowImage, Information.NowBlock + 1);
            }
            else
            {
                for (int i = 1; i <= 30; i++)
                {
                    if (File.Exists(Information.TempBlock + $"\\image-{Information.NowImage + i}_block-{1}_{Information.ClassifierChoose}.jpg"))
                    {
                        image.Source = new BitmapImage(new Uri(Information.TempBlock + $"\\image-{Information.NowImage + i}_block-{1}_{Information.ClassifierChoose}.jpg"));
                        return (Information.NowImage + i, 1);
                    }
                }
                image.Source = new BitmapImage(new Uri(Information.DefaultImage));
                if(Information.ClassifierChoose == null)
                {
                    return (1, 0);
                }
                else
                {
                    MessageBox.Show("图片展示完毕，请保存！");
                    image.Source.Freeze();
                    return (1, 0);
                }
                
            }
        }//轮换图片块显示
        public static void GetClassifierModel(RadioButton a, RadioButton b, RadioButton c, RadioButton d)
        {
            if (a.IsChecked.Value)
            {
                Information.ClassifierChoose = ClassifierChoose.EyesClassifier;
            }
            if (b.IsChecked.Value)
            {
                Information.ClassifierChoose = ClassifierChoose.EarsClassifier;
            }
            if (c.IsChecked.Value)
            {
                Information.ClassifierChoose = ClassifierChoose.NoseClassifier;
            }
            if (d.IsChecked.Value)
            {
                Information.ClassifierChoose = ClassifierChoose.MouthClassifier;
            }
        }//设定分类器选择
    }
}
