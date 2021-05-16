using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowShifter
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [System.ComponentModel.Browsable(false)]
        public IntPtr Handle { get; }

        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;

        public Form1()
        {
            InitializeComponent();
            int x = 0;
            int y = 0;
            foreach (var screen in Screen.AllScreens)
            {
                ListBox newListBox = new ListBox()
                {
                    AutoSize = true,
                    Location = new Point(x, y)
                };
                newListBox.Items.Add(screen.DeviceName);
                x += 150;
                Controls.Add(newListBox);
                Console.WriteLine($"Screen Processed: {screen.DeviceName}");
            }
        }
    }
}
