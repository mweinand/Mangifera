using System;

namespace Mangifera.Phone.Sensors.Accelerometer
{
    public struct Vector3D : IEquatable<Vector3D>
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Z coordinate
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Overloaded constructor to set values
        /// </summary>
        /// <param name="x">Initial X Value</param>
        /// <param name="y">Initial Y Value</param>
        /// <param name="z">Initial Z Value</param>
        public Vector3D(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

#region Operators

        /// <summary>
        /// Are these 2 the same?
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            return (v1.X == v2.X) && (v1.Y == v2.Y) && (v1.Z == v2.Z);
        }

        /// <summary>
        /// Are they not the same?
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Let's add 2 <see cref="Vector3D"/>s together
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Let's do some subtraction
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Multiply 2 <see cref="Vector3D"/>s
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator *(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        /// <summary>
        /// Scale a vector
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vector3D operator *(Vector3D v1, double d)
        {
            return new Vector3D(v1.X * d, v1.Y * d, v1.Z * d);
        }

#endregion

        #region Equality

        public bool Equals(Vector3D other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y) && other.Z.Equals(Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (Vector3D)) return false;
            return Equals((Vector3D) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = X.GetHashCode();
                result = (result*397) ^ Y.GetHashCode();
                result = (result*397) ^ Z.GetHashCode();
                return result;
            }
        }

        #endregion
    }
}
