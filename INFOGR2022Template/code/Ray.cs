using System;

namespace Template
{
    public class Ray
    {
        Vector3 origin, direction;
        public float scalar;
        public int color;
        
        public Vector3 Origin { get { return origin; } }
        public Vector3 Direction { get { return direction; } }

        public float Scalar { get { return scalar; } }

        // Rays are infinite vectors with an origin and a direction vector, which are entered as parameters when creating a ray instance.
        public Ray(Vector3 org, Vector3 dir)
        {
            origin = org;
            direction = new Vector3(dir.X, dir.Y, dir.Z);
            color = 0x000000;
        }

        /* This function returns the function of a ray given a scalar t.
         * The function for a ray is R(t) = origin + (direction * t).
         */
        public Vector3 GetFunction(float t)
        {
            scalar = t;
            return origin.Plus(direction.MultiplyFloat(t));
        }
    }
}
