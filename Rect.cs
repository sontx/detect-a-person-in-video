namespace detect_a_person_in_video
{
    internal struct Rect
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public bool IsEmpty
        {
            get { return Left == 0 && Top == 0 && Width == 0 && Height == 0; }
        }

        public Rect(Point point, Size size)
        {
            Left = point.X;
            Top = point.Y;
            Width = size.Width;
            Height = size.Height;
        }
    }
}