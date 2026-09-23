using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using WindowsInput;
using WindowsInput.Native;

namespace ItsKeyPad
{
    public class Hook
    {
        private static IntPtr _handle = IntPtr.Zero;
        private static IntPtr _hModule = IntPtr.Zero;
        private static IntPtr _keyboardId = IntPtr.Zero;
        private static IntPtr _mouseId = IntPtr.Zero;

        private static Win32Api.HookProc _keyboardProc = new Win32Api.HookProc(KeyboardProc);
        private static Win32Api.HookProc _mouseProc = new Win32Api.HookProc(MouseProc);

        private static Window _window;
        private static Win32Api.MOUSEHOOKSTRUCT _mouseParam;
        private static Rect hookingArea;

        private static IntPtr _prevWindow = IntPtr.Zero;
        private static IntPtr _prevFocus = IntPtr.Zero;

        public delegate void MouseClickEventHandler(Win32Api.POINT point, Win32Api.MouseMessages msg);
        public static event MouseClickEventHandler MouseClickEvent;

        public delegate void KeyClickEventHandler(uint keyCode);
        public static event KeyClickEventHandler KeyClickEvent;

        public static bool IsRun { get; private set; }
        public static bool UseGlobal { get; set; }

        public Hook()
        {

        }

        public static void Start(Rect hookingArea)
        {
            if (!IsRun)
            {
                Hook.hookingArea = hookingArea;

                uint threadId = Win32Api.GetCurrentThreadId();

                using (Process process = Process.GetCurrentProcess())
                {
                    using (ProcessModule module = process.MainModule)
                    {
                        _window = System.Windows.Application.Current.MainWindow;
                        _handle = process.MainWindowHandle;

                        _hModule = Win32Api.GetModuleHandle(module.ModuleName);

                        _keyboardId = Win32Api.SetWindowsHookEx((int)Win32Api.HookType.WH_KEYBOARD_LL, _keyboardProc, _hModule, 0);
                        _mouseId = Win32Api.SetWindowsHookEx((int)Win32Api.HookType.WH_MOUSE_LL, _mouseProc, _hModule, 0);

                        IsRun = true;
                    }
                }
            }
        }

        public static void Stop()
        {
            if (IsRun)
            {
                Win32Api.UnhookWindowsHookEx(_keyboardId);
                Win32Api.UnhookWindowsHookEx(_mouseId);

                IsRun = false;
            }
        }

        private static IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == Win32Api.HC_ACTION)
            {
                uint wParamValue = (uint)wParam;
                long lParamValue = (long)lParam;

                if (wParamValue == 256)
                {
                    var keyboardParam = (Win32Api.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32Api.KBDLLHOOKSTRUCT));

                    var onKeyClickEvent = KeyClickEvent;
                    if (onKeyClickEvent != null)
                    {
                        onKeyClickEvent(keyboardParam.vkCode);
                    }
                }

                // 229 ( 0xE5 ) : VK_PROCESSKEY ( IME PROCESS key )
                if ((wParamValue == 229 && lParamValue == -2147483647) || (wParamValue == 229 && lParamValue == -2147483648))
                {
                    if (IsHookingArea())
                    {
                        return (IntPtr)1;
                    }
                }
            }

            return Win32Api.CallNextHookEx(_keyboardId, nCode, wParam, lParam);
        }

        private static IntPtr MouseProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                _mouseParam = (Win32Api.MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32Api.MOUSEHOOKSTRUCT));
                var mouseMessage = (Win32Api.MouseMessages)wParam;

                if (UseGlobal)
                {
                    if (mouseMessage == Win32Api.MouseMessages.WM_LBUTTONDOWN || mouseMessage == Win32Api.MouseMessages.WM_LBUTTONUP)
                    {
                        var onMouseClickEvent = MouseClickEvent;
                        if (onMouseClickEvent != null)
                        {
                            onMouseClickEvent(_mouseParam.pt, mouseMessage);
                        }

                        if (mouseMessage == Win32Api.MouseMessages.WM_LBUTTONDOWN && IsHookingArea())
                        {
                            return (IntPtr)1;
                        }
                    }
                }
            }

            return Win32Api.CallNextHookEx(_mouseId, nCode, wParam, lParam);
        }

        private static bool IsHookingArea()
        {
            var point = _window.PointFromScreen(new Point((double)_mouseParam.pt.x, (double)_mouseParam.pt.y));
            var contains = hookingArea.Contains(point);

            return contains;
        }
    }

    public class Win32Api
    {
        public enum HookType : int
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_NCLBUTTONDOWN = 0x00A
        }

        public enum KBDLLHOOKSTRUCTFlags
        {
            LLKHF_EXTENDED = 0x01,
            LLKHF_INJECTED = 0x10,
            LLKHF_ALTDOWN = 0x20,
            LLKHF_UP = 0x80,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEHOOKSTRUCT
        {
            public POINT pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        public const int HC_ACTION = 0;

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
    }

    public class InputSimulatorStatic
    {
        private static InputSimulator inputSimulator;
        private static KeyboardSimulator keyboardSimulator;

        private InputSimulatorStatic()
        {

        }

        public static InputSimulator Input
        {
            get { return inputSimulator ?? (inputSimulator = new InputSimulator()); }
        }

        public static KeyboardSimulator Keyboard
        {
            get { return keyboardSimulator ?? (keyboardSimulator = new KeyboardSimulator(Input)); }
        }
    }
}
