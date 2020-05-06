using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;

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

        public Vector3 Up { get; set; }

        public Vector3 Front { get; set; }

        public Vector3 Right { get; set; }

        public Vector3 Eye { get; set; }

        public Vector3 LookAt { get; set; }

        public Matrix4 Projection { get; set; }

        public Matrix4 View { get; set; }

        public Matrix4 Model { get; set; }

        public Matrix4 MVP { get; set; }

        public Double AspectRatio { get; set; }

        public CameraControl()
        {

        }

        public void SetWindowSize(int width, int height)
        {
            AspectRatio = width / height;
        }

        public void SetProjectionParameter()
        {
            
        }
    }
}
