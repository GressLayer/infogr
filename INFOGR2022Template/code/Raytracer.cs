using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Raytracer
    {
        public Camera camera;
        public Vector3 origin;
        public Surface screen;

        public Raytracer()
        {
            camera = new Camera(0, 0, 0);
            screen = new Surface(512, 384);
            origin = new Vector3(screen.width / 2, screen.height / 2, 0);

            screen.Clear(0x000000);
        }

        public void Render()
        {
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width; x++)
                {
                    if (y == screen.height / 2)
                    {
                        Ray ray = new Ray(camera.Position.Plus(origin), 
                            new Vector3((camera.plane[0] + 2 / screen.width) * 100, 
                            (camera.plane[2] + 2 / screen.height) * 100, 0));
                        screen.Line((int)origin.X, (int)origin.Y, (int)ray.Direction.X * 100, (int)ray.Direction.Y * 100, 0xff0000);
                    }
                }
            }
        }
    }
}
