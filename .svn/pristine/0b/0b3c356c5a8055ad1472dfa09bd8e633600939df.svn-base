using System.Xml.Serialization;
using System.ComponentModel;

namespace LabelDesign
{
    public class DocumentSetup
    {
        #region #### 属性窗口的属性

        [Browsable(true), Category("라벨사이즈"), Description("纸张旋转")]
        [XmlAttribute("PageRotation")]
        public float 용지회전
        {
            get { return PageRotation; }
            set { PageRotation = value; }
        }

        [Browsable(true), Category("라벨사이즈"), Description("条码纸宽度 (mm)")]
        [XmlAttribute("PageWidth")]
        public float 용지너비
        {
            get { return PageWidth; }
            set { PageWidth = value; }
        }

        [Browsable(true), Category("라벨사이즈"), Description("条码纸高度 (mm)")]
        [XmlAttribute("PageHeight")]
        public float 용지높이
        {
            get { return PageHeight; }
            set { PageHeight = value; }
        }

        [Browsable(true), Category("라벨사이즈"), Description("横向打印")]
        [XmlAttribute("Landscape")]
        public bool 가로출력여부
        {
            get { return Landscape; }
            set { Landscape = value; }
        }

        [Browsable(true), Category("간격"), Description("상단간격 (mm)")]
        [XmlAttribute("MarginTop")]
        public float 상단간격
        {
            get { return MarginTop; }
            set { MarginTop = value; }
        }

        [Browsable(true), Category("간격"), Description("좌측간격 (mm)")]
        [XmlAttribute("MarginLeft")]
        public float 좌측간격
        {
            get { return MarginLeft; }
            set { MarginLeft = value; }
        }

        [Browsable(true), Category("간격"), Description("우측간격 (mm)")]
        [XmlAttribute("MarginRight")]
        public float 우측간격
        {
            get { return MarginRight; }
            set { MarginRight = value; }
        }

        [Browsable(true), Category("간격"), Description("하단간격 (mm)")]
        [XmlAttribute("MarginBottom")]
        public float 하단간격
        {
            get { return MarginBottom; }
            set { MarginBottom = value; }
        }

        #endregion

        [Browsable(false), Category("라벨사이즈"), Description("纸张旋转")]
        [XmlIgnore]
        public float PageRotation
        {
            get { return _pageRotation; }
            set
            {
                _pageRotation = value;
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("라벨사이즈"), Description("라벨지너비 (mm)")]
        [XmlIgnore]
        public float PageWidth
        {
            get { return _pageWidth; }
            set
            {
                _pageWidth = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("라벨사이즈"), Description("라벨지높이 (mm)")]
        [XmlIgnore]
        public float PageHeight
        {
            get { return _pageHeight; }
            set
            {
                _pageHeight = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("라벨사이즈"), Description("가로출력")]
        [XmlIgnore]
        public bool Landscape
        {
            get { return _landscape; }
            set
            {
                _landscape = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("간격"), Description("상단간격 (mm)")]
        [XmlIgnore]
        public float MarginTop
        {
            get { return _marginTop; }
            set
            {
                _marginTop = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("간격"), Description("좌측간격 (mm)")]
        [XmlIgnore]
        public float MarginLeft
        {
            get { return _marginLeft; }
            set
            {
                _marginLeft = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("간격"), Description("우측간격 (mm)")]
        [XmlIgnore]
        public float MarginRight
        {
            get { return _marginRight; }
            set
            {
                _marginRight = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("간격"), Description("하단간격 (mm)")]
        [XmlIgnore]
        public float MarginBottom
        {
            get { return _marginBottom; }
            set
            {
                _marginBottom = value;
                RecalcOffset();
                if (PageSizeChanged != null) PageSizeChanged(this, System.EventArgs.Empty);
            }
        }

        [Browsable(false), Category("기타")]
        public float OffsetX
        {
            get { return _offsetX + _scrollX - PageWidth / 2; }
            //set { /*_offsetX = value;*/ }
        }

        [Browsable(false), Category("기타")]
        public float OffsetY
        {
            get { return _offsetY + _scrollY - PageHeight / 2; }
            //set { /*_offsetY = value;*/ }
        }

        [Browsable(false), Category("기타")]
        public float ZoomFactor
        {
            get { return _zoomFactor; }
            set
            {
                if (value < 0.1F) value = 0.1F;
                _zoomFactor = value;
            }
        }

        [Browsable(false), Category("기타")]
        public float VirtualWidth
        {
            get { return _virtualWidth; }
            set
            {
                _virtualWidth = value;
                RecalcOffset();
            }
        }

        [Browsable(false), Category("기타")]
        public float VirtualHeight
        {
            get { return _virtualHeight; }
            set
            {
                _virtualHeight = value;
                RecalcOffset();
            }
        }

        [Browsable(true), Category("  ")]
        [System.Xml.Serialization.XmlIgnore]
        public string 유형
        {
            get { return "용지"; }
        }

        private float _virtualWidth = 5000;
        private float _virtualHeight = 5000;
        private float _pageRotation = 0F;
        private float _pageWidth = 200;
        private float _pageHeight = 100;
        private float _offsetX = 100;
        private float _offsetY = 100;
        private float _zoomFactor = 1.0F;
        private float _marginTop = 0F;
        private float _marginLeft = 0F;
        private float _marginRight = 0F;
        private float _marginBottom = 0F;
        private bool _landscape = false;

        private float _scrollX = 0;

        [Browsable(false), Category("기타")]
        public float ScrollX
        {
            get { return _scrollX; }
            set { _scrollX = value; }
        }

        [Browsable(false), Category("기타")]
        public float ScrollY
        {
            get { return _scrollY; }
            set { _scrollY = value; }
        }

        private float _scrollY = 0;

        private void RecalcOffset()
        {
            float oldOffsetX = _offsetX;
            float oldOffsetY = _offsetY;

            _offsetX = _virtualWidth / 2 - _pageWidth / 2 ;
            _offsetY = _virtualHeight / 2 - _pageHeight / 2 ;

            if (oldOffsetX != _offsetX || oldOffsetY != _offsetY)
            {
                if (OffsetChanged != null)
                    OffsetChanged(this, System.EventArgs.Empty);
            }
        }

        public delegate void OffsetChangedEventHandler(object Sender, System.EventArgs e);
        public event OffsetChangedEventHandler OffsetChanged;

        public delegate void PageSizeChangedEventHandler(object Sender, System.EventArgs e);
        public event PageSizeChangedEventHandler PageSizeChanged;
    }
}
