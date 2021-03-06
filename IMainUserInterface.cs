﻿using System.Collections.Generic;

namespace detect_a_person_in_video
{
    internal interface IMainUserInterface : IUserInterface, IInputDisplayable
    {
        void DisplayProcessResult(List<DetectionResult> detectionResults);
    }
}