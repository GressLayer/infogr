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
        Vector3 forwardDirection, upwardDirection;
        public float[] plane = new float[4];

        public Vector3 Position { get { return position; } }

        // Camera constructor. Parameters set the position of the camera.
        public Camera(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
            forwardDirection = new Vector3(1, 0, 0);
            upwardDirection = new Vector3(0, 1, 0);

            plane = new float[4] { -1, -1, 1, 1 };
        }
    }
}
