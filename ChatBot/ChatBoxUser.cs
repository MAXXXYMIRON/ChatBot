using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;   

namespace ChatBot
{
    /// <summary>
    /// Панель представляющая окна сообщений в чате.
    /// </summary>
    class ChatBoxUser : Panel
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
        /// Закругленный левый нижний угол.
        /// </summary>
        PictureBox AngleDL = new PictureBox();


        /// <summary>
        /// Сообщение введенное пользователем.
        /// </summary>
        Label Message = new Label();


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


        /// <summary>
        /// Позиция правого верхнего угла по Х.
        /// </summary>
        int rigthPos;
        /// <summary>
        /// Промежуточная прерменная для возврата смещенной позиции.
        /// </summary>
        Point tempLoc = new Point();

        /// <summary>
        /// Сокрытое свойство позиционирующее окно 
        /// сообщения по провому верхнему углу.
        /// </summary>
        public new Point Location
        {
            get
            {
                tempLoc.X = rigthPos;
                tempLoc.Y = ((Control)this).Location.Y;
                return tempLoc;
            }
            set
            {
                rigthPos = value.X;
                ((Control)this).Location = new Point(value.X - Width, value.Y);
            }
        }


        public ChatBoxUser(int widthMainContorl)
        {
            WidthMainContorl = widthMainContorl;

            BackColor = Color.FromArgb(79, 79, 79);


            AngleTL.Size = new Size(PictureWidth, PictureHeight);
            AngleTR.Size = new Size(PictureWidth, PictureHeight);
            AngleDL.Size = new Size(PictureWidth, PictureHeight);
            AngleTL.Image = Image.FromFile(@"Pictures\ChatAngleTL.png");
            AngleTR.Image = Image.FromFile(@"Pictures\ChatAngleTR.png");
            AngleDL.Image = Image.FromFile(@"Pictures\ChatAngleDL.png");

            Message.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            Message.ForeColor = Color.Silver;
            Message.Location = new Point(PictureWidth, PictureHeight);
            Message.AutoSize = true;
    
            Controls.Add(AngleTL);
            Controls.Add(AngleDL);
            Controls.Add(AngleTR);
            Controls.Add(Message);

            AutoPositioningAndSizing();
        }



        /// <summary>
        /// Авто настройка размеров окна в соответствии с размером сообщения
        /// и позиционирование его на главном окне с учетом того, что оно 
        /// находится по правому краю 
        /// </summary>
        void AutoPositioningAndSizing()
        {

            Size = new Size(Message.Width + PictureWidth + PictureWidth, 
                PictureHeight + PictureHeight + Message.Height);
            Location = new Point(Location.X, Location.Y);


            AngleTL.Location = new Point(0, 0);
            AngleTR.Location = new Point(Width - PictureWidth, 0);
            AngleDL.Location = new Point(0, Height - PictureWidth);
        }


        /// <summary>
        /// Запись текста в окно сообщений
        /// </summary>
        public void InputText(string text)
        {
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
            AutoPositioningAndSizing();
        }
    }
}
