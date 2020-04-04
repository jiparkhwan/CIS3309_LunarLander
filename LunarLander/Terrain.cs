using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    class Terrain
    {
        //Constructor
        public Terrain()
        {
            points = new List<PointF>();
        }

        public int numOfPoints = 0;
        public int TotalHeight = 100;
        public int Width = 1700;
        const int landingStripWidth = 30;
        public List<PointF> points;
        /*
         * The class terrain is in charge of creating the points that will be connected to make the terrain
         */
        public void GenerateTerrain()
        {
            Random rnd = new Random();

            double amp = 0.2;                                           //amplitude of wave
            double waveLength = rnd.NextDouble() * (.03 - .01) + 0.01;    //waveLength of wave
            //Previous period and current period are used to check different waves
            int previousPeriod = 0;
            int currentPeriod = 0;
            float tempHeight = 0;

            //our terrain is left list of connected dots in random height < 1/2 of screen
            for (int w = 0; w < Width; w += rnd.Next(1, 40))        //randomly chooses the x coordinate based on its range and as long as its under the width
            {

                previousPeriod = (Width - w) / 200;
                //new sizes for new wave
                if (currentPeriod != previousPeriod)
                {
                    //unique random amplitude 
                    amp = rnd.NextDouble() * (1 - 0.1) + .1; ;
                }

                currentPeriod = previousPeriod;
                //apply new numbers to the sine wave
                tempHeight = (Convert.ToSingle((amp * Math.Sin(waveLength * w) + 1) * 200)) + 350;
                points.Add(new PointF(w, tempHeight));
            }

            numOfPoints = points.Count();

            int landingsCount = 3;
            for (int i = 0; i < landingsCount; i++)
            {
                int idx = rnd.Next(numOfPoints);
                try
                {
                    while ((points[idx + 1].X - points[idx].X) < 30)
                    {
                        idx = rnd.Next(numOfPoints);
                    }
                }
                catch
                {
                    break;
                }
                points.Insert(idx + 1, (new PointF(points[idx].X + landingStripWidth, points[idx].Y)));
            }
            points.Add(new PointF(Width, rnd.Next(TotalHeight)));
        }
    }
}