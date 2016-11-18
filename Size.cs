namespace detect_a_person_in_video
{
    internal struct Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height { get; internal set; }
        public double Width { get; internal set; }
    }
}