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
            this.Add = new System.Windows.Forms.Button();
            this.addTopic = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged In\r\n\r\n";
            this.label1.Click += new System.EventHandler(this.label1_);
            this.label1.Enter += new System.EventHandler(this.label1_);
            this.label1.Leave += new System.EventHandler(this.label1_);
            // 
            // UserChat
            // 
            this.UserChat.AccessibleName = "UserChat";
            this.UserChat.Location = new System.Drawing.Point(339, 39);
            this.UserChat.Margin = new System.Windows.Forms.Padding(2);
            this.UserChat.Multiline = true;
            this.UserChat.Name = "UserChat";
            this.UserChat.ReadOnly = true;
            this.UserChat.Size = new System.Drawing.Size(440, 308);
            this.UserChat.TabIndex = 1;
            this.UserChat.TextChanged += new System.EventHandler(this.UserChat_TextChanged);
            // 
            // UserMessage
            // 
            this.UserMessage.AccessibleName = "UserMessage";
            this.UserMessage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.UserMessage.Location = new System.Drawing.Point(339, 375);
            this.UserMessage.Margin = new System.Windows.Forms.Padding(2);
            this.UserMessage.Multiline = true;
            this.UserMessage.Name = "UserMessage";
            this.UserMessage.Size = new System.Drawing.Size(439, 43);
            this.UserMessage.TabIndex = 2;
            this.UserMessage.Text = "Type your message here...";
            this.UserMessage.TextChanged += new System.EventHandler(this.UserMessage_TextChanged);
            this.UserMessage.Enter += new System.EventHandler(this.UserMessage_Focus);
            this.UserMessage.Leave += new System.EventHandler(this.UserMessage_Focus2);
            // 
            // Send
            // 
            this.Send.AccessibleName = "Send";
            this.Send.Location = new System.Drawing.Point(688, 422);
            this.Send.Margin = new System.Windows.Forms.Padding(2);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(88, 23);
            this.Send.TabIndex = 3;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Sports",
            "C#",
            "It",
            "Internships",
            "Finances",
            "Music"});
            this.listBox1.Location = new System.Drawing.Point(18, 29);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(272, 342);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // Add
            // 
            this.Add.AccessibleDescription = "Add";
            this.Add.AccessibleName = "Add";
            this.Add.Location = new System.Drawing.Point(134, 394);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(25, 20);
            this.Add.TabIndex = 6;
            this.Add.Text = "+";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.button2_Click);
            // 
            // addTopic
            // 
            this.addTopic.AccessibleDescription = "addTopic";
            this.addTopic.AccessibleName = "addTopic";
            this.addTopic.Location = new System.Drawing.Point(18, 394);
            this.addTopic.MaxLength = 15;
            this.addTopic.Name = "addTopic";
            this.addTopic.Size = new System.Drawing.Size(100, 20);
            this.addTopic.TabIndex = 7;
            this.addTopic.Text = "Add a Topic";
            this.addTopic.TextChanged += new System.EventHandler(this.addTopic_TextChanged);
            // 
            // Form2
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addTopic);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.UserMessage);
            this.Controls.Add(this.UserChat);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Activated += new System.EventHandler(this.label1_);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserChat;
        private System.Windows.Forms.TextBox UserMessage;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox addTopic;
    }
}