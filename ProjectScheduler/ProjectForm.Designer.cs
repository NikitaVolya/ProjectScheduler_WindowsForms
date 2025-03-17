namespace Project
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
            choice_location_btn = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 15F);
            name_label.Location = new Point(15, 11);
            name_label.Margin = new Padding(4, 0, 4, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(192, 41);
            name_label.TabIndex = 0;
            name_label.Text = "Project name";
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Segoe UI", 15F);
            name_textbox.Location = new Point(15, 59);
            name_textbox.Margin = new Padding(4, 4, 4, 4);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(429, 47);
            name_textbox.TabIndex = 1;
            // 
            // description_textbox
            // 
            description_textbox.Font = new Font("Segoe UI", 15F);
            description_textbox.Location = new Point(15, 219);
            description_textbox.Margin = new Padding(4, 4, 4, 4);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(429, 249);
            description_textbox.TabIndex = 3;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Font = new Font("Segoe UI", 15F);
            description_label.Location = new Point(15, 171);
            description_label.Margin = new Padding(4, 0, 4, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(266, 41);
            description_label.TabIndex = 2;
            description_label.Text = "Project description";
            // 
            // create_btn
            // 
            create_btn.Location = new Point(15, 491);
            create_btn.Margin = new Padding(4, 4, 4, 4);
            create_btn.Name = "create_btn";
            create_btn.Size = new Size(430, 56);
            create_btn.TabIndex = 4;
            create_btn.Text = "Create project";
            create_btn.UseVisualStyleBackColor = true;
            create_btn.Click += create_btn_Click;
            // 
            // members_listbox
            // 
            members_listbox.Font = new Font("Segoe UI", 12F);
            members_listbox.FormattingEnabled = true;
            members_listbox.ItemHeight = 32;
            members_listbox.Location = new Point(470, 59);
            members_listbox.Margin = new Padding(4, 4, 4, 4);
            members_listbox.Name = "members_listbox";
            members_listbox.Size = new Size(465, 420);
            members_listbox.TabIndex = 5;
            members_listbox.DoubleClick += members_listbox_DoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(470, 491);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(222, 56);
            button1.TabIndex = 6;
            button1.Text = "add project member";
            button1.UseVisualStyleBackColor = true;
            button1.Click += add_member_btn_Click;
            // 
            // delete_member_btn
            // 
            delete_member_btn.Location = new Point(714, 491);
            delete_member_btn.Margin = new Padding(4, 4, 4, 4);
            delete_member_btn.Name = "delete_member_btn";
            delete_member_btn.Size = new Size(222, 56);
            delete_member_btn.TabIndex = 7;
            delete_member_btn.Text = "delete project member";
            delete_member_btn.UseVisualStyleBackColor = true;
            delete_member_btn.Click += delete_member_btn_Click;
            // 
            // members_label
            // 
            members_label.AutoSize = true;
            members_label.Font = new Font("Segoe UI", 15F);
            members_label.Location = new Point(470, 11);
            members_label.Margin = new Padding(4, 0, 4, 0);
            members_label.Name = "members_label";
            members_label.Size = new Size(243, 41);
            members_label.TabIndex = 8;
            members_label.Text = "Project members";
            // 
            // choice_location_btn
            // 
            choice_location_btn.Location = new Point(15, 118);
            choice_location_btn.Margin = new Padding(4, 4, 4, 4);
            choice_location_btn.Name = "choice_location_btn";
            choice_location_btn.Size = new Size(430, 50);
            choice_location_btn.TabIndex = 9;
            choice_location_btn.Text = "Chose location";
            choice_location_btn.UseVisualStyleBackColor = true;
            choice_location_btn.Click += choice_location_btn_Click;
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 562);
            Controls.Add(choice_location_btn);
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
            Margin = new Padding(4, 4, 4, 4);
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
        private Button choice_location_btn;
        private FolderBrowserDialog folderBrowserDialog;
    }
}