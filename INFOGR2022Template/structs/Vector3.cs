using System;

namespace Template
{
    /* This class contains the definition for a three-dimensional vector.
     * Every single Vector3 has an X, Y and Z value in a three-dimensional space.
     */
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /* The following functions were created to allow simple arithmetic operations to be performed on the Vector3 class.
         * An input vector is used along with the Vector3 that calls the function to return a resulting Vector3.
         */

        // Add two vectors together.
        public Vector3 Plus(Vector3 vector)
        {
            return new Vector3(X + vector.X, Y + vector.Y, Z + vector.Z);
        }

        // Subtract the first vector by the second vector.
        public Vector3 Minus(Vector3 vector)
        {
            return new Vector3(X - vector.X, Y - vector.Y, Z - vector.Z);
        }

        /* For the next two functions:
         * Multiply every axis of the vector by a single double or float as a multiplier.
         */
        public Vector3 MultiplyDouble(double multiplier)
        {
            return new Vector3(X * (float)multiplier, Y * (float)multiplier, Z * (float)multiplier);
        }
        public Vector3 MultiplyFloat(float multiplier)
        {
            return new Vector3(X * multiplier, Y * multiplier, Z * multiplier);
        }
    }
}
