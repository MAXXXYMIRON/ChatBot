using System;
using System.Drawing;
using System.Windows.Forms;
using Chat;

namespace ChatBot
{
    public partial class Autorization : Form
    {
        static public Bot ChoosenBot;
        StyleOfBot ChooseStyle()
        {
            if (activeSimple) return new Chat.Bots.SimpleBot();
            return null;
        }


        public Autorization()
        {
            InitializeComponent();
            labelSimple.Hide();
            labelEvil.Hide();
            labelPank.Hide();
        }


        Color Active = Color.Black;
        Color Passive = Color.FromArgb(72, 55, 71);
        Color ActiveBack = Color.FromArgb(180, 120, 186);
        Color PassiveBack = Color.FromArgb(123, 60, 130);
        Color ReadyBack = Color.FromArgb(255, 164, 102);



        int dataIsReady = 0;
        //Проверяет все ли данные введены.
        void IsReady()
        {
            if (dataIsReady == 5)
            {
                pictureBoxUser.Image = Image.FromFile(@"Pictures\AutorizationReady.png");
                pictureBoxEnter.Image = Image.FromFile(@"Pictures\AutorizationEnterReady.png");
            }
            else
            {
                pictureBoxUser.Image = Image.FromFile(@"Pictures\AutorizationPassive.png");
                pictureBoxEnter.Image = Image.FromFile(@"Pictures\AutorizationEnterPassive.png");
            }
        }
        void writeData()
        {
            if (dataIsReady == 5)
            {
                try
                {
                    DateTime dateTime = DateTime.Parse(textDate.Text);

                    ChoosenBot = new Bot(ChooseStyle());
                    Sex sex = (choosenMale) ? Sex.Male : Sex.Female;
                    ChoosenBot.User = new User(textName.Text, sex, dateTime);
                    ChoosenBot.User.Password = textPassword.Text;
                }
                catch
                {
                    MessageBox.Show("Данные некорректны!");
                    return;
                }
                Close();
            }
        }



        //Закрытие формы
        private void Close_MouseMove(object sender, MouseEventArgs e)
        {
            Close.BackColor = Color.FromArgb(216, 94, 94);
            Hide.BackColor = PassiveBack;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }



        //Сворачивание формы
        private void Hide_MouseMove(object sender, MouseEventArgs e)
        {
            Hide.BackColor = Passive;
            Close.BackColor = PassiveBack;
        }
        private void Hide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide.BackColor = PassiveBack;
        }



