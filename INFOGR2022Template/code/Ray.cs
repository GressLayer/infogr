using System;

namespace Template
{
    public class Ray
    {
        Vector3 origin, direction;
        
        public Vector3 Origin { get { return origin; } }
        public Vector3 Direction { get { return direction; } }

        public Ray(Vector3 o, Vector3 d)
        {
            origin = o;
            direction = d;
        }

        /* This function returns the function of a ray given a scalar t.
         * The function for a ray is R(t) = origin + (direction * t).
         */
        public Vector3 GetFunction(float t)
        {
            return origin.Plus(direction.MultiplyFloat(t));
        }
    }
}
