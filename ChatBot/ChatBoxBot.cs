using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ChatBot
{
    class ChatBoxBot : Panel
    {
        /// <summary>
        /// Закругленный левый верхний угол.
        /// </summary>
        PictureBox AngleTL = new PictureBox();
        /// <summary>
        /// Закругленный правый верхний угол.
        /// </summary>
        PictureBox AngleTR = new PictureBox();
        /// <summary>
        /// Закругленный правый нижний угол.
        /// </summary>
        PictureBox AngleDR = new PictureBox();


        /// <summary>
        /// Сообщение введенное пользователем.
        /// </summary>
        Label Message = new Label();
        /// <summary>
        /// Сообщение в виде картинки.
        /// </summary>
        PictureBox Picture = new PictureBox();

        //Размеры теккуших сообщений.
        int insideWidth = 0, insideHeight = 0;

        /// <summary>
        /// Высота картинки угла.
        /// </summary>
        const int PictureHeight = 20;
        /// <summary>
        /// Ширина картинки угла.
        /// </summary>
        const int PictureWidth = 20;


        /// <summary>
        /// Ширина окна содержащего этот контрол.
        /// </summary>
        public int WidthMainContorl
        {
            set
            {
                if (value < 600) throw new Exception("Недопустимый размер содержащего окна.");
                Length = value / 15;
            }
        }

        /// <summary>
        /// Текущий текст окна.
        /// </summary>
        string messageText = "";
        /// <summary>
        /// Число символов в одной строке.
        /// </summary>
        int len;
        /// <summary>
        /// Задать, получить число символов в одной строке.
        /// </summary>
        int Length
        {
            get => len;
            set
            {
                len = value;
                InputText(messageText);
            }
        }


        public ChatBoxBot(int widthMainContorl)
        {
            WidthMainContorl = widthMainContorl;

            BackColor = Color.FromArgb(79, 79, 79);

            AngleTL.Size = new Size(PictureWidth, PictureHeight);
            AngleTR.Size = new Size(PictureWidth, PictureHeight);
            AngleDR.Size = new Size(PictureWidth, PictureHeight);

            AngleTL.Image = Image.FromFile(@"Pictures\ChatAngleTL.png");
            AngleTR.Image = Image.FromFile(@"Pictures\ChatAngleTR.png");
            AngleDR.Image = Image.FromFile(@"Pictures\ChatAngleDR.png");


            Message.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            Message.ForeColor = Color.Silver;
            Message.Location = new Point(PictureWidth, PictureHeight);
            Message.AutoSize = true;

            Picture.Location = new Point(PictureWidth, PictureHeight);
            Picture.WaitOnLoad = true;
            Picture.AutoSize = true;
            Picture.Hide();

            Controls.Add(AngleTL);
            Controls.Add(AngleDR);
            Controls.Add(AngleTR);
            Controls.Add(Message);
            Controls.Add(Picture);

            AutoPositioningAndSizing();
        }

        /// <summary>
        /// Авто настройка размеров окна в соответствии с размером сообщения
        /// </summary>
        void AutoPositioningAndSizing()
        {
            Size = new Size(insideWidth + PictureWidth + PictureWidth,
                insideHeight + PictureHeight + PictureHeight);


            AngleTR.Location = new Point(Width - PictureWidth, 0);
            AngleDR.Location = new Point(Width - PictureWidth, Height - PictureWidth);
        }


        /// <summary>
        /// Запись текста в окно сообщений
        /// </summary>
        public void InputText(string text)
        {
            Message.Show();
            Picture.Hide();

            messageText = text;
            StringBuilder str = new StringBuilder(text);
            List<StringBuilder> words = new List<StringBuilder>();

            int start = 0,
                end = 0,
                count = 0,
                strSize = 0;

            if (str.Length > Length)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ' || i == str.Length - 1)
                    {
                        end = i + 1;

                        words.Add(new StringBuilder(str.ToString(start, end - start)));

                        start = end;
                    }
                }

                str.Clear();

                for (int i = 0; i < words.Count; i++)
                {
                    if (words[i].Length < Length)
                    {
                        if (count + words[i].Length < Length)
                        {
                            str.Append(words[i]);
                            count += words[i].Length;
                        }
                        else
                        {
                            str.Append('\n');
                            str.Append(words[i]);
                            count = words[i].Length;
                        }
                    }
                    else
                    {

                        words[i] = words[i].Insert((Length - 2) - count, "-");
                        words[i] = words[i].Insert((Length - 1) - count, "\n");

                        strSize = Length - count;

                        while (strSize + (Length - 2) < words[i].Length)
                        {
                            strSize += (Length - 2);
                            words[i] = words[i].Insert(strSize, "-");
                            strSize++;
                            words[i] = words[i].Insert(strSize, "\n");
                            strSize++;
                        }

                        count = words[i].Length - strSize;
                        str.Append(words[i]);
                    }
                    words[i].Clear();
                }
            }

            words.Clear();

            Message.Text = str.ToString();

            insideWidth = Message.Width;
            insideHeight = Message.Height;

            AutoPositioningAndSizing();
        }


        /// <summary>
        /// Запись картинки в окно сообщений.
        /// </summary>
        public void InputImage(string imageName)
        {
            Message.Hide();
            Picture.Show();
            Picture.Image = Image.FromFile(imageName);

            insideWidth = Picture.Width;
            insideHeight = Picture.Height;

            AutoPositioningAndSizing();
        }
    }
}
