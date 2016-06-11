using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WindowsUniversalMTGHelper.Model.VisualRepresentations;

namespace WindowsUniversalMTGHelper.Model
{
    public class PlayerScoreboard
    {

        private string playerName;
        private int lifePoints;
        private int poisonPoints;
        private PlayerScoreboardPostix shape;
        private Scoreboard board;

        public PlayerScoreboard(Scoreboard board)
        {
            this.board = board;
            this.playerName = "Foo";
            this.lifePoints = 20;
            this.poisonPoints = 0;
            this.shape = new PlayerScoreboardPostix(this);
        }


        /// <summary>
        /// Returns the remaining players's life points.
        /// </summary>
        public int getLifePoints()
        {
            return this.lifePoints;
        }

        /// <summary>
        /// Add one life point to the remaining players's life points.
        /// </summary>
        public void addOneLifePoints()
        {
            this.lifePoints++;
        }

        /// <summary>
        /// returns the visual representation for a PlayerScoreboard.
        /// </summary>
        public Canvas getVisualRepresentation()
        {
            return this.shape.getShape();
        }

        /// <summary>
        /// Sub one life point to the remaining players's life points.
        /// </summary>
        public void subOneLifePoints()
        {
            if (this.getLifePoints() > 0)
            {
                this.lifePoints--;
            }
        }

        /// <summary>
        /// Add X life point to the remaining players's life points.
        /// </summary>
        private void addXLifePoints(int numberOfLifePoints)
        {
            for(int i = 0; i < numberOfLifePoints; i++)
            {
                this.addOneLifePoints();
            }
        }



        /// <summary>
        /// Sub X life point to the remaining players's life points.
        /// </summary>
        private void subXLifePoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.subOneLifePoints();
            }
        }

        /// <summary>
        /// Add X poison point to the remaining players's life points.
        /// </summary>
        private void addXPoisonPoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.addOnePoisonPoint();
            }
        }

        /// <summary>
        /// Sub X poison point to the remaining players's life points.
        /// </summary>
        private void subXPoisonPoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.subOnePoisonPoint();
            }
        }

        /// <summary>
        /// Add five life point to the remaining players's life points.
        /// </summary>
        public void addFiveLifePoints()
        {
            this.addXLifePoints(5);
        }

        /// <summary>
        /// Sub five life point to the remaining players's life points.
        /// </summary>
        public void subFiveLifePoints()
        {
            this.subXLifePoints(5);
        }


        /// <summary>
        /// Returns the remaining players's poison points.
        /// </summary>
        public int getPoisonPoints()
        {
            return this.poisonPoints;
        }

        /// <summary>
        /// Add one poison point to the remaining players's poison points.
        /// </summary>
        public void addOnePoisonPoint()
        {
            this.poisonPoints++;
        }

        /// <summary>
        /// Sub one poison point to the remaining players's poison points.
        /// </summary>
        public void subOnePoisonPoint()
        {
            if(this.getPoisonPoints() > 0)
            {
                this.poisonPoints--;
            }
        }

        /// <summary>
        /// Add five poison point to the remaining players's life points.
        /// </summary>
        public void addFivePoisonPoints()
        {
            this.addXPoisonPoints(5);
        }

        /// <summary>
        /// Sub five poison point to the remaining players's life points.
        /// </summary>
        public void subFivePoisonPoints()
        {
            this.subXPoisonPoints(5);
        }

        /// <summary>
        /// Returns the players's name.
        /// </summary>
        public string getPlayerName()
        {
            return this.playerName;
        }

        /// <summary>
        /// Change the players's name for another.
        /// </summary>
        public void changeName(string aName)
        {
            this.playerName = aName;
        }

        public Scoreboard getScoreBoard()
        {
            return this.board;
        }

    }
}
