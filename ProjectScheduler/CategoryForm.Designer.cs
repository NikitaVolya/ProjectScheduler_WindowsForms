namespace Project
{
    partial class CategoryForm
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
            description_textbox = new TextBox();
            label1 = new Label();
            name_textbox = new TextBox();
            name_label = new Label();
            color_panel = new Panel();
            color_label = new Label();
            red_numeric = new NumericUpDown();
            red_label = new Label();
            grean_label = new Label();
            green_numeric = new NumericUpDown();
            blue_label = new Label();
            blue_numeric = new NumericUpDown();
            create_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)red_numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)green_numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blue_numeric).BeginInit();
            SuspendLayout();
            // 
            // description_textbox
            // 
            description_textbox.Font = new Font("Segoe UI", 12F);
            description_textbox.Location = new Point(15, 155);
            description_textbox.Margin = new Padding(4, 4, 4, 4);
            description_textbox.Multiline = true;
            description_textbox.Name = "description_textbox";
            description_textbox.Size = new Size(365, 303);
            description_textbox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(15, 108);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(169, 41);
            label1.TabIndex = 6;
            label1.Text = "Description";
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Segoe UI", 12F);
            name_textbox.Location = new Point(15, 61);
            name_textbox.Margin = new Padding(4, 4, 4, 4);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(365, 39);
            name_textbox.TabIndex = 5;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 15F);
            name_label.Location = new Point(15, 11);
            name_label.Margin = new Padding(4, 0, 4, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(221, 41);
            name_label.TabIndex = 4;
            name_label.Text = "Category name";
            // 
            // color_panel
            // 
            color_panel.BackColor = SystemColors.ControlDark;
            color_panel.Location = new Point(434, 61);
            color_panel.Margin = new Padding(4, 4, 4, 4);
            color_panel.Name = "color_panel";
            color_panel.Size = new Size(366, 42);
            color_panel.TabIndex = 12;
            // 
            // color_label
            // 
            color_label.AutoSize = true;
            color_label.Font = new Font("Segoe UI", 15F);
            color_label.Location = new Point(434, 11);
            color_label.Margin = new Padding(4, 0, 4, 0);
            color_label.Name = "color_label";
            color_label.Size = new Size(214, 41);
            color_label.TabIndex = 13;
            color_label.Text = "Category color";
            // 
            // red_numeric
            // 
            red_numeric.Font = new Font("Segoe UI", 12F);
            red_numeric.ForeColor = SystemColors.WindowText;
            red_numeric.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            red_numeric.Location = new Point(548, 146);
            red_numeric.Margin = new Padding(4, 4, 4, 4);
            red_numeric.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            red_numeric.Name = "red_numeric";
            red_numeric.Size = new Size(252, 39);
            red_numeric.TabIndex = 14;
            red_numeric.ValueChanged += color_Scroll;
            // 
            // red_label
            // 
            red_label.AutoSize = true;
            red_label.Font = new Font("Segoe UI", 15F);
            red_label.Location = new Point(434, 145);
            red_label.Margin = new Padding(4, 0, 4, 0);
            red_label.Name = "red_label";
            red_label.Size = new Size(76, 41);
            red_label.TabIndex = 15;
            red_label.Text = "Red:";
            // 
            // grean_label
            // 
            grean_label.AutoSize = true;
            grean_label.Font = new Font("Segoe UI", 15F);
            grean_label.Location = new Point(434, 195);
            grean_label.Margin = new Padding(4, 0, 4, 0);
            grean_label.Name = "grean_label";
            grean_label.Size = new Size(104, 41);
            grean_label.TabIndex = 17;
            grean_label.Text = "Grean:";
            // 
            // green_numeric
            // 
            green_numeric.Font = new Font("Segoe UI", 12F);
            green_numeric.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            green_numeric.Location = new Point(548, 196);
            green_numeric.Margin = new Padding(4, 4, 4, 4);
            green_numeric.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            green_numeric.Name = "green_numeric";
            green_numeric.Size = new Size(252, 39);
            green_numeric.TabIndex = 16;
            green_numeric.ValueChanged += color_Scroll;
            // 
            // blue_label
            // 
            blue_label.AutoSize = true;
            blue_label.Font = new Font("Segoe UI", 15F);
            blue_label.Location = new Point(434, 245);
            blue_label.Margin = new Padding(4, 0, 4, 0);
            blue_label.Name = "blue_label";
            blue_label.Size = new Size(82, 41);
            blue_label.TabIndex = 19;
            blue_label.Text = "Blue:";
            // 
            // blue_numeric
            // 
            blue_numeric.Font = new Font("Segoe UI", 12F);
            blue_numeric.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            blue_numeric.Location = new Point(548, 246);
            blue_numeric.Margin = new Padding(4, 4, 4, 4);
            blue_numeric.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            blue_numeric.Name = "blue_numeric";
            blue_numeric.Size = new Size(252, 39);
            blue_numeric.TabIndex = 18;
            blue_numeric.ValueChanged += color_Scroll;
            // 
            // create_btn
            // 
            create_btn.Location = new Point(434, 414);
            create_btn.Margin = new Padding(4, 4, 4, 4);
            create_btn.Name = "create_btn";
            create_btn.Size = new Size(366, 45);
            create_btn.TabIndex = 20;
            create_btn.Text = "create";
            create_btn.UseVisualStyleBackColor = true;
            create_btn.Click += create_btn_Click;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 480);
            Controls.Add(create_btn);
            Controls.Add(blue_label);
            Controls.Add(blue_numeric);
            Controls.Add(grean_label);
            Controls.Add(green_numeric);
            Controls.Add(red_label);
            Controls.Add(red_numeric);
            Controls.Add(color_label);
            Controls.Add(color_panel);
            Controls.Add(description_textbox);
            Controls.Add(label1);
            Controls.Add(name_textbox);
            Controls.Add(name_label);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 4, 4, 4);
            Name = "CategoryForm";
            Text = "CategoryForm";
            ((System.ComponentModel.ISupportInitialize)red_numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)green_numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)blue_numeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox description_textbox;
        private Label label1;
        private TextBox name_textbox;
        private Label name_label;
        private Panel color_panel;
        private Label color_label;
        private NumericUpDown red_numeric;
        private Label red_label;
        private Label grean_label;
        private NumericUpDown green_numeric;
        private Label blue_label;
        private NumericUpDown blue_numeric;
        private Button create_btn;
    }
}