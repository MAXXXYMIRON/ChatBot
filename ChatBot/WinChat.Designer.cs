namespace ChatBot
{
    partial class WinChat
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelChat = new System.Windows.Forms.Panel();
            this.sizeLeft = new System.Windows.Forms.Panel();
            this.sizeRight = new System.Windows.Forms.Panel();
            this.sizeDown = new System.Windows.Forms.Panel();
            this.sizeAngleRight = new System.Windows.Forms.Panel();
            this.sizeAngleLeft = new System.Windows.Forms.Panel();
            this.panelSeporator = new System.Windows.Forms.Panel();
            this.inputText = new System.Windows.Forms.RichTextBox();
            this.movingTop = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.panelHide = new System.Windows.Forms.Panel();
            this.panelClose = new System.Windows.Forms.Panel();
            this.movingTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChat
            // 
            this.panelChat.AutoScroll = true;
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(120)))), ((int)(((byte)(186)))));
            this.panelChat.Location = new System.Drawing.Point(16, 30);
            this.panelChat.Margin = new System.Windows.Forms.Padding(4);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(848, 350);
            this.panelChat.TabIndex = 0;
            // 
            // sizeLeft
            // 
            this.sizeLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sizeLeft.Location = new System.Drawing.Point(0, 30);
            this.sizeLeft.Margin = new System.Windows.Forms.Padding(4);
            this.sizeLeft.Name = "sizeLeft";
            this.sizeLeft.Size = new System.Drawing.Size(16, 439);
            this.sizeLeft.TabIndex = 1;
            this.sizeLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeLeft_MouseDown);
            // 
            // sizeRight
            // 
            this.sizeRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sizeRight.Location = new System.Drawing.Point(864, 30);
            this.sizeRight.Margin = new System.Windows.Forms.Padding(4);
            this.sizeRight.Name = "sizeRight";
            this.sizeRight.Size = new System.Drawing.Size(16, 439);
            this.sizeRight.TabIndex = 2;
            this.sizeRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeRight_MouseDown);
            // 
            // sizeDown
            // 
            this.sizeDown.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.sizeDown.Location = new System.Drawing.Point(16, 469);
            this.sizeDown.Margin = new System.Windows.Forms.Padding(4);
            this.sizeDown.Name = "sizeDown";
            this.sizeDown.Size = new System.Drawing.Size(848, 15);
            this.sizeDown.TabIndex = 3;
            this.sizeDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeDown_MouseDown);
            // 
            // sizeAngleRight
            // 
            this.sizeAngleRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sizeAngleRight.Location = new System.Drawing.Point(864, 469);
            this.sizeAngleRight.Margin = new System.Windows.Forms.Padding(4);
            this.sizeAngleRight.Name = "sizeAngleRight";
            this.sizeAngleRight.Size = new System.Drawing.Size(16, 15);
            this.sizeAngleRight.TabIndex = 4;
            this.sizeAngleRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeAngleRight_MouseDown);
            // 
            // sizeAngleLeft
            // 
            this.sizeAngleLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.sizeAngleLeft.Location = new System.Drawing.Point(0, 469);
            this.sizeAngleLeft.Margin = new System.Windows.Forms.Padding(4);
            this.sizeAngleLeft.Name = "sizeAngleLeft";
            this.sizeAngleLeft.Size = new System.Drawing.Size(16, 15);
            this.sizeAngleLeft.TabIndex = 5;
            this.sizeAngleLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeAngleLeft_MouseDown);
            // 
            // panelSeporator
            // 
            this.panelSeporator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.panelSeporator.Location = new System.Drawing.Point(16, 380);
            this.panelSeporator.Margin = new System.Windows.Forms.Padding(4);
            this.panelSeporator.Name = "panelSeporator";
            this.panelSeporator.Size = new System.Drawing.Size(848, 15);
            this.panelSeporator.TabIndex = 6;
            // 
            // inputText
            // 
            this.inputText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.inputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputText.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputText.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputText.Location = new System.Drawing.Point(16, 395);
            this.inputText.Margin = new System.Windows.Forms.Padding(4);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(848, 74);
            this.inputText.TabIndex = 5;
            this.inputText.Text = "";
            this.inputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputText_KeyPress);
            // 
            // movingTop
            // 
            this.movingTop.Controls.Add(this.labelName);
            this.movingTop.Controls.Add(this.panelHide);
            this.movingTop.Controls.Add(this.panelClose);
            this.movingTop.Location = new System.Drawing.Point(0, 0);
            this.movingTop.Margin = new System.Windows.Forms.Padding(4);
            this.movingTop.MinimumSize = new System.Drawing.Size(880, 30);
            this.movingTop.Name = "movingTop";
            this.movingTop.Size = new System.Drawing.Size(880, 30);
            this.movingTop.TabIndex = 0;
            this.movingTop.DoubleClick += new System.EventHandler(this.movingTop_DoubleClick);
            this.movingTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(400, 1);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 29);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Chat";
            this.labelName.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // panelHide
            // 
            this.panelHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.panelHide.Location = new System.Drawing.Point(808, 14);
            this.panelHide.Margin = new System.Windows.Forms.Padding(4);
            this.panelHide.Name = "panelHide";
            this.panelHide.Size = new System.Drawing.Size(24, 12);
            this.panelHide.TabIndex = 1;
            this.panelHide.Click += new System.EventHandler(this.panelHide_Click);
            this.panelHide.MouseLeave += new System.EventHandler(this.panelHide_MouseLeave);
            this.panelHide.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHide_MouseMove);
            // 
            // panelClose
            // 
            this.panelClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.panelClose.Location = new System.Drawing.Point(840, 4);
            this.panelClose.Margin = new System.Windows.Forms.Padding(4);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(24, 22);
            this.panelClose.TabIndex = 0;
            this.panelClose.Click += new System.EventHandler(this.panelClose_Click);
            this.panelClose.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            this.panelClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // WinChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(880, 484);
            this.Controls.Add(this.movingTop);
            this.Controls.Add(this.panelSeporator);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.sizeAngleLeft);
            this.Controls.Add(this.sizeAngleRight);
            this.Controls.Add(this.sizeDown);
            this.Controls.Add(this.sizeRight);
            this.Controls.Add(this.sizeLeft);
            this.Controls.Add(this.panelChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WinChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат";
            this.movingTop.ResumeLayout(false);
            this.movingTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.Panel sizeLeft;
        private System.Windows.Forms.Panel sizeDown;
        private System.Windows.Forms.Panel sizeAngleRight;
        private System.Windows.Forms.Panel sizeAngleLeft;
        private System.Windows.Forms.Panel sizeRight;
        private System.Windows.Forms.Panel panelSeporator;
        private System.Windows.Forms.RichTextBox inputText;
        private System.Windows.Forms.Panel movingTop;
        private System.Windows.Forms.Panel panelClose;
        private System.Windows.Forms.Panel panelHide;
        private System.Windows.Forms.Label labelName;
    }
}

