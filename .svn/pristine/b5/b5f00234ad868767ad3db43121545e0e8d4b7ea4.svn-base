namespace LabelDesign
{
    public struct HitTestInfo
    {
        public ItsBarcode.GeneralDrawCommand HitObject
        {
            get { return _hitObject; }
            private set { _hitObject = value; }
        }
        private ItsBarcode.GeneralDrawCommand _hitObject;

        public HitObjectTypes HitObjectType
        {
            get { return _hitObjectType; }
            private set { _hitObjectType = value; }
        }
        private HitObjectTypes _hitObjectType;

        public enum HitObjectTypes
        {
            Unknown = 0,
            Command, 
            HandleNE,   
            HandleN,
            HandleNW,
            HandleE,
            HandleW,
            HandleSE,
            HandleS,
            HandleSW,

            LineHandle1, 
            LineHandle2,

            PageMove,
        }

        public HitTestInfo(ItsBarcode.GeneralDrawCommand hitObject, HitObjectTypes hitObjectType)
        {
            _hitObject = hitObject;
            _hitObjectType = hitObjectType;
        }
    }
}
