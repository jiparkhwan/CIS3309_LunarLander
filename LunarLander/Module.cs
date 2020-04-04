using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace LunarLander
{
    class Module
    {
        public Module()
        {
            Fuel = 300;
            X = 800;
            Y = 200;
        }

        public const float MaxLandingSpeed = 15;
        const float heightsize = 25;
        const float widthsize = 20;
        double Gravity = 6;
        double ThrustSpeed = 30;
        const double RotationBurnedFuel = 0.5;
        public Bitmap Sprite { get; set; }

        public Game Game { get; set; }

        /// <summary>
        /// X speed in m/s 
        /// </summary>
        public double sX { get; set; }

        /// <summary>
        /// Y speed in m/s
        /// </summary>
        public double sY { get; set; }

        /// <summary>
        /// Location of lander
        /// </summary>
        public PointF Location
        {
            get
            {
                return new PointF((float)X, (float)Y);
            }
        }

        /// <summary>
        /// Location of "top left" point of our graphics sprite
        /// </summary>
        public PointF LocationGraphics
        {
            get
            {
                return new PointF((float)X - widthsize / 2, (float)Y - heightsize / 2);
            }
        }

        /// <summary>
        /// rectangle of the sprite
        /// </summary>
        public RectangleF Rectangle
        {
            get
            {
                return new RectangleF((float)X - widthsize / 2, (float)Y - heightsize / 2, widthsize, heightsize);
            }
        }

        /// <summary>
        /// X location
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y location
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// current angle in rads
        /// </summary>
        public double Rotation { get; set; }

        /// <summary>
        /// current angle in degrees
        /// </summary>
        public double RotationDegrees
        {
            get { return Rotation / Math.PI * 180; }
        }

        /// <summary>
        /// Updates lander with specified timespan
        /// </summary>
        /// <param name="ts"></param>
        public void Update(TimeSpan ts)
        {
            Console.WriteLine(ts);
            //gravity
            sY += Gravity * ts.TotalSeconds;

            //thrust
            if (Game.IsKeyDown(GameKeys.Up))
                Thrust(ts.TotalSeconds);
            if (Game.IsKeyDown(GameKeys.Right))
                RotateLeft(ts.TotalSeconds);
            if (Game.IsKeyDown(GameKeys.Left))
                RotateRight(ts.TotalSeconds);

            //calculate new location
            X += sX * ts.TotalSeconds;
            Y += sY * ts.TotalSeconds;

        }


        /// <summary>
        /// Apply rotation throttle
        /// </summary>
        private void RotateLeft(double totalSeconds)
        {
            if (Fuel < 0)
                return;
            Rotation -= 3 * totalSeconds;
            //decrease fuel
            Fuel -= RotationBurnedFuel;
        }

        private void RotateRight(double totalSeconds)
        {
            if (Fuel < 0)
                return;

            Rotation += 3 * totalSeconds;
            //decrease fuel
            Fuel -= RotationBurnedFuel;
        }


        /// <summary>
        /// Thrust the engines
        /// </summary>
        private void Thrust(double totalSeconds)
        {
            if (Fuel < 0)
                return;
            //lander rotation 
            //add thrust
            sY -= Math.Sin(ConvertAngle.NormalizeAngle(Rotation + Math.PI / 2)) * totalSeconds * ThrustSpeed;
            Console.WriteLine(sY);
            sX -= Math.Cos(ConvertAngle.NormalizeAngle(Rotation + Math.PI / 2)) * totalSeconds * ThrustSpeed;
            //decrease fuel
            Fuel--;
        }

        public double Fuel { get; set; }

        public bool IntersectsWithLine(PointF a, PointF b)
        {
            //get all 4 points of our bounding square and rotate them around its center
            //top left
            if (TestPointUnderLine(a, b, new PointF(Rectangle.Left, Rectangle.Top)))
                return true;

            //top right
            if (TestPointUnderLine(a, b, new PointF(Rectangle.Right, Rectangle.Top)))
                return true;

            //bottom left
            if (TestPointUnderLine(a, b, new PointF(Rectangle.Left, Rectangle.Bottom)))
                return true;

            //bottom right
            if (TestPointUnderLine(a, b, new PointF(Rectangle.Right, Rectangle.Bottom)))
                return true;


            return false;
        }

        /// <summary>
        /// Checks if point is "under" a line
        /// </summary>x
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool TestPointUnderLine(PointF left, PointF right, PointF point)
        {
            //skip if point is not in x-range of our line
            if (point.X < left.X || point.X > right.X)
                return false;

            //basically test if Line.GetYCoordAtX(point.X) > point.Y
            //get elements for line equation
            //we want to get coords of each point on line by using y=a*x+b

            //a is increment for each X
            float a = (right.Y - left.Y) / (right.X - left.X);
            //b is the starting y
            float b = left.Y;

            //we make test as if point started at x=0 so we shift its X location relative to start of the line
            //and store it in newX
            float newX = point.X - left.X;

            //if point is "under" the line, we 
            return (point.Y > (a * newX + b));
        }

        public bool IsRotatedForLanding
        {
            get
            {
                return ((RotationDegrees > 350) || (RotationDegrees < 10));
            }
        }
    }
}