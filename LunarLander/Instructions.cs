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
 * LunarLander-Instructions Class
 * 
 * This class is responsible for displaying the instructions for the game.
 * The Form contains information on the controls for the game as well as directions
 */
namespace LunarLander
{
    public partial class Instructions : Form
    {
        //Loads instructions form
        public Instructions()
        {
            InitializeComponent();
            //Sets screen in the middle
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(725, 280);
        }

    }
}
