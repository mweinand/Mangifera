using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Mangifera.Sensors.Accelerometer
{
    public struct Vector3D
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
        /// Default constructor
        /// </summary>
        public Vector3D()
        {
        }

        /// <summary>
        /// Overloaded constructor to set values
        /// </summary>
        /// <param name="x">Initial X Value</param>
        /// <param name="y">Initial Y Value</param>
        /// <param name="z">Initial Z Value</param>
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = x;
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
            // check for null
            if (v1 == null && v2 == null)
            {
                return true;
            } 
            else if (v1 == null || v2 == null)
            {
                return false;
            }

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

    }
}
