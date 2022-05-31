using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Plane : Primitive
    {
        Vector3 normal, origin;

        public Vector3 Normal { get { return normal; } }
        public Vector3 Origin { get { return origin; } }

        // Plane constructor takes two vectors as parameters: a normal vector and the origin of said normal vector.
        public Plane(Vector3 nor, Vector3 org)
        {
            normal = nor;
            origin = org;
        }
    }
}
