using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public static class ItsEnums
{
    public enum CRUD
    {
        Create = 0, Read = 1, Update = 2, Delete = 3
    }

    public enum TextAlignType
    {
        TopLeft, TopCenter, TopRight,
        CenterLeft, CenterCenter, CenterRight,
        BottomLeft, BottomCenter, BottomRight
    }

    public enum FieldTypes
    {
        String, 
        Decimal,
        Bool,
        Date,
        Time,
        Pop
    }

    public enum InputTypes
    {
        None,
        Alphabat,
        Native
    }

    public enum TrueFalse
    {
        True,
        False
    }

    public enum CellTypes
    {
        Text,
        Number,
        Combo,
        Check,
        Pop,
        Date,
        Time,
        Button,
        Image,
        ImageView,
        StdChk
    }
}
