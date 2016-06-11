using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsUniversalMTGHelper.AppModel;

namespace WindowsUniversalMTGHelper.Model
{

    public class Scoreboard
    {
        private List<PlayerScoreboard> boards;
        private BoardAppModel appModel;

        public Scoreboard(BoardAppModel appModel)
        {
            this.boards = new List<PlayerScoreboard>();
            this.appModel = appModel;
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
            PlayerScoreboard newPlayerScoreboard = new PlayerScoreboard(this);
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

        /// <summary>
        /// Remove from the ScoreBoard the last PlayerScoreboard added.
        /// </summary>
        public void removeLastPlayerScoreboard()
        {
            this.boards.Remove(this.boards.Last());
        }

        public BoardAppModel getAppModel()
        {
            return this.appModel;
        }


    }
}
