using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Chat;

namespace ChatBot
{
    public partial class WinChat : Form
    {
        Bot IsChoosenBot = Autorization.ChoosenBot;

        List<string> Answers = new List<string>();
        List<string> Questions = new List<string>();

        List<ChatBoxBot> AnswersBot = new List<ChatBoxBot>();
        List<ChatBoxUser> QuestionsUser = new List<ChatBoxUser>();

        Thread BotIsAnswering;

        public WinChat()
        {
            InitializeComponent();
        }


        private void inputText_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        string[] ToSentMessage(string message)
        {
            return IsChoosenBot.ToAsk(message);
        }


        /// <summary>
        /// Свойство ограничивающее размер окна по горизрнтал
        /// </summary>
        int LockedWidth
        {
            set
            {
                if (value < 660) return;
                Width = value;
            }
        }
        
        /// <summary>
        /// Свойство ограничивающее размер окна по вертикали
        /// </summary>
        int LockedHeight
        {
            set
            {
                if (value < 393) return;
                Height = value;
            }
        }




        //----------------------------------Масштабирование и перемение окна----------------------------------\\
        /// <summary>
        /// Курсор мыши с учетом положения окна.
        /// </summary>
        Point curs = new Point();

        /// <summary>
        /// Переменная указывающая на то, что масштабирование окна продолжается.
        /// </summary>
        static bool sizing = true;
        /// <summary>
        /// Поток проверяющий завершено ли масштабирование или перемещение.
        /// </summary>
        Thread stop;

        /// <summary>
        /// Поправка по Х, необходимая для предотвращения скачка рамки в позицию курсора.
        /// </summary>
        int? correctionX = null;
        /// <summary>
        /// Поправка по Y, необходимая для предотвращения скачка рамки в позицию курсора.
        /// </summary>
        int? correctionY = null;

        /// <summary>
        /// Позиция правого верхнего угла на экране.
        /// </summary>
        int? prevPositionX = null;

        /// <summary>
        /// Высота рабочей зоны (чат, окно ввода сообщения и разделительная линия)
        /// </summary>
        int heigthWorkZone = 0;
        /// <summary>
        /// Переменная для задания локации контролов на форме
        /// </summary>
        Point locControls = new Point();



        /// <summary>
        /// Функция из отдельного потока, проверяющая состояние масштабирования или перемещения.
        /// </summary>
        private static void SizingRight()
        {
            while (true && sizing)
            {
                if (MouseButtons == MouseButtons.None) sizing = false; 
            }
        }

        /// <summary>
        /// Определение позиции курсора с учетом позиции окна.
        /// </summary>
        void PositioningCursor()
        {
            curs.X = Cursor.Position.X - Location.X;
            curs.Y = Cursor.Position.Y - Location.Y;
        }

        
        /// <summary>
        /// Масштабирование и позиционирование контролов формы относительное её размеров.
        /// </summary>
        void SizingPositioningControls()
        {
            //Настройка размеров внутренних контролов
            panelChat.Width = Width - (sizeLeft.Width * 2);
            heigthWorkZone = (Height - (sizeLeft.Width * 3));
            panelChat.Height = heigthWorkZone - (panelSeporator.Height + inputText.Height);

            panelSeporator.Width = panelChat.Width;
            inputText.Width = panelChat.Width;

            movingTop.Width = Width;
            sizeLeft.Height = heigthWorkZone;
            sizeRight.Height = heigthWorkZone;
            sizeDown.Width = panelChat.Width;

            //Настройка позиций внутренних контролов
            locControls.X = Width - sizeLeft.Width;
            locControls.Y = sizeLeft.Location.Y;
            sizeRight.Location = locControls;

            locControls.Y = Height - sizeAngleLeft.Height;
            sizeAngleRight.Location = locControls;

            locControls.X = 0;
            sizeAngleLeft.Location = locControls;

            locControls.X += sizeDown.Height;
            sizeDown.Location = locControls;

            locControls.Y = panelChat.Location.Y + panelChat.Height;
            panelSeporator.Location = locControls;

            locControls.Y += panelSeporator.Height;
            inputText.Location = locControls;

            locControls.X = (Width / 2) - labelName.Width;
            locControls.Y = labelName.Location.Y;
            labelName.Location = locControls;

            locControls.X = Width - (sizeLeft.Width + panelClose.Width);
            locControls.Y = 3;
            panelClose.Location = locControls;

            locControls.X -= (panelHide.Width + 6);
            locControls.Y += 8;
            panelHide.Location = locControls;


        }



        /// <summary>
        /// Масштабирование провой границей.
        /// </summary>
        private void sizeRight_MouseDown(object sender, MouseEventArgs e)
        {
            stop = new Thread(SizingRight);
            stop.Start();
            while (sizing)
            {
                PositioningCursor();

                if (correctionX == null)
                    correctionX = ((curs.X - Width) + sizeRight.Width);

                LockedWidth = (curs.X - (int)correctionX) + sizeRight.Width;

                SizingPositioningControls();
            }
            stop = null;
            correctionX = null;
            sizing = true;

        }

        /// <summary>
        /// Масштабирование правым нижним углом.
        /// </summary>
        private void sizeAngleRight_MouseDown(object sender, MouseEventArgs e)
        {
            stop = new Thread(SizingRight);
            stop.Start();
            while (sizing)
            {
                PositioningCursor();

                if (correctionX == null)
                {
                    correctionX = ((curs.X - Width) + sizeAngleRight.Width);
                    correctionY = ((curs.Y - Height) + sizeAngleRight.Height);
                }

                LockedWidth = (curs.X - (int)correctionX) + sizeAngleRight.Width;
                LockedHeight = (curs.Y - (int)correctionY) + sizeAngleRight.Height;

                SizingPositioningControls();
            }
            stop = null;
            correctionX = null;
            correctionY = null;
            sizing = true;
        }

