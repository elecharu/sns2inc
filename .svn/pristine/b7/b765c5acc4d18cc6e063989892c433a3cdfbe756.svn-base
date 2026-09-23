using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using BarcodeLib;
using ThoughtWorks.QRCode.Codec;

public class ItsBarcode : IDisposable
{
    public string _ERRMSG = "";
    public static Image Base64ToImage(string base64Str)
    {
        if (base64Str.Trim() == "")
        {
            return null;
        }
        byte[] bt = Convert.FromBase64String(base64Str);
        MemoryStream ms = new MemoryStream(bt);
        Image img = Image.FromStream(ms);
        return img;
    }
    public static string ImageToBase64(Image img)
    {
        if (img == null) return "";

        ImageConverter converter = new ImageConverter();
        byte[] bt = (byte[])converter.ConvertTo(img, typeof(byte[]));
        string base64 = Convert.ToBase64String(bt);
        return base64;
    }
    public enum enumTextAlignType
    {
        TopLeft, TopCenter, TopRight,
        CenterLeft, CenterCenter, CenterRight,
        BottomLeft, BottomCenter, BottomRight
    }

    public enum Barcode1DTypes : int
    {
        UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT,
        EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, CODE39Extended,
        Codabar, PostNet, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11,
        MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13,
        LOGMARS, CODE128, CODE128A, CODE128B, CODE128C, ITF14, CODE93, TELEPEN, FIM, CODE128CM
    }

    private Dictionary<string, string> _XmlDocList = new Dictionary<string, string>();

    public enum PredefinedAngles
    {
        Degree0 = 0, Degree90 = 90, Degree180 = 180, Degree270 = 270
    }

    public enum Barcode2DTypes : int
    {
        QRCODE
    }

    public enum BarcodeTypes
    {
        Barcode1D, Barcode2D
    }

    public enum RotationOriginTypes
    {
        TopLeft, TopRight, BottomLeft, BottomRight, Center
    }

    public enum RotationTypes
    {
        RotateBoundary, RotateContentOnly
    }

    #region ############# 속성
    /// <summary>
    /// 인쇄 문서 (PrintDocument)
    /// </summary>
    public PrintDocument PrintDocument { get { return _PrintDocument; } }
    private PrintDocument _PrintDocument;

    /// <summary>
    /// ComMate: 바코드 인쇄시 데이터바인딩에 사용되는 데이터
    /// </summary>
    public ItsBarcodeData Data { get { return _Data; } }
    private ItsBarcodeData _Data;

    /// <summary>
    /// ComMate: 바코드 출력 프린트명
    /// </summary>
    public string PrinterName { get { return _PrintName; } set { _PrintName = value; } }
    private string _PrintName = "";

    /// <summary>
    /// ComMate: 용지너비 (단위 mm)
    /// </summary>
    [DefaultValue(200F)]
    public float PageWidth { get; set; }
    /// <summary>
    /// ComMate: 용지높이 (단위 mm)
    /// </summary>
    [DefaultValue(200F)]
    public float PageHeight { get; set; }
    /// <summary>
    /// ComMate: 인쇄시 좌측 여백 (단위 mm)
    /// </summary>
    [DefaultValue(0.0F)]
    public float MarginLeft { get; set; }
    /// <summary>
    /// ComMate: 인쇄시 상단 여백 (단위 mm)
    /// </summary>
    [DefaultValue(0.0F)]
    public float MarginTop { get; set; }
    /// <summary>
    /// ComMate: 인쇄시 우측 여백 (단위 mm)
    /// </summary>
    [DefaultValue(0.0F)]
    public float MarginRight { get; set; }
    /// <summary>
    /// ComMate: 인쇄시 하단 여백 (단위 mm)
    /// </summary>
    [DefaultValue(0.0F)]
    public float MarginBottom { get; set; }

    /// <summary>
    /// ComMate: 가로인쇄 모드
    /// </summary>
    [DefaultValue(false)]
    public bool Landscape { get; set; }

    /// <summary>
    /// ComMate: 인쇄시 회전각도
    /// </summary>
    [DefaultValue(0)]
    public float PageRotation { get; set; }

    /// <summary>
    /// ComMate: 글자색, 선 색상, ...
    /// </summary>
    //[DefaultValue(Color.Black)]
    public Color ForeColor
    {
        get { return _ForeColor; }
        set { _ForeColor = value; }
    }
    private Color _ForeColor = Color.Black;
    /// <summary>
    /// ComMate: 선 두께
    /// </summary>
    [DefaultValue(0.1F)]
    public float LineWidth
    {
        get { return _LineWidth; }
        set { _LineWidth = value; }
    }
    private float _LineWidth = 0.1F;
    /// <summary>
    /// ComMate: 폰트
    /// </summary>
    [DefaultValue("굴림")]
    public string FontName
    {
        get { return _FontName; }
        set { _FontName = value; }
    }
    private string _FontName = "굴림";
    /// <summary>
    /// ComMate: 폰트 굵게
    /// </summary>
    [DefaultValue(false)]
    public bool FontBold
    {
        get { return _FontBold; }
        set { _FontBold = value; }
    }
    private bool _FontBold = false;
    /// <summary>
    /// ComMate: 폰트 크기(point 단위)
    /// </summary>
    [DefaultValue(12.0F)]
    public float FontSize
    {
        get { return _FontSize; }
        set { _FontSize = value; }
    }
    private float _FontSize = 12.0F;

    /// <summary>
    /// ComMate: 바코드 코드 보이기 여부
    /// </summary>
    [DefaultValue(true)]
    public bool ShowBarcodeCode
    {
        get { return _ShowBarcodeCode; }
        set { _ShowBarcodeCode = value; }
    }
    private bool _ShowBarcodeCode = true;
    /// <summary>
    /// ComMate: 1차원 바코드 형식 (기본: CODE128)
    /// </summary>
    [DefaultValue(Barcode1DTypes.CODE128)]
    public Barcode1DTypes Barcode1DType
    {
        get { return _Barcode1DType; }
        set { _Barcode1DType = value; }
    }
    private Barcode1DTypes _Barcode1DType = Barcode1DTypes.CODE128;
    /// <summary>
    /// ComMate: 2차원 바코드 형식 (기본: QRCODE)
    /// </summary>
    [DefaultValue(Barcode2DTypes.QRCODE)]
    public Barcode2DTypes Barcode2DType
    {
        get { return _Barcode2DType; }
        set { _Barcode2DType = value; }
    }
    private Barcode2DTypes _Barcode2DType = Barcode2DTypes.QRCODE;
    /// <summary>
    /// ComMate: 바코드 형식 (기본: 1차원 바코드)
    /// </summary>
    [DefaultValue(BarcodeTypes.Barcode1D)]
    public BarcodeTypes BarcodeType
    {
        get { return _BarcodeType; }
        set { _BarcodeType = value; }
    }
    private BarcodeTypes _BarcodeType = BarcodeTypes.Barcode1D;
    /// <summary>
    /// ComMate: 문자열 정렬
    /// </summary>
    [DefaultValue(enumTextAlignType.TopLeft)]
    public enumTextAlignType TextAlignType
    {
        get { return _TextAlignType; }
        set { _TextAlignType = value; }
    }
    private enumTextAlignType _TextAlignType = enumTextAlignType.TopLeft;
    /// <summary>
    /// ComMate: 자동 줄 바꿈 켜기/끄기
    /// </summary>
    [DefaultValue(false)]
    public bool WordWrap
    {
        get { return _WordWrap; }
        set { _WordWrap = value; }
    }
    private bool _WordWrap = false;
    /// <summary>
    /// ComMate: 회전각도
    /// </summary>
    [DefaultValue(0.0F)]
    public float Rotation
    {
        get { return _Rotation; }
        set
        {
            if (value > 360 || value < 0)
                throw new ArgumentException("각도는 0도~360도 까지 조절 가능합니다.");
            _Rotation = value;
        }
    }
    private float _Rotation = 0.0F;
    /// <summary>
    /// ComMate: 중심 원점
    /// </summary>
    [DefaultValue(RotationOriginTypes.Center)]
    public RotationOriginTypes RotationOriginType
    {
        get { return _RotationOriginType; }
        set { _RotationOriginType = value; }
    }
    private RotationOriginTypes _RotationOriginType = RotationOriginTypes.Center;
    /// <summary>
    /// ComMate: 회전 적용 방식
    /// </summary>
    [DefaultValue(RotationTypes.RotateContentOnly)]
    public RotationTypes RotationType
    {
        get { return _RotationType; }
        set { _RotationType = value; }
    }
    private RotationTypes _RotationType = RotationTypes.RotateContentOnly;

    /// <summary>
    /// ComMate: 바코드 유형이 CODE128CM 일때, 가장 얇은 바의 폭 배율 지정 0.3F ~ 1.8F 까지 (기본 1.0F)
    /// </summary>
    public float NarrowBarcodeFactor
    {
        get
        {
            return _NarrowBarFactor;
        }
        set
        {
            _NarrowBarFactor = Math.Max(Math.Min(value, 1.8F), 0.3F);
        }
    }
    private float _NarrowBarFactor = 1.0F;

    #endregion

    #region ############### 내부 변수
    private float _CalculatedPageMarginLeft = 0;
    private float _CalculatedPageMarginTop = 0;
    #endregion

