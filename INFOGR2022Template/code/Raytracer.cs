using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Raytracer
    {
        public Surface screen;
        public Camera camera;

        public Raytracer()
        {
            camera = new Camera(0, 0, 0);
            screen = new Surface(1024, 384);

            screen.Clear(0x000000);
        }
    }
}
