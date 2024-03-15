namespace CsvCleanToUSCharset
{
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private bool SkipFirstRow { get; set; }

        private readonly ConcurrentDictionary<int, string> LogInfo = new();

        private FileInfo? InputFile { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void SelectInputFileButton_Click(object sender, EventArgs e)
        {
            if (OpenInputFileDialog.ShowDialog() == DialogResult.OK)
            {
                InputFileNameTextbox.Text = OpenInputFileDialog.FileName;
                InputFileNameTextbox_Validating(sender, new CancelEventArgs());
            }
        }

        private async void ActionButton_Click(object sender, EventArgs e)
        {
            if (InputFile is null)
            {
                MessageBox.Show("Please select a valid file to proceed");
                return;
            }
            ShowLogWindow();
            using CancellationTokenSource cts = new();
            try
            {
                cts.CancelAfter(10000);
                if (await Processor.ProcessFileAsync(InputFile, SkipFirstRow, LogInfo, cts.Token))
                {
                    UpdateLog("Operations completed", LogInfo);

                    Clipboard.SetText(InputFileNameTextbox.Text);
                }
                else
                {
                    UpdateLog("Operations failed", LogInfo);
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("The operation timed out after 10 seconds.");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message = message + "\r\n" + ex.InnerException.Message;
                }
                UpdateLog(message);
            }
            ActionButton.Enabled = true;
        }

        private void UpdateLog(string message, ConcurrentDictionary<int, string> logInfo)
        {
            UpdateLog(message);
            UpdateLog("The following details were recorded from the operation:\r\n");
            for (int i = 0; i < logInfo.Count; i++)
            {
                UpdateLog(logInfo[i] + "\r\n");
            }
            UpdateLog("\r\nThe results have been copied to the clipboard.");
        }

        private void UpdateLog(string message)
        {
            ResultTextbox.Text += message + "\r\n";
        }

        private void ShowLogWindow()
        {
            ResultTextbox.Clear();
            ActionButton.Enabled = false;
            ResultTextbox.Text = "Please wait until the file is processed ...\r\n\r\n";
        }

        private void InputFileNameTextbox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputFileNameTextbox.Text) ||
                !CheckFileIsValid(InputFileNameTextbox.Text))
            {
                MessageBox.Show($"The file \"{InputFileNameTextbox.Text}\" does not exist or is empty or is not a *.txt or *.csv file.\r\nPlease select a valid / existing file.");
                InputFileNameTextbox.Text = string.Empty;
                InputFile = null;
                e.Cancel = true;
            }
        }

        private bool CheckFileIsValid(string text)
        {
            FileInfo fi = new(text);
            InputFile = fi;
            if (fi.Exists && fi.Length > 0 && (fi.Extension == ".csv" || fi.Extension == ".txt")) { return true; }
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F10))
            {
                ActionButton.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void HeaderLineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SkipFirstRow = HeaderLineCheckbox.Checked;
        }
    }
}
