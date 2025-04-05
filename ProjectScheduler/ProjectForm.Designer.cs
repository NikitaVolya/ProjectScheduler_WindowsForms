namespace ProjectScheduler
{
    partial class ProjectForm
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
            description_textbox = new TextBox();
            description_label = new Label();
            create_btn = new Button();
            members_listbox = new ListBox();
            button1 = new Button();
            delete_member_btn = new Button();
            members_label = new Label();
            SuspendLayout();
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 15F);
            name_label.Location = new Point(12, 9);
            name_label.Name = "name_label";
            name_label.Size = new Size(161, 35);
            name_label.TabIndex = 0;
            name_label.Text = "Project name";
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Segoe UI", 15F);
            name_textbox.Location = new Point(12, 47);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(344, 41);
            name_textbox.TabIndex = 1;
            // 
            // description_textbox
            // 
            description_textbox.Font = new Font("Segoe UI", 15F);
            description_textbox.Location = new Point(12, 175);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(344, 200);
            description_textbox.TabIndex = 3;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Font = new Font("Segoe UI", 15F);
            description_label.Location = new Point(12, 137);
            description_label.Name = "description_label";
            description_label.Size = new Size(223, 35);
            description_label.TabIndex = 2;
            description_label.Text = "Project description";
            // 
            // create_btn
            // 
            create_btn.Location = new Point(12, 393);
            create_btn.Name = "create_btn";
            create_btn.Size = new Size(344, 45);
            create_btn.TabIndex = 4;
            create_btn.Text = "Create project";
            create_btn.UseVisualStyleBackColor = true;
            create_btn.Click += create_btn_Click;
            // 
            // members_listbox
            // 
            members_listbox.Font = new Font("Segoe UI", 12F);
            members_listbox.FormattingEnabled = true;
            members_listbox.ItemHeight = 28;
            members_listbox.Location = new Point(376, 47);
            members_listbox.Name = "members_listbox";
            members_listbox.Size = new Size(373, 312);
            members_listbox.TabIndex = 5;
            members_listbox.DoubleClick += members_listbox_DoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(376, 393);
            button1.Name = "button1";
            button1.Size = new Size(178, 45);
            button1.TabIndex = 6;
            button1.Text = "add project member";
            button1.UseVisualStyleBackColor = true;
            button1.Click += add_member_btn_Click;
            // 
            // delete_member_btn
            // 
            delete_member_btn.Location = new Point(571, 393);
            delete_member_btn.Name = "delete_member_btn";
            delete_member_btn.Size = new Size(178, 45);
            delete_member_btn.TabIndex = 7;
            delete_member_btn.Text = "delete project member";
            delete_member_btn.UseVisualStyleBackColor = true;
            delete_member_btn.Click += delete_member_btn_Click;
            // 
            // members_label
            // 
            members_label.AutoSize = true;
            members_label.Font = new Font("Segoe UI", 15F);
            members_label.Location = new Point(376, 9);
            members_label.Name = "members_label";
            members_label.Size = new Size(204, 35);
            members_label.TabIndex = 8;
            members_label.Text = "Project members";
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 450);
            Controls.Add(members_label);
            Controls.Add(delete_member_btn);
            Controls.Add(button1);
            Controls.Add(members_listbox);
            Controls.Add(create_btn);
            Controls.Add(description_textbox);
            Controls.Add(description_label);
            Controls.Add(name_textbox);
            Controls.Add(name_label);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ProjectForm";
            Text = "CreateProjectForm";
            FormClosed += CreateProjectForm_FormClosed;
            Load += CreateProjectForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_label;
        private TextBox name_textbox;
        private TextBox description_textbox;
        private Label description_label;
        private Button create_btn;
        private ListBox members_listbox;
        private Button button1;
        private Button delete_member_btn;
        private Label members_label;
    }
}