namespace LabelDesign
{
    public partial class ItsBarcodeEditor : System.Windows.Forms.ScrollableControl, System.IDisposable, System.ComponentModel.INotifyPropertyChanged
    {
        public ItsBarcodeEditor()
        {
            InitializeComponent();

            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.Selectable, true);

            AutoScroll = true;
            AutoScrollMinSize = new System.Drawing.Size((int)5000, (int)5000);
            

            _backBuffer = new System.Drawing.Bitmap(1, 1);
            _ItsBarcode = new ItsBarcode();
            _brushList = new ItsBarcode.BrushList();
            _penList = new ItsBarcode.PenList();
            _fontList = new ItsBarcode.FontList();

            _documentSetup = new DocumentSetup();
            Clear();

            _documentSetup.PageSizeChanged += new DocumentSetup.PageSizeChangedEventHandler(_documentSetup_PageSizeChanged);
            _documentSetup_PageSizeChanged(null, null);

            _dragInfo = new DragInfo();
            _dragInfo.OnEndDrag += new DragInfo.EndDragEventHandler(_dragInfo_OnEndDrag);
        }

        public enum Tools
        {
            ArrowTool = 0,
            LineTool,
            BarcodeTool,
            ImageTool,
            RectangleTool,
            CircleTool,
            TextTool,
        }

        private System.Drawing.Bitmap _backBuffer;

        public ItsBarcode Barcode
        {
            get { return _ItsBarcode; }
        }
        private ItsBarcode _ItsBarcode;
        private ItsBarcode.BrushList _brushList;
        private ItsBarcode.PenList _penList;
        private ItsBarcode.FontList _fontList;
        private DragInfo _dragInfo;
        
        public DocumentSetup DocumentSetup
        {
            get { return _documentSetup; }
        }
        private DocumentSetup _documentSetup;

        public Tools SelectedTool
        {
            get { return _selectedTool; }
            set
            {
                _selectedTool = value;
                OnSelectedToolChanged();
            }
        }
        private Tools _selectedTool;

        private bool _isSpaceKeyDown = false;

        public int SizeHandleSize = 3;

        #region 

        public delegate void SelectedCmdChangedEventHandler(object sender, System.EventArgs e);
        public event SelectedCmdChangedEventHandler SelectedCmdChanged;

        protected virtual void OnSelectedCmdChanged()
        {
            if (SelectedCmdChanged != null)
                SelectedCmdChanged(this, System.EventArgs.Empty);
        }

        public delegate void ZoomChangedEventHandler(object sender, System.EventArgs e);
        public event ZoomChangedEventHandler ZoomChanged;

        protected virtual void OnZoomChanged()
        {
            if (ZoomChanged != null)
                ZoomChanged(this, System.EventArgs.Empty);
        }

        public delegate void SelectedToolChangedEventHandler(object sender, System.EventArgs e);
        public event SelectedToolChangedEventHandler SelectedToolChanged;

        protected virtual void OnSelectedToolChanged()
        {
            if (SelectedToolChanged != null)
                SelectedToolChanged(this, System.EventArgs.Empty);
        }

        #endregion

        private ItsBarcode.GeneralDrawCommand _selectedObject = null;
        public ItsBarcode.GeneralDrawCommand SelectedObject
        {
            get { return _selectedObject; }
        }

