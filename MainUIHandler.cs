using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace detect_a_person_in_video
{
    class MainUIHandler
    {
        private readonly IMainUserInterface mainUserInterface;
        private readonly VisionService visionService;  
        
        public string VideoInputPath
        {
            get { return visionService.VideoInputPath; }
            set
            {
                visionService.VideoInputPath = value;
                mainUserInterface.DisplayVideoInput(value);
            }
        }

        public string ImageInputPath
        {
            get { return visionService.ImageInputPath; }
            set
            {
                visionService.ImageInputPath = value;
                mainUserInterface.DisplayFaceInput(value);
            }
        }

        public MainUIHandler(IMainUserInterface mainUserInterface)
        {
            this.mainUserInterface = mainUserInterface;
            this.visionService = new VisionService();
        }
    }
}
