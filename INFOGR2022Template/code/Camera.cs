using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Camera
    {
        Vector3 position;
        public Vector3 forwardDirection, upwardDirection, rightDirection;
        Vector3 planeCenter;
        public Vector3[] plane;
        float distance;

        float aspectRatio;
        public int FOV;

        public Vector3 Position { get { return position; } }

        /* Camera constructor. Parameters set the position of the camera and the FOV (field of view).
         * First, the position and three normal vectors are initialized.
         * Then, the aspect ratio and FOV are set.
         * After this, the plane in front of the camera is created using the aforementioned normal vectors and an FOV-based distance.
         */
        public Camera(Vector3 pos, int fov)
        {
            position = pos;
            forwardDirection = new Vector3(0, 1, 0);
            upwardDirection = new Vector3(0, 0, 1);
            rightDirection = new Vector3(1, 0, 0);

            aspectRatio = 4 / 3;
            FOV = fov;

            distance = position.X / (float)Math.Tan(FOV * ((float)Math.PI / 180) / 2);
            planeCenter = position.Plus(forwardDirection.MultiplyFloat(distance));
            plane = GetCorners();
        }

        // Returns the plane's four corners. Technically, only three are needed, but this saves further calculation.
        Vector3[] GetCorners()
        {
            return new Vector3[4]
            {
                planeCenter.Plus(upwardDirection).Minus(rightDirection.MultiplyFloat(aspectRatio)),
                planeCenter.Plus(upwardDirection).Plus(rightDirection.MultiplyFloat(aspectRatio)),
                planeCenter.Minus(upwardDirection).Minus(rightDirection.MultiplyFloat(aspectRatio)),
                planeCenter.Minus(upwardDirection).Plus(rightDirection.MultiplyFloat(aspectRatio))
            };
        }
    }
}
