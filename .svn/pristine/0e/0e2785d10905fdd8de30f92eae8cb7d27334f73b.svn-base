using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

public static class ItsMsgBox
{
    public static void Show(string msg)
    {
        MessageBox.Show(msg, "ITSCO", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
    }

    public static void Show(object obj)
    {
        MessageBox.Show(obj.ToString(), "ITSCO", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
    }

    public static void ShowErr(string msg)
    {
        MessageBox.Show(msg, "ITSCO", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
    }

    public static bool ShowYesNo(string msg)
    {
        MessageBoxResult result = MessageBox.Show(msg, "ITSCO", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
        if (result == MessageBoxResult.Yes) return true;
        else return false;
    }
}
