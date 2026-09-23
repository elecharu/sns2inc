using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

public class ItsHelper
{
    // 마우스 드레그
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(POINT Point);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetCursorPos(out POINT lpPoint);

    [DllImportAttribute("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    public static void DragMove()
    {
        POINT curPos;
        IntPtr hWndPopup;

        GetCursorPos(out curPos);
        hWndPopup = WindowFromPoint(curPos);

        ReleaseCapture();
        SendMessage(hWndPopup, WM_NCLBUTTONDOWN, new IntPtr(HT_CAPTION), IntPtr.Zero);
    }
}
