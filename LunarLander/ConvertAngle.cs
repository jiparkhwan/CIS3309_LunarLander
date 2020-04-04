using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    class ConvertAngle
    {

        /// <summary>
        /// Normalizes the angle, that means - fits it in &lt;0, 2*pi&gt;.
        /// </summary>
        /// <param name="angle">Angle to normalize.</param>
        /// <returns>Normalized angle</returns>
        public static double NormalizeAngle(double angle)
        {
            while (angle < 0)
                angle += 2 * Math.PI;
            //Console.WriteLine("Angle is less than 0 " + angle);
            while (angle > 2 * Math.PI)
                angle -= 2 * Math.PI;
            //Console.WriteLine("Angle is more than 0 " + angle);
            return angle;
        }

        /// <summary>
        /// Converts angle in radians to degrees.
        /// </summary>
        /// <param name="angle">Angle in radians.</param>
        /// <returns>Angle in degrees.</returns>
        public static double RadiansToDegrees(double angle)
        {
            return angle / Math.PI * 180;
        }

    }
}