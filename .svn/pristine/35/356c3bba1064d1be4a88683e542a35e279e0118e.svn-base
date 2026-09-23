using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

public class ItsModelBase : INotifyPropertyChanged
{
    SynchronizationContext context;
    protected Action<string> OnPropertyChanged;
    public ItsModelBase(SynchronizationContext _context)
    {
        context = _context;
        OnPropertyChanged = propertyName =>
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                context.Post(t => propertyChanged(this, new PropertyChangedEventArgs((string)t)), propertyName);
            }
        };
    }

    public ItsModelBase()
    {
        OnPropertyChanged = propertyName =>
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        };

    }

    public Dictionary<string, object> _data = new Dictionary<string, object>();
    public event PropertyChangedEventHandler PropertyChanged;
    private string _curPropertyName = "";
    private string _curCheckName = "";

    public bool IsChecked { get { return GetBool(); } set { SetValue(value); } }
    public string Background { get { return GetText(); } set { SetValue(value); } }
    public string Foreground { get { return GetText(); } set { SetValue(value); } }

    public bool IsProperty(object property)
    {
        if (_curCheckName != "" && _curCheckName == _curPropertyName) return true;
        else return false;
    }
    private static string GetPropertyName()
    {
        StackFrame[] frameList = new StackTrace(true).GetFrames();
        foreach (StackFrame frame in frameList)
        {
            string methodName = frame.GetMethod().Name;
            if (methodName.StartsWith("get_") || methodName.StartsWith("set_") ||
                methodName.StartsWith("put_"))
            {
                return methodName.Substring("get_".Length);
            }
        }
        return "";
    }

    public virtual string GetKey() { return ""; }

    protected object GetValue()
    {
        string name = GetPropertyName().ToUpper();
        object value;
        _curPropertyName = name;
        if (_data.Keys.Contains(name.ToUpper()))
        {
            value = _data[name.ToUpper()];
        }
        else
        {
            PutData(name, "");
            value = "";
        }

        if (_GPCD_CODE_LIST.ContainsKey(name.ToUpper()))
        {
            try
            {
                if (_GPCD_VALUE_LIST[name.ToUpper()].Trim() != "")
                {
                    value = value.ToString() + "•" + _GPCD_VALUE_LIST[name.ToUpper()];
                }
                else
                {
                    value = value.ToString();
                }
            }
            catch
            {
                value = value.ToString();
            }
        }

        return value;
    }

    protected bool GetBool()
    {
        object value = GetValue();
        if (value == null) return false;
        if (value.ToString() == "Y") return true;
        if (value.ToString().ToUpper() == "TRUE") return true;
        return false;
    }

    protected string GetText()
    {
        object value = GetValue();
        if (value == null) return "";
        else if (value.ToString() == "TRUE")
        {
            return "Y";
        }
        else if (value.ToString() == "FALSE")
        {
            return "N";
        }
        else
        {
            return value.ToString();
        }
    }
    protected decimal GetDecimal()
    {
        string value = GetText();
        if (value == "") return 0m;
        else
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return 0m;
            }
        }
    }
    protected int GetInt()
    {
        return (int)(GetDecimal());
    }

    protected string GetDate()
    {
        return DateTime.Parse(GetText().Substring(0, 10)).ToString("yyyy-MM-dd");
    }

    protected Dictionary<string, string> _GPCD_CODE_LIST = new Dictionary<string, string>();
    protected Dictionary<string, string> _GPCD_VALUE_LIST = new Dictionary<string, string>();
    public void GPCD(string property, string gpcd, string value)
    {
        if (!_GPCD_CODE_LIST.ContainsKey(property.ToUpper()))
        {
            _GPCD_CODE_LIST.Add(property.ToUpper(), gpcd);
            _GPCD_VALUE_LIST.Add(property.ToUpper(), value);
        }
        else
        {
            _GPCD_CODE_LIST[property.ToUpper()] = gpcd;
            _GPCD_VALUE_LIST[property.ToUpper()] = value;
        }
    }

    protected void SetValue(object value)
    {
        if (value == null) value = "";
        int point = value.ToString().IndexOf("•");
        if (point > -1)
        {
            value = value.ToString().Substring(0, point);
        }

        if (value.ToString().ToUpper() == "TRUE") value = "Y";
        if (value.ToString().ToUpper() == "FALSE") value = "N";

        string name = GetPropertyName();
        if (!_data.Keys.Contains(name.ToUpper()))
        {
            _data.Add(name.ToUpper(), value);
        }
        else if (object.Equals(_data[name.ToUpper()], value))
        {
            return;
        }
        else
        {
            _data[name.ToUpper()] = value;
        }

        // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        OnPropertyChanged(name);

        _curCheckName = name;

        if (name != "IsChecked" && name != "Background" && name != "Foreground")
        {
            this.IsChecked = true;
        }

        ValueChanged();
    }
    public virtual void ValueChanged()
    {

    }

    public void PutData(string key, object value)
    {
        if (_data.Keys.Contains(key.ToUpper()))
        {
            _data[key.ToUpper()] = value;
        }
        else
        {
            _data.Add(key.ToUpper(), value);
        }
    }
}
