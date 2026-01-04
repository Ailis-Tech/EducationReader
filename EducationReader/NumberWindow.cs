// Copyright (c) 2025 Ailis-Tech
// SPDX-License-Identifier: MIT

using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace EducationReader
{
    public partial class NumberWindow : Form
    {
        public NumberWindow()
        {
            InitializeComponent();
            initializeWindow();
            createButtons();
            createPictbox();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private readonly CommonConst CONST_NUM = new CommonConst();
        private Button[] buttons;
        private PictureBox[] pictureBoxes;
        private System.Media.SoundPlayer player = null;

        private void initializeWindow()
        {
            // サイズや配置の初期設定
            int vIndex = CONST_NUM.BTN_HEIGHT + CONST_NUM.BTN_SPACE;
            int hIndex = CONST_NUM.BTN_WIDTH + CONST_NUM.BTN_SPACE;
            this.Height = vIndex * 3 + CONST_NUM.PICT_HEIGHT * 2 + CONST_NUM.BTN_SPACE * 8;
            this.Width = hIndex * 4 + CONST_NUM.BTN_SPACE * 4;
        }

        private void createButtons()
        {
            int vIndex = CONST_NUM.BTN_HEIGHT + CONST_NUM.BTN_SPACE;
            int hIndex = CONST_NUM.BTN_WIDTH + CONST_NUM.BTN_SPACE;

            // 0～9までの10数の初期化
            this.buttons = new Button[10];

            for (int i = 0; i < buttons.Length; i++)
            {
                this.buttons[i] = new Button
                {
                    Name = "bt" + i.ToString(),
                    Text = i.ToString(),
                    Height = CONST_NUM.BTN_HEIGHT,
                    Width = CONST_NUM.BTN_WIDTH
                };
                this.buttons[i].Font = new Font(this.buttons[i].Font.OriginalFontName, CONST_NUM.TXT_SIZE);

                // 0～9ボタンの配置
                if (i == 0)
                {
                    // 0は左上に表示
                    this.buttons[i].Top = CONST_NUM.BTN_SPACE;
                    this.buttons[i].Left = CONST_NUM.BTN_SPACE;
                }
                else
                {
                    // 1～9は3×3の9マス表示
                    this.buttons[i].Top = CONST_NUM.BTN_SPACE + (((i - 1) / 3) * vIndex);
                    this.buttons[i].Left = CONST_NUM.BTN_SPACE + hIndex + (((i - 1) % 3) * hIndex);
                }

                this.Controls.Add(this.buttons[i]);
                this.buttons[i].Click += new System.EventHandler(btnClick);
            }
        }

        private void createPictbox()
        {
            int boxLocationX = CONST_NUM.BTN_SPACE * 4;
            int boxLocationY = CONST_NUM.BTN_SPACE + (CONST_NUM.BTN_HEIGHT+ CONST_NUM.BTN_SPACE) * 3;

            // 1～9個の画像格納領域の初期化
            this.pictureBoxes = new PictureBox[9];

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                this.pictureBoxes[i] = new PictureBox
                {
                    Name = "pict" + (i + 1).ToString(),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Height = CONST_NUM.PICT_HEIGHT,
                    Width = CONST_NUM.PICT_WIDTH,
                    Top = boxLocationY + (i / 5) * CONST_NUM.PICT_HEIGHT,
                    Left = boxLocationX + (i % 5) * CONST_NUM.PICT_WIDTH
                };
                this.Controls.Add(this.pictureBoxes[i]);
            }
        }

        private void btnClick(object sender, System.EventArgs e)
        {
            // 引数のボタンオブジェクトをセット
            Button btn = (Button)sender;

            // 音声メディアのリソース名を取得
            string voiceName = "v" + btn.Text;

            // 音声メディアを再生
            Common.playVoice(voiceName);

            // メディアフォルダを取得
            string mediaDirectory = Common.getMediaDirectory("number");

            // 画像メディアを取得
            string imageMediaPath = Path.Combine(mediaDirectory, "image.jpg");
            setImage(imageMediaPath, int.Parse(btn.Text));
        }

        private void setImage(string imagePath, int idx)
        {
            // 画像を読み込んでpictureBoxに表示
            try
            {
                if (System.IO.File.Exists(imagePath))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        // Image.FromFileメソッドを使用
                        string pictboxName = "pict" + (i + 1).ToString();
                        foreach (Control cont in this.Controls)
                        {
                            if (cont is PictureBox pictBox && cont.Name == pictboxName)
                            {
                                PictureBox pictureBox = pictBox;

                                if (idx > 0 && i < idx)
                                {
                                    pictBox.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    if (pictBox.Image != null)
                                    {
                                        pictBox.Image.Dispose();
                                        pictBox.Image = null;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("画像の読み込み中にエラーが発生しました: " + ex.Message);
            }
        }
    }
}
