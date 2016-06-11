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
        private MainPage view;
        private Scoreboard scoreBoard;

        public BoardAppModel(MainPage mainPage)
        {
            this.view = mainPage;
            this.scoreBoard = new Scoreboard(this);
        }

        public Canvas addAPlayerScoreboard()
        {
            return this.scoreBoard.addAPlayerScoreboard().getVisualRepresentation();
        }

        public void removeAPlayerScoreboard()
        {
            this.scoreBoard.removeLastPlayerScoreboard();
        }

        public MainPage getView()
        {
            return this.view;
        }
    }
}