        //Значек авторизации
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dataIsReady != 5)
                pictureBoxUser.Image = Image.FromFile(@"Pictures\AutorizationActive.png");
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            labelName.ForeColor = Active;
        }



        //Действие при выходе из выше перечисленных
        private void Autorization_MouseMove(object sender, MouseEventArgs e)
        {
            Close.BackColor = PassiveBack;
            Hide.BackColor = PassiveBack;
            if (dataIsReady != 5)
                pictureBoxUser.Image = Image.FromFile(@"Pictures\AutorizationPassive.png");
            labelName.ForeColor = Passive;
        }



        //Мужской пол
        bool choosenMale = false;
        private void pictureBoxMale_MouseMove(object sender, MouseEventArgs e)
        {
            if (!choosenMale)
                pictureBoxMale.Image = Image.FromFile(@"Pictures\AutorizationMaleActive.png");
        }
        private void pictureBoxMale_MouseLeave(object sender, EventArgs e)
        {
            if (!choosenMale)
                pictureBoxMale.Image = Image.FromFile(@"Pictures\AutorizationMalePassive.png");
        }
        private void pictureBoxMale_Click(object sender, EventArgs e)
        {
            if (!choosenMale && !choosenFemale)
            {
                dataIsReady++;
                IsReady();
            }

            pictureBoxMale.Image = Image.FromFile(@"Pictures\AutorizationMaleReady.png");
            pictureBoxFemale.Image = Image.FromFile(@"Pictures\AutorizationFemalePassive.png");
            choosenMale = true;
            choosenFemale = false;
        }



        //Женский пол
        bool choosenFemale = false;
        private void pictureBoxFemale_MouseMove(object sender, MouseEventArgs e)
        {
            if (!choosenFemale)
                pictureBoxFemale.Image = Image.FromFile(@"Pictures\AutorizationFemaleActive.png");
        }
        private void pictureBoxFemale_MouseLeave(object sender, EventArgs e)
        {
            if (!choosenFemale)
                pictureBoxFemale.Image = Image.FromFile(@"Pictures\AutorizationFemalePassive.png");
        }
        private void pictureBoxFemale_Click(object sender, EventArgs e)
        {
            if (!choosenMale && !choosenFemale)
            {
                dataIsReady++;
                IsReady();
            }


            pictureBoxFemale.Image = Image.FromFile(@"Pictures\AutorizationFemaleReady.png");
            pictureBoxMale.Image = Image.FromFile(@"Pictures\AutorizationMalePassive.png");
            choosenMale = false;
            choosenFemale = true;
        }



        //Поле ввода имени
        bool activeName = false;
        private void textName_MouseMove(object sender, MouseEventArgs e)
        {
            panelName.BackColor = ReadyBack;
        }
        private void textName_MouseLeave(object sender, EventArgs e)
        {
            if (!activeName)
                panelName.BackColor = ActiveBack;
        }
        private void textName_TextChanged(object sender, EventArgs e)
        {
            if (textName.Text.Length == 0)
            {
                dataIsReady--;
                IsReady();


                activeName = false;
                panelName.BackColor = ActiveBack;
                pictureName.Image = Image.FromFile(@"Pictures\AutorizationNamePassive.png");
            }
            else
            {
                if (activeName != true) dataIsReady++;
                IsReady();

                activeName = true;
                panelName.BackColor = ReadyBack;
                pictureName.Image = Image.FromFile(@"Pictures\AutorizationNameReady.png");
            }
        }
        private void pictureName_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activeName)
                pictureName.Image = Image.FromFile(@"Pictures\AutorizationNameActive.png");
        }
        private void pictureName_MouseLeave(object sender, EventArgs e)
        {
            if (!activeName)
                pictureName.Image = Image.FromFile(@"Pictures\AutorizationNamePassive.png");
        }
        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                writeData();
        }



        //Поле ввода даты
        bool activeDate = false;
        private void textDate_MouseMove_1(object sender, MouseEventArgs e)
        {
            panelDate.BackColor = ReadyBack;
        }
        private void textDate_MouseLeave_1(object sender, EventArgs e)
        {
            if (!activeDate)
                panelDate.BackColor = ActiveBack;
        }
        private void textDate_TextChanged_1(object sender, EventArgs e)
        {
            if (textDate.Text.Length == 0)
            {
                dataIsReady--;
                IsReady();


                activeDate = false;
                panelDate.BackColor = ActiveBack;
                pictureDate.Image = Image.FromFile(@"Pictures\AutorizationDatePassive.png");
            }
            else
            {
                if (activeDate != true) dataIsReady++;
                IsReady();


                activeDate = true;
                panelDate.BackColor = ReadyBack;
                pictureDate.Image = Image.FromFile(@"Pictures\AutorizationDateReady.png");
            }
        }
        private void pictureDate_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activeDate)
                pictureDate.Image = Image.FromFile(@"Pictures\AutorizationDateActive.png");
        }
        private void pictureDate_MouseLeave(object sender, EventArgs e)
        {
            if (!activeDate)
                pictureDate.Image = Image.FromFile(@"Pictures\AutorizationDatePassive.png");
        }
        private void textDate_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                writeData();
        }



        //Поле ввода пароля
        bool activePassword = false;
        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            panelPassword.BackColor = ReadyBack;
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!activePassword)
                panelPassword.BackColor = ActiveBack;
        }
        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            if (textPassword.Text.Length == 0)
            {
                dataIsReady--;
                IsReady();


                activePassword = false;
                panelPassword.BackColor = ActiveBack;
                pictureKey.Image = Image.FromFile(@"Pictures\AutorizationKeyPassive.png");
            }
            else
            {
                if (activePassword != true) dataIsReady++;
                IsReady();


                activePassword = true;
                panelPassword.BackColor = ReadyBack;
                pictureKey.Image = Image.FromFile(@"Pictures\AutorizationKeyReady.png");
            }
        }
        private void pictureKey_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activePassword)
                pictureKey.Image = Image.FromFile(@"Pictures\AutorizationKeyActive.png");
        }
        private void pictureKey_MouseLeave(object sender, EventArgs e)
        {
            if (!activePassword)
                pictureKey.Image = Image.FromFile(@"Pictures\AutorizationKeyPassive.png");
        }
   
        bool passwordActive = false;
        private void Glass_MouseMove(object sender, MouseEventArgs e)
        {
            if (!passwordActive)
                Glass.Image = Image.FromFile(@"Pictures\AutorizationWatchActiveMove.png");
        }
        private void Glass_MouseLeave(object sender, EventArgs e)
        {
            if (!passwordActive)
                Glass.Image = Image.FromFile(@"Pictures\AutorizationWatchPassive.png");
        }
        private void Glass_Click(object sender, EventArgs e)
        {
            if (!passwordActive)
            {
                Glass.Image = Image.FromFile(@"Pictures\AutorizationWatchActive.png");
                passwordActive = true;
                textPassword.UseSystemPasswordChar = false;
            }
            else
            {
                Glass.Image = Image.FromFile(@"Pictures\AutorizationWatchPassive.png");
                passwordActive = false;
                textPassword.UseSystemPasswordChar = true;
            }

        }
        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                writeData();
        }



        //Подтверждение введенных данных
        private void pictureBoxEnter_MouseMove(object sender, MouseEventArgs e)
        {
            if (dataIsReady != 5)
                pictureBoxEnter.Image = Image.FromFile(@"Pictures\AutorizationEnterActive.png");
        }
        private void pictureBoxEnter_MouseLeave(object sender, EventArgs e)
        {
            if (dataIsReady != 5)
                pictureBoxEnter.Image = Image.FromFile(@"Pictures\AutorizationEnterPassive.png");
        }



        //Подтверждение
        private void pictureBoxEnter_Click(object sender, EventArgs e)
        {
            writeData();
        }



        //Выбор простого бота
        bool activeSimple = false;
        private void simpleBot_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activeSimple)
                simpleBot.Image = Image.FromFile(@"Pictures\AutorizationBotSimpleActive.png");
            labelSimple.Show();
        }
        private void simpleBot_MouseLeave(object sender, EventArgs e)
        {
            if (!activeSimple)
                simpleBot.Image = Image.FromFile(@"Pictures\AutorizationBotSimplePassive.png");
            labelSimple.Hide();
        }
        private void simpleBot_Click(object sender, EventArgs e)
        {
            if (activeSimple)
            {
                activeSimple = false;
                simpleBot.Image = Image.FromFile(@"Pictures\AutorizationBotSimpleActive.png");
                dataIsReady--;
                IsReady();
                return;
            }
            activeSimple = true;
            activeEvil = false;
            activePank = false;
            evilBot.Image = Image.FromFile(@"Pictures\AutorizationBotEvilPassive.png");
            pankBot.Image = Image.FromFile(@"Pictures\AutorizationBotPankPassive.png");
            simpleBot.Image = Image.FromFile(@"Pictures\AutorizationBotSimpleReady.png");

            dataIsReady++;
            IsReady();
        }



        //Выбор злого бота
        bool activeEvil = false;
        private void evilBot_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activeEvil)
                evilBot.Image = Image.FromFile(@"Pictures\AutorizationBotEvilActive.png");
            labelEvil.Show();
        }
        private void evilBot_MouseLeave(object sender, EventArgs e)
        {
            if (!activeEvil)
                evilBot.Image = Image.FromFile(@"Pictures\AutorizationBotEvilPassive.png");
            labelEvil.Hide();
        }



        //Выбор бота панка
        bool activePank = false;
        private void pankBot_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activePank)
                pankBot.Image = Image.FromFile(@"Pictures\AutorizationBotPankActive.png");
            labelPank.Show();
        }
        private void pankBot_MouseLeave(object sender, EventArgs e)
        {
            if (!activePank)
                pankBot.Image = Image.FromFile(@"Pictures\AutorizationBotPankPassive.png");
            labelPank.Hide();
        }



        private void label1_MouseMove_1(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Active;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Passive;
        }
    }
}
