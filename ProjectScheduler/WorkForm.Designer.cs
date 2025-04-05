namespace ProjectScheduler
{
    partial class WorkForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            planned_panel = new Panel();
            progress_panel = new Panel();
            done_panel = new Panel();
            menuStrip1 = new MenuStrip();
            projectToolStripMenuItem = new ToolStripMenuItem();
            propertysToolStripMenuItem = new ToolStripMenuItem();
            newCategoryToolStripMenuItem = new ToolStripMenuItem();
            newTaskToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            task_context_menu = new ContextMenuStrip(components);
            infoToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            planned_label = new Label();
            progress_label = new Label();
            done_label = new Label();
            menuStrip1.SuspendLayout();
            task_context_menu.SuspendLayout();
            SuspendLayout();
            // 
            // planned_panel
            // 
            planned_panel.AutoScroll = true;
            planned_panel.BackColor = SystemColors.AppWorkspace;
            planned_panel.Location = new Point(12, 27);
            planned_panel.Name = "planned_panel";
            planned_panel.Size = new Size(272, 471);
            planned_panel.TabIndex = 0;
            // 
            // progress_panel
            // 
            progress_panel.AutoScroll = true;
            progress_panel.BackColor = SystemColors.AppWorkspace;
            progress_panel.Location = new Point(290, 27);
            progress_panel.Name = "progress_panel";
            progress_panel.Size = new Size(272, 471);
            progress_panel.TabIndex = 1;
            // 
            // done_panel
            // 
            done_panel.AutoScroll = true;
            done_panel.BackColor = SystemColors.AppWorkspace;
            done_panel.Location = new Point(568, 27);
            done_panel.Name = "done_panel";
            done_panel.Size = new Size(272, 471);
            done_panel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { projectToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(850, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { propertysToolStripMenuItem, newCategoryToolStripMenuItem, newTaskToolStripMenuItem, closeToolStripMenuItem });
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(70, 24);
            projectToolStripMenuItem.Text = "project";
            // 
            // propertysToolStripMenuItem
            // 
            propertysToolStripMenuItem.Name = "propertysToolStripMenuItem";
            propertysToolStripMenuItem.Size = new Size(224, 26);
            propertysToolStripMenuItem.Text = "properties";
            propertysToolStripMenuItem.Click += propertysToolStripMenuItem_Click;
            // 
            // newCategoryToolStripMenuItem
            // 
            newCategoryToolStripMenuItem.Name = "newCategoryToolStripMenuItem";
            newCategoryToolStripMenuItem.Size = new Size(224, 26);
            newCategoryToolStripMenuItem.Text = "new category";
            newCategoryToolStripMenuItem.Click += newCategoryToolStripMenuItem_Click;
            // 
            // newTaskToolStripMenuItem
            // 
            newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            newTaskToolStripMenuItem.Size = new Size(224, 26);
            newTaskToolStripMenuItem.Text = "new task";
            newTaskToolStripMenuItem.Click += newTaskToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(224, 26);
            closeToolStripMenuItem.Text = "close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // task_context_menu
            // 
            task_context_menu.ImageScalingSize = new Size(24, 24);
            task_context_menu.Items.AddRange(new ToolStripItem[] { infoToolStripMenuItem, deleteToolStripMenuItem });
            task_context_menu.Name = "contextMenuStrip1";
            task_context_menu.Size = new Size(121, 52);
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(120, 24);
            infoToolStripMenuItem.Text = "info";
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(120, 24);
            deleteToolStripMenuItem.Text = "delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // planned_label
            // 
            planned_label.AutoSize = true;
            planned_label.Font = new Font("Segoe UI", 20F);
            planned_label.Location = new Point(76, 502);
            planned_label.Margin = new Padding(2, 0, 2, 0);
            planned_label.Name = "planned_label";
            planned_label.Size = new Size(140, 46);
            planned_label.TabIndex = 4;
            planned_label.Text = "Planned";
            // 
            // progress_label
            // 
            progress_label.AutoSize = true;
            progress_label.Font = new Font("Segoe UI", 20F);
            progress_label.Location = new Point(333, 502);
            progress_label.Margin = new Padding(2, 0, 2, 0);
            progress_label.Name = "progress_label";
            progress_label.Size = new Size(187, 46);
            progress_label.TabIndex = 5;
            progress_label.Text = "In progress";
            // 
            // done_label
            // 
            done_label.AutoSize = true;
            done_label.Font = new Font("Segoe UI", 20F);
            done_label.Location = new Point(654, 502);
            done_label.Margin = new Padding(2, 0, 2, 0);
            done_label.Name = "done_label";
            done_label.Size = new Size(101, 46);
            done_label.TabIndex = 6;
            done_label.Text = "Done";
            // 
            // WorkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 557);
            Controls.Add(done_label);
            Controls.Add(progress_label);
            Controls.Add(planned_label);
            Controls.Add(done_panel);
            Controls.Add(progress_panel);
            Controls.Add(planned_panel);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "WorkForm";
            Text = "Form1";
            FormClosed += WorkForm_FormClosed;
            Load += WorkForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            task_context_menu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel planned_panel;
        private Panel progress_panel;
        private Panel done_panel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem propertysToolStripMenuItem;
        private ToolStripMenuItem newTaskToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem newCategoryToolStripMenuItem;
        private ContextMenuStrip task_context_menu;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private Label planned_label;
        private Label progress_label;
        private Label done_label;
    }
}
