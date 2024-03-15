namespace CsvCleanToUSCharset
{
    partial class Form1
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
            OpenInputFileDialog = new OpenFileDialog();
            InputFileNameTextbox = new TextBox();
            SelectInputFileButton = new Button();
            label1 = new Label();
            ActionButton = new Button();
            HeaderLineCheckbox = new CheckBox();
            ResultTextbox = new TextBox();
            SeparatorTextbox = new TextBox();
            DelimeterTextbox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // InputFileNameTextbox
            // 
            InputFileNameTextbox.BackColor = SystemColors.Window;
            InputFileNameTextbox.CausesValidation = false;
            InputFileNameTextbox.Location = new Point(109, 32);
            InputFileNameTextbox.Margin = new Padding(3, 2, 3, 2);
            InputFileNameTextbox.Name = "InputFileNameTextbox";
            InputFileNameTextbox.ReadOnly = true;
            InputFileNameTextbox.Size = new Size(296, 23);
            InputFileNameTextbox.TabIndex = 0;
            InputFileNameTextbox.Validating += InputFileNameTextbox_Validating;
            // 
            // SelectInputFileButton
            // 
            SelectInputFileButton.Location = new Point(430, 30);
            SelectInputFileButton.Margin = new Padding(3, 2, 3, 2);
            SelectInputFileButton.Name = "SelectInputFileButton";
            SelectInputFileButton.Size = new Size(38, 22);
            SelectInputFileButton.TabIndex = 1;
            SelectInputFileButton.Text = "...";
            SelectInputFileButton.UseVisualStyleBackColor = true;
            SelectInputFileButton.Click += SelectInputFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 37);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 2;
            label1.Text = "Select file";
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(584, 31);
            ActionButton.Margin = new Padding(3, 2, 3, 2);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(105, 22);
            ActionButton.TabIndex = 3;
            ActionButton.Text = "Clean (F10)";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // HeaderLineCheckbox
            // 
            HeaderLineCheckbox.AutoSize = true;
            HeaderLineCheckbox.Location = new Point(109, 72);
            HeaderLineCheckbox.Margin = new Padding(3, 2, 3, 2);
            HeaderLineCheckbox.Name = "HeaderLineCheckbox";
            HeaderLineCheckbox.Size = new Size(107, 19);
            HeaderLineCheckbox.TabIndex = 4;
            HeaderLineCheckbox.Text = "Has header line";
            HeaderLineCheckbox.UseVisualStyleBackColor = true;
            HeaderLineCheckbox.CheckedChanged += HeaderLineCheckbox_CheckedChanged;
            // 
            // ResultTextbox
            // 
            ResultTextbox.BackColor = SystemColors.Window;
            ResultTextbox.Location = new Point(10, 105);
            ResultTextbox.Margin = new Padding(3, 2, 3, 2);
            ResultTextbox.Multiline = true;
            ResultTextbox.Name = "ResultTextbox";
            ResultTextbox.ReadOnly = true;
            ResultTextbox.Size = new Size(680, 224);
            ResultTextbox.TabIndex = 5;
            // 
            // SeparatorTextbox
            // 
            SeparatorTextbox.Location = new Point(254, 68);
            SeparatorTextbox.Name = "SeparatorTextbox";
            SeparatorTextbox.Size = new Size(34, 23);
            SeparatorTextbox.TabIndex = 6;
            SeparatorTextbox.Text = ",";
            SeparatorTextbox.Validating += SeparatorTextbox_Validating;
            // 
            // DelimeterTextbox
            // 
            DelimeterTextbox.Location = new Point(432, 70);
            DelimeterTextbox.Name = "DelimeterTextbox";
            DelimeterTextbox.Size = new Size(34, 23);
            DelimeterTextbox.TabIndex = 7;
            DelimeterTextbox.Validating += DelimeterTextbox_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 73);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 8;
            label2.Text = "Separator Character";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(472, 73);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 9;
            label3.Text = "Text delimiter";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(DelimeterTextbox);
            Controls.Add(SeparatorTextbox);
            Controls.Add(ResultTextbox);
            Controls.Add(HeaderLineCheckbox);
            Controls.Add(ActionButton);
            Controls.Add(label1);
            Controls.Add(SelectInputFileButton);
            Controls.Add(InputFileNameTextbox);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Clean non-US characters";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog OpenInputFileDialog;
        private Button SelectInputFileButton;
        private Label label1;
        private Button ActionButton;
        private CheckBox HeaderLineCheckbox;
        private TextBox InputFileNameTextbox;
        private TextBox ResultTextbox;
        private TextBox SeparatorTextbox;
        private TextBox DelimeterTextbox;
        private Label label2;
        private Label label3;
    }
}
