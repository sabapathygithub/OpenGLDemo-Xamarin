using System;
using System.Collections.Generic;
using System.Text;

namespace Opengl_Sample.Shaders
{
    public class CameraControl
    {
        public const double FIELD_OF_VIEW_MAX = 90.0;
        public const double FIELD_OF_VIEW_MIN = 5.0;
        public const double FIELD_OF_VIEW_DEFAULT = 60.0;
        public const double FIELD_OF_VIEW_STEP = 5.0;
        public const double ZOOM_DEFAULT = 0.7;
        public const double ZOOM_MIN = 0.02;
        public const double ZOOM_MAX = 2.0;
        public const double ZOOM_STEP = 0.02;
        public const double ROTATION_RADIAN_PER_PIXEL = 0.003;
    }
}
