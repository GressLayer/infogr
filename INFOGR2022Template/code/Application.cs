using System;
using System.Windows.Input;

namespace Template
{
	class Application
	{
		public Raytracer raytracer;
		public Surface screen;

		public void Init()
		{
			raytracer = new Raytracer();
			screen.Clear(0x000000);


		}

		public void Tick()
		{
			
		}
	}
}