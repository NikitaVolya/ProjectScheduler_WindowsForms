namespace ProjectScheduler
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
            components = new System.ComponentModel.Container();
            recent_project_listbox = new ListBox();
            projectContextMenuStrip = new ContextMenuStrip(components);
            copyNameToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            create_project_btn = new Button();
            remove_project_btn = new Button();
            projectContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // recent_project_listbox
            // 
            recent_project_listbox.ContextMenuStrip = projectContextMenuStrip;
            recent_project_listbox.FormattingEnabled = true;
            recent_project_listbox.Location = new Point(12, 12);
            recent_project_listbox.Name = "recent_project_listbox";
            recent_project_listbox.Size = new Size(700, 424);
            recent_project_listbox.TabIndex = 0;
            recent_project_listbox.DoubleClick += recent_project_listbox_DoubleClick;
            // 
            // projectContextMenuStrip
            // 
            projectContextMenuStrip.ImageScalingSize = new Size(24, 24);
            projectContextMenuStrip.Items.AddRange(new ToolStripItem[] { copyNameToolStripMenuItem, removeToolStripMenuItem });
            projectContextMenuStrip.Name = "contextMenuStrip1";
            projectContextMenuStrip.Size = new Size(152, 52);
            // 
            // copyNameToolStripMenuItem
            // 
            copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            copyNameToolStripMenuItem.Size = new Size(151, 24);
            copyNameToolStripMenuItem.Text = "copy name";
            copyNameToolStripMenuItem.Click += copyNameToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(210, 24);
            removeToolStripMenuItem.Text = "remove";
            removeToolStripMenuItem.Click += remove_project_btn_Click;
            // 
            // create_project_btn
            // 
            create_project_btn.Location = new Point(718, 12);
            create_project_btn.Name = "create_project_btn";
            create_project_btn.Size = new Size(233, 51);
            create_project_btn.TabIndex = 1;
            create_project_btn.Text = "Create project";
            create_project_btn.UseVisualStyleBackColor = true;
            create_project_btn.Click += create_project_btn_Click;
            // 
            // remove_project_btn
            // 
            remove_project_btn.Location = new Point(718, 69);
            remove_project_btn.Name = "remove_project_btn";
            remove_project_btn.Size = new Size(233, 51);
            remove_project_btn.TabIndex = 3;
            remove_project_btn.Text = "Remove project";
            remove_project_btn.UseVisualStyleBackColor = true;
            remove_project_btn.Click += remove_project_btn_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 450);
            Controls.Add(remove_project_btn);
            Controls.Add(create_project_btn);
            Controls.Add(recent_project_listbox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainMenuForm";
            Text = "MainMenu";
            Load += MainMenu_Load;
            projectContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox recent_project_listbox;
        private Button create_project_btn;
        private Button remove_project_btn;
        private ContextMenuStrip projectContextMenuStrip;
        private ToolStripMenuItem copyNameToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
    }
}