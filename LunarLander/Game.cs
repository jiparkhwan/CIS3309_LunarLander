using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LunarLander
{
    class Game
    {
        private static String imageName = "lander";
        public Bitmap sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
        Terrain terrain = new Terrain();
        Player newPlayer;
        public Game(Player newPlayer)
        {
            bmp = new Bitmap(1600, 1000);
            statsFont = new Font(FontFamily.GenericMonospace, 25, GraphicsUnit.Pixel);
            terrain = new Terrain();
            terrain.TotalHeight = 1600;
            terrain.GenerateTerrain();
            Module = new Module();
            Module.Game = this;
            Paused = false;
            keys = new HashSet<GameKeys>();
            whitePen = Pens.White;
            landingPen = new Pen(Brushes.White, 3);
            this.newPlayer = newPlayer;
            //load lander


            Module.Sprite = sprite;
        }
        #region public properties
        //public Ground Ground { get; set; }
        public Module Module { get; set; }
        #endregion

        #region fields
        public PauseReason Reason;
        Font statsFont;
        Bitmap bmp;
        Pen whitePen;
        /// <summary>
        /// Pen for landing pad
        /// </summary>
        Pen landingPen;
        HashSet<GameKeys> keys;
        public bool Paused { get; set; }
        //Bitmap landerBmp;
        #endregion

        #region events
        /// <summary>
        /// Called on key down
        /// </summary>
        /// <param name="e"></param>
        public void KeyDown(KeyEventArgs e)
        {
            //KeysPressed |= GetKeyFromKeyEventArgs(e);
            keys.Add(GetKeyFromKeyEventArgs(e));
        }

        /// <summary>
        /// Called on key up
        /// </summary>
        /// <param name="e"></param>
        public void KeyUp(KeyEventArgs e)
        {
            //KeysPressed &= ~GetKeyFromKeyEventArgs(e);
            keys.Remove(GetKeyFromKeyEventArgs(e));
        }

        private GameKeys GetKeyFromKeyEventArgs(KeyEventArgs e)
        {
            GameKeys key;
            switch (e.KeyData)
            {
                case Keys.Up:
                    key = GameKeys.Up;
                    break;
                case Keys.Down:
                    key = GameKeys.Down;
                    break;
                case Keys.Left:
                    key = GameKeys.Left;
                    break;
                case Keys.Right:
                    key = GameKeys.Right;
                    break;
                case Keys.Space:
                    key = GameKeys.Space;
                    break;
                default:
                    key = GameKeys.Unknown;
                    break;
            }
            return key;
        }

        /// <summary>
        /// Checks if left key is pressed
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(GameKeys key)
        {
            //return ((KeysPressed & key) == key);
            return keys.Contains(key);
        }
        #endregion
        
        public void Update(TimeSpan ts)
        {
            //check pause key
            if (IsKeyDown(GameKeys.Space))
            {
                if (Reason == PauseReason.Paused)
                    Paused = !Paused;
            }
            //update all game objects
            if (!Paused)
                Module.Update(ts);
            //check for collisions
            for (int i = 0; i < terrain.points.Count - 1; i++)
            {
                if (Module.IntersectsWithLine(terrain.points[i], terrain.points[i + 1]))
                {
                    //check if we crashed 
                    Paused = true;
                    Reason = PauseReason.Crashed;

                    if (terrain.points[i].Y == terrain.points[i + 1].Y)
                        if ((Module.sY < Module.MaxLandingSpeed) && (Module.IsRotatedForLanding))
                            Reason = PauseReason.Landed;
                }
            }
        }

        public Bitmap Draw()
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
                //draw the ground
                for (int i = 0; i < terrain.points.Count - 1; i++)
                    g.DrawLine((terrain.points[i].Y == terrain.points[i + 1].Y) ? landingPen : whitePen, terrain.points[i], terrain.points[i + 1]);



                //transform graphics object by the rotation
                Matrix m = new Matrix();
                m.RotateAt((float)ConvertAngle.RadiansToDegrees(Module.Rotation), Module.Location);
                g.Transform = m;
                g.DrawImage(Module.Sprite, Module.LocationGraphics);
                //restore transformation
                m.Reset();
                g.Transform = m;

                
                //draw stats
                const int posStatX = 0;
                g.DrawString(DateTime.Now.ToLongTimeString(), statsFont, Brushes.White, (bmp.Width) / 2, 0);
                g.DrawString("Fuel: " + Module.Fuel, statsFont, Brushes.White, posStatX, 0);
                g.DrawString(string.Format("Lander: x={0:0.00} y={1:0.00}", Module.X, Module.Y, ConvertAngle.RadiansToDegrees(Module.Rotation)), statsFont, Brushes.White, posStatX, 30);
                g.DrawString(string.Format("Speed: x={0:0.00} y={1:0.00}", Module.sX, Module.sY, 0), statsFont, Brushes.White, posStatX, 60);
                g.DrawString("Score:   " + newPlayer.getScore().ToString(), statsFont, Brushes.White, 1000, 10);
                if (Paused) //or game over
                    g.DrawString(Reason.ToString(), new Font(statsFont, FontStyle.Bold), Brushes.White, (bmp.Width) / 2, (bmp.Height) / 2 - 200);
            }
            return bmp;
        }


        public enum PauseReason
        {
            Paused, Crashed, Landed
        }
    }
}