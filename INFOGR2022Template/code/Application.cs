using System;
using System.Windows.Input;

namespace Template
{
	class Application
	{
		public Camera camera;
		public Vector3 origin;
		public Surface screen;

		public void Init()
		{
			camera = new Camera(0, 0, 0);
			screen = new Surface(512, 384);
			origin = new Vector3(screen.width / 2, screen.height / 2, 0);

			screen.Clear(0x000000);
		}

		public void Tick()
		{
			Render();
		}

		public void Render()
		{
			for (int y = 0; y < screen.height; y++)
			{
				for (int x = 0; x < screen.width; x++)
				{
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