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
            components = new System.ComponentModel.Container();
            recent_project_listbox = new ListBox();
            projectContextMenuStrip = new ContextMenuStrip(components);
            copyPathToolStripMenuItem = new ToolStripMenuItem();
            showInExploerToolStripMenuItem = new ToolStripMenuItem();
            removeFromListToolStripMenuItem = new ToolStripMenuItem();
            create_project_btn = new Button();
            add_project_btn = new Button();
            openFileDialog1 = new OpenFileDialog();
            remove_project_btn = new Button();
            delete_project_btn = new Button();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            projectContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // recent_project_listbox
            // 
            recent_project_listbox.ContextMenuStrip = projectContextMenuStrip;
            recent_project_listbox.FormattingEnabled = true;
            recent_project_listbox.ItemHeight = 25;
            recent_project_listbox.Location = new Point(15, 15);
            recent_project_listbox.Margin = new Padding(4);
            recent_project_listbox.Name = "recent_project_listbox";
            recent_project_listbox.Size = new Size(874, 529);
            recent_project_listbox.TabIndex = 0;
            recent_project_listbox.DoubleClick += recent_project_listbox_DoubleClick;
            // 
            // projectContextMenuStrip
            // 
            projectContextMenuStrip.ImageScalingSize = new Size(24, 24);
            projectContextMenuStrip.Items.AddRange(new ToolStripItem[] { copyPathToolStripMenuItem, showInExploerToolStripMenuItem, removeFromListToolStripMenuItem, deleteToolStripMenuItem });
            projectContextMenuStrip.Name = "contextMenuStrip1";
            projectContextMenuStrip.Size = new Size(241, 165);
            // 
            // copyPathToolStripMenuItem
            // 
            copyPathToolStripMenuItem.Name = "copyPathToolStripMenuItem";
            copyPathToolStripMenuItem.Size = new Size(240, 32);
            copyPathToolStripMenuItem.Text = "copy path";
            copyPathToolStripMenuItem.Click += copyPathToolStripMenuItem_Click;
            // 
            // showInExploerToolStripMenuItem
            // 
            showInExploerToolStripMenuItem.Name = "showInExploerToolStripMenuItem";
            showInExploerToolStripMenuItem.Size = new Size(240, 32);
            showInExploerToolStripMenuItem.Text = "show in exploer";
            showInExploerToolStripMenuItem.Click += showInExploerToolStripMenuItem_Click;
            // 
            // removeFromListToolStripMenuItem
            // 
            removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            removeFromListToolStripMenuItem.Size = new Size(240, 32);
            removeFromListToolStripMenuItem.Text = "remove from list";
            removeFromListToolStripMenuItem.Click += remove_project_btn_Click;
            // 
            // create_project_btn
            // 
            create_project_btn.Location = new Point(898, 15);
            create_project_btn.Margin = new Padding(4);
            create_project_btn.Name = "create_project_btn";
            create_project_btn.Size = new Size(291, 64);
            create_project_btn.TabIndex = 1;
            create_project_btn.Text = "Create project";
            create_project_btn.UseVisualStyleBackColor = true;
            create_project_btn.Click += create_project_btn_Click;
            // 
            // add_project_btn
            // 
            add_project_btn.Location = new Point(898, 230);
            add_project_btn.Margin = new Padding(4);
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
            remove_project_btn.Margin = new Padding(4);
            remove_project_btn.Name = "remove_project_btn";
            remove_project_btn.Size = new Size(291, 64);
            remove_project_btn.TabIndex = 3;
            remove_project_btn.Text = "Remove project";
            remove_project_btn.UseVisualStyleBackColor = true;
            remove_project_btn.Click += remove_project_btn_Click;
            // 
            // delete_project_btn
            // 
            delete_project_btn.Location = new Point(898, 158);
            delete_project_btn.Margin = new Padding(4);
            delete_project_btn.Name = "delete_project_btn";
            delete_project_btn.Size = new Size(291, 64);
            delete_project_btn.TabIndex = 4;
            delete_project_btn.Text = "Delete project";
            delete_project_btn.UseVisualStyleBackColor = true;
            delete_project_btn.Click += delete_project_btn_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(240, 32);
            deleteToolStripMenuItem.Text = "delete";
            deleteToolStripMenuItem.Click += delete_project_btn_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 562);
            Controls.Add(delete_project_btn);
            Controls.Add(remove_project_btn);
            Controls.Add(add_project_btn);
            Controls.Add(create_project_btn);
            Controls.Add(recent_project_listbox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "MainMenuForm";
            Text = "MainMenu";
            Load += MainMenu_Load;
            projectContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox recent_project_listbox;
        private Button create_project_btn;
        private Button add_project_btn;
        private OpenFileDialog openFileDialog1;
        private Button remove_project_btn;
        private ContextMenuStrip projectContextMenuStrip;
        private ToolStripMenuItem copyPathToolStripMenuItem;
        private ToolStripMenuItem showInExploerToolStripMenuItem;
        private ToolStripMenuItem removeFromListToolStripMenuItem;
        private Button delete_project_btn;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}