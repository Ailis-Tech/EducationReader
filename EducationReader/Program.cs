// Copyright (c) 2025 Ailis-Tech
// SPDX-License-Identifier: MIT

using System;
using System.Threading;
using System.Windows.Forms;

namespace EducationReader
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
