namespace LabelDesign
{
    internal class DragInfo
    {
        private const int _threshold = 5;

        public bool IsDrag(float x, float y)
        {
            if (_isDrag)
            {
                if (_isDragStartedReally) return true;

                if (System.Math.Abs(_startPosition.X - x) > _threshold)
                {
                    _isDragStartedReally = true;
                    return true;
                }
                if (System.Math.Abs(_startPosition.Y - y) > _threshold)
                {
                    _isDragStartedReally = true;
                    return true;
                }
            }

            return false;
        }

        public bool IsDrag()
        {
            if (_isDragStartedReally) return true;

            return false;
        }

        public System.Drawing.PointF GetNewPosition(float x, float y)
        {
            return new System.Drawing.PointF(ObjectStartPosition.X + (x - StartPosition.X), ObjectStartPosition.Y + (y - StartPosition.Y));
        }

        private bool _isDrag = false;
        private bool _isDragStartedReally = false;

        public System.Drawing.PointF StartPosition
        {
            get { return _startPosition; }
            private set { _startPosition = value; }
        }
        private System.Drawing.PointF _startPosition;
        public System.Drawing.PointF ObjectStartPosition
        {
            get { return _objectStartPosition; }
            private set { _objectStartPosition = value; }
        }
        private System.Drawing.PointF _objectStartPosition;
        public System.Drawing.SizeF ObjectStartSize
        {
            get { return _objectStartSize; }
            set { _objectStartSize = value; }
        }
        private System.Drawing.SizeF _objectStartSize;

        public HitTestInfo.HitObjectTypes DragOrigin
        {
            get { return _dragOrigin; }
            private set { _dragOrigin = value; }
        }
        private HitTestInfo.HitObjectTypes _dragOrigin = HitTestInfo.HitObjectTypes.Command;

        public void StartDrag(float x, float y, System.Drawing.PointF objectPosition, System.Drawing.SizeF objectSize)
        {
            StartDrag(x, y, objectPosition, objectSize, HitTestInfo.HitObjectTypes.Command);
        }

        public void StartDrag(float x, float y, System.Drawing.PointF objectPosition, System.Drawing.SizeF objectSize, HitTestInfo.HitObjectTypes objectType)
        {
            this.StartPosition = new System.Drawing.PointF(x, y);
            this.ObjectStartPosition = objectPosition;
            this.ObjectStartSize = objectSize;
            this.DragOrigin = objectType;

            _isDrag = true;
            _isDragStartedReally = false;
        }

        public void EndDrag()
        {
            _isDrag = false;
            _isDragStartedReally = false;

            if (OnEndDrag != null) OnEndDrag(this, System.EventArgs.Empty);
        }

        public delegate void EndDragEventHandler(object Sender, System.EventArgs e);
        public event EndDragEventHandler OnEndDrag;
    }
}
