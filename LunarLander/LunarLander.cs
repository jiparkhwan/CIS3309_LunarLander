using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


/*
 * This class holds the first layer to the game. It creates an instance of game and holds the event listeners
 * for the keys the users might press
 */

namespace LunarLander
{
    public partial class LunarLander : Form
    {
        public LunarLander()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, 100);
        }

        //Creates an instance of the game class
        static Player player = new Player();

        Game game = new Game(player);
        
        /*
         * KeyDown has to be registered in a hash set so that multiple keys can be read at once
         * 
         */
        private void keyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                //Creates a new instance of the game class which will restart the game and create new terrain
                case Keys.Escape:
                    if (game.Reason == Game.PauseReason.Landed)
                    {
                        player.landed();
                    }
                    else
                    {
                        player.reset();
                    }
                    game = new Game(player);
                    picInstructions.Enabled = true;
                    break;
                case Keys.Back:
                    this.Close();
                    break;
                default:
                    //Registers keys to hash set in game class
                    game.KeyDown(e);
                    break;
            }
        }

        /*
         * The key up method will remove the keys from the hash set
         */
        private void keyUp(object sender, KeyEventArgs e)
        {
            game.KeyUp(e);
        }
        /*
        * The timer method will execute repeatedly 
        * This update will update the sprite and current status of the game (Pause or not paused)
        */
        private void timer(object sender, EventArgs e)
        {
            //updates the sprites location and rotation, current status of the game.....
            game.Update(new TimeSpan(updateTimer.Interval * 10000));
            //Displays and applys all the updated information to the screen
            gameScreen.Image = game.Draw();
            if (game.Reason == Game.PauseReason.Crashed)
            {
                picInstructions.Enabled = false;
            }
        }

        private void instructions_Click(object sender, EventArgs e)
        {   
            game.Reason = Game.PauseReason.Paused;
            game.Paused = true;

            Instructions instructions = new Instructions();
            instructions.ShowDialog();
            game.Paused = false;
        }
    }
}
