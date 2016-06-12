using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WindowsUniversalMTGHelper.Model;
using WindowsUniversalMTGHelper.Views.ObjectVisualsRepresentations;

namespace WindowsUniversalMTGHelper.AppModel
{
    public class PlayerScoreboardAppModel
    {
        private MainPage view;

        public PlayerScoreboardAppModel(MainPage view)
        {
            this.view = view;
        }

        public Canvas addAPlayerScoreboard()
        {
            return (new PlayerScoreboardPostix(this).getShape());
        }

        public void removeSpecificPlayerScoreBoard(Canvas canvas)
        {
            this.view.removeSpecificPlayerScoreBoard(canvas);
        }

        public PlayerScoreboard createNewScoreBoard()
        {
            return new PlayerScoreboard();
        }
    }

}
