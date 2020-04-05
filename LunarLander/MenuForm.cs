using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Gary Mejia and Ji Hwan Park
 * CIS 3309
 * Date Due: 4/5/2020
 * 
 * Program Identification
 * LunarLander-MenuForm Class
 * 
 * This class is responsible for displaying the menu of the game.
 * The menu form redirects the user to either the game or the instructions. The 
 * user also has the option the end the program by pressing exit.
 */

namespace LunarLander
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            //sets screen in the middle
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(590, 280);
        }

        //Redirects to the Game 
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            LunarLander landerForm = new LunarLander();
            landerForm.Closed += (s, args) => this.Close();
            landerForm.Show();
        }
        //Closes game
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Redirects to instructions screen.Showdialog() instead of Show() to 
        //prevent user from interacting with the menuform screen before closing 
        //the instructions screen
        private void btnInstructions_Click(object sender, EventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.ShowDialog();
        }
    }
}
