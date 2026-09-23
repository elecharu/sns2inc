using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

public static class ItsElement
{
    public static ITSLIB.MainWindow OFFICE_MAIN_WINDOW = null;
    public static TMLMAIN.MainWindow TML_MAIN_WINDOW = null;
    public static ITSLIB.ItsPageBase ActivePage = null;
    public static string ActiveTml = "";

    // 화면 이동 시 전달할 파라미터 (LoadMenu → EventMenuParam)
    public static Dictionary<string, string> MenuParam = null;

    public static void SetMenuParam(Dictionary<string, string> param)
    {
        MenuParam = param;
    }

    public static Dictionary<string, string> GetMenuParam()
    {
        return MenuParam;
    }

    public static string GetMenuParam(string key)
    {
        if (MenuParam == null || string.IsNullOrEmpty(key)) return "";
        if (MenuParam.ContainsKey(key) && MenuParam[key] != null) return MenuParam[key];
        return "";
    }

    public static void ClearMenuParam()
    {
        MenuParam = null;
    }

    public static T FindParent<T>(object obj) where T : FrameworkElement
    {
        DependencyObject dobj = obj as DependencyObject;
        if (dobj == null) return null;

        DependencyObject parent = VisualTreeHelper.GetParent(dobj);
        if (parent == null)
        {
            object popupRoot = LogicalTreeHelper.GetParent(dobj);
            if (popupRoot is T) return (T)popupRoot;
            if (popupRoot is Popup)
            {
                parent = (popupRoot as Popup).Parent;
            }
        }

        while (parent != null)
        {
            if (parent is T)
            {
                return (T)parent;
            }

            dobj = parent;
            parent = VisualTreeHelper.GetParent(dobj);
            if (parent == null)
            {
                object popupRoot = LogicalTreeHelper.GetParent(dobj);
                if (popupRoot is T) return (T)popupRoot;
                if (popupRoot is Popup)
                {
                    parent = (popupRoot as Popup).Parent;
                }
            }
        }
        return null;
    }

    public static Page GetPage(object obj)
    {
        DependencyObject dobj = obj as DependencyObject;
        if (dobj == null) return null;

        DependencyObject parent = VisualTreeHelper.GetParent(dobj);
        if (parent == null)
        {
            object popupRoot = LogicalTreeHelper.GetParent(dobj);
            if (popupRoot is Page) return popupRoot as Page;
            if (popupRoot is Popup)
            {
                parent = (popupRoot as Popup).Parent;
            }
        }
        while (parent != null)
        {
            if (parent is Page)
            {
                return (Page)parent;
            }
            dobj = parent;
            parent = VisualTreeHelper.GetParent(dobj);
            if (parent == null)
            {
                object popupRoot = LogicalTreeHelper.GetParent(dobj);
                if (popupRoot is Page) return (Page)popupRoot;
                if (popupRoot is Popup)
                {
                    parent = (popupRoot as Popup).Parent;
                }
            }
        }
        return null;
    }

    public static List<T> FindChild<T>(object obj) where T : FrameworkElement
    {
        DependencyObject dobj = obj as DependencyObject;
        if (dobj == null) return new List<T>();

        DependencyObject child = null;
        List<T> childList = new List<T>();

        int count = VisualTreeHelper.GetChildrenCount(dobj);
        for (int i = 0; i < count; i++)
        {
            child = VisualTreeHelper.GetChild(dobj, i);
            if (child is T)
            {
                childList.Add((T)child);
            }
            childList.AddRange(FindChild<T>(child));
        }

        if (count == 0)
        {
            foreach (object childObj in LogicalTreeHelper.GetChildren(dobj))
            {
                FrameworkElement fe = childObj as FrameworkElement;
                if (fe != null && fe is T)
                {
                    childList.Add((T)fe);
                }
                childList.AddRange(FindChild<T>(fe));
            }
        } 

        return childList;
    }

    public static void Refresh(FrameworkElement element)
    {
        element.Dispatcher.Invoke((System.Threading.ThreadStart)(() => { }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
    }

    public static object FindByName(object obj, string name)
    {
        DependencyObject dobj = obj as DependencyObject;
        if (dobj == null) return null;

        DependencyObject child = null;
        int count = 0;
        try
        {
            count = VisualTreeHelper.GetChildrenCount(dobj);
        } catch { }
        for (int i = 0; i < count; i++)
        {
            child = VisualTreeHelper.GetChild(dobj, i);
            FrameworkElement element = child as FrameworkElement;
            if (element != null && element.Name == name) return element;

            element = FindByName(child, name) as FrameworkElement;
            if (element != null)
            {
                return element;
            }
        }

        if (count == 0)
        {
            foreach (object childObj in LogicalTreeHelper.GetChildren(dobj))
            {
                FrameworkElement fe = childObj as FrameworkElement;
                if (fe != null && fe.Name == name) return fe;

                FrameworkElement ele = FindByName(childObj, name) as FrameworkElement;
                if (ele != null)
                {
                    return ele;
                }
            }
        }

        return null;
    }

    public static string GetObjectUid(DependencyObject obj)
    {
        string objUid = obj.GetType() + "." + obj.GetHashCode();
        return objUid.Replace("System.Windows.Controls.", "").Replace("ITSLIB.", "");
    }
}
