namespace Project
{
    partial class MemberForm
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
            name_label = new Label();
            name_textbox = new TextBox();
            surname_textbox = new TextBox();
            second_name_label = new Label();
            description_label = new Label();
            description_textbox = new TextBox();
            confirm_btn = new Button();
            SuspendLayout();
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 12F);
            name_label.Location = new Point(15, 11);
            name_label.Margin = new Padding(4, 0, 4, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(125, 32);
            name_label.TabIndex = 0;
            name_label.Text = "First name";
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Segoe UI", 12F);
            name_textbox.ImeMode = ImeMode.NoControl;
            name_textbox.Location = new Point(15, 50);
            name_textbox.Margin = new Padding(4);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(350, 39);
            name_textbox.TabIndex = 1;
            name_textbox.KeyPress += input_filter;
            // 
            // surname_textbox
            // 
            surname_textbox.Font = new Font("Segoe UI", 12F);
            surname_textbox.ImeMode = ImeMode.NoControl;
            surname_textbox.Location = new Point(15, 135);
            surname_textbox.Margin = new Padding(4);
            surname_textbox.Name = "surname_textbox";
            surname_textbox.Size = new Size(350, 39);
            surname_textbox.TabIndex = 3;
            // 
            // second_name_label
            // 
            second_name_label.AutoSize = true;
            second_name_label.Font = new Font("Segoe UI", 12F);
            second_name_label.Location = new Point(15, 96);
            second_name_label.Margin = new Padding(4, 0, 4, 0);
            second_name_label.Name = "second_name_label";
            second_name_label.Size = new Size(160, 32);
            second_name_label.TabIndex = 2;
            second_name_label.Text = "Second name";
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Font = new Font("Segoe UI", 12F);
            description_label.Location = new Point(15, 181);
            description_label.Margin = new Padding(4, 0, 4, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(135, 32);
            description_label.TabIndex = 4;
            description_label.Text = "Description";
            // 
            // description_textbox
            // 
            description_textbox.Font = new Font("Segoe UI", 12F);
            description_textbox.Location = new Point(15, 232);
            description_textbox.Margin = new Padding(4);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(350, 248);
            description_textbox.TabIndex = 5;
            // 
            // create_btn
            // 
            confirm_btn.Location = new Point(15, 489);
            confirm_btn.Margin = new Padding(4);
            confirm_btn.Name = "create_btn";
            confirm_btn.Size = new Size(351, 59);
            confirm_btn.TabIndex = 6;
            confirm_btn.Text = "Create";
            confirm_btn.UseVisualStyleBackColor = true;
            confirm_btn.Click += create_btn_Click;
            // 
            // MemberForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 562);
            Controls.Add(confirm_btn);
            Controls.Add(description_textbox);
            Controls.Add(description_label);
            Controls.Add(surname_textbox);
            Controls.Add(second_name_label);
            Controls.Add(name_textbox);
            Controls.Add(name_label);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "MemberForm";
            Text = "CreateMember";
            Load += CreateMember_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_label;
        private TextBox name_textbox;
        private TextBox surname_textbox;
        private Label second_name_label;
        private Label description_label;
        private TextBox description_textbox;
        private Button confirm_btn;
    }
}