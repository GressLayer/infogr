using System;

namespace Template
{
	class Application
	{
		public Surface screen;

		int location;
		int pixel;

		public void Init()
		{
			screen.Clear(0x000000);
		}

		public void Tick()
		{
			for (int i = 0; i <= 80; i++)
				screen.Line(0, i + 100, screen.width, i + 100, (0xffff00 - Math.Abs(i - 40) * 6) << 2);
		}
	}
}