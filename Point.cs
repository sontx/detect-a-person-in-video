namespace detect_a_person_in_video
{
    internal struct Point
    {      
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; internal set; }
        public double Y { get; internal set; }
    }
}