    #region ################## 내장 클래스
    public class FontList : IDisposable
    {
        private Dictionary<string, Font> _FontList;

        public FontList()
        {
            _FontList = new Dictionary<string, Font>();
        }

        public void Dispose()
        {
            Clear();
            _FontList = null;
        }

        public void Clear()
        {
            foreach (KeyValuePair<string, Font> pair in _FontList)
            {
                pair.Value.Dispose();
            }

            _FontList.Clear();
        }

        private string GetKey(string FontFamilyName, float SizeInPt, bool isBold)
        {
            return FontFamilyName + "|" + SizeInPt.ToString() + "|" + isBold.ToString();
        }

        public Font GetFont(string FontFamilyName, float SizeInPt, bool isBold)
        {
            string key = GetKey(FontFamilyName, SizeInPt, isBold);
            if (_FontList.ContainsKey(key))
            {
                return _FontList[key];
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                if (isBold) style = FontStyle.Bold;
                Font font = new Font(FontFamilyName, SizeInPt, style);
                _FontList.Add(key, font);

                return font;
            }
        }
    }

    public class PenList : IDisposable
    {
        private Dictionary<string, Pen> _PenList;

        public PenList()
        {
            _PenList = new Dictionary<string, Pen>();
        }

        public void Dispose()
        {
            Clear();
            _PenList = null;
        }

        public void Clear()
        {
            foreach (KeyValuePair<string, Pen> pair in _PenList)
            {
                pair.Value.Dispose();
            }

            _PenList.Clear();
        }

        private string GetKey(Color Color, float Width, System.Drawing.Drawing2D.DashStyle DashStyle)
        {
            return Color.ToString() + "|" + Width.ToString() + "|" + ((int)DashStyle).ToString();
        }

        public Pen GetPen(Color Color, float Width)
        {
            return GetPen(Color, Width, System.Drawing.Drawing2D.DashStyle.Solid);
        }

        public Pen GetPen(Color Color, float Width, System.Drawing.Drawing2D.DashStyle DashStyle)
        {
            string key = GetKey(Color, Width, DashStyle);
            if (_PenList.ContainsKey(key))
            {
                return _PenList[key];
            }
            else
            {
                Pen pen = new Pen(Color, Width);
                pen.DashStyle = DashStyle;
                _PenList.Add(key, pen);

                return pen;
            }
        }
    }

    public class BrushList : IDisposable
    {
        private Dictionary<string, Brush> _BrushList;

        public BrushList()
        {
            _BrushList = new Dictionary<string, Brush>();
        }

        public void Dispose()
        {
            Clear();
            _BrushList = null;
        }

        public void Clear()
        {
            foreach (KeyValuePair<string, Brush> pair in _BrushList)
            {
                pair.Value.Dispose();
            }

            _BrushList.Clear();
        }

        private string GetKey(Color Color)
        {
            return Color.ToString();
        }

        public Brush GetBrush(Color Color)
        {
            string key = GetKey(Color);
            if (_BrushList.ContainsKey(key))
            {
                return _BrushList[key];
            }
            else
            {
                Brush brush = new SolidBrush(Color);
                _BrushList.Add(key, brush);

                return brush;
            }
        }
    }
    #endregion

    private FontList _FontList;
    private BrushList _BrushList;
    private PenList _PenList;

    [XmlInclude(typeof(DrawRectCmd))]
    [XmlInclude(typeof(DrawLineCmd))]
    [XmlInclude(typeof(DrawBarcodeCmd))]
    [XmlInclude(typeof(DrawCircleCmd))]
    [XmlInclude(typeof(DrawImgCmd))]
    [XmlInclude(typeof(DrawTextCmd))]
    [XmlInclude(typeof(PageBreakCmd))]
    public abstract class GeneralDrawCommand
    {
        public abstract void Draw(Graphics g);
        public abstract void Draw(Graphics g, float MarginLeft, float MarginTop);
        public virtual void Draw(Graphics g, float MarginLeft, float MarginTop, float FontScale)
        {
        }

        public abstract string GetCommandType();

        public abstract RectangleF GetBound(Graphics g);

        protected static BrushList _BrushList = new BrushList();
        protected static PenList _PenList = new PenList();

        private RectangleF _rect;

        #region ##### 속성창 속성

        [Browsable(true), Category("내용"), Description("DB에서 가져온 값과 연결할때 필드(혹은 컬럼)명")]
        [XmlAttribute("DataField")]
        public string 데이터바인딩
        {
            get { return DataField; }
            set
            {
                DataField = MakeDataField(value);
            }
        }
        [Browsable(true), Category("위치 및 크기"), Description("mm단위로 값을 입력해주세요.")]
        [XmlAttribute("X")]
        public float X좌표
        {
            get { return Location.X; }
            set
            {
                Location = new PointF(value, Location.Y);
            }
        }
        [Browsable(true), Category("위치 및 크기"), Description("mm단위로 값을 입력해주세요.")]
        [XmlAttribute("Y")]
        public float Y좌표
        {
            get { return Location.Y; }
            set
            {
                Location = new PointF(Location.X, value);
            }
        }
        [Browsable(true), Category("위치 및 크기"), Description("mm단위로 값을 입력해주세요.")]
        [XmlAttribute("Width")]
        public float 너비
        {
            get { return Size.Width; }
            set
            {
                Size = new SizeF(Math.Max(Math.Min(value, 3000), 1), Size.Height);
            }
        }
        [Browsable(true), Category("위치 및 크기"), Description("mm단위로 값을 입력해주세요.")]
        [XmlAttribute("Height")]
        public float 높이
        {
            get { return Size.Height; }
            set
            {
                Size = new SizeF(Size.Width, Math.Max(Math.Min(value, 3000), 1));
            }
        }
        [Browsable(true), Category("위치 및 크기"), Description("mm단위로 값을 입력해주세요.")]
        [XmlAttribute("Angle")]
        [TypeConverter()]
        public PredefinedAngles 내용회전
        {
            get
            {
                return (PredefinedAngles)Enum.Parse(typeof(PredefinedAngles), Rotation.ToString());
            }
            set
            {
                Rotation = (float)(int)value;
            }
        }
        [Browsable(true), Category("모양")]
        //[XmlAttribute("ForeColor")]
        [XmlIgnore]
        public Color 색상
        {
            get { return Color; }
            set { Color = value; }
        }
        [Browsable(true), Category("모양")]
        //[XmlAttribute("BackColor")]
        [XmlIgnore]
        public Color 배경색상
        {
            get { return BackColor; }
            set { BackColor = value; }
        }
        [Browsable(true), Category("모양")]
        [XmlAttribute("LineWidth")]
        public float 선굵기
        {
            get { return LineWidth; }
            set { LineWidth = value; }
        }
        [Browsable(true), Category("모양")]
        [XmlAttribute("DashStyle")]
        public System.Drawing.Drawing2D.DashStyle 선모양
        {
            get { return DashStyle; }
            set { DashStyle = value; }
        }
        [Browsable(true), Category("모양")]
        [XmlAttribute("Visible")]
        public bool 보이기여부
        {
            get { return Visible; }
            set { Visible = value; }
        }
        [Browsable(true), Category("  ")]
        [XmlIgnore]
        public string 유형
        {
            get { return GetCommandType(); }
        }

        #endregion

        [Browsable(false)]
        [XmlIgnore]
        public RectangleF Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

        [Browsable(false)]
        [XmlIgnore]
        public PointF Location
        {
            get { return Rect.Location; }
            set { _rect = new RectangleF(value, Rect.Size); }
        }

        [Browsable(false)]
        [XmlIgnore]
        public SizeF Size
        {
            get { return Rect.Size; }
            set { _rect = new RectangleF(Rect.Location, value); }
        }

        [XmlIgnore]
        public Color Color = Color.Black;
        [XmlIgnore]
        public Color BackColor = Color.Transparent;
        [XmlIgnore]
        public float LineWidth = 1.0F;
        [XmlIgnore]
        public System.Drawing.Drawing2D.DashStyle DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        [XmlIgnore]
        public float Rotation = 0;
        [XmlIgnore]
        public RotationOriginTypes RotationOriginType = RotationOriginTypes.Center;
        [XmlIgnore]
        public RotationTypes RotationType = RotationTypes.RotateContentOnly;
        [XmlIgnore]
        public string DataField = "";
        [XmlIgnore]
        public bool Visible = true;

        protected string MakeDataField(string value)
        {
            if (value == "")
            {
                return "";
            }

            value = value.ToUpper();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Z0-9]+");
            if (!regex.IsMatch(value))
            {
                throw new FormatException("데이터필드에는 영어와 숫자만 사용하십시오.");
            }

            return value;
        }

