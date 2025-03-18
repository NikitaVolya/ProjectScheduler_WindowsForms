namespace ProjectScheduler
{
    partial class ProjectPropertiesForm
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
            members_label = new Label();
            delete_member_btn = new Button();
            add_member_btn = new Button();
            members_listbox = new ListBox();
            description_textbox = new TextBox();
            description_label = new Label();
            name_textbox = new TextBox();
            name_label = new Label();
            categories_label = new Label();
            categories_listbox = new ListBox();
            delete_category_btn = new Button();
            add_category_btn = new Button();
            change_btn = new Button();
            SuspendLayout();
            // 
            // members_label
            // 
            members_label.AutoSize = true;
            members_label.Font = new Font("Segoe UI", 15F);
            members_label.Location = new Point(462, 8);
            members_label.Margin = new Padding(4, 0, 4, 0);
            members_label.Name = "members_label";
            members_label.Size = new Size(243, 41);
            members_label.TabIndex = 17;
            members_label.Text = "Project members";
            // 
            // delete_member_btn
            // 
            delete_member_btn.Location = new Point(706, 488);
            delete_member_btn.Margin = new Padding(4);
            delete_member_btn.Name = "delete_member_btn";
            delete_member_btn.Size = new Size(222, 56);
            delete_member_btn.TabIndex = 16;
            delete_member_btn.Text = "delete project member";
            delete_member_btn.UseVisualStyleBackColor = true;
            delete_member_btn.Click += delete_member_btn_Click;
            // 
            // add_member_btn
            // 
            add_member_btn.Location = new Point(462, 488);
            add_member_btn.Margin = new Padding(4);
            add_member_btn.Name = "add_member_btn";
            add_member_btn.Size = new Size(222, 56);
            add_member_btn.TabIndex = 15;
            add_member_btn.Text = "add project member";
            add_member_btn.UseVisualStyleBackColor = true;
            add_member_btn.Click += add_member_btn_Click;
            // 
            // members_listbox
            // 
            members_listbox.Font = new Font("Segoe UI", 12F);
            members_listbox.FormattingEnabled = true;
            members_listbox.ItemHeight = 32;
            members_listbox.Location = new Point(462, 56);
            members_listbox.Margin = new Padding(4);
            members_listbox.Name = "members_listbox";
            members_listbox.Size = new Size(465, 420);
            members_listbox.TabIndex = 14;
            members_listbox.DoubleClick += members_listbox_DoubleClick;
            // 
            // description_textbox
            // 
            description_textbox.Font = new Font("Segoe UI", 15F);
            description_textbox.Location = new Point(7, 216);
            description_textbox.Margin = new Padding(4);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(429, 249);
            description_textbox.TabIndex = 12;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Font = new Font("Segoe UI", 15F);
            description_label.Location = new Point(7, 168);
            description_label.Margin = new Padding(4, 0, 4, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(266, 41);
            description_label.TabIndex = 11;
            description_label.Text = "Project description";
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Segoe UI", 15F);
            name_textbox.Location = new Point(7, 56);
            name_textbox.Margin = new Padding(4);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(429, 47);
            name_textbox.TabIndex = 10;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 15F);
            name_label.Location = new Point(7, 8);
            name_label.Margin = new Padding(4, 0, 4, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(192, 41);
            name_label.TabIndex = 9;
            name_label.Text = "Project name";
            // 
            // categories_label
            // 
            categories_label.AutoSize = true;
            categories_label.Font = new Font("Segoe UI", 15F);
            categories_label.Location = new Point(957, 9);
            categories_label.Margin = new Padding(4, 0, 4, 0);
            categories_label.Name = "categories_label";
            categories_label.Size = new Size(255, 41);
            categories_label.TabIndex = 18;
            categories_label.Text = "Project categories";
            // 
            // categories_listbox
            // 
            categories_listbox.Font = new Font("Segoe UI", 12F);
            categories_listbox.FormattingEnabled = true;
            categories_listbox.ItemHeight = 32;
            categories_listbox.Location = new Point(957, 56);
            categories_listbox.Margin = new Padding(4);
            categories_listbox.Name = "categories_listbox";
            categories_listbox.Size = new Size(465, 420);
            categories_listbox.TabIndex = 19;
            categories_listbox.DoubleClick += categories_listbox_DoubleClick;
            // 
            // delete_category_btn
            // 
            delete_category_btn.Location = new Point(1200, 488);
            delete_category_btn.Margin = new Padding(4);
            delete_category_btn.Name = "delete_category_btn";
            delete_category_btn.Size = new Size(222, 56);
            delete_category_btn.TabIndex = 21;
            delete_category_btn.Text = "delete project category";
            delete_category_btn.UseVisualStyleBackColor = true;
            delete_category_btn.Click += delete_category_btn_Click;
            // 
            // add_category_btn
            // 
            add_category_btn.Location = new Point(956, 488);
            add_category_btn.Margin = new Padding(4);
            add_category_btn.Name = "add_category_btn";
            add_category_btn.Size = new Size(222, 56);
            add_category_btn.TabIndex = 20;
            add_category_btn.Text = "add project category";
            add_category_btn.UseVisualStyleBackColor = true;
            add_category_btn.Click += add_category_btn_Click;
            // 
            // change_btn
            // 
            change_btn.Location = new Point(7, 488);
            change_btn.Name = "change_btn";
            change_btn.Size = new Size(429, 56);
            change_btn.TabIndex = 22;
            change_btn.Text = "Change name and description";
            change_btn.UseVisualStyleBackColor = true;
            change_btn.Click += confirm_btn_Click;
            // 
            // ProjectPropertiesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1446, 557);
            Controls.Add(change_btn);
            Controls.Add(delete_category_btn);
            Controls.Add(add_category_btn);
            Controls.Add(categories_listbox);
            Controls.Add(categories_label);
            Controls.Add(members_label);
            Controls.Add(delete_member_btn);
            Controls.Add(add_member_btn);
            Controls.Add(members_listbox);
            Controls.Add(description_textbox);
            Controls.Add(description_label);
            Controls.Add(name_textbox);
            Controls.Add(name_label);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ProjectPropertiesForm";
            Text = "ProjectProperties";
            Load += ProjectProperties_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label members_label;
        private Button delete_member_btn;
        private Button add_member_btn;
        private ListBox members_listbox;
        private TextBox description_textbox;
        private Label description_label;
        private TextBox name_textbox;
        private Label name_label;
        private Label categories_label;
        private ListBox categories_listbox;
        private Button delete_category_btn;
        private Button add_category_btn;
        private Button change_btn;
    }
}