        public float Zoom
        {
            get {
                if (_documentSetup == null) return 1;
                return _documentSetup.ZoomFactor / 4.0F; 
            }
            set
            {
                if (_documentSetup == null)
                    return; 

                float newZoomFactor = value*4.0F;
                if (System.Math.Abs(_documentSetup.ZoomFactor - newZoomFactor) < float.Epsilon)
                    return;
                _documentSetup.ZoomFactor = newZoomFactor;
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {

                //for (int i = 0; i < 100; i++)
                //    _cmBarcode.AddLine(0, 100, 100, i);

                //_cmBarcode.BarcodeType = CmBarcode.BarcodeTypes.Barcode2D;
                //_cmBarcode.Barcode2DType = CmBarcode.Barcode2DTypes.QRCODE;
                //_selectedObject = _cmBarcode.AddBarcode("Hello world", new RectangleF(100, 100, 200, 200));
                //_cmBarcode.AddLine(0, 100, 100, 0);
                //_cmBarcode.AddLine(0, 100, 100, 200);

                //_cmBarcode.AddRectangle(0, 0, 100, 150);
                //_cmBarcode.AddCircle(0, 0, 100, 150);
                //Bitmap dd = new Bitmap(100, 100);
                //using (Graphics g = Graphics.FromImage(dd))
                //{
                //    g.FillRectangle(Brushes.Red, 0, 0, 50, 100);

                //}
                //_cmBarcode.AddImage(dd, 0, 0, 100, 150);

                //var z = _cmBarcode.AddText("救崇?", 100, 100);
                //z.DataField = "TEXT";
                //z = _cmBarcode.AddText("Hello world", 100, 100, 100, 100);
                //z.DataField = "TEXT2";

                /*
                            System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof (List<CmBarcode.GeneralDrawCommand>));

                using(var ms = new System.IO.MemoryStream())
                using(var textWriter = new System.IO.StreamWriter(ms, Encoding.UTF8))
                {
                    serializer.Serialize(textWriter, _cmBarcode.DrawCommandList);
                
                    textWriter.Close();

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                }*/

                //string xml = SaveToXml();

                //Clipboard.SetText(xml);

                //System.Xml.Serialization.XmlSerializer serializer =
                //    new System.Xml.Serialization.XmlSerializer(typeof (List<CmBarcode.GeneralDrawCommand>));
                //using (System.IO.MemoryStream ms = new System.IO.MemoryStream(MateClass.CmString.StringToByte(xml)))
                //using (var textReader = new System.IO.StreamReader(ms, Encoding.UTF8))
                //{
                //    serializer.Deserialize(textReader);
                //}

                //string newXml = _cmBarcode.SaveToXml();
                //Clipboard.SetText(newXml);

                //Clear();

                //LoadFromXml(newXml);

                //_cmBarcode.ForeColor = Color.Red;

                //for (int i = 0; i < 100; i++)
                //    _cmBarcode.AddLine(0, 500, 1000, 100 + i * 5);
            }
        }

        void _dragInfo_OnEndDrag(object Sender, System.EventArgs e)
        {
            if (_selectedObject != null)
            {
                if (!(_selectedObject is ItsBarcode.DrawLineCmd))
                {
                    if (_selectedObject.Size.Width < 0 || _selectedObject.Size.Height < 0)
                    {
                        float x = _selectedObject.Location.X;
                        float y = _selectedObject.Location.Y;
                        float width = _selectedObject.Size.Width;
                        float height = _selectedObject.Size.Height;

                        if (_selectedObject.Size.Width < 0)
                        {
                            x = x + width;
                            width = -width;
                        }

                        if (_selectedObject.Size.Height < 0)
                        {
                            y = y + height;
                            height = -height;
                        }

                        _selectedObject.Location = new System.Drawing.PointF(x, y);
                        _selectedObject.Size = new System.Drawing.SizeF(width, height);
                    }
                }
            }
        }

        void _documentSetup_PageSizeChanged(object Sender, System.EventArgs e)
        {
            _ItsBarcode.PageWidth = _documentSetup.PageWidth;
            _ItsBarcode.PageHeight = _documentSetup.PageHeight;
            _ItsBarcode.MarginTop = _documentSetup.MarginTop;
            _ItsBarcode.MarginBottom = _documentSetup.MarginBottom;
            _ItsBarcode.MarginLeft = _documentSetup.MarginLeft;
            _ItsBarcode.MarginRight = _documentSetup.MarginRight;
            _ItsBarcode.Landscape = _documentSetup.Landscape;
            _ItsBarcode.PageRotation = _documentSetup.PageRotation;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);

            System.Drawing.Graphics g = pe.Graphics;
            g.PageUnit = System.Drawing.GraphicsUnit.Pixel;

            if (this.Size != _backBuffer.Size)
            {
                _backBuffer.Dispose();
                _backBuffer = new System.Drawing.Bitmap(this.Width, this.Height);
            }

            ClearCanvas();

            float fontScale = 1.0F * 25.4F / g.DpiY;

            // 
            using (System.Drawing.Graphics backBufferGraphic = System.Drawing.Graphics.FromImage(_backBuffer))
            {
                backBufferGraphic.PageUnit = System.Drawing.GraphicsUnit.Pixel;
                backBufferGraphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                backBufferGraphic.TranslateTransform(_documentSetup.OffsetX, _documentSetup.OffsetY);
                backBufferGraphic.ScaleTransform(_documentSetup.ZoomFactor, _documentSetup.ZoomFactor);

                foreach (ItsBarcode.GeneralDrawCommand cmd in _ItsBarcode.DrawCommandList)
                {
                    if (cmd is ItsBarcode.DrawTextCmd || cmd is ItsBarcode.DrawBarcodeCmd)
                    {
                        cmd.Draw(backBufferGraphic, 0, 0, fontScale);
                    }
                    else
                    {
                        cmd.Draw(backBufferGraphic);
                    }
                }

                backBufferGraphic.ResetTransform();

                backBufferGraphic.DrawRectangle(_penList.GetPen(System.Drawing.Color.Black, 1), _documentSetup.OffsetX, _documentSetup.OffsetY,
                                 _documentSetup.PageWidth*_documentSetup.ZoomFactor,
                                 _documentSetup.PageHeight*_documentSetup.ZoomFactor);
                
                if (_selectedObject != null)
                {
                    DrawHandle(backBufferGraphic, _selectedObject);
                }
            }
            g.PageScale = 1F;

            g.DrawImage(_backBuffer, 0, 0);
        }

        private System.Drawing.PointF ApplyTransform(float offsetX, float offsetY, float zoom, System.Drawing.PointF pt)
        {
            float newX = pt.X * zoom + offsetX;
            float newY = pt.Y * zoom + offsetY;

            return new System.Drawing.PointF(newX, newY);
        }

        private System.Drawing.RectangleF ApplyTransform(float offsetX, float offsetY, float zoom, System.Drawing.RectangleF rect)
        {
            float newX = rect.X*zoom + offsetX;
            float newY = rect.Y*zoom + offsetY;
            float newWidth = rect.Width*zoom;
            float newHeight = rect.Height*zoom;

            return new System.Drawing.RectangleF(newX, newY, newWidth, newHeight);
        }

        private System.Drawing.PointF UnApplyTransform(float offsetX, float offsetY, float zoom, System.Drawing.PointF pt)
        {
            if (zoom < 0.01F) zoom = 0.01F;

            float newX = (pt.X - offsetX)/ zoom;
            float newY = (pt.Y - offsetY)/ zoom;

            return new System.Drawing.PointF(newX, newY);
        }

        private System.Drawing.RectangleF UnApplyTransform(float offsetX, float offsetY, float zoom, System.Drawing.RectangleF rect)
        {
            if (zoom < 0.01F) zoom = 0.01F;

            float newX = (rect.X - offsetX)/zoom;
            float newY = (rect.Y - offsetY)/zoom;
            float newWidth = rect.Width / zoom;
            float newHeight = rect.Height / zoom;

            return new System.Drawing.RectangleF(newX, newY, newWidth, newHeight);
        }

        public void DrawHandle(System.Drawing.Graphics g, ItsBarcode.GeneralDrawCommand obj)
        {
            System.Drawing.RectangleF rect = obj.GetBound(g);

            System.Drawing.RectangleF transformedRect = ApplyTransform(_documentSetup.OffsetX, _documentSetup.OffsetY, _documentSetup.ZoomFactor, rect);
            g.DrawRectangle(_penList.GetPen(System.Drawing.Color.HotPink, 1, System.Drawing.Drawing2D.DashStyle.Dash),
                transformedRect.X, transformedRect.Y, transformedRect.Width, transformedRect.Height);

            if (obj is ItsBarcode.DrawLineCmd)
            {
                DrawHandle(g, obj.Rect.X * _documentSetup.ZoomFactor + _documentSetup.OffsetX, obj.Rect.Y * _documentSetup.ZoomFactor + _documentSetup.OffsetY);
                DrawHandle(g, obj.Rect.Right * _documentSetup.ZoomFactor + _documentSetup.OffsetX, obj.Rect.Bottom * _documentSetup.ZoomFactor + _documentSetup.OffsetY);
            }
            else
            {
                DrawHandle(g, obj.GetBound(g));
            }
        }

