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
        float[] plane = new float[4]; 

        public Camera(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
            forwardDirection = new Vector3(1, 0, 0);
            upwardDirection = new Vector3(0, 1, 0);
        }
    }
}
