using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HaarAccelerator
{
    class ErrorHandler
    {
        public static void UnKnownError()
        {
            MessageBox.Show("发生未知错误，请联系开发者！");
            Logger logger = new Logger(Information.Log);
            logger.Write("Unknown error has happened!", Logger.LogType.Error);
        }

        public static void IsUsing()
        {
            MessageBox.Show("文件正在占用，请解除后再试！");
        }
    }
}