        public void DrawHandle(System.Drawing.Graphics g, System.Drawing.RectangleF bound)
        {
            float x = bound.X * _documentSetup.ZoomFactor + _documentSetup.OffsetX;
            float y = bound.Y * _documentSetup.ZoomFactor + _documentSetup.OffsetY;

            DrawHandle(g, x, y);                                                                                            // 谅惑
            DrawHandle(g, x, y + bound.Height * _documentSetup.ZoomFactor );                                                // 谅窍
            DrawHandle(g, x + bound.Width * _documentSetup.ZoomFactor, y);                                                  // 快惑
            DrawHandle(g, x + bound.Width * _documentSetup.ZoomFactor, y + bound.Height * _documentSetup.ZoomFactor);       // 快窍

            DrawHandle(g, x + bound.Width * _documentSetup.ZoomFactor / 2, y);                                              // 惑
            DrawHandle(g, x + bound.Width * _documentSetup.ZoomFactor / 2, y + bound.Height * _documentSetup.ZoomFactor);   // 窍
            DrawHandle(g, x, y + bound.Height * _documentSetup.ZoomFactor / 2);                                             // 谅
            DrawHandle(g, x + bound.Width * _documentSetup.ZoomFactor, y + bound.Height * _documentSetup.ZoomFactor / 2);   // 快
        }

