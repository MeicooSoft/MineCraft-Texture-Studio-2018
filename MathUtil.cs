using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftTextureStudio
{
    public class MathUtil
    {
        public static float toRad(float degree)
        {
            return (float)(degree * Math.PI / 180);
        }

        public static double toRad(double degree)
        {
            return (float)(degree * Math.PI / 180);
        }

        public static float toDeg(float radian)
        {
            return (float)(radian * 180 / Math.PI);
        }

        public static double toDeg(double radian)
        {
            return (float)(radian * 180 / Math.PI);
        }

        public static float clampAngle(float angle)
        {
            if (angle > 360)
            {
                int intAngle = (int)angle;
                intAngle /= 360;

                angle = angle - intAngle * 360;
            }

            if (angle < 0)
            {
                angle += 360;
            }

            if (angle == 360)
            {
                angle = 0;
            }

            return angle;
        }

        public static float getDist(Vector3 vector1, Vector3 vector2)
        {
            float diffX = Math.Abs(vector1.x - vector2.x);
            float diffY = Math.Abs(vector1.y - vector2.y);
            float diffZ = Math.Abs(vector1.z - vector2.z);

            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        //returns an angle in degrees
        public static float getDirectionFromVector(Vector2 vector)
        {
            float degrees = (float)toDeg(Math.Atan2(vector.y, vector.x));
            clampAngle(degrees);
            return degrees;
        }

        public static float getDegreesBetween(Vector2 posA, Vector2 posB)
        {
            float diffX = posB.x - posA.x;
            float diffY = posB.y - posA.y;

            float angle = (float)toDeg(Math.Atan2(diffY, diffX));
            angle = clampAngle(angle);
            return angle;
        }

        public static float angleDiff(float angleA, float angleB)
        {
            angleA = clampAngle(angleA);
            angleB = clampAngle(angleB);

            float diff1 = Math.Abs(angleA - angleB);
            float diff2 = 360 - diff1;

            return (diff1 < diff2 ? diff1 : diff2);
        }

        public static Vector2 getRotatedOffset(Vector2 offset, float rotation)
        {
            float pivotAngle = MathUtil.getDirectionFromVector(offset);
            return MathUtil.getVector2Offset(offset.Length(), pivotAngle + rotation);
        }

        //returns a vector using the specified length, pointing in the specified direction in degrees
        public static Vector2 getVector2Offset(float length, float direction)
        {
            return new Vector2((float)Math.Cos(MathUtil.toRad(direction)) * length,
                (float)Math.Sin(MathUtil.toRad(direction)) * length);
        }

        public static float stoppingDist(float initialSpeed, float acceleration)
        {
            return (initialSpeed * initialSpeed) / (acceleration * 2);
        }

        public static Vector2 getClosestPointOnLine(Vector2 linePoint1, Vector2 linePoint2, Vector2 point)
        {
            Vector2 L1P = new Vector2(point.x - linePoint1.x, point.y - linePoint1.y);
            Vector2 L1L2 = new Vector2(linePoint2.x - linePoint1.x, linePoint2.y - linePoint1.y);

            float l1l2sq = L1L2.x * L1L2.x + L1L2.y * L1L2.y;
            float l1p_l1l2 = L1P.x * L1L2.x + L1P.y * L1L2.y;
            float u = l1p_l1l2 / l1l2sq;

            if (u < 0.0f)
            {
                u = 0.0f;
            }
            else if (u > 1.0f)
            {
                u = 1.0f;
            }

            Vector2 Closest = new Vector2(L1L2.x * u + linePoint1.x, L1L2.y * u + linePoint1.y);
            return Closest;
        }

        public static string round2places(float number)
        {
            float newNum = (int)Math.Round(number * 100) / 100.0f;
            string strNewNum = newNum.ToString();
            int index = strNewNum.IndexOf(".");

            if (index != -1)
            {
                string dec = strNewNum.Substring(strNewNum.IndexOf(".") + 1);

                if (dec.Length == 1)
                {
                    strNewNum += "0";
                }
            }
            else
            {
                strNewNum += ".00";
            }

            return strNewNum;
        }
    }
}
