using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using ShiftOS.Metadata;
using ShiftOS.Commands;
using System.Windows.Forms;

namespace ShiftOS.Programs
{
    [Program("terminal", "Terminal", "Run commands in a bash-like shell.")]
    public partial class Terminal : Window, IConsoleContext
    {
        // This is an implementation of Peacenet's terminal in winforms. This is the stdin buffer. Stdout is in the textbox Text.
        private string _inputBuffer = "";
        private bool _interpreting = false;
        private List<Action<string>> _latentCallbacks = new List<Action<string>>();

        public Terminal()
        {
            InitializeComponent();
        }

        protected override void OnDesktopUpdate()
        {
            // Hide the window border until the "Windowed Terminal" upgrade is purchased.
            this.ShowShiftOSBorders = CurrentSystem.HasShiftoriumUpgrade("windowedterminal");

            // Make ourselves maximized if the borders are hidden.
            this.WindowState = ShowShiftOSBorders ? FormWindowState.Normal : FormWindowState.Maximized;

            // Terminal scrollbar upgrade.
            if(CurrentSystem.HasShiftoriumUpgrade("terminalscrollbar"))
            {
                TerminalControl.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                TerminalControl.ScrollBars = ScrollBars.None;
            }

            base.OnDesktopUpdate();
        }

        public void Write(string text)
        {
            TerminalControl.SelectionStart = TerminalControl.Text.Length;
            TerminalControl.Text += text;
            TerminalControl.SelectionStart = TerminalControl.Text.Length;

            if(CurrentSystem.HasShiftoriumUpgrade("autoscrollterminal"))
            {
                TerminalControl.ScrollToCaret();
            }
        }

        public void WriteLine(string text)
        {
            this.Write(text + Environment.NewLine);
        }

        public void Clear()
        {
            this.TerminalControl.Text = "";
            this.TerminalControl.SelectionStart = 0;
        }

        public bool ReadLine(ref string OutLine)
        {
            if(_inputBuffer.Contains(Environment.NewLine))
            {
                OutLine = _inputBuffer.Substring(0, _inputBuffer.IndexOf(Environment.NewLine));
                _inputBuffer = _inputBuffer.Remove(0, OutLine.Length + Environment.NewLine.Length);
                return true;
            }
            else
            {
                OutLine = "";
                return false;
            }
        }

        private void CommandInterpreterTimer_Tick(object sender, EventArgs e)
        {
            if(_latentCallbacks.Count > 0)
            {
                var callback = _latentCallbacks[0];

                string line = "";
                if(ReadLine(ref line))
                {
                    callback.Invoke(line);
                    _latentCallbacks.RemoveAt(0);
                }
                return;
            }

            if(!_interpreting)
            {
                Write($"{CurrentSystem.Username}@{CurrentSystem.OSName} $> ");
                _interpreting = true;
            }

            string command = "";
            if(ReadLine(ref command))
            {
                CurrentSystem.ExecuteCommand(this, command);
                _interpreting = false;
            }
        }

        private void TerminalControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\b')
            {
                if(_inputBuffer.Length>0)
                {
                    _inputBuffer = _inputBuffer.Remove(_inputBuffer.Length - 1, 1);
                    TerminalControl.Text = TerminalControl.Text.Remove(TerminalControl.Text.Length - 1, 1);
                    e.Handled = true;
                }
            }
            else
            {
                if(e.KeyChar=='\r')
                {
                    _inputBuffer += Environment.NewLine;
                    Write(Environment.NewLine);
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar != '\0')
                {
                    _inputBuffer += e.KeyChar;
                    Write(e.KeyChar.ToString());
                    e.Handled = true;
                }
            }
        }

        private void TerminalControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left||e.KeyCode==Keys.Right||e.KeyCode==Keys.Up||e.KeyCode==Keys.Down)
            {
                e.Handled = true;
                return;
            }
        }

        public void Latent_ReadLine(Action<string> Callback)
        {
            string test = "";
            if(ReadLine(ref test))
            {
                Callback?.Invoke(test);
                return;
            }
            else
            {
                this._latentCallbacks.Add(Callback);
            }
        }
    }
}
