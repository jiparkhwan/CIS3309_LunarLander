using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    class Player
    {
        private  int score;
        public Player()
        {
            score = 0;
        }
        public void landed()
        {
            score += 100;
        }

        public int getScore()
        {
            return score;
        }

        public void reset()
        {
            score = 0;
        }
    }
}