        #region XML Serialize 도우미

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("Color")]
        public int XmlHelperColor
        {
            get { return Color.ToArgb(); }
            set { Color = System.Drawing.Color.FromArgb(value); }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("BackColor")]
        public int XmlHelperBackColor
        {
            get { return BackColor.ToArgb(); }
            set { BackColor = System.Drawing.Color.FromArgb(value); }
        }

        #endregion

        #region 회전관련

        public PointF GetTranslateOffset(RectangleF rect)
        {
            float offsetX = 0;
            float offsetY = 0;

            RotationOriginTypes rt = RotationOriginType;

            // 회전 방식이 내용만 회전인 경우 무조건 중앙을 기준으로 회전
            if (RotationType == RotationTypes.RotateContentOnly)
            {
                rt = RotationOriginTypes.Center;

                if ((int)Math.Round(Rotation, 0) % 90 != 0)
                {
                    throw new ArgumentException("회전 방식이 RotateContentOnly인 경우 90도, 180도, 270도로만 회전 가능합니다.");
                }
            }

            switch (rt)
            {
                case RotationOriginTypes.TopLeft:
                    offsetX = rect.X;
                    offsetY = rect.Y;
                    break;
                case RotationOriginTypes.TopRight:
                    offsetX = rect.X + rect.Width;
                    offsetY = rect.Y;
                    break;
                case RotationOriginTypes.BottomLeft:
                    offsetX = rect.X;
                    offsetY = rect.Y + rect.Height;
                    break;
                case RotationOriginTypes.BottomRight:
                    offsetX = rect.X + rect.Width;
                    offsetY = rect.Y + rect.Height;
                    break;
                case RotationOriginTypes.Center:
                    offsetX = rect.X + rect.Width / 2;
                    offsetY = rect.Y + rect.Height / 2;
                    break;
            }

            return new PointF(offsetX, offsetY);
        }

        protected RectangleF GetRotatedBound(RectangleF inRectF)
        {
            return GetRotatedBound(Rotation, inRectF);
        }

        protected RectangleF GetRotatedBound(float degrees, RectangleF inRectF)
        {
            if (RotationType == RotationTypes.RotateContentOnly)
                return inRectF;

            PointF offset = GetTranslateOffset(inRectF);

            PointF topLeft = new PointF(inRectF.X, inRectF.Y);
            PointF topRight = new PointF(inRectF.X + inRectF.Width, inRectF.Y);
            PointF bottomLeft = new PointF(inRectF.X, inRectF.Y + inRectF.Height);
            PointF bottomRight = new PointF(inRectF.X + inRectF.Width, inRectF.Y + inRectF.Height);

            PointF p1 = GetRotatedPointF(degrees, offset, topLeft);
            PointF p2 = GetRotatedPointF(degrees, offset, topRight);
            PointF p3 = GetRotatedPointF(degrees, offset, bottomLeft);
            PointF p4 = GetRotatedPointF(degrees, offset, bottomRight);

            float left = Min(p1.X, p2.X, p3.X, p4.X);
            float right = Max(p1.X, p2.X, p3.X, p4.X);
            float top = Min(p1.Y, p2.Y, p3.Y, p4.Y);
            float bottom = Max(p1.Y, p2.Y, p3.Y, p4.Y);

            return new RectangleF(left, top, right - left, bottom - top);
        }

        /// <summary>
        /// 0점을 기준으로 해서 회전한 점 위치를 구함
        /// </summary>
        /// <param name="degrees">각도</param>
        /// <param name="inPointf">원래의 점 위치</param>
        /// <returns>0점을 기준으로 회전된 점의 위치</returns>
        protected PointF GetRotatedPointF(float degrees, PointF offset, PointF inPointf)
        {
            float x = inPointf.X;
            float y = inPointf.Y;

            double radian = degrees * Math.PI / 180;

            float resultX = (float)((x - offset.X) * Math.Cos(radian) - (y - offset.Y) * Math.Sin(radian));
            float resultY = (float)((x - offset.X) * Math.Sin(radian) + (y - offset.Y) * Math.Cos(radian));

            return new PointF(resultX + offset.X, resultY + offset.Y);
        }

        protected float Min(params float[] values)
        {
            float min = float.MaxValue;

            foreach (float f in values)
            {
                if (f < min)
                    min = f;
            }

            return min;
        }

        protected float Max(params float[] values)
        {
            float max = float.MinValue;

            foreach (float f in values)
            {
                if (f > max)
                    max = f;
            }

            return max;
        }

        protected RectangleF ApplyRectangle(RectangleF adjustedRect)
        {
            if (RotationType == RotationTypes.RotateContentOnly)
            {
                int intAngle = (int)Math.Round(Rotation, 0);
                if (intAngle == 90 || intAngle == 270)
                {
                    float x, y;

                    x = adjustedRect.X + adjustedRect.Width / 2 - adjustedRect.Height / 2;
                    y = adjustedRect.Y + adjustedRect.Height / 2 - adjustedRect.Width / 2;

                    return new RectangleF(x, y, adjustedRect.Height, adjustedRect.Width);
                }
            }

            return adjustedRect;
        }

        #endregion
    }

    //Drawstr 함수 호출시 사용되는 구조체
    public class DrawTextCmd : GeneralDrawCommand
    {
        #region ##### 속성창 속성
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true), Category("내용")]
        [XmlAttribute("Text")]
        public string 글씨
        {
            get { return Text; }
            set { Text = value; }
        }
        [Browsable(true), Category("모양")]
        [XmlAttribute("Font")]
        [XmlIgnore]
        public Font 글꼴
        {
            get { return Font; }
            set { Font = value; }
        }
        [Browsable(true), Category("정렬")]
        [XmlAttribute("HorizontalAlign")]
        public StringAlignment 가로정렬
        {
            get { return Format.Alignment; }
            set
            {
                if (Format == null) Format = new StringFormat();
                Format.Trimming = StringTrimming.None;
                Format.Alignment = value;
            }
        }
        [Browsable(true), Category("정렬")]
        [XmlAttribute("VerticalAlign")]
        public StringAlignment 세로정렬
        {
            get { return Format.LineAlignment; }
            set
            {
                if (Format == null) Format = new StringFormat();
                Format.Trimming = StringTrimming.None;
                Format.LineAlignment = value;
            }
        }
        [Browsable(true), Category("정렬")]
        [XmlAttribute("WordWrap")]
        public bool 자동줄바꿈
        {
            get { return Format.FormatFlags != StringFormatFlags.NoWrap; }
            set
            {
                if (Format == null) Format = new StringFormat();
                Format.Trimming = StringTrimming.None;
                if (value)
                {
                    Format.FormatFlags &= ~StringFormatFlags.NoWrap;
                }
                else
                {
                    Format.FormatFlags |= StringFormatFlags.NoWrap;
                }
            }
        }

        #endregion

        #region ##### 쓰지 않는 속성

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new float 선굵기 { get; set; }

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new System.Drawing.Drawing2D.DashStyle 선모양 { get; set; }

        #endregion

        [XmlIgnore]
        public string Text;
        [XmlIgnore]
        public Font Font;
        [XmlIgnore]
        public StringFormat Format;

        public override void Draw(Graphics g)
        {
            Draw(g, 0, 0, 1F);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop)
        {
            Draw(g, MarginLeft, MarginTop, 1F);
        }

        //private static int i = 1;
        public override void Draw(Graphics g, float MarginLeft, float MarginTop, float FontScale)
        {
            try
            {
                RectangleF adjustedRect = new RectangleF(Rect.Left + MarginLeft, Rect.Top + MarginTop, Rect.Width, Rect.Height);

                float fontSize = Font.Size * g.PageScale * FontScale;

                using (Font ScaledFont = new Font(Font.FontFamily, fontSize, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont))
                using (new ApplyDrawCommandTransform(this, g, adjustedRect))
                {
                    adjustedRect = ApplyRectangle(adjustedRect);

                    if (Rect.Width == -1 || Rect.Height == -1)
                    {
                        g.DrawString(Text, ScaledFont, _BrushList.GetBrush(Color), adjustedRect.Left, adjustedRect.Top, Format);
                    }
                    else
                    {
                        if (BackColor != Color.Transparent)
                            g.FillRectangle(_BrushList.GetBrush(BackColor), adjustedRect.Left, adjustedRect.Top,
                                            adjustedRect.Width, adjustedRect.Height);

                        g.DrawString(Text, ScaledFont, _BrushList.GetBrush(Color), adjustedRect, Format);
                    }
                }
            }
            catch { }
        }

        public override string GetCommandType()
        {
            return "텍스트";
        }

        public override RectangleF GetBound(Graphics g)
        {
            if (Rect.Width == -1 || Rect.Height == -1)
            {
                SizeF size = g.MeasureString(Text, Font, new SizeF(Rect.Width, Rect.Height), Format);
                return GetRotatedBound(Rotation, new RectangleF(Rect.Left, Rect.Top, size.Width, size.Height));
                //return new RectangleF(Rect.Left, Rect.Top, size.Width, size.Height);
            }
            else
            {
                return GetRotatedBound(Rect);
                //return Rect;
            }
        }

        #region XML Serialize 도우미

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("Font")]
        public string XmlHelperFont
        {
            get { return string.Format("{0}^@^{1}^@^{2}", Font.FontFamily.Name, Font.SizeInPoints, Font.Style.ToString()); }
            set
            {
                string[] list = value.Split(new string[] { "^@^" }, StringSplitOptions.RemoveEmptyEntries);
                if (list.Count() == 3)
                {
                    Font = new Font(list[0], (float)(Convert.ToDecimal(list[1])), (FontStyle)Enum.Parse(typeof(FontStyle), list[2]));
                }
            }
        }

        #endregion
    }

    //DrawImg 함수 호출시 사용되는 구조체
    public class DrawImgCmd : GeneralDrawCommand
    {
        #region ##### 속성창 속성

        [Browsable(true), Category("바코드")]
        [XmlIgnore]
        public Image 이미지
        {
            get { return Image; }
            set { Image = value; }
        }

        #endregion

        #region ##### 쓰지 않는 속성

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new Color 색상 { get; set; }

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new Color 배경색상 { get; set; }

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new float 선굵기 { get; set; }

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new System.Drawing.Drawing2D.DashStyle 선모양 { get; set; }

        //[Browsable(false), Category("내용")]
        //[XmlIgnore]
        //public new string 데이터바인딩 { get; set; }

        #endregion

        [XmlIgnore]
        public Image Image;

        public override void Draw(Graphics g)
        {
            Draw(g, 0, 0);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop)
        {
            RectangleF adjustedRect = new RectangleF(Rect.Left + MarginLeft, Rect.Top + MarginTop, Rect.Width, Rect.Height);

            using (new ApplyDrawCommandTransform(this, g, adjustedRect))
            {
                adjustedRect = ApplyRectangle(adjustedRect);

                g.DrawImage(Image, adjustedRect);
            }
        }

        public override RectangleF GetBound(Graphics g)
        {
            return GetRotatedBound(Rect);
            //return Rect;
        }

        public override string GetCommandType()
        {
            return "그림";
        }

        #region XML Serialize 도우미

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("Image")]
        public string XmlHelperFont
        {
            get { return ImageToBase64(Image); }
            set
            {
                Image = Base64ToImage(value);
            }
        }

        #endregion
    }

    //DrawBarcode 함수 호출시 사용되는 구조체
    public class DrawBarcodeCmd : GeneralDrawCommand
    {
        #region ##### 속성창 속성

        [Browsable(true), Category("내용")]
        [XmlAttribute("Code")]
        public string 코드
        {
            get { return Code; }
            set { Code = value; }
        }
        [Browsable(true), Category("바코드")]
        [XmlAttribute("ShowCodeText")]
        public bool 코드보이기
        {
            get { return ShowCodeText; }
            set { ShowCodeText = value; }
        }
        [Browsable(true), Category("바코드")]
        [XmlIgnore]
        public Font 바코드글꼴
        {
            get { return BarcodeFont; }
            set { BarcodeFont = value; }
        }
        [Browsable(true), Category("바코드")]
        [XmlAttribute("BarcodeType")]
        public BarcodeTypes 바코드유형
        {
            get { return BarcodeType; }
            set { BarcodeType = value; }
        }
        [Browsable(true), Category("바코드")]
        [XmlAttribute("Barcode1DType")]
        public Barcode1DTypes 바코드유형_1차원
        {
            get { return Barcode1DType; }
            set { Barcode1DType = value; }
        }
        [Browsable(true), Category("바코드")]
        [XmlAttribute("Barcode2DType")]
        public Barcode2DTypes 바코드유형_2차원
        {
            get { return Barcode2DType; }
            set { Barcode2DType = value; }
        }

        #endregion

        #region ##### 쓰지 않는 속성

        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new Color 배경색상 { get; set; }

        #endregion

        [XmlIgnore]
        public string Code;
        [XmlIgnore]
        public Font BarcodeFont;
        [XmlIgnore]
        public bool ShowCodeText;
        [XmlIgnore]
        public BarcodeTypes BarcodeType;
        [XmlIgnore]
        public Barcode1DTypes Barcode1DType;
        [XmlIgnore]
        public Barcode2DTypes Barcode2DType;
        [XmlIgnore]
        public float NarrowBarcodeFactor = 1.0F;

        public override void Draw(Graphics g)
        {
            Draw(g, 0, 0);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop)
        {
            Draw(g, MarginLeft, MarginTop, 1F);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop, float FontScale)
        {
            if (BarcodeType == BarcodeTypes.Barcode1D)
                Draw1D(g, MarginLeft, MarginTop, FontScale);
            else if (BarcodeType == BarcodeTypes.Barcode2D)
                Draw2D(g, MarginLeft, MarginTop, FontScale);
            else
                throw new ArgumentOutOfRangeException("알 수 없는 바코드 유형");
        }

        public void Draw1D(Graphics g, float MarginLeft, float MarginTop, float FontScale)
        {
            RectangleF adjustedRect = new RectangleF(Rect.Left + MarginLeft, Rect.Top + MarginTop, Rect.Width, Rect.Height);
            float scale = 1;

            using (new ApplyDrawCommandTransform(this, g, adjustedRect))
            {
                adjustedRect = ApplyRectangle(adjustedRect);

                float width = adjustedRect.Width * g.PageScale;
                float height = adjustedRect.Height * g.PageScale;

                if (width < 600 || height < 400)
                {
                    float scaleX, scaleY;

                    scaleX = 400.0F / width;
                    scaleY = 300.0F / height;

                    scale = Math.Min(scaleX, scaleY);
                }

                float textHeight = 0;

                if (ShowCodeText)
                {
                    using (Font ScaledFont = new Font(BarcodeFont.FontFamily, BarcodeFont.Size * g.PageScale * FontScale,
                                                      BarcodeFont.Style, BarcodeFont.Unit, BarcodeFont.GdiCharSet, BarcodeFont.GdiVerticalFont))
                    {
                        textHeight = ScaledFont.GetHeight(g);      // 300 DPI일때 폰트 높이. 300 dot / 1 inch = x / 1 mm
                    }
                }

                try
                {
                    using (Image barcodeImage = Barcode.DoEncode((TYPE)Barcode1DType, Code, false, (int)(width * scale), (int)(height * scale), NarrowBarcodeFactor))
                    {
                        //g.DrawImage(barcodeImage, new RectangleF(adjustedRect.Left, adjustedRect.Top, adjustedRect.Width, adjustedRect.Height - textHeight));

                        float leftMargin, rightMargin;

                        Bitmap b = barcodeImage as Bitmap;
                        if (b == null) b = new Bitmap(barcodeImage);

                        leftMargin = 0;
                        rightMargin = 0;
                        for (int j = 0; j < barcodeImage.Height; j++)
                        {
                            for (int i = 0; i < barcodeImage.Width - 1; i++)
                            {
                                if (b.GetPixel(i, j).ToArgb() != -1)
                                {
                                    leftMargin = i;
                                    goto FindRightMargin;
                                }
                            }
                        }
                        FindRightMargin:
                        for (int j = 0; j < barcodeImage.Height; j++)
                        {
                            for (int i = barcodeImage.Width - 1; i >= 0; i--)
                            {
                                if (b.GetPixel(i, j).ToArgb() != -1)
                                {
                                    rightMargin = barcodeImage.Width - 1 - i;
                                    goto FindMarginEnd;
                                }
                            }
                        }
                        FindMarginEnd:

                        var oldInterpolationMode = g.InterpolationMode;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                        g.DrawImage(barcodeImage,
                                    new RectangleF(adjustedRect.Left, adjustedRect.Top, adjustedRect.Width, adjustedRect.Height - textHeight),
                                    new RectangleF(leftMargin, 0, barcodeImage.Width - leftMargin - rightMargin, barcodeImage.Height),
                                    GraphicsUnit.Pixel);

                        g.InterpolationMode = oldInterpolationMode;
                    }
                }
                catch
                {
                }

                if (ShowCodeText)
                {
                    using (Font ScaledFont = new Font(BarcodeFont.FontFamily, BarcodeFont.Size * g.PageScale * FontScale,
                                                      BarcodeFont.Style, BarcodeFont.Unit, BarcodeFont.GdiCharSet, BarcodeFont.GdiVerticalFont))
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        g.DrawString(Code, ScaledFont, _BrushList.GetBrush(Color), new RectangleF(adjustedRect.Left, adjustedRect.Bottom - textHeight, adjustedRect.Width, textHeight), stringFormat);
                    }
                }
            }
        }

        public void Draw2D(Graphics g, float MarginLeft, float MarginTop, float FontScale)
        {
            RectangleF adjustedRect = new RectangleF(Rect.Left + MarginLeft, Rect.Top + MarginTop, Rect.Width, Rect.Height);

            float textHeight = 0;

            using (new ApplyDrawCommandTransform(this, g, adjustedRect))
            {
                adjustedRect = ApplyRectangle(adjustedRect);

                //if (ShowCodeText)
                //{
                //    using (Font ScaledFont = new Font(BarcodeFont.FontFamily, BarcodeFont.Size * g.PageScale,
                //        BarcodeFont.Style, BarcodeFont.Unit, BarcodeFont.GdiCharSet, BarcodeFont.GdiVerticalFont))
                //    {
                //        textHeight = ScaledFont.GetHeight(g);      // 300 DPI일때 폰트 높이. 300 dot / 1 inch = x / 1 mm
                //    }
                //}

                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                for (int i = 0; i < Code.Length; i++)
                {
                    if (!Char.IsNumber(Code[i]))
                    {
                        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                        break;
                    }
                }// TODO: AlphaNumeric 체크 (알파벳과 숫자만)
                qrCodeEncoder.QRCodeScale = 1;
                qrCodeEncoder.QRCodeVersion = 0;

                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                using (Image image = qrCodeEncoder.Encode(Code))
                {
                    var oldInterpolationMode = g.InterpolationMode;

                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(image,
                                new RectangleF(adjustedRect.Left, adjustedRect.Top, adjustedRect.Width,
                                               adjustedRect.Height - textHeight),
                                new RectangleF(-1, -1, image.Width,
                                               image.Height),
                                GraphicsUnit.Pixel);
                    g.InterpolationMode = oldInterpolationMode;
                }

                //if (ShowCodeText)
                //{
                //    using (Font ScaledFont = new Font(BarcodeFont.FontFamily, BarcodeFont.Size * g.PageScale,
                //        BarcodeFont.Style, BarcodeFont.Unit, BarcodeFont.GdiCharSet, BarcodeFont.GdiVerticalFont))
                //    using (Brush barcodeTextBrush = new SolidBrush(Color))
                //    {
                //        StringFormat stringFormat = new StringFormat();
                //        stringFormat.Alignment = StringAlignment.Center;
                //        stringFormat.LineAlignment = StringAlignment.Center;
                //        g.DrawString(Code, ScaledFont, barcodeTextBrush, new RectangleF(adjustedRect.Left, adjustedRect.Bottom - textHeight, adjustedRect.Width, textHeight), stringFormat);
                //    }
                //}
            }
        }

        public override string GetCommandType()
        {
            return "바코드";
        }

        public override RectangleF GetBound(Graphics g)
        {
            return GetRotatedBound(Rect);
            //return Rect;
        }

        #region XML Serialize 도우미

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("Font")]
        public string XmlHelperFont
        {
            get { return string.Format("{0}^@^{1}^@^{2}", BarcodeFont.FontFamily.Name, BarcodeFont.SizeInPoints, BarcodeFont.Style.ToString()); }
            set
            {
                string[] list = value.Split(new string[] { "^@^" }, StringSplitOptions.RemoveEmptyEntries);
                if (list.Count() == 3)
                {
                    BarcodeFont = new Font(list[0], (float)(Convert.ToDecimal(list[1])), (FontStyle)Enum.Parse(typeof(FontStyle), list[2]));
                }
            }
        }

        #endregion
    }

    //DrawLine 함수 호출시 사용되는 구조체
    public class DrawLineCmd : GeneralDrawCommand
    {
        #region ##### 안쓰는 속성창 속성

        [Browsable(false), Category("위치 및 크기")]
        [XmlIgnore]
        public new float X좌표
        {
            get { return Location.X; }
            set { Location = new PointF(value, Location.Y); }
        }
        [Browsable(false), Category("위치 및 크기")]
        [XmlIgnore]
        public new float Y좌표
        {
            get { return Location.Y; }
            set { Location = new PointF(Location.X, value); }
        }
        [Browsable(false), Category("위치 및 크기")]
        [XmlIgnore]
        public new float 너비
        {
            get { return Size.Width; }
            set { Size = new SizeF(value, Size.Height); }
        }
        [Browsable(false), Category("위치 및 크기")]
        [XmlIgnore]
        public new float 높이
        {
            get { return Size.Height; }
            set { Size = new SizeF(Size.Width, value); }
        }
        [Browsable(false), Category("모양")]
        [XmlIgnore]
        public new Color 배경색상 { get; set; }
        [Browsable(false), Category("내용")]
        [XmlIgnore]
        public new string 데이터바인딩 { get; set; }

        #endregion

        #region ##### 속성창 속성

        [Browsable(true), Category("위치 및 크기")]
        [XmlAttribute("X1")]
        public float X1
        {
            get { return Location.X; }
            set { Location = new PointF(value, Location.Y); }
        }
        [Browsable(true), Category("위치 및 크기")]
        [XmlAttribute("Y1")]
        public float Y1
        {
            get { return Location.Y; }
            set { Location = new PointF(Location.X, value); }
        }
        [Browsable(true), Category("위치 및 크기")]
        [XmlAttribute("X2")]
        public float X2
        {
            get { return Size.Width; }
            set { Size = new SizeF(value, Size.Height); }
        }
        [Browsable(true), Category("위치 및 크기")]
        [XmlAttribute("Y2")]
        public float Y2
        {
            get { return Size.Height; }
            set { Size = new SizeF(Size.Width, value); }
        }

        #endregion

        [XmlIgnore]
        public Pen Pen;
        //public float X1, Y1, X2, Y2;

        public override void Draw(Graphics g)
        {
            Draw(g, 0, 0);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop)
        {
            float X1 = Rect.X;
            float Y1 = Rect.Y;
            float X2 = X1 + Rect.Width;
            float Y2 = Y1 + Rect.Height;

            if (RotationType != RotationTypes.RotateContentOnly)
            {
                using (
                    new ApplyDrawCommandTransform(this, g,
                                                  new RectangleF(X1 + MarginLeft, Y1 + MarginTop, X2 + MarginLeft,
                                                                 Y2 + MarginTop)))
                {
                    g.DrawLine(_PenList.GetPen(Color, LineWidth, DashStyle), X1 + MarginLeft, Y1 + MarginTop,
                               X2 + MarginLeft, Y2 + MarginTop);
                }
            }
            else
            {
                g.DrawLine(_PenList.GetPen(Color, LineWidth, DashStyle), X1 + MarginLeft, Y1 + MarginTop,
                           X2 + MarginLeft, Y2 + MarginTop);
            }
        }

        public override string GetCommandType()
        {
            return "직선";
        }

        public override RectangleF GetBound(Graphics g)
        {
            float X1 = Rect.X;
            float Y1 = Rect.Y;
            float X2 = X1 + Rect.Width;
            float Y2 = Y1 + Rect.Height;

            float x = Math.Min(X1, X2);
            float y = Math.Min(Y1, Y2);
            float width = Math.Max(X1, X2) - x;
            float height = Math.Max(Y1, Y2) - y;

            return GetRotatedBound(new RectangleF(x, y, width, height));
            //return new RectangleF(x, y, width, height);
        }
    }

    //DrawCircle 함수 호출시 사용되는 구조체 (ellipse?)
    public class DrawCircleCmd : GeneralDrawCommand
    {
        #region ##### 안쓰는 속성창 속성

        [Browsable(false), Category("내용")]
        [XmlIgnore]
        public new string 데이터바인딩 { get; set; }

        #endregion

        public override void Draw(Graphics g)
        {
            Draw(g, 0, 0);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop)
        {
            RectangleF adjustedRect = new RectangleF(Rect.Left + MarginLeft, Rect.Top + MarginTop, Rect.Width, Rect.Height);

            using (new ApplyDrawCommandTransform(this, g, adjustedRect))
            {
                adjustedRect = ApplyRectangle(adjustedRect);

                if (BackColor != Color.Transparent)
                    g.FillEllipse(_BrushList.GetBrush(BackColor), adjustedRect.Left, adjustedRect.Top,
                                  adjustedRect.Width, adjustedRect.Height);
                g.DrawEllipse(_PenList.GetPen(Color, LineWidth, DashStyle), adjustedRect.Left, adjustedRect.Top,
                              adjustedRect.Width, adjustedRect.Height);
            }
        }

        public override string GetCommandType()
        {
            return "원";
        }

        public override RectangleF GetBound(Graphics g)
        {
            return GetRotatedBound(Rect);
            //return Rect;
        }
    }

    //DrawRect 함수 호출시 사용되는 구조체
    public class DrawRectCmd : GeneralDrawCommand
    {
        #region ##### 안쓰는 속성창 속성

        [Browsable(false), Category("내용")]
        [XmlIgnore]
        public new string 데이터바인딩 { get; set; }

        #endregion

        public override void Draw(Graphics g)
        {
            Draw(g, 0, 0);
        }

        public override void Draw(Graphics g, float MarginLeft, float MarginTop)
        {
            RectangleF adjustedRect = new RectangleF(Rect.Left + MarginLeft, Rect.Top + MarginTop, Rect.Width, Rect.Height);

            using (new ApplyDrawCommandTransform(this, g, adjustedRect))
            {
                adjustedRect = ApplyRectangle(adjustedRect);

                if (BackColor != Color.Transparent)
                    g.FillRectangle(_BrushList.GetBrush(BackColor), adjustedRect.Left, adjustedRect.Top,
                                    adjustedRect.Width, adjustedRect.Height);
                g.DrawRectangle(_PenList.GetPen(Color, LineWidth, DashStyle), adjustedRect.Left, adjustedRect.Top,
                                adjustedRect.Width, adjustedRect.Height);
            }
        }

        public override string GetCommandType()
        {
            return "사각형";
        }

        public override RectangleF GetBound(Graphics g)
        {
            return Rect;
        }
    }

    public class PageBreakCmd : GeneralDrawCommand
    {
        public override void Draw(Graphics g)
        {
        }

        public override void Draw(Graphics g, float x, float y)
        {
        }

        public override string GetCommandType()
        {
            return "페이지넘김";
        }

        public override RectangleF GetBound(Graphics g)
        {
            return new RectangleF();
        }
    }

    /// <summary>
    /// 인쇄명령 목록
    /// </summary>
    public List<GeneralDrawCommand> DrawCommandList
    {
        get { return _DrawCommandList; }
    }

    protected List<GeneralDrawCommand> _DrawCommandList = new List<GeneralDrawCommand>();

    /// <summary>
    /// ComMate: 텍스트 추가 (단위 mm)
    /// </summary>
    public DrawTextCmd AddText(string Text, float X, float Y)
    {
        return AddText(Text, new RectangleF(X, Y, -1, -1));
    }

    /// <summary>
    /// ComMate: 텍스트 추가 (단위 mm)
    /// </summary>
    public DrawTextCmd AddText(string Text, float X, float Y, float Width, float Height)
    {
        return AddText(Text, new RectangleF(X, Y, Width, Height));
    }

    private Font GetFont()
    {
        return _FontList.GetFont(this.FontName, this.FontSize, this.FontBold);
    }

    private Brush GetBrush()
    {
        return _BrushList.GetBrush(this.ForeColor);
    }

    private Pen GetPen()
    {
        return _PenList.GetPen(this.ForeColor, this.LineWidth);
    }

    private StringFormat GetFormat()
    {
        StringFormat sf = new StringFormat();
        switch (TextAlignType)
        {
            case enumTextAlignType.BottomCenter:
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Far;
                break;
            case enumTextAlignType.BottomLeft:
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Far;
                break;
            case enumTextAlignType.BottomRight:
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                break;
            case enumTextAlignType.CenterLeft:
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                break;
            case enumTextAlignType.CenterRight:
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
                break;
            case enumTextAlignType.TopCenter:
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Near;
                break;
            case enumTextAlignType.TopLeft:
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                break;
            case enumTextAlignType.TopRight:
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Near;
                break;
            case enumTextAlignType.CenterCenter:
            default:
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                break;
        }

        if (_WordWrap == false)
        {
            sf.FormatFlags = StringFormatFlags.NoWrap;
        }
        sf.Trimming = StringTrimming.None;
        return sf;
    }

    /// <summary>
    /// ComMate: 텍스트 추가 (단위 mm)
    /// </summary>
    public DrawTextCmd AddText(string Text, RectangleF Rect)
    {
        DrawTextCmd cmd = new DrawTextCmd();

        cmd.Text = Text;
        cmd.Font = GetFont();
        cmd.Color = ForeColor;
        cmd.BackColor = Color.Transparent;
        cmd.Format = GetFormat();
        cmd.Rect = Rect;
        cmd.Rotation = _Rotation;
        cmd.RotationOriginType = _RotationOriginType;
        cmd.RotationType = _RotationType;

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 이미지 추가 (단위 mm)
    /// </summary>
    public DrawImgCmd AddImage(Image Image, float Left, float Top, float Width, float Height)
    {
        return AddImage(Image, new RectangleF(Left, Top, Width, Height));
    }

    /// <summary>
    /// ComMate: 이미지 추가 (단위 mm)
    /// </summary>
    public DrawImgCmd AddImage(Image Image, RectangleF Rect)
    {
        DrawImgCmd cmd = new DrawImgCmd();

        cmd.Image = Image;
        cmd.Rect = Rect;
        cmd.Rotation = _Rotation;
        cmd.RotationOriginType = _RotationOriginType;
        cmd.RotationType = _RotationType;

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 바코드 추가 (단위 mm)
    /// </summary>
    public DrawBarcodeCmd AddBarcode(string Code, float Left, float Top, float Width, float Height)
    {
        return AddBarcode(Code, new RectangleF(Left, Top, Width, Height));
    }

    /// <summary>
    /// ComMate: 바코드 추가 (단위 mm)
    /// </summary>
    public DrawBarcodeCmd AddBarcode(string Code, RectangleF Rect)
    {
        DrawBarcodeCmd cmd = new DrawBarcodeCmd();

        cmd.Color = this.ForeColor;
        cmd.Code = Code;
        cmd.Rect = Rect;
        cmd.BarcodeFont = GetFont();
        cmd.ShowCodeText = ShowBarcodeCode;
        cmd.Barcode1DType = _Barcode1DType;
        cmd.Barcode2DType = _Barcode2DType;
        cmd.BarcodeType = _BarcodeType;
        cmd.Rotation = _Rotation;
        cmd.RotationOriginType = _RotationOriginType;
        cmd.RotationType = _RotationType;
        cmd.NarrowBarcodeFactor = _NarrowBarFactor;

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 직선 추가 (단위 mm)
    /// </summary>
    public DrawLineCmd AddLine(float X1, float Y1, float X2, float Y2)
    {
        DrawLineCmd cmd = new DrawLineCmd();

        cmd.Pen = GetPen();
        cmd.Rect = new RectangleF(X1, Y1, X2 - X1, Y2 - Y1);
        cmd.Color = ForeColor;
        cmd.LineWidth = LineWidth;
        cmd.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        cmd.BackColor = Color.Transparent;
        cmd.Rotation = _Rotation;
        cmd.RotationOriginType = _RotationOriginType;
        cmd.RotationType = _RotationType;

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 직선 추가 (단위 mm)
    /// </summary>
    /// 
    public DrawLineCmd AddLine(RectangleF Rect)
    {
        return AddLine(Rect.Left, Rect.Top, Rect.Width + Rect.Left, Rect.Height + Rect.Top);
    }

    /// <summary>
    /// ComMate: 타원 추가 (단위 mm)
    /// </summary>
    public DrawCircleCmd AddCircle(float x1, float y1, float x2, float y2)
    {
        return AddCircle(new RectangleF(x1, y1, x2 - x1, y2 - y1));
    }

    /// <summary>
    /// ComMate: 타원 추가 (단위 mm)
    /// </summary>
    public DrawCircleCmd AddCircle(RectangleF Rect)
    {
        DrawCircleCmd cmd = new DrawCircleCmd();

        cmd.Color = ForeColor;
        cmd.Rect = Rect;
        cmd.LineWidth = LineWidth;
        cmd.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        cmd.BackColor = Color.Transparent;

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 사각형 추가 (단위 mm)
    /// </summary>
    public DrawRectCmd AddRectangle(float x1, float y1, float x2, float y2)
    {
        return AddRectangle(new RectangleF(x1, y1, x2 - x1, y2 - y1));
    }

    /// <summary>
    /// ComMate: 사각형 추가 (단위 mm)
    /// </summary>
    public DrawRectCmd AddRectangle(RectangleF Rect)
    {
        DrawRectCmd cmd = new DrawRectCmd();

        cmd.Color = ForeColor;
        cmd.Rect = Rect;
        cmd.LineWidth = LineWidth;
        cmd.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        cmd.BackColor = Color.Transparent;
        cmd.Rotation = _Rotation;
        cmd.RotationOriginType = _RotationOriginType;
        cmd.RotationType = _RotationType;

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 페이지 넘김
    /// </summary>
    public PageBreakCmd AddPageBreak()
    {
        PageBreakCmd cmd = new PageBreakCmd();

        DrawCommandList.Add(cmd);

        return cmd;
    }

    /// <summary>
    /// ComMate: 그리기 초기화
    /// </summary>
    public void Clear()
    {
        DrawCommandList.Clear();
    }

    public void Draw(Image Image, int Left, int Top, int Width, int Height)
    {
        using (Image renderedImage = Render(Width, Height))
        using (Graphics g = Graphics.FromImage(Image))
        {
            g.DrawImage(renderedImage, new Rectangle(Left, Top, Width, Height));
        }
    }

    public RectangleF GetBound(Graphics g)
    {
        float left = 100000;
        float top = 100000;
        float right = -100000;
        float bottom = -100000;

        //bool processed = false;

        foreach (GeneralDrawCommand cmd in DrawCommandList)
        {
            RectangleF rect = cmd.GetBound(g);

            if (rect.Left < left) left = rect.Left;
            if (rect.Top < top) top = rect.Top;
            if (rect.Right > right) right = rect.Right;
            if (rect.Bottom > bottom) bottom = rect.Bottom;
        }

        if (left == 100000 || top == 100000 || right == -100000 || bottom == -100000)
        {
            return new RectangleF(0, 0, 0, 0);
        }

        return new RectangleF(left, top, right - left, bottom - top);
    }

    public Image Render(int Width, int Height)
    {
        Bitmap image = new Bitmap(Width, Height);

        CalculateMargins(null);

        using (Graphics g = Graphics.FromImage(image))
        {
            g.PageUnit = GraphicsUnit.Millimeter;

            RectangleF rectInMillimeter = GetBound(g);
            if (PageWidth > 0 && PageHeight > 0)
            {
                rectInMillimeter = new RectangleF(0, 0, PageWidth, PageHeight);
            }

            RectangleF rect = new RectangleF(rectInMillimeter.Left / 25.4F * g.DpiX,
                rectInMillimeter.Top / 25.4F * g.DpiY,
                rectInMillimeter.Width / 25.4F * g.DpiX,
                rectInMillimeter.Height / 25.4F * g.DpiY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

            //float scale = Math.Max(Width / rect.Width, Height / rect.Height);
            float scale = 1.0F;

            int scaledWidth = (int)Math.Floor(rect.Width * scale);
            int scaledHeight = (int)Math.Floor(rect.Height * scale);

            if (scaledWidth <= 0 || scaledHeight <= 0)
            {
                return new Bitmap(1, 1);
            }

            using (Bitmap bitmap = new Bitmap(scaledWidth, scaledHeight))
            using (Graphics gBitmap = Graphics.FromImage(bitmap))
            {
                gBitmap.PageUnit = GraphicsUnit.Millimeter;

                foreach (GeneralDrawCommand cmd in DrawCommandList)
                {
                    cmd.Draw(gBitmap);
                }

                //bitmap.Save("c:\\commate\\a.png", System.Drawing.Imaging.ImageFormat.Png);
                g.DrawImage(bitmap, new Rectangle(0, 0, Width, Height), new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Millimeter);
            }
        }

        return image;
    }
    /// <summary>
    /// ComMate: 인쇄
    /// </summary>
    public void Print(string PrinterName, string PrintFileName)
    {
        PrintDocument.PrinterSettings.PrinterName = PrinterName;
        PrintDocument.PrinterSettings.PrintFileName = PrintFileName;
        PrintDocument.PrinterSettings.PrintToFile = true;


        // 디자이너에서 설정한 용지 크기로 변경
        const float coeff = 100 / 25.4F; // x (mm) : y (1/100 inch) = 25.4 (mm) : 100 (1/100inch)
        PrintDocument.DefaultPageSettings.PaperSize = new PaperSize("CUSTOM", (int)(this.PageWidth * coeff), (int)(this.PageHeight * coeff));

        // 디자이너에서 설정한 가로세로 인쇄 모드 적용
        PrintDocument.DefaultPageSettings.Landscape = this.Landscape;

        if (PageRotation > 0)
        {
            if (PageRotation >= 270)
                PrintDocument.DefaultPageSettings.Landscape = !PrintDocument.DefaultPageSettings.Landscape;
            else if (PageRotation < 180 && PageRotation >= 90)
                PrintDocument.DefaultPageSettings.Landscape = !PrintDocument.DefaultPageSettings.Landscape;
        }
        PrintDialog pd = new PrintDialog();
        pd.UseEXDialog = false;
        pd.Document = PrintDocument;
        //if (pd.ShowDialog() == DialogResult.Cancel)
        //{
        //    return;
        //}
        // PrintDocument.PrinterSettings.DefaultPageSettings.Margins = new Margins(20, 0, 0, 0);
        // PrintDocument.DefaultPageSettings.Margins = new Margins(20, 0, 0, 0);
        PrintDocument.Print();
        System.Threading.Thread.Sleep(SleepTime);
    }

    public int SleepTime = 200;

    public ItsBarcode()
    {
        _PrintDocument = new PrintDocument();
        _PrintDocument.BeginPrint += new PrintEventHandler(_PrintDocument_BeginPrint);
        _PrintDocument.PrintPage += new PrintPageEventHandler(_PrintDocument_PrintPage);
        _PrintDocument.EndPrint += new PrintEventHandler(_PrintDocument_EndPrint);

        _Data = new ItsBarcodeData();
        _FontList = new FontList();
        _PenList = new PenList();
        _BrushList = new BrushList();
        _ERRMSG = "";
    }

    public ItsBarcode(string LabelCD)
        : this()
    {
        try
        {
            LoadFromCode(LabelCD);
        }
        catch (Exception ex)
        {
            _ERRMSG = "LABEL로드 에러";
        }
    }

    protected void CalculateMargins(PageSettings PageSettings)
    {
        if (PageSettings == null)
        {
            _CalculatedPageMarginLeft = 0.0F;
            _CalculatedPageMarginTop = 0.0F;
        }
        else
        {
            if (MarginLeft < PageSettings.PrintableArea.Left)
            {
                _CalculatedPageMarginLeft = PageSettings.PrintableArea.Left;
            }
            else
            {
                _CalculatedPageMarginLeft = MarginLeft;
            }

            if (MarginTop < PageSettings.PrintableArea.Top)
            {
                _CalculatedPageMarginTop = PageSettings.PrintableArea.Top;
            }
            else
            {
                _CalculatedPageMarginTop = MarginTop;
            }
        }
        _CalculatedPageMarginLeft = MarginLeft;
        _CalculatedPageMarginTop = MarginTop;
    }

    private int _drawCommandIndex = 0;
    private bool _marginCalculated = false;

    protected void _PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
        if (_marginCalculated == false)
        {
            CalculateMargins(e.PageSettings);
            _marginCalculated = true;
        }

        RectangleF rect = GetBound(e.Graphics);

        float marginLeft;
        float marginTop;
        float rotation = Math.Abs(PageRotation % 360);

        //marginLeft = (e.PageBounds.Width / 100.0F * 25.4F) / 2.0F - rect.Width / 2.0F;
        marginLeft = _CalculatedPageMarginLeft;
        //marginTop = (e.PageBounds.Height / 100.0F * 25.4F) / 2.0F - rect.Height / 2.0F;
        marginTop = _CalculatedPageMarginTop;

        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

        if (PageRotation > 0 && PageRotation < 90)
        {
            e.Graphics.TranslateTransform(PageWidth / 2, PageHeight / 2);
            e.Graphics.RotateTransform(rotation);
            e.Graphics.TranslateTransform(-PageWidth / 2, -PageHeight / 2);
        }
        else if (PageRotation >= 90 && PageRotation < 180)
        {
            e.Graphics.TranslateTransform(PageHeight, 0);
            e.Graphics.RotateTransform(rotation);
        }
        else if (PageRotation >= 180 && PageRotation < 270)
        {
            e.Graphics.TranslateTransform(PageWidth / 2, PageHeight / 2);
            e.Graphics.RotateTransform(rotation);
            e.Graphics.TranslateTransform(-PageWidth / 2, -PageHeight / 2);
        }
        else if (PageRotation >= 270 && PageRotation <= 360)
        {
            e.Graphics.TranslateTransform(0, PageWidth);
            e.Graphics.RotateTransform(rotation);
        }

        while (true)
        {
            if (_drawCommandIndex >= DrawCommandList.Count)
            {
                if (Data.Count > (Data.ActiveLabelIndex + 1))
                {
                    // 마지막 페이지이고 마지막 페이지에 바인딩된 사항이 없는 경우 인쇄 종료
                    if (Data.Count == ((Data.ActiveLabelIndex + 1) + 1) && Data.GetRowDataFieldCount(Data.ActiveLabelIndex + 1) == 0)
                        break;

                    // 데이터 바인딩 된 자료가 남아있으면 더 인쇄
                    _drawCommandIndex = 0;
                    Data.ActiveLabelIndex++;
                    e.HasMorePages = true;
                    break;
                }

                // 데이터 바인딩된 자료가 없거나 다 인쇄되면 인쇄 종료
                e.HasMorePages = false;
                break;
            }

            GeneralDrawCommand drawCommand = DrawCommandList[_drawCommandIndex];
            _drawCommandIndex++;

            if (drawCommand is PageBreakCmd)
            {
                if (_drawCommandIndex < DrawCommandList.Count)
                {
                    e.HasMorePages = true;
                    break;
                }
            }

            bool visible = drawCommand.Visible;

            if (Data.Count > 0 && drawCommand.DataField != "" && Data.ContainsKey(drawCommand.DataField))
            {
                if (drawCommand is DrawBarcodeCmd)
                {
                    if (visible)
                    {
                        string text = Data.GetText(drawCommand.DataField);
                        string oldText = (drawCommand as DrawBarcodeCmd).Code;
                        (drawCommand as DrawBarcodeCmd).Code = text;
                        drawCommand.Draw(e.Graphics, marginLeft, marginTop);
                        (drawCommand as DrawBarcodeCmd).Code = oldText;
                    }
                }
                else if (drawCommand is DrawTextCmd)
                {
                    if (visible)
                    {
                        string text = Data.GetText(drawCommand.DataField);
                        string oldText = (drawCommand as DrawTextCmd).Text;
                        (drawCommand as DrawTextCmd).Text = text;
                        drawCommand.Draw(e.Graphics, marginLeft, marginTop);
                        (drawCommand as DrawTextCmd).Text = oldText;
                    }
                }
                else if (drawCommand is DrawImgCmd)
                {
                    string text = Data.GetText(drawCommand.DataField);

                    if (text.Length > 10)   // 데이터바인딩 값이 10자리 넘으면 그림이라 간주
                    {
                        if (visible)
                        {
                            using (Image image = Base64ToImage(text))
                            {
                                Image oldImage = (drawCommand as DrawImgCmd).Image;
                                (drawCommand as DrawImgCmd).Image = image;
                                drawCommand.Draw(e.Graphics, marginLeft, marginTop);
                                (drawCommand as DrawImgCmd).Image = oldImage;
                            }
                        }
                    }
                    else
                    {
                        if (text.Length == 1)
                        {
                            if (text.ToUpper() == "Y")
                            {
                                visible = true; // 데이터바인딩에 Y 이면 보이기
                            }
                            else if (text.ToUpper() == "N")
                            {
                                visible = false; // N이면 숨기기
                            }
                        }

                        if (visible)
                        {
                            drawCommand.Draw(e.Graphics, marginLeft, marginTop);
                        }
                    }
                }
            }
            else if (visible)
            {
                drawCommand.Draw(e.Graphics, marginLeft, marginTop);
            }
        }
        Application.DoEvents();
    }

    protected void _PrintDocument_EndPrint(object sender, PrintEventArgs e)
    {
    }

    private void _PrintDocument_BeginPrint(object sender, PrintEventArgs e)
    {
        _drawCommandIndex = 0;
        _marginCalculated = false;
    }

    public void Dispose()
    {
        if (_PrintDocument != null)
        {
            _PrintDocument.Dispose();
            _PrintDocument = null;
        }

        _PenList.Dispose();
        _BrushList.Dispose();
        _FontList.Dispose();
    }

    public static float FitValue(float value)
    {
        const float fitFactor = 0.25F;
        const float fitFactorHalf = fitFactor / 2F;

        float remainder = Math.Abs(value) % fitFactor;
        float delta = 0;

        if (remainder < fitFactorHalf)
        {
            delta = 0;
        }
        else
        {
            delta = fitFactor;
        }

        return (int)(value / fitFactor) * fitFactor + delta;
    }

    #region XML Serialize

    [XmlRoot("ItsBarcode")]
    [XmlInclude(typeof(GeneralDrawCommand))]
    public class SerializationHelper
    {
        public float MarginLeft { get; set; }
        public float MarginTop { get; set; }
        public float MarginRight { get; set; }
        public float MarginBottom { get; set; }
        public bool Landscape { get; set; }
        public float PageWidth { get; set; }
        public float PageHeight { get; set; }
        public float PageRotation { get; set; }

        [XmlArray("DrawCommandList")]
        [XmlArrayItem("DrawCommand", typeof(GeneralDrawCommand))]
        public List<GeneralDrawCommand> DrawCommandList
        {
            get { return _drawCommandList; }
            set { _drawCommandList = value; }
        }
        private List<GeneralDrawCommand> _drawCommandList;
    }

    public string SaveToXml()
    {
        SerializationHelper helper = new SerializationHelper();
        helper.MarginLeft = MarginLeft;
        helper.MarginTop = MarginTop;
        helper.MarginRight = MarginRight;
        helper.MarginBottom = MarginBottom;
        helper.Landscape = Landscape;
        helper.DrawCommandList = DrawCommandList;
        helper.PageWidth = PageWidth;
        helper.PageHeight = PageHeight;
        helper.PageRotation = PageRotation;

        XmlSerializer serializer = new XmlSerializer(typeof(SerializationHelper));

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        System.IO.StreamWriter textWriter = new System.IO.StreamWriter(ms, Encoding.UTF8);
        serializer.Serialize(textWriter, helper);

        string xml = Encoding.UTF8.GetString(ms.ToArray());

        ms.Close();
        ms.Dispose();
        textWriter.Close();
        textWriter.Dispose();

        return xml;
    }

    public bool LoadFromXml(string xml)
    {
        if (xml.IndexOf("<ItsBarcode") == -1)
        {
            _ERRMSG = "바코드 XML자료를 인식하지 못했습니다.";
            //ItsMsgBox.ShowErr("바코드 XML자료를 인식하지 못했습니다.");
            return false;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(SerializationHelper));
        System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(xml));
        System.IO.StreamReader textReader = new System.IO.StreamReader(ms, Encoding.UTF8);

        try
        {
            ItsBarcode.SerializationHelper sh = serializer.Deserialize(textReader) as ItsBarcode.SerializationHelper;

            if (sh == null)
            {
                _ERRMSG = "바코드 XML자료를 파싱하지 못했습니다.";
                //ItsMsgBox.ShowErr("바코드 XML자료를 파싱하지 못했습니다.");
                return false;
            }

            Clear();

            foreach (GeneralDrawCommand cmd in sh.DrawCommandList)
            {
                DrawCommandList.Add(cmd);
            }

            Landscape = sh.Landscape;
            MarginTop = sh.MarginTop;
            MarginBottom = sh.MarginBottom;
            MarginLeft = sh.MarginLeft;
            MarginRight = sh.MarginRight;
            PageWidth = sh.PageWidth;
            PageHeight = sh.PageHeight;
            PageRotation = sh.PageRotation;

        }
        catch (Exception ex)
        {
            //ItsMsgBox.Show(ex.Message);
            return false;
        }
        ms.Close();
        ms.Dispose();
        textReader.Close();
        textReader.Dispose();

        return true;

    }

    #endregion

    internal sealed class ApplyDrawCommandTransform : IDisposable
    {
        private System.Drawing.Drawing2D.Matrix _oldMatrix;
        private Graphics _oldGraphics = null;

        public ApplyDrawCommandTransform(GeneralDrawCommand command, Graphics g, RectangleF rect)
        {
            _oldGraphics = g;
            _oldMatrix = g.Transform;

            if (Math.Abs(command.Rotation) < float.Epsilon) return;

            PointF offset = command.GetTranslateOffset(rect);
            float rotationDegree = command.Rotation;

            if (command.RotationType == RotationTypes.RotateContentOnly)
            {
                rotationDegree = (int)Math.Round(command.Rotation, 0);
            }

            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(rotationDegree);
            g.TranslateTransform(-offset.X, -offset.Y);
        }

        public void Dispose()
        {
            _oldGraphics.Transform = _oldMatrix;
        }
    }

    public void SetDataTable(DataTable dt)
    {
        if (Data != null)
            Data.SetDataTable(dt);
    }

    public void SetText(string dataField, string text)
    {
        if (Data != null)
            Data.SetText(dataField, text);
    }

    /// <summary>
    /// 바코드디자인을 DB에서 가져옴
    /// </summary>
    /// <param name="barcodeCd">바코드 코드</param>
    /// <returns>읽기 성공 여부</returns>
    public bool LoadFromCode(string LabelCD)
    {
        if (!_XmlDocList.ContainsKey(LabelCD))
        {
            _XmlDocList.Add(LabelCD, "");
            ItsMaria maria = new ItsMaria();
            maria.AddQuery("SELECT XMLDATA FROM SYSLABEL WHERE LABELCD = '" + LabelCD + "';");
            DataSet ds = maria.Query();
            string xml = ds.Tables[0].Rows[0][0].ToString();
            if (xml == "")
            {
                _ERRMSG = "{" + LabelCD + "}에 해당되는 LABELXML를 다운로드 하지 못했습니다.";
                //ItsMsgBox.ShowErr("{" + LabelCD + "}에 해당되는 LABELXML를 다운로드 하지 못했습니다.");
            }
            else
            {
                _XmlDocList[LabelCD] = xml;
            }
        }
        return LoadFromXml(_XmlDocList[LabelCD]);
    }
}

public class ItsBarcodeData
{
    protected List<Dictionary<string, string>> _labelList = new List<Dictionary<string, string>>();
    protected DataTable _dataTable = null;

    public void SetDataTable(DataTable dataTable)
    {
        Clear();
        _dataTable = dataTable;
    }
    public int ActiveLabelIndex
    {
        get { return _activeLabelIndex; }
        set
        {
            if (value < 0) value = 0;
            if (value >= Count) value = Count - 1;

            _activeLabelIndex = value;
        }
    }
    private int _activeLabelIndex = 0;
    public void Clear()
    {
        _activeLabelIndex = 0;
        _dataTable = null;
        _labelList.Clear();
        _IsClear = true;
    }
    bool _IsClear = false;

    public void AddLabel()
    {
        if (_dataTable != null) throw new ApplicationException("DataTable이 바인딩된 경우 AddLabel을 사용할 수 없습니다.");

        _labelList.Add(new Dictionary<string, string>());
    }
    public void SetText(string dataField, string text)
    {
        if (!_IsClear) Clear();

        if (_dataTable != null) throw new ApplicationException("DataTable이 바인딩된 경우 SetText을 사용할 수 없습니다.");

        EnsureHasLabel();
        _labelList[_labelList.Count - 1][dataField] = text;
    }

    protected void EnsureHasLabel()
    {
        if (_labelList.Count == 0)
            AddLabel();
    }
    public int Count
    {
        get
        {
            if (_dataTable == null)
                return _labelList.Count;
            else
                return _dataTable.Rows.Count;
        }
    }
    public string GetText(Enum dataField)
    {
        return GetText(dataField.ToString());
    }
    public string GetText(string dataField)
    {
        return GetText(_activeLabelIndex, dataField);
    }
    public string GetText(int labelIndex, Enum dataField)
    {
        return GetText(labelIndex, dataField.ToString());
    }
    public string GetText(int labelIndex, string dataField)
    {
        if (Count == 0) return "";

        if (labelIndex >= Count)
            throw new ArgumentOutOfRangeException(string.Format("등록된 라벨 갯수는 {0}개인데, {1} 번째 항목을 참조하였습니다.", Count,
                                                                labelIndex + 1));

        if (_dataTable == null)
        {
            if (_labelList[labelIndex].ContainsKey(dataField))
            {
                return _labelList[labelIndex][dataField];
            }
        }
        else
        {
            return _dataTable.Rows[labelIndex][dataField].ToString();
        }

        return "";
    }
    public int GetRowDataFieldCount(int rowIndex)
    {
        if (rowIndex >= Count) return 0;

        if (_dataTable == null)
        {
            return _labelList[rowIndex].Count;
        }

        return _dataTable.Columns.Count;
    }

    public bool ContainsKey(string dataField)
    {
        if (Count == 0) return false;

        if (_dataTable == null)
        {
            if (_labelList[_activeLabelIndex].ContainsKey(dataField))
            {
                return true;
            }
        }
        else
        {
            return _dataTable.Columns.Contains(dataField);
        }

        return false;
    }

}