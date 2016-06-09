using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUniversalMTGHelper.Model
{

    public class Scoreboard
    {
        private List<PlayerScoreboard> boards;

        public Scoreboard()
        {
            this.boards = new List<PlayerScoreboard>();
        }

        /// <summary>
        /// Returns the number of Player Scoreboards in this Scoreboard.
        /// </summary>
        public int numberOfScoreboardsCreated()
        {
            return this.boards.Count;
        }

        /// <summary>
        /// Create, add and return's a PlayerScoreboard.
        /// </summary>
        public PlayerScoreboard addAPlayerScoreboard()
        {
            PlayerScoreboard newPlayerScoreboard = new PlayerScoreboard();
            this.boards.Add(newPlayerScoreboard);
            return (newPlayerScoreboard);
        }

        /// <summary>
        /// Remove from the ScoreBoard the given PlayerScoreboard.
        /// </summary>
        public void removeplayerScoreboard(PlayerScoreboard aPlayerScoreboard)
        {
            this.boards.Remove(aPlayerScoreboard);
        }


    }
}
