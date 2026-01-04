// Copyright (c) 2025 Ailis-Tech
// SPDX-License-Identifier: MIT

using System;
using System.Windows.Forms;

namespace EducationReader
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        //モーダルで表示
        private void btHiragana_Click(object sender, EventArgs e)
        {
            var hiraganaWindow = new HiraganaWindow();
            hiraganaWindow.ShowDialog();
            hiraganaWindow.Dispose();
        }

        private void btNumber_Click(object sender, EventArgs e)
        {
            var numberWindow = new NumberWindow();
            numberWindow.ShowDialog();
            numberWindow.Dispose();
        }
    }
}
