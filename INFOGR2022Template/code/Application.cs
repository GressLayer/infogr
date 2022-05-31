using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace Template
{
    class Application
    {
        public Camera camera;
        public Surface screen;

        public Scene scene;

        List<Ray> rays;
        List<Sphere> spheres;

        /* The function where everything is initialized. 
         * The camera and screen instance are created, along with the scenes and lists of rays and primitives.
         */
        public void Init()
        {
            camera = new Camera(Vector3.Zero, 90);
            screen = new Surface(512, 384);

            scene = new Scene();

            rays = new List<Ray>();
            spheres = new List<Sphere>();

            screen.Clear(0x000000);

            Sphere sphere = new Sphere(new Vector3(-1, 1, 0), 1);
            spheres.Add(sphere);
        }

        // Cleans the screen, updates the camera, checks input and intersections and then renders the camera's view, every single frame.
        public void Tick()
        {
            screen.Clear(0x000000);

            GetKeyboardInput();

            Render();

            foreach (Ray ray in rays)
                foreach (Sphere sphere in spheres)
                    Intersect(sphere, ray);

            screen.Print("FOV:" + camera.FOV, 2, 2, 0xffffff);
            screen.Print("Camera: " + camera.Position.X + ", " + camera.Position.Y + ", " + camera.Position.Z, 2, 18, 0xffffff);
        }

        // The render function that fires out rays at every single pixel.
        public void Render()
        {
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width; x++)
                {
                    {
                        float a = x / screen.width;
                        float b = y / screen.height;
                        if (camera.plane != null)
                        {
                            Vector3 u = camera.plane[1].Minus(camera.plane[0]);
                            Vector3 v = camera.plane[2].Minus(camera.plane[0]);

                            Ray ray = new Ray(camera.Position,
                                camera.plane[0].Plus(u.MultiplyFloat(a).Plus(v.MultiplyFloat(b))).Plus(camera.Position));
                            rays.Add(ray);
                            screen.Line(x, y, x, y, ray.color);
                        }
                    }
                }
            }
        }

        // Called every frame to check for keyboard input, used to change the camera's orientation.
        public void GetKeyboardInput()
        {
            var key = Keyboard.GetState();

            // Using WASD keys moves the camera along the X and Y axis.
            if (key[Key.A])
                camera.Position.X--;
            if (key[Key.D])
                camera.Position.X++;
            if (key[Key.W])
                camera.Position.Y++;
            if (key[Key.S])
                camera.Position.Y--;

            // Using Space and LeftShift moves the camera along the Z axis.
            if (key[Key.Space])
                camera.Position.Z++;
            if (key[Key.ShiftLeft])
                camera.Position.Z--;

            // Using the up and down arrow keys, FOV can be increased or decreased.
            if (key[Key.Up])
                camera.FOV++;
            if (key[Key.Down])
                camera.FOV--;

            // Hardcoded limits on the FOV.
            if (camera.FOV > 360)
                camera.FOV = 360;
            if (camera.FOV < 0)
                camera.FOV = 0;
        }

        void Intersect(Sphere sphere, Ray ray)
        {
            Vector3 c = sphere.Origin.Minus(ray.Origin);
            float t = c.DotProduct(ray.Direction);
            Vector3 q = c.Minus(ray.Direction.MultiplyFloat(t));
            float p2 = q.Length() * q.Length();
            if (p2 > sphere.Radius * sphere.Radius)
                return;
            t -= (float)Math.Sqrt(sphere.Radius * sphere.Radius - q.Length() * q.Length());
            if ((t < ray.scalar) && (t > 0))
            {
                ray.scalar = t;
                ray.color = 0xffffff;
            }
        }
    }
}