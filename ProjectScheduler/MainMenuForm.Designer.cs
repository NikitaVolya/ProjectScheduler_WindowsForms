namespace Project
{
    partial class MainMenuForm
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
            recent_project_listbox = new ListBox();
            create_project_btn = new Button();
            add_project_btn = new Button();
            openFileDialog1 = new OpenFileDialog();
            remove_project_btn = new Button();
            SuspendLayout();
            // 
            // recent_project_listbox
            // 
            recent_project_listbox.FormattingEnabled = true;
            recent_project_listbox.ItemHeight = 25;
            recent_project_listbox.Location = new Point(15, 15);
            recent_project_listbox.Margin = new Padding(4, 4, 4, 4);
            recent_project_listbox.Name = "recent_project_listbox";
            recent_project_listbox.Size = new Size(874, 529);
            recent_project_listbox.TabIndex = 0;
            recent_project_listbox.SelectedIndexChanged += recent_project_listbox_SelectedIndexChanged;
            recent_project_listbox.DoubleClick += recent_project_listbox_DoubleClick;
            // 
            // create_project_btn
            // 
            create_project_btn.Location = new Point(898, 15);
            create_project_btn.Margin = new Padding(4, 4, 4, 4);
            create_project_btn.Name = "create_project_btn";
            create_project_btn.Size = new Size(291, 64);
            create_project_btn.TabIndex = 1;
            create_project_btn.Text = "Create project";
            create_project_btn.UseVisualStyleBackColor = true;
            create_project_btn.Click += create_project_btn_Click;
            // 
            // add_project_btn
            // 
            add_project_btn.Location = new Point(898, 158);
            add_project_btn.Margin = new Padding(4, 4, 4, 4);
            add_project_btn.Name = "add_project_btn";
            add_project_btn.Size = new Size(291, 64);
            add_project_btn.TabIndex = 2;
            add_project_btn.Text = "Add local project";
            add_project_btn.UseVisualStyleBackColor = true;
            add_project_btn.Click += add_project_btn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // remove_project_btn
            // 
            remove_project_btn.Location = new Point(898, 86);
            remove_project_btn.Margin = new Padding(4, 4, 4, 4);
            remove_project_btn.Name = "remove_project_btn";
            remove_project_btn.Size = new Size(291, 64);
            remove_project_btn.TabIndex = 3;
            remove_project_btn.Text = "Remove project";
            remove_project_btn.UseVisualStyleBackColor = true;
            remove_project_btn.Click += remove_project_btn_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 562);
            Controls.Add(remove_project_btn);
            Controls.Add(add_project_btn);
            Controls.Add(create_project_btn);
            Controls.Add(recent_project_listbox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainMenuForm";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox recent_project_listbox;
        private Button create_project_btn;
        private Button add_project_btn;
        private OpenFileDialog openFileDialog1;
        private Button remove_project_btn;
    }
}