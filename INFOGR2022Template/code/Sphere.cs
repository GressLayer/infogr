using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Sphere : Primitive
    {
        Vector3 origin;
        float radius;

        public Vector3 Origin { get{ return origin; } }
        public float Radius { get { return radius; } }

        // Sphere constructor takes three float values for the origin and a float for the radius.
        public Sphere(Vector3 org, float rad)
        {
            origin = org;
            radius = rad;
        }
    }
}