        /// <summary>
        /// Масштабирование нижней границей.
        /// </summary>
        private void sizeDown_MouseDown(object sender, MouseEventArgs e)
        {
            stop = new Thread(SizingRight);
            stop.Start();
            while (sizing)
            {
                PositioningCursor();

                if (correctionY == null)
                    correctionY = ((curs.Y - Height) + sizeDown.Height);

                LockedHeight = (curs.Y - (int)correctionY) + sizeDown.Height;

                panelChat.Height = Height - (sizeDown.Height * 3);

                SizingPositioningControls();
            }
            stop = null;
            correctionY = null;
            sizing = true;
        }

        /// <summary>
        /// Масштабирование левым нижним углом.
        /// </summary>
        private void sizeAngleLeft_MouseDown(object sender, MouseEventArgs e)
        {
            stop = new Thread(SizingRight);
            stop.Start();
            while (sizing)
            {
                PositioningCursor();

                if (correctionX == null)
                {
                    correctionX = curs.X;
                    correctionY = ((curs.Y - Height) + sizeAngleLeft.Height);
                }

                if(prevPositionX == null)
                    prevPositionX = Location.X + Width;

                LockedWidth = (int)prevPositionX - (Cursor.Position.X - (int)correctionX);
                Location = new Point(Cursor.Position.X - (int)correctionX, Location.Y);

                LockedHeight = (curs.Y - (int)correctionY) + sizeAngleLeft.Height;

                SizingPositioningControls();
            }
            stop = null;
            correctionX = null;
            correctionY = null;
            prevPositionX = null;
            sizing = true;
        }

        /// <summary>
        /// Масштабирование левой границей.
        /// </summary>
        private void sizeLeft_MouseDown(object sender, MouseEventArgs e)
        {
            stop = new Thread(SizingRight);
            stop.Start();
            while (sizing)
            {
                PositioningCursor();

                if (correctionX == null)
                    correctionX = curs.X;

                if (prevPositionX == null)
                    prevPositionX = Location.X + Width;

                Width = (int)prevPositionX - (Cursor.Position.X - (int)correctionX);
                Location = new Point(Cursor.Position.X - (int)correctionX, Location.Y);

                SizingPositioningControls();
            }
            stop = null;
            correctionX = null;
            prevPositionX = null;
            sizing = true;
        }

        /// <summary>
        /// Позиция окна перед разворотом на весь экран.
        /// </summary>
        Point befLocation = new Point();
        /// <summary>
        /// Ширина и высота окна перед разворотом на весь экран.
        /// </summary>
        int befWidth = 0, befHeight = 0;
        /// <summary>
        /// Текущее состояние окна.
        /// </summary>
        bool asScreen = false;

        /// <summary>
        /// Растянуть окно на весь экран двойным кликом.
        /// </summary>
        private void movingTop_DoubleClick(object sender, EventArgs e)
        {
            if(!asScreen)
            {
                befLocation = Location;
                befWidth = Width;
                befHeight = Height;
                asScreen = true;

                Location = new Point(0, 0);
                LockedWidth = Screen.PrimaryScreen.Bounds.Width;
                LockedHeight = Screen.PrimaryScreen.Bounds.Height;
            }
            else
            {
                Location = befLocation;
                LockedWidth = befWidth;
                LockedHeight = befHeight;
                asScreen = false;
            }
            SizingPositioningControls();
        }

        /// <summary>
        /// Растянуть окно на весь экран двойным кликом.
        /// </summary>
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (!asScreen)
            {
                befLocation = Location;
                befWidth = Width;
                befHeight = Height;
                asScreen = true;

                Location = new Point(0, 0);
                LockedWidth = Screen.PrimaryScreen.Bounds.Width;
                LockedHeight = Screen.PrimaryScreen.Bounds.Height;
            }
            else
            {
                Location = befLocation;
                LockedWidth = befWidth;
                LockedHeight = befHeight;
                asScreen = false;
            }
            SizingPositioningControls();
        }

        /// <summary>
        /// Перемещение окна.
        /// </summary>
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            stop = new Thread(SizingRight);
            stop.Start();
            while (sizing)
            {

                if (correctionX == null)
                {
                    PositioningCursor();
                    correctionX = curs.X;
                    correctionY = curs.Y;
                }

                Location = new Point(Cursor.Position.X - (int)correctionX, Cursor.Position.Y - (int)correctionY);
            }
            stop = null;
            correctionX = null;
            correctionY = null;
            sizing = true;
        }

        /// <summary>
        /// Перемещение окна.
        /// </summary>
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            panel2_MouseDown(sender, e);
        }





        //----------------------------------Действия кнопок----------------------------------\\

        //Закрытие формы
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(216, 94, 94);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(134, 134, 134);
        }

        private void panelClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        //Сворачивание формы
        private void panelHide_MouseMove(object sender, MouseEventArgs e)
        {
            panelHide.BackColor = Color.FromArgb(72, 55, 71);
        }

        private void panelHide_MouseLeave(object sender, EventArgs e)
        {
            panelHide.BackColor = Color.FromArgb(134, 134, 134);
        }

        private void panelHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            panelHide.BackColor = Color.FromArgb(134, 134, 134);
        }


    }
}
