using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace HaarAccelerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Images> SourceImage;
        public MainWindow()
        {
            InitializeComponent();
            ImageBlock.Source = new BitmapImage(new Uri(Information.DefaultImage));
        }

        private void LoadingImage_Click(object sender, RoutedEventArgs e)
        {
            SourceImage = new List<Images>();
            bool CanAdd = FileOperate.Loading();
            #region 是否添加至选择列表 CanAdd
            if (CanAdd)
            {
                Information.TempImagePath.AddRange(Information.LoadPath);
                foreach (var item in Information.TempImagePath)
                {
                    SourceImage.Add(new Images() { SourceImage = item });
                }
                Information.LoadPath.Clear();
            }
            lstImgs.ItemsSource = SourceImage;
            #endregion
        }

        private void StartClassifier_Click(object sender, RoutedEventArgs e)
        {
            Information.IsSave = false;
            Information.IsStart = true;
            MainWindowOperate.GetClassifierModel(EyesClassifier,EarsClassifier,NoseClassifier,MouthClassifier);
            HaarClassifier haarClassifier = new HaarClassifier();
            haarClassifier.Start();
            if(Information.TempImagePath.Count != 0)
            {
                (Information.NowImage, Information.NowBlock) = MainWindowOperate.ReplaceImage(ImageBlock);
            }
            else
            {
                MessageBox.Show("未获得有效分类，请调参！");
                FileOperate.ReStart();
            }
        }

        private void CancleChoose_Click(object sender, RoutedEventArgs e)
        {
            SourceImage = new List<Images>();
            lstImgs.ItemsSource = SourceImage;
            ImageBlock.Source.Freeze();
            ImageBlock.Source = new BitmapImage(new Uri(Information.DefaultImage));
            FileOperate.ReStart();
        }

        private void PosImage_Click(object sender, RoutedEventArgs e)
        {
            if (!Information.IsStart)
            {
                MessageBox.Show("请先开始分类！");
                return;
            }
            FileOperate.TempPosSave();
            (Information.NowImage, Information.NowBlock) = MainWindowOperate.ReplaceImage(ImageBlock);
        }

        private void SkipImage_Click(object sender, RoutedEventArgs e)
        {
            if (!Information.IsStart)
            {
                MessageBox.Show("请先开始分类！");
                return;
            }
            FileOperate.TempSkipSave();
            (Information.NowImage, Information.NowBlock) = MainWindowOperate.ReplaceImage(ImageBlock);
        }

        private void NegImage_Click(object sender, RoutedEventArgs e)
        {
            if (!Information.IsStart)
            {
                MessageBox.Show("请先开始分类！");
                return;
            }
            FileOperate.TempNegSave();
            (Information.NowImage, Information.NowBlock) = MainWindowOperate.ReplaceImage(ImageBlock);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            FileOperate.Save();
        }
    }
}
