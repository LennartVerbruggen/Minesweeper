using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ScreenViewModels
{
    public class MainViewModel
    {
        public MainViewModel(IGame game)
        {

            CurrentScreen = Cell.Create<ScreenViewModel>(null);

            var startUpScreen = new SettingsScreenViewModel(game, this.CurrentScreen);

            CurrentScreen.Value = startUpScreen;
        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }
}
