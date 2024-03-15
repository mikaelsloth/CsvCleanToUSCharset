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
            SuspendLayout();
            // 
            // InputFileNameTextbox
            // 
            InputFileNameTextbox.BackColor = SystemColors.Window;
            InputFileNameTextbox.CausesValidation = false;
            InputFileNameTextbox.Location = new Point(125, 42);
            InputFileNameTextbox.Name = "InputFileNameTextbox";
            InputFileNameTextbox.ReadOnly = true;
            InputFileNameTextbox.Size = new Size(338, 27);
            InputFileNameTextbox.TabIndex = 0;
            InputFileNameTextbox.Validating += InputFileNameTextbox_Validating;
            // 
            // SelectInputFileButton
            // 
            SelectInputFileButton.Location = new Point(492, 40);
            SelectInputFileButton.Name = "SelectInputFileButton";
            SelectInputFileButton.Size = new Size(44, 29);
            SelectInputFileButton.TabIndex = 1;
            SelectInputFileButton.Text = "...";
            SelectInputFileButton.UseVisualStyleBackColor = true;
            SelectInputFileButton.Click += SelectInputFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 2;
            label1.Text = "Select file";
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(668, 41);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(120, 29);
            ActionButton.TabIndex = 3;
            ActionButton.Text = "Clean (F10)";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // HeaderLineCheckbox
            // 
            HeaderLineCheckbox.AutoSize = true;
            HeaderLineCheckbox.Location = new Point(125, 96);
            HeaderLineCheckbox.Name = "HeaderLineCheckbox";
            HeaderLineCheckbox.Size = new Size(134, 24);
            HeaderLineCheckbox.TabIndex = 4;
            HeaderLineCheckbox.Text = "Has header line";
            HeaderLineCheckbox.UseVisualStyleBackColor = true;
            HeaderLineCheckbox.CheckedChanged += HeaderLineCheckbox_CheckedChanged;
            // 
            // ResultTextbox
            // 
            ResultTextbox.BackColor = SystemColors.Window;
            ResultTextbox.Location = new Point(12, 140);
            ResultTextbox.Multiline = true;
            ResultTextbox.Name = "ResultTextbox";
            ResultTextbox.ReadOnly = true;
            ResultTextbox.Size = new Size(776, 298);
            ResultTextbox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ResultTextbox);
            Controls.Add(HeaderLineCheckbox);
            Controls.Add(ActionButton);
            Controls.Add(label1);
            Controls.Add(SelectInputFileButton);
            Controls.Add(InputFileNameTextbox);
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
    }
}
