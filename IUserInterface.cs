using System.Windows.Forms;

namespace detect_a_person_in_video
{
    internal interface IUserInterface : ILogable
    {
        DialogResult ShowMessageBox(string message, MessageBoxIcon icon, MessageBoxButtons buttons);
    }
}