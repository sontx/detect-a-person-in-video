using System.Drawing;

namespace detect_a_person_in_video
{
    internal class FrameHighlight
    {
        public Rect[] HighlightRects { get; set; }
        public float Time { get; set; }
        public int FaceId { get; set; }
    }
}