        public void DrawHandle(System.Drawing.Graphics g, float x, float y)
        {
            float doubleSizeHandleSize = SizeHandleSize * 2;
            g.FillRectangle(System.Drawing.Brushes.White, x - SizeHandleSize, y - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
            g.DrawRectangle(System.Drawing.Pens.HotPink, x - SizeHandleSize, y - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            System.Drawing.PointF pt = UnApplyTransform(_documentSetup.OffsetX, _documentSetup.OffsetY, _documentSetup.ZoomFactor, new System.Drawing.PointF(e.X, e.Y));

            if (_dragInfo.IsDrag(e.X, e.Y))
            {
                // 

                // 
                System.Drawing.PointF objectStartPosition = _dragInfo.ObjectStartPosition;
                System.Drawing.SizeF objectStartSize = _dragInfo.ObjectStartSize;
                System.Drawing.PointF dragStartPosition = _dragInfo.StartPosition;

                if (_dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.PageMove)
                {
                    //AutoScrollPosition.Offset(
                    //    (int) (AutoScrollPosition.X - FitValue(objectStartPosition.X + e.X - dragStartPosition.X)),
                    //    (int) (AutoScrollPosition.Y - FitValue(objectStartPosition.Y + e.Y - dragStartPosition.Y)));

                    //AutoScrollPosition = new System.Drawing.Point(100, 100);
                    //AutoScrollPosition.Offset(100, 100);
                    AutoScrollPosition =
                        new System.Drawing.Point(-(int) FitValue(objectStartPosition.X + e.X - dragStartPosition.X),
                            -(int) FitValue(objectStartPosition.Y + e.Y - dragStartPosition.Y));

                    _documentSetup.ScrollX = AutoScrollPosition.X;
                    _documentSetup.ScrollY = AutoScrollPosition.Y;

                    //_documentSetup.ScrollX = FitValue(objectStartPosition.X + e.X - dragStartPosition.X);
                    //_documentSetup.ScrollY = FitValue(objectStartPosition.Y + e.Y - dragStartPosition.Y);

                    System.Diagnostics.Debug.WriteLine(string.Format("({0:0000}/ {1:0000}) - ({2:0000}/ {3:0000})", _documentSetup.ScrollX, _documentSetup.ScrollY, AutoScrollPosition.X, AutoScrollPosition.Y));

                    Invalidate();
                    return;
                }

                if (_selectedObject == null) return;

                float offsetX = (e.X - dragStartPosition.X)/_documentSetup.ZoomFactor;
                float offsetY = (e.Y - dragStartPosition.Y)/_documentSetup.ZoomFactor;

                //System.Diagnostics.Debug.WriteLine(string.Format("{0} / {1}", Math.Abs(offsetX), Math.Abs(offsetY)));

                switch (_dragInfo.DragOrigin)
                {
                    case HitTestInfo.HitObjectTypes.HandleNE:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X),
                                                              FitValue(objectStartPosition.Y + offsetY));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width + offsetX),
                                                         FitValue(objectStartSize.Height - offsetY));
                        break;
                    case HitTestInfo.HitObjectTypes.LineHandle1:
                    case HitTestInfo.HitObjectTypes.HandleNW:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X + offsetX),
                                                              FitValue(objectStartPosition.Y + offsetY));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width - offsetX),
                                                         FitValue(objectStartSize.Height - offsetY));
                        break;
                    case HitTestInfo.HitObjectTypes.LineHandle2:
                    case HitTestInfo.HitObjectTypes.HandleSE:
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width + offsetX),
                                                         FitValue(objectStartSize.Height + offsetY));
                        break;
                    case HitTestInfo.HitObjectTypes.HandleSW:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X + offsetX),
                                                              FitValue(objectStartPosition.Y));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width - offsetX),
                                                         FitValue(objectStartSize.Height + offsetY));
                        break;

                    case HitTestInfo.HitObjectTypes.HandleN:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X),
                                                              FitValue(objectStartPosition.Y + offsetY));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width),
                                                         FitValue(objectStartSize.Height - offsetY));
                        break;
                    case HitTestInfo.HitObjectTypes.HandleS:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X),
                                                              FitValue(objectStartPosition.Y));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width),
                                                         FitValue(objectStartSize.Height + offsetY));
                        break;
                    case HitTestInfo.HitObjectTypes.HandleW:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X + offsetX),
                                                              FitValue(objectStartPosition.Y));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width - offsetX),
                                                         FitValue(objectStartSize.Height));
                        break;
                    case HitTestInfo.HitObjectTypes.HandleE:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X),
                                                              FitValue(objectStartPosition.Y));
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(objectStartSize.Width + offsetX),
                                                         FitValue(objectStartSize.Height));
                        break;

                    default:
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(objectStartPosition.X + offsetX),
                                                              FitValue(objectStartPosition.Y + offsetY));
                        break;
                }

                if ((System.Windows.Forms.Control.ModifierKeys == System.Windows.Forms.Keys.ShiftKey || System.Windows.Forms.Control.ModifierKeys == System.Windows.Forms.Keys.Shift))
                {
                    if (_dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.LineHandle1 || _dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.LineHandle2)
                    {
                        if (System.Math.Abs(_selectedObject.Size.Width) > System.Math.Abs(_selectedObject.Size.Height))
                        {
                            if (_dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.LineHandle1)
                            {
                                _selectedObject.Location = new System.Drawing.PointF(_selectedObject.Location.X,
                                                                      _selectedObject.Location.Y +
                                                                      _selectedObject.Size.Height);
                                _selectedObject.Size = new System.Drawing.SizeF(_selectedObject.Size.Width, 0);
                            }

                            if (_dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.LineHandle2)
                            {
                                _selectedObject.Size = new System.Drawing.SizeF(_selectedObject.Size.Width, 0);
                            }
                        }
                        else
                        {
                            if (_dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.LineHandle1)
                            {
                                _selectedObject.Location = new System.Drawing.PointF(_selectedObject.Location.X +
                                                                      _selectedObject.Size.Width,
                                                                      _selectedObject.Location.Y);
                                _selectedObject.Size = new System.Drawing.SizeF(0, _selectedObject.Size.Height);
                            }

                            if (_dragInfo.DragOrigin == HitTestInfo.HitObjectTypes.LineHandle2)
                            {
                                _selectedObject.Size = new System.Drawing.SizeF(0, _selectedObject.Size.Height);
                            }
                        }
                    }
                }
            }
            else
            {
                // 

                var hti = HitTest(new System.Drawing.PointF(e.X, e.Y));

                switch(hti.HitObjectType)
                {
                    case HitTestInfo.HitObjectTypes.HandleN:
                    case HitTestInfo.HitObjectTypes.HandleS:
                        this.Cursor = System.Windows.Forms.Cursors.SizeNS;
                        break;
                    case HitTestInfo.HitObjectTypes.HandleE:
                    case HitTestInfo.HitObjectTypes.HandleW:
                        this.Cursor = System.Windows.Forms.Cursors.SizeWE;
                        break;
                    case HitTestInfo.HitObjectTypes.HandleNW:
                    case HitTestInfo.HitObjectTypes.HandleSE:
                        this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                        break;
                    case HitTestInfo.HitObjectTypes.Command:
                        if (_selectedObject != null && hti.HitObject == _selectedObject)
                            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
                        else
                            this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        break;
                    case HitTestInfo.HitObjectTypes.HandleNE:
                    case HitTestInfo.HitObjectTypes.HandleSW:
                        this.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                        break;
                    case HitTestInfo.HitObjectTypes.LineHandle1:
                    case HitTestInfo.HitObjectTypes.LineHandle2:
                        this.Cursor = System.Windows.Forms.Cursors.SizeAll;
                        break;
                    case HitTestInfo.HitObjectTypes.PageMove:
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        break;
                    case HitTestInfo.HitObjectTypes.Unknown:
                    default:
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        break;
                }
            }

            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (_isSpaceKeyDown)
                {
                    _dragInfo.StartDrag(e.X, e.Y, new System.Drawing.PointF(_documentSetup.ScrollX, _documentSetup.ScrollY),
                                        new System.Drawing.SizeF(_documentSetup.PageWidth, _documentSetup.PageHeight),
                                        HitTestInfo.HitObjectTypes.PageMove);

                    return;
                }
            }

            if (SelectedTool != Tools.ArrowTool)
            {
                Tools tool = SelectedTool;

                System.Drawing.PointF drawStartPoint = UnApplyTransform(_documentSetup.OffsetX, _documentSetup.OffsetY,
                    _documentSetup.ZoomFactor, new System.Drawing.PointF(e.X, e.Y));
                ItsBarcode.GeneralDrawCommand newObject = null;

                switch (tool)
                {
                    case Tools.BarcodeTool:
                        newObject = this.AddBarcode("1234", new System.Drawing.RectangleF(drawStartPoint.X, drawStartPoint.Y, 0, 0));
                        break;
                    case Tools.LineTool:
                        newObject = this.AddLine(new System.Drawing.RectangleF(drawStartPoint.X, drawStartPoint.Y, 0, 0));
                        break;
                    case Tools.ImageTool:
                        System.Drawing.Bitmap tempImage = new System.Drawing.Bitmap(100, 100);
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(tempImage))
                        {
                            g.FillRectangle(System.Drawing.Brushes.LightPink, new System.Drawing.Rectangle(0, 0, 100, 100));
                            g.DrawString("NO\nIMAGE", new System.Drawing.Font(this.Font.FontFamily, 20), System.Drawing.Brushes.White, new System.Drawing.PointF(0, 0));
                        }
                        newObject = this.AddImage(tempImage, new System.Drawing.RectangleF(drawStartPoint.X, drawStartPoint.Y, 0, 0));
                        break;
                    case Tools.TextTool:
                        newObject = this.AddText("新标签", new System.Drawing.RectangleF(drawStartPoint.X, drawStartPoint.Y, 0, 0));
                        break;
                    case Tools.CircleTool:
                        newObject = this.AddCircle(new System.Drawing.RectangleF(drawStartPoint.X, drawStartPoint.Y, 0, 0));
                        break;
                    case Tools.RectangleTool:
                        newObject = this.AddRectangle(new System.Drawing.RectangleF(drawStartPoint.X, drawStartPoint.Y, 0, 0));
                        break;
                }

                SelectedTool = Tools.ArrowTool;

                if (newObject != null)
                {
                    _selectedObject = newObject;
                    OnSelectedCmdChanged();

                    if (tool == Tools.LineTool)
                    {
                        // 
                        _dragInfo.StartDrag(e.X, e.Y, _selectedObject.Location, _selectedObject.Size,
                            HitTestInfo.HitObjectTypes.LineHandle2);
                    }
                    else
                    {
                        // 
                        _dragInfo.StartDrag(e.X, e.Y, _selectedObject.Location, _selectedObject.Size,
                            HitTestInfo.HitObjectTypes.HandleSE);
                    }
                    Invalidate();

                    return;
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ItsBarcode.GeneralDrawCommand newSelectedObject = null;

                var hti = HitTest(new System.Drawing.PointF(e.X, e.Y));
                newSelectedObject = hti.HitObject;
                               
                if (_selectedObject == newSelectedObject && newSelectedObject != null)
                {
                    _dragInfo.StartDrag(e.X, e.Y, _selectedObject.Location, _selectedObject.Size, hti.HitObjectType);
                }

                _selectedObject = newSelectedObject;
                
                OnSelectedCmdChanged();
                Invalidate();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                System.Drawing.Point pt = this.PointToScreen(new System.Drawing.Point(e.X, e.Y));

                contextMenuStrip_Menu.Show(pt.X, pt.Y);
            }
        }

        protected HitTestInfo HitTest(System.Drawing.PointF pt)
        {
            ItsBarcode.GeneralDrawCommand newSelectedObject = null;

            using (System.Drawing.Graphics g = this.CreateGraphics())
            {
                if (_selectedObject != null)
                {
                    System.Drawing.RectangleF rect;

                    // 
                    float doubleSizeHandleSize = SizeHandleSize * 2;

                    if (_selectedObject is ItsBarcode.DrawLineCmd)
                    {
                        rect = ApplyTransform(_documentSetup.OffsetX, _documentSetup.OffsetY, _documentSetup.ZoomFactor, _selectedObject.Rect);

                        System.Drawing.RectangleF lineHandle1 = new System.Drawing.RectangleF(rect.X - SizeHandleSize, rect.Y - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                        if (lineHandle1.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.LineHandle1);

                        System.Drawing.RectangleF lineHandle2 = new System.Drawing.RectangleF(rect.Right - SizeHandleSize, rect.Bottom - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                        if (lineHandle2.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.LineHandle2);
                    }

                    rect = ApplyTransform(_documentSetup.OffsetX, _documentSetup.OffsetY, _documentSetup.ZoomFactor, _selectedObject.GetBound(g));

                    System.Drawing.RectangleF ne = new System.Drawing.RectangleF(rect.X - SizeHandleSize, rect.Y - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (ne.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleNW);

                    System.Drawing.RectangleF nw = new System.Drawing.RectangleF(rect.Right - SizeHandleSize, rect.Y - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (nw.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleNE);
                    
                    System.Drawing.RectangleF se = new System.Drawing.RectangleF(rect.X - SizeHandleSize, rect.Bottom - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (se.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleSW);
                    
                    System.Drawing.RectangleF sw = new System.Drawing.RectangleF(rect.Right - SizeHandleSize, rect.Bottom - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (sw.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleSE);

                    System.Drawing.RectangleF north = new System.Drawing.RectangleF(rect.X + rect.Width / 2 - SizeHandleSize, rect.Y - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (north.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleN);

                    System.Drawing.RectangleF south = new System.Drawing.RectangleF(rect.X + rect.Width / 2 - SizeHandleSize, rect.Bottom - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (south.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleS);

                    System.Drawing.RectangleF west = new System.Drawing.RectangleF(rect.X - SizeHandleSize, rect.Y + rect.Height / 2 - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (west.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleW);

                    System.Drawing.RectangleF east = new System.Drawing.RectangleF(rect.Right - SizeHandleSize, rect.Y + rect.Height / 2 - SizeHandleSize, doubleSizeHandleSize, doubleSizeHandleSize);
                    if (east.Contains(pt)) return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.HandleE);
                }
                
                pt = UnApplyTransform(_documentSetup.OffsetX, _documentSetup.OffsetY, _documentSetup.ZoomFactor, pt);

                const int lineCmdMinimumWidthHeight = 5;

                #region 
                /*
                if (_selectedObject != null)
                {
                    System.Drawing.RectangleF rect = _selectedObject.GetBound(g);
                    if (_selectedObject is CmBarcode.DrawLineCmd)
                    {
                        float dWidth = 0;
                        float dHeight = 0;

                        if (rect.Width < lineCmdMinimumWidthHeight)
                        {
                            dWidth = (lineCmdMinimumWidthHeight - rect.Width)/2;
                        }
                        if (rect.Height < lineCmdMinimumWidthHeight)
                        {
                            dHeight = (lineCmdMinimumWidthHeight - rect.Height)/2;
                        }

                        if (dWidth != 0 || dHeight != 0)
                            rect = new System.Drawing.RectangleF(rect.X - dWidth, rect.Y - dHeight, rect.Width + dWidth + dWidth, rect.Height + dHeight + dHeight);
                    }

                    if (rect.Contains(pt))
                    {
                        return new HitTestInfo(_selectedObject, HitTestInfo.HitObjectTypes.Command);
                    }
                }
                 */
                #endregion

                if (_ItsBarcode.DrawCommandList.Count > 0)
                {
                    for (int i = _ItsBarcode.DrawCommandList.Count - 1; i >= 0; i--)
                    {
                        ItsBarcode.GeneralDrawCommand cmd = _ItsBarcode.DrawCommandList[i];
                        System.Drawing.RectangleF rect = cmd.GetBound(g);

                        if (cmd is ItsBarcode.DrawLineCmd)   // 
                        {
                            float dWidth = 0;
                            float dHeight = 0;

                            // 
                            if (rect.Width < lineCmdMinimumWidthHeight)
                            {
                                dWidth = (lineCmdMinimumWidthHeight - rect.Width)/2;
                            }
                            if (rect.Height < lineCmdMinimumWidthHeight)
                            {
                                dHeight = (lineCmdMinimumWidthHeight - rect.Height)/2;
                            }

                            if (dWidth != 0 || dHeight != 0)
                                rect = new System.Drawing.RectangleF(rect.X - dWidth, rect.Y - dHeight, rect.Width + dWidth + dWidth,
                                                      rect.Height + dHeight + dHeight);
                        }

                        if (cmd is ItsBarcode.DrawRectCmd && (cmd.BackColor == System.Drawing.Color.Transparent || cmd.BackColor.A == 0))
                        {
                            // 
                            const int lineWidth = 2;

                            System.Drawing.RectangleF topRect = new System.Drawing.RectangleF(rect.X, rect.Y - lineWidth, rect.Width, lineWidth * 2);
                            System.Drawing.RectangleF leftRect = new System.Drawing.RectangleF(rect.X - lineWidth, rect.Y, lineWidth * 2, rect.Height);
                            System.Drawing.RectangleF rightRect = new System.Drawing.RectangleF(rect.Right - lineWidth, rect.Y, lineWidth * 2, rect.Height);
                            System.Drawing.RectangleF bottomRect = new System.Drawing.RectangleF(rect.X, rect.Bottom - lineWidth, rect.Width, lineWidth * 2);

                            if (topRect.Contains(pt) || leftRect.Contains(pt) || rightRect.Contains(pt) || bottomRect.Contains(pt))
                            {
                                newSelectedObject = cmd;
                                break;
                            }
                        } 
                        else if (rect.Contains(pt))
                        {
                            // 
                            newSelectedObject = cmd;
                            break;
                        }
                    }
                }
            }

            return new HitTestInfo(newSelectedObject, HitTestInfo.HitObjectTypes.Command);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            // 靛贰弊 辆丰
            _dragInfo.EndDrag();

            if (_selectedObject != null)
            {
                if (_selectedObject is ItsBarcode.DrawLineCmd)
                {
                    // 流急老 版快 呈厚客 臭捞啊 笛促 0老锭 昏力
                    if (_selectedObject.Rect.Width == 0 && _selectedObject.Rect.Height == 0)
                    {
                        DeleteSelectedObject();
                    }
                }
                else
                {
                    // 流急捞 酒囱 版快 呈厚唱 臭捞啊 0捞搁 昏力
                    if (_selectedObject.Rect.Width == 0 || _selectedObject.Rect.Height == 0)
                    {
                        DeleteSelectedObject();
                    }
                }
            }

            OnPropertyChanged("");
        }

        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            _documentSetup.ZoomFactor = _documentSetup.ZoomFactor + e.Delta / 1000.0F;
            Invalidate();

            OnZoomChanged();

            //base.OnMouseWheel(e);
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            System.Windows.Forms.Keys keyCode = (keyData & System.Windows.Forms.Keys.KeyCode);
            System.Windows.Forms.Keys modifier = keyData & System.Windows.Forms.Keys.Modifiers;
            bool isControlEnabled = (modifier & System.Windows.Forms.Keys.Control) == System.Windows.Forms.Keys.Control;
            bool isShiftEnabled = (modifier & System.Windows.Forms.Keys.Shift) == System.Windows.Forms.Keys.Shift;
            float movement = 0.25F;
            bool handled = false;

            if (_selectedObject != null)
            {
                if (keyCode == System.Windows.Forms.Keys.Left)
                {
                    if (isControlEnabled) movement = 1;
                    if (isShiftEnabled)
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(_selectedObject.Size.Width - movement),
                                                         FitValue(_selectedObject.Size.Height));
                    else
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(_selectedObject.Location.X - movement),
                                                              FitValue(_selectedObject.Location.Y));
                    OnPropertyChanged("");
                    handled = true;
                    Invalidate();
                }
                else if (keyCode == System.Windows.Forms.Keys.Right)
                {
                    if (isControlEnabled) movement = 1;
                    if (isShiftEnabled)
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(_selectedObject.Size.Width + movement),
                                                         FitValue(_selectedObject.Size.Height));
                    else
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(_selectedObject.Location.X + movement),
                                                              FitValue(_selectedObject.Location.Y));
                    OnPropertyChanged("");
                    handled = true;
                    Invalidate();
                }
                else if (keyCode == System.Windows.Forms.Keys.Up)
                {
                    if (isControlEnabled) movement = 1;
                    if (isShiftEnabled)
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(_selectedObject.Size.Width),
                                                         FitValue(_selectedObject.Size.Height - movement));
                    else
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(_selectedObject.Location.X),
                                                              FitValue(_selectedObject.Location.Y - movement));
                    OnPropertyChanged("");
                    handled = true;
                    Invalidate();
                }
                else if (keyCode == System.Windows.Forms.Keys.Down)
                {
                    if (isControlEnabled) movement = 1;
                    if (isShiftEnabled)
                        _selectedObject.Size = new System.Drawing.SizeF(FitValue(_selectedObject.Size.Width),
                                                         FitValue(_selectedObject.Size.Height + movement));
                    else
                        _selectedObject.Location = new System.Drawing.PointF(FitValue(_selectedObject.Location.X),
                                                              FitValue(_selectedObject.Location.Y + movement));
                    OnPropertyChanged("");
                    handled = true;
                    Invalidate();
                }
                else if (keyCode == System.Windows.Forms.Keys.OemOpenBrackets)
                {
                    if (isControlEnabled) 
                        SendToBack();
                    else
                        SendToBackward();
                    handled = true;
                    Invalidate();
                }
                else if (keyCode == System.Windows.Forms.Keys.OemCloseBrackets)
                {
                    if (isControlEnabled)
                        SendToFront();
                    else
                        SendToForward();
                    handled = true;
                    Invalidate();
                }
            }

            if (handled)
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == System.Windows.Forms.Keys.Space)
            {
                _isSpaceKeyDown = true;
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == System.Windows.Forms.Keys.Space)
            {
                _isSpaceKeyDown = false;
                Cursor = System.Windows.Forms.Cursors.Default;
            } else if (e.KeyCode == System.Windows.Forms.Keys.Delete && e.Modifiers == System.Windows.Forms.Keys.None)
            {
                DeleteSelectedObject();
            }
        }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);

            Focus();
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);

            _isSpaceKeyDown = false;
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            Focus();
        }

        protected override void OnScroll(System.Windows.Forms.ScrollEventArgs se)
        {
            base.OnScroll(se);

            _documentSetup.ScrollX = AutoScrollPosition.X;
            _documentSetup.ScrollY = AutoScrollPosition.Y;
        }

        public void ClearCanvas()
        {
            using (System.Drawing.Graphics bg = System.Drawing.Graphics.FromImage(_backBuffer))
            {
                bg.FillRectangle(_brushList.GetBrush(System.Drawing.Color.LightGray), 0, 0, Width, Height);

                bg.FillRectangle(_brushList.GetBrush(System.Drawing.Color.White), _documentSetup.OffsetX, _documentSetup.OffsetY,
                                 _documentSetup.PageWidth*_documentSetup.ZoomFactor,
                                 _documentSetup.PageHeight*_documentSetup.ZoomFactor);
                bg.DrawRectangle(_penList.GetPen(System.Drawing.Color.Black, 1), _documentSetup.OffsetX, _documentSetup.OffsetY,
                                 _documentSetup.PageWidth*_documentSetup.ZoomFactor,
                                 _documentSetup.PageHeight*_documentSetup.ZoomFactor);
            }
        }

        #region IDisposable Members

        void System.IDisposable.Dispose()
        {
            _backBuffer.Dispose();
            _ItsBarcode.Dispose();
            _brushList.Dispose();
            _penList.Dispose();
            _fontList.Dispose();
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public static float FitValue(float value)
        {
            const float fitFactor = 0.25F;
            const float fitFactorHalf = fitFactor / 2F;

            float remainder = System.Math.Abs(value) % fitFactor;
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

        #region ItsBarcode Delegate

        public ItsBarcode.DrawTextCmd AddText(string Text, float X, float Y)
        {
            ItsBarcode.DrawTextCmd newObject = _ItsBarcode.AddText(Text, X, Y);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawTextCmd AddText(string Text, float X, float Y, float Width, float Height)
        {
            ItsBarcode.DrawTextCmd newObject = _ItsBarcode.AddText(Text, X, Y, Width, Height);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawTextCmd AddText(string Text, System.Drawing.RectangleF Rect)
        {
            ItsBarcode.DrawTextCmd newObject = _ItsBarcode.AddText(Text, Rect);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawImgCmd AddImage(System.Drawing.Image Image, float Left, float Top, float Width, float Height)
        {
            ItsBarcode.DrawImgCmd newObject = _ItsBarcode.AddImage(Image, Left, Top, Width, Height);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawImgCmd AddImage(System.Drawing.Image Image, System.Drawing.RectangleF Rect)
        {
            ItsBarcode.DrawImgCmd newObject = _ItsBarcode.AddImage(Image, Rect);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawBarcodeCmd AddBarcode(string Code, float Left, float Top, float Width, float Height)
        {
            ItsBarcode.DrawBarcodeCmd newObject = _ItsBarcode.AddBarcode(Code, Left, Top, Width, Height);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawBarcodeCmd AddBarcode(string Code, System.Drawing.RectangleF Rect)
        {
            ItsBarcode.DrawBarcodeCmd newObject = _ItsBarcode.AddBarcode(Code, Rect);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawLineCmd AddLine(float X1, float Y1, float X2, float Y2)
        {
            ItsBarcode.DrawLineCmd newObject = _ItsBarcode.AddLine(X1, Y1, X2, Y2);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawLineCmd AddLine(System.Drawing.RectangleF Rect)
        {
            ItsBarcode.DrawLineCmd newObject = _ItsBarcode.AddLine(Rect);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawCircleCmd AddCircle(float x1, float y1, float x2, float y2)
        {
            ItsBarcode.DrawCircleCmd newObject = _ItsBarcode.AddCircle(x1, y1, x2, y2);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawCircleCmd AddCircle(System.Drawing.RectangleF Rect)
        {
            ItsBarcode.DrawCircleCmd newObject = _ItsBarcode.AddCircle(Rect);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawRectCmd AddRectangle(float x1, float y1, float x2, float y2)
        {
            ItsBarcode.DrawRectCmd newObject = _ItsBarcode.AddRectangle(x1, y1, x2, y2);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public ItsBarcode.DrawRectCmd AddRectangle(System.Drawing.RectangleF Rect)
        {
            ItsBarcode.DrawRectCmd newObject = _ItsBarcode.AddRectangle(Rect);

            _selectedObject = newObject;
            Invalidate();
            return newObject;
        }

        public void SendToForward()
        {
            if (_selectedObject == null) return;

            int oldIndex = _ItsBarcode.DrawCommandList.IndexOf(_selectedObject);
            if (oldIndex == -1) return;

            int newIndex = System.Math.Min(oldIndex+1, System.Math.Max(_ItsBarcode.DrawCommandList.Count - 1, 0));

            _ItsBarcode.DrawCommandList.Remove(_selectedObject);
            _ItsBarcode.DrawCommandList.Insert(newIndex, _selectedObject);
        }

        public void SendToBackward()
        {
            if (_selectedObject == null) return;

            int oldIndex = _ItsBarcode.DrawCommandList.IndexOf(_selectedObject);
            if (oldIndex == -1) return;

            _ItsBarcode.DrawCommandList.Remove(_selectedObject);
            _ItsBarcode.DrawCommandList.Insert(System.Math.Max(oldIndex - 1, 0), _selectedObject);
        }

        public void SendToFront()
        {
            if (_selectedObject == null) return;

            int oldIndex = _ItsBarcode.DrawCommandList.IndexOf(_selectedObject);
            if (oldIndex == -1) return;

            _ItsBarcode.DrawCommandList.Remove(_selectedObject);
            _ItsBarcode.DrawCommandList.Insert(System.Math.Max(_ItsBarcode.DrawCommandList.Count, 0), _selectedObject);
        }

        public new void SendToBack()
        {
            if (_selectedObject == null) return;

            int oldIndex = _ItsBarcode.DrawCommandList.IndexOf(_selectedObject);
            if (oldIndex == -1) return;

            _ItsBarcode.DrawCommandList.Remove(_selectedObject);
            _ItsBarcode.DrawCommandList.Insert(0, _selectedObject);
        }

        public void Clear()
        {
            _selectedObject = null;

            _ItsBarcode.Clear();

            _documentSetup.PageWidth = 210;
            _documentSetup.PageHeight = 297;
            //_documentSetup.OffsetX = 0;
            //_documentSetup.OffsetY = 0;
            _documentSetup.VirtualWidth = AutoScrollMinSize.Width;
            _documentSetup.VirtualHeight = AutoScrollMinSize.Height;
            _documentSetup.MarginLeft = 0;
            _documentSetup.MarginTop = 0;
            _documentSetup.MarginRight = 0;
            _documentSetup.MarginBottom = 0;
            _documentSetup.Landscape = false;

            AutoScrollPosition = new System.Drawing.Point(AutoScrollMinSize.Width / 2 - (int)(_documentSetup.PageWidth),
                               AutoScrollMinSize.Height / 2 - (int)(_documentSetup.PageHeight));
            _documentSetup.ScrollX = AutoScrollPosition.X;
            _documentSetup.ScrollY = AutoScrollPosition.Y;

            _documentSetup.ZoomFactor = 1;
            this.Zoom = 1;

            _selectedObject = null;
            OnSelectedCmdChanged();
        }

        #endregion

        #region 皋春急琶

        private void toolStripMenuItem_AddLine_Click(object sender, System.EventArgs e)
        {
            SelectedTool = Tools.LineTool;
            //AddLine(new System.Drawing.RectangleF(0, 0, 100, 100));
        }

        private void toolStripMenuItem_AddRectangle_Click(object sender, System.EventArgs e)
        {
            SelectedTool = Tools.RectangleTool;
            //AddRectangle(new System.Drawing.RectangleF(0, 0, 100, 100));
        }

        private void toolStripMenuItem_AddCircle_Click(object sender, System.EventArgs e)
        {
            SelectedTool = Tools.CircleTool;
            //AddRectangle(new System.Drawing.RectangleF(0, 0, 100, 100));
        }

        private void toolStripMenuItem_AddText_Click(object sender, System.EventArgs e)
        {
            SelectedTool = Tools.TextTool;
            //AddBarcode("Text", 0, 0, 100, 100);
        }

        private void toolStripMenuItem_AddBarcode_Click(object sender, System.EventArgs e)
        {
            SelectedTool = Tools.BarcodeTool;
            //AddBarcode("123456789", 0, 0, 100, 100);
        }

        private void toolStripMenuItem_AddImage_Click(object sender, System.EventArgs e)
        {
            SelectedTool = Tools.ImageTool;
            //AddImage(new System.Drawing.Bitmap(100, 100), 0, 0, 100, 100);
        }

        private void toolStripMenuItem_SendToForward_Click(object sender, System.EventArgs e)
        {
            SendToForward();
        }

        private void toolStripMenuItem_SendToBackward_Click(object sender, System.EventArgs e)
        {
            SendToBackward();
        }

        private void toolStripMenuItem_SendToFront_Click(object sender, System.EventArgs e)
        {
            SendToFront();
        }

        private void toolStripMenuItem_SendToBack_Click(object sender, System.EventArgs e)
        {
            SendToBack();
        }

        private void toolStripMenuItem_Preview_Click(object sender, System.EventArgs e)
        {
            _ItsBarcode.Print(true);
        }

        private void toolStripMenuItem_Delete_Click(object sender, System.EventArgs e)
        {
            DeleteSelectedObject();
        }

        private void DeleteSelectedObject()
        {
            if (_selectedObject != null)
            {
                _ItsBarcode.DrawCommandList.Remove(_selectedObject);
                _selectedObject = null;
                Invalidate();
            }
        }

        #endregion

        public string SaveToXml()
        {
            //System.Xml.Serialization.XmlSerializer serializer =
            //    new System.Xml.Serialization.XmlSerializer(typeof (List<CmBarcode.GeneralDrawCommand>));

            //using(var ms = new System.IO.MemoryStream())
            //using(var textWriter = new System.IO.StreamWriter(ms, Encoding.UTF8))
            //{
            //    serializer.Serialize(textWriter, _cmBarcode.DrawCommandList);
                
            //    textWriter.Close();

            //    return Encoding.UTF8.GetString(ms.ToArray());
            //}

            return _ItsBarcode.SaveToXml();
        }

        public void LoadFromXml(string xml)
        {
            try
            {
                Clear();
                _selectedObject = null;

                _ItsBarcode.LoadFromXml(xml);

                // 关俊辑 PageWidth 殿阑 何咯且锭 捞亥飘甫 鸥扁 锭巩俊 咯扁辑 函荐肺 罐绊 蔼阑 持澜
                float pageWidth = _ItsBarcode.PageWidth;
                float pageHeight = _ItsBarcode.PageHeight;
                float pageRotation = _ItsBarcode.PageRotation;
                float marginLeft = _ItsBarcode.MarginLeft;
                float marginTop = _ItsBarcode.MarginTop;
                float marginRight = _ItsBarcode.MarginRight;
                float marginBottom = _ItsBarcode.MarginBottom;
                bool landscape = _ItsBarcode.Landscape;

                _documentSetup.PageWidth = pageWidth;
                _documentSetup.PageHeight = pageHeight;
                //_documentSetup.OffsetX = 0;
                //_documentSetup.OffsetY = 0;
                _documentSetup.VirtualWidth = AutoScrollMinSize.Width;
                _documentSetup.VirtualHeight = AutoScrollMinSize.Height;
                _documentSetup.MarginLeft = marginLeft;
                _documentSetup.MarginTop = marginTop;
                _documentSetup.MarginRight = marginRight;
                _documentSetup.MarginBottom = marginBottom;
                _documentSetup.Landscape = landscape;
                _documentSetup.PageRotation = pageRotation;

                AutoScrollPosition =
                    new System.Drawing.Point((int)(_documentSetup.VirtualWidth / 2) - (int)pageWidth,
                        (int)(_documentSetup.VirtualHeight / 2) - (int)pageHeight);
                _documentSetup.ScrollX = AutoScrollPosition.X;
                _documentSetup.ScrollY = AutoScrollPosition.Y;

                _documentSetup.ZoomFactor = 1.0F;
                this.Zoom = 1;

                Invalidate();
            }
            catch (System.Exception ex)
            {
                ItsMsgBox.ShowErr(ex.Message);
            }
        }

        public System.Drawing.Image Render()
        {
            return Render(0, 0);
        }

        public System.Drawing.Image Render(int width, int height)
        {
            int baseSize = 0;

            if (width <= 0 && height <= 0)
            {
                baseSize = 800;
            }

            if (_ItsBarcode.PageHeight < _ItsBarcode.PageWidth)
            {
                height = baseSize;
                width = (int)(baseSize * _ItsBarcode.PageWidth / _ItsBarcode.PageHeight);
            }
            else
            {
                width = baseSize;
                height = (int) (baseSize*_ItsBarcode.PageHeight/_ItsBarcode.PageWidth);
            }

            return _ItsBarcode.Render(width, height);
        }

        public void Print()
        {
            _ItsBarcode.Print(false);
        }

        public void Preview()
        {
            _ItsBarcode.Print(true);
        }
    }
}
