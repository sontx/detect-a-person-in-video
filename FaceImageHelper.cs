using System.IO;

namespace detect_a_person_in_video
{
    internal static class FaceImageHelper
    {
        public static string BuildFaceImageName(int faceFrameSeconds, int faceId)
        {
            return string.Format("{0}_{1}.png", faceFrameSeconds, faceId);
        }

        public static int ExtractSecondsInFaceImageName(string faceImageName)
        {
            string fileName = Path.GetFileName(faceImageName);
            string sSeconds = fileName.Substring(0, fileName.IndexOf('_'));
            return int.Parse(sSeconds);
        }
    }
}