using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUniversalMTGHelper.Model
{
    public class PlayerScoreboard
    {

        string playerName;
        int lifePoints;
        int poisonPoints;

        public PlayerScoreboard()
        {
            this.playerName = "Foo";
            this.lifePoints = 20;
            this.poisonPoints = 0;
        }


        public int getLifePoints()
        {
            return this.lifePoints;
        }

        public void addOneLifePoints()
        {
            this.lifePoints++;
        }

        public void subOneLifePoints()
        {
            if (this.getLifePoints() > 0)
            {
                this.lifePoints--;
            }
        }

        private void addXLifePoints(int c)
        {
            for(int i = 0; i < c; i++)
            {
                this.addOneLifePoints();
            }
        }

        private void subXLifePoints(int c)
        {
            for (int i = 0; i < c; i++)
            {
                this.subOneLifePoints();
            }
        }

        public void addFiveLifePoints()
        {
            this.addXLifePoints(5);
        }

        public void subFiveLifePoints()
        {
            this.subXLifePoints(5);
        }

        public int getPoisonPoints()
        {
            return this.poisonPoints;
        }

        public void addOnePoisonPoint()
        {
            this.poisonPoints++;
        }

        public void subOnePoisonPoint()
        {
            if(this.getPoisonPoints() > 0)
            {
                this.poisonPoints--;
            }
        }

        public string getPlayerName()
        {
            return this.playerName;
        }

        public void changeName(string aName)
        {
            this.playerName = aName;
        }

    }
}
