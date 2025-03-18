namespace Project
{
    partial class TaskForm
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
            label1 = new Label();
            category_combobox = new ComboBox();
            category_label = new Label();
            add_category_btn = new Button();
            owner_combobox = new ComboBox();
            owner_combo = new Label();
            deadlineDateTimePicker = new DateTimePicker();
            deadline_label = new Label();
            color_panel = new Panel();
            confirm_btn = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 15F);
            name_label.Location = new Point(15, 9);
            name_label.Margin = new Padding(4, 0, 4, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(156, 41);
            name_label.TabIndex = 0;
            name_label.Text = "Task name";
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Segoe UI", 12F);
            name_textbox.Location = new Point(15, 59);
            name_textbox.Margin = new Padding(4);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(365, 39);
            name_textbox.TabIndex = 1;
            // 
            // description_textbox
            // 
            description_textbox.Font = new Font("Segoe UI", 12F);
            description_textbox.Location = new Point(15, 152);
            description_textbox.Margin = new Padding(4);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(365, 303);
            description_textbox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(15, 105);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(169, 41);
            label1.TabIndex = 2;
            label1.Text = "Description";
            // 
            // category_combobox
            // 
            category_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            category_combobox.Font = new Font("Segoe UI", 12F);
            category_combobox.FormattingEnabled = true;
            category_combobox.Location = new Point(419, 56);
            category_combobox.Margin = new Padding(4);
            category_combobox.Name = "category_combobox";
            category_combobox.Size = new Size(245, 40);
            category_combobox.TabIndex = 4;
            category_combobox.SelectedValueChanged += category_combobox_ValueMemberChanged;
            // 
            // category_label
            // 
            category_label.AutoSize = true;
            category_label.Font = new Font("Segoe UI", 15F);
            category_label.Location = new Point(419, 9);
            category_label.Margin = new Padding(4, 0, 4, 0);
            category_label.Name = "category_label";
            category_label.Size = new Size(198, 41);
            category_label.TabIndex = 5;
            category_label.Text = "Task category";
            // 
            // add_category_btn
            // 
            add_category_btn.Location = new Point(686, 54);
            add_category_btn.Margin = new Padding(4);
            add_category_btn.Name = "add_category_btn";
            add_category_btn.Size = new Size(144, 48);
            add_category_btn.TabIndex = 6;
            add_category_btn.Text = "add category";
            add_category_btn.UseVisualStyleBackColor = true;
            add_category_btn.Click += add_category_btn_Click;
            // 
            // owner_combobox
            // 
            owner_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            owner_combobox.Font = new Font("Segoe UI", 12F);
            owner_combobox.FormattingEnabled = true;
            owner_combobox.Location = new Point(419, 200);
            owner_combobox.Margin = new Padding(4);
            owner_combobox.Name = "owner_combobox";
            owner_combobox.Size = new Size(410, 40);
            owner_combobox.TabIndex = 7;
            // 
            // owner_combo
            // 
            owner_combo.AutoSize = true;
            owner_combo.Font = new Font("Segoe UI", 15F);
            owner_combo.Location = new Point(419, 152);
            owner_combo.Margin = new Padding(4, 0, 4, 0);
            owner_combo.Name = "owner_combo";
            owner_combo.Size = new Size(335, 41);
            owner_combo.TabIndex = 8;
            owner_combo.Text = "Responsible for the task";
            // 
            // deadlineDateTimePicker
            // 
            deadlineDateTimePicker.Font = new Font("Segoe UI", 12F);
            deadlineDateTimePicker.Location = new Point(420, 328);
            deadlineDateTimePicker.Margin = new Padding(4);
            deadlineDateTimePicker.Name = "deadlineDateTimePicker";
            deadlineDateTimePicker.Size = new Size(410, 39);
            deadlineDateTimePicker.TabIndex = 9;
            // 
            // deadline_label
            // 
            deadline_label.AutoSize = true;
            deadline_label.Font = new Font("Segoe UI", 15F);
            deadline_label.Location = new Point(419, 251);
            deadline_label.Margin = new Padding(4, 0, 4, 0);
            deadline_label.Name = "deadline_label";
            deadline_label.Size = new Size(292, 41);
            deadline_label.TabIndex = 10;
            deadline_label.Text = "Deadline for the task";
            // 
            // color_panel
            // 
            color_panel.Location = new Point(419, 109);
            color_panel.Margin = new Padding(4);
            color_panel.Name = "color_panel";
            color_panel.Size = new Size(411, 40);
            color_panel.TabIndex = 11;
            // 
            // create_btn
            // 
            confirm_btn.Location = new Point(419, 401);
            confirm_btn.Margin = new Padding(4);
            confirm_btn.Name = "create_btn";
            confirm_btn.Size = new Size(411, 55);
            confirm_btn.TabIndex = 12;
            confirm_btn.Text = "create";
            confirm_btn.UseVisualStyleBackColor = true;
            confirm_btn.Click += create_btn_Click;
            // 
            // TaskForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 486);
            Controls.Add(confirm_btn);
            Controls.Add(color_panel);
            Controls.Add(deadline_label);
            Controls.Add(deadlineDateTimePicker);
            Controls.Add(owner_combo);
            Controls.Add(owner_combobox);
            Controls.Add(add_category_btn);
            Controls.Add(category_label);
            Controls.Add(category_combobox);
            Controls.Add(description_textbox);
            Controls.Add(label1);
            Controls.Add(name_textbox);
            Controls.Add(name_label);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "TaskForm";
            Text = "TaskForm";
            Load += TaskForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_label;
        private TextBox name_textbox;
        private TextBox description_textbox;
        private Label label1;
        private ComboBox category_combobox;
        private Label category_label;
        private Button add_category_btn;
        private ComboBox owner_combobox;
        private Label owner_combo;
        private DateTimePicker deadlineDateTimePicker;
        private Label deadline_label;
        private Panel color_panel;
        private Button confirm_btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}