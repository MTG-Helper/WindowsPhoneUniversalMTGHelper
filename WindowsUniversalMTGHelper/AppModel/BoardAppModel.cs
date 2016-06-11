using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WindowsUniversalMTGHelper.Model;

namespace WindowsUniversalMTGHelper.AppModel
{
    public class BoardAppModel
    {
        private Scoreboard scoreBoard;

        public BoardAppModel()
        {
            this.scoreBoard = new Scoreboard();
        }

        public Canvas addAPlayerScoreboard()
        {
            return this.scoreBoard.addAPlayerScoreboard().getVisualRepresentation();
        }
    }
}
