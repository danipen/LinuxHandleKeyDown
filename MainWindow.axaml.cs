using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;

namespace LinuxHandleKeyDown
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mLogTextBox = this.Find<TextBox>("logTextBox");
            mTextBox = this.Find<TextBox>("textBox");

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                mTextBox.Focus();
            }, DispatcherPriority.Input - 1);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyModifiers.HasFlag(KeyModifiers.Control))
            {
                mLogTextBox.Text += "Pressed Ctrl+" + e.Key + Environment.NewLine;
                e.Handled = true;
            }
        }

        TextBox mLogTextBox;
        TextBox mTextBox;
    }
}