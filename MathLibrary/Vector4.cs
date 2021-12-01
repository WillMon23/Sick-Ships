using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector4
    {
        //X axis location
        public float X;
        //Yaxis location
        public float Y;
        //Z axis location
        public float Z;
        //W location
        public float W;

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Get the distance of two vectors vectors 
        /// </summary>
        public float Magnitude { get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); } }

        /// <summary>
        /// Gwts the vector its assigned to and 
        /// normalizes it 
        public Vector4 Normalized
        {
            get
            {
                Vector4 value = this;
                return value.Normalize();
            }
        }

        /// <summary>
        /// Gets two vectors and multyplies there X, Y, Z's 
        /// in oder to add them together
        /// </summary>
        /// <param name="lhs">vector to left hand side</param>
        /// <param name="rhs">vector to the right hand</param>
        /// <returns></returns>
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        /// <summary>
        /// Gets the Perpecdicular Vector from two 4D Vectors 
        /// </summary>
        /// <param name="lhs">Left Hand Side</param>
        /// <param name="rhs">Right Hand Side</param>
        /// <returns>Perpendicular Vector from the two vectors</returns>
        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4
            {
                X = (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                Y = (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                Z = (lhs.X * rhs.Y) - (lhs.Y * rhs.X),
                W = 0  
            };
        }


        /// <summary>
        /// Change this vector to have a magnitude that is equal to one 
        /// </summary>
        /// <returns>The result of the normalization. Returns an empty vector if the magnitude is zero</returns>
        public Vector4 Normalize()
        {
            if (Magnitude == 0)
                return new Vector4();
            return this /= Magnitude;
        }


        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { W = lhs.W + rhs.W, X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z };
        }

        /// <summary>
        /// Subtract the values in order to make a new vactor 
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns> new Vector4</returns>
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { W = lhs.W - rhs.W, X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z };
        }

        /// <summary>
        /// Overrrides the  * operator in order to 
        /// creat a new vector with the values multiplied 
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns> new Vector4</returns>
        public static Vector4 operator *(Vector4 lhs, float scaler)
        {
            return new Vector4 { W = lhs.W * scaler, X = lhs.X * scaler, Y = lhs.Y * scaler, Z = lhs.Z * scaler };
        }

        /// <summary>
        /// Overrrides the  * operator in order to 
        /// creat a new vector with the values multiplied 
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns> new Vector4</returns>
        public static Vector4 operator *(float scaler, Vector4 lhs)
        {
            return new Vector4 { W = lhs.W * scaler, X = lhs.X * scaler, Y = lhs.Y * scaler, Z = lhs.Z * scaler };
        }
        /// <summary>
        /// Overrides the == in order to get a bool wether the value in the 
        /// vectors are equal together 
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns> new Vector4</returns>
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W);
        }

        /// <summary>
        /// Overrides the != operator in order to get a 
        /// bool to see weather the vectors are diffrent
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns> new Vector4</returns>
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z || lhs.W != rhs.W);
        }

        /// <summary>
        /// Overrides the / operator in order to 
        /// create a new vector with the values devided
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns> new Vector4</returns>
        public static Vector4 operator /(Vector4 lhs, float scaler)
        {
            return new Vector4 { W = lhs.W / scaler, X = lhs.X / scaler, Y = lhs.Y / scaler, Z = lhs.Z / scaler };
        }


    }
}
