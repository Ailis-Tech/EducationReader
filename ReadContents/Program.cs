using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ReadContents
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        
        private static Mutex mutex;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool newWindow;
            mutex = new Mutex(true, "MainMenu", out newWindow);

            try
            {
                if (!newWindow)
                {
                    // 多重起動を検出
                    return;
                }

                Application.Run(new MainMenu());
            }
            finally
            {
                if (newWindow)
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
