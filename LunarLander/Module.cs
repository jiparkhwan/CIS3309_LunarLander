using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace LunarLander
{


/*
This class is responsible for handling
the events associated with
the ship(module) itself. It will factor in the gravity,
the max speed in which the ship may land not crash,
fuel, and more.

In addition, it implements equations, getting, and setting points
of the rectangle where the module is contained inside.
This will make sure the landing, turning, and thrusting of the
ship is working properly. 

(there is some basic calculus involved in the math)
*/

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

        //getter and setter for the speed the module moves on x plane
        public double sX { get; set; }

       //getter and setter for the speed the module moves on y plane
        public double sY { get; set; }

       //the x and y coordinate to create a Point
        public PointF Location
        {
            get
            {
                return new PointF((float)X, (float)Y);
            }
        }

        //this is the location of the module
	//corner of the top left rectangle
	//constantly updated as the x and y coordinate changes
        public PointF LocationGraphics
        {
            get
            {
                return new PointF((float)X - widthsize / 2, (float)Y - heightsize / 2);
            }
        }

	/*
	this is the actual rectangle itself.
	this is basically what is the module itself.
	the module isn't really doing the landing,
	a rectangle is
	*/
        public RectangleF Rectangle
        {
            get
            {
                return new RectangleF((float)X - widthsize / 2, (float)Y - heightsize / 2, widthsize, heightsize);
            }
        }

	//getter setter for JUST the location of x plane itself
        public double X { get; set; }

   	//getter setter for JUST the location of x plane itself
        public double Y { get; set; }

  	//getter setter for the angle of the ship in rads
        public double Rotation { get; set; }

  	//getter setter for the angle of the ship in degrees
        public double RotationDegrees
        {
            get { return Rotation / Math.PI * 180; }
        }

        //moves the module as time goes by.
	//takes into account the gravity with the time
        public void Update(TimeSpan ts) //takes in a TimeSpan argument
        {
            Console.WriteLine(ts);

            //gravity
            sY += Gravity * ts.TotalSeconds;

            //thrust (only when up, right, and left pressed down)
            if (Game.IsKeyDown(GameKeys.Up))
                Thrust(ts.TotalSeconds);
            if (Game.IsKeyDown(GameKeys.Right))
                RotateLeft(ts.TotalSeconds);
            if (Game.IsKeyDown(GameKeys.Left))
                RotateRight(ts.TotalSeconds);

            //calculates the new location
            X += sX * ts.TotalSeconds;
            Y += sY * ts.TotalSeconds;

        }


  	//this applies the rotation of the rectangle left
	//when the "left" arrow is pressed down
        private void RotateLeft(double totalSeconds)
        {
            if (Fuel < 0)
                return;
            Rotation -= 3 * totalSeconds;
            //decrease fuel
            Fuel -= RotationBurnedFuel;
        }
	
	//this applies the rotation of the rectangle right
	//when the "right" arrow is pressed down
        private void RotateRight(double totalSeconds)
        {
            if (Fuel < 0)
                return;

            Rotation += 3 * totalSeconds;
            //decrease fuel
            Fuel -= RotationBurnedFuel;
        }


 	//this handles the thrust (when right, left, or up is pressed)
        private void Thrust(double totalSeconds)
        {
            if (Fuel < 0)
                return;
            //lander rotation 
            //add thrust
            sY -= Math.Sin(ConvertAngle.NormalizeAngle(Rotation + Math.PI / 2)) * totalSeconds * ThrustSpeed;
            
		Console.WriteLine(sY);
           
	    sX -= Math.Cos(ConvertAngle.NormalizeAngle(Rotation + Math.PI / 2)) * totalSeconds * ThrustSpeed;
            
	  //decrease fuel as thrust is active (keys being pressed)
            Fuel--;
        }
	
	//getter setter for the fuel
        public double Fuel { get; set; }
	
	//get all 4 points of our bounding rectangle and rotate them around its center
        public bool IntersectsWithLine(PointF a, PointF b)
        {
            
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


            return false; //return false otherwise.
        }

        //this method will make sure all the points are under the line
        private bool TestPointUnderLine(PointF left, PointF right, PointF point)
        {
            //skip if point is not in x-range of our line
            if (point.X < left.X || point.X > right.X)
                return false;

            //basically test if Line.GetYCoordAtX(point.X) > point.Y
            //get elements for line equation
            //we want to get coords of each point on line by using y=a*x+b

            //a is increment for each X coordinte
            float a = (right.Y - left.Y) / (right.X - left.X);
            
	    //b is the starting y coordinate
            float b = left.Y;

            //we make test as if point started at x=0 so we shift its 
	    //X location relative to start of the line
            //and store it in newX
            float newX = point.X - left.X;

            //if point is "under" the line, we 
            return (point.Y > (a * newX + b));
        }
	//returns true or false
	//depending if the degree rotation is greater than 350 degrees, or less than 10 degrees
        public bool IsRotatedForLanding
        {
            get
            {
                return ((RotationDegrees > 350) || (RotationDegrees < 10));
            }
        }
    }
}
