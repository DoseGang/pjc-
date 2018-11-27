namespace WindowsFormsApp2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UserChat = new System.Windows.Forms.TextBox();
            this.UserMessage = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged In";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // UserChat
            // 
            this.UserChat.AccessibleName = "UserChat";
            this.UserChat.Location = new System.Drawing.Point(452, 48);
            this.UserChat.Multiline = true;
            this.UserChat.Name = "UserChat";
            this.UserChat.Size = new System.Drawing.Size(585, 378);
            this.UserChat.TabIndex = 1;
            // 
            // UserMessage
            // 
            this.UserMessage.AccessibleName = "UserMessage";
            this.UserMessage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.UserMessage.Location = new System.Drawing.Point(452, 462);
            this.UserMessage.Multiline = true;
            this.UserMessage.Name = "UserMessage";
            this.UserMessage.Size = new System.Drawing.Size(584, 52);
            this.UserMessage.TabIndex = 2;
            this.UserMessage.Text = "Type your message here...";
            this.UserMessage.TextChanged += new System.EventHandler(this.UserMessage_TextChanged);
            this.UserMessage.Enter += new System.EventHandler(this.UserMessage_Focus);
            this.UserMessage.Leave += new System.EventHandler(this.UserMessage_Focus2);
            // 
            // Send
            // 
            this.Send.AccessibleName = "Send";
            this.Send.Location = new System.Drawing.Point(918, 520);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(118, 28);
            this.Send.TabIndex = 3;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Sports",
            "C#",
            "It",
            "Internships",
            "Finances"});
            this.listBox1.Location = new System.Drawing.Point(24, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(361, 420);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.UserMessage);
            this.Controls.Add(this.UserChat);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserChat;
        private System.Windows.Forms.TextBox UserMessage;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.ListBox listBox1;
    }
}