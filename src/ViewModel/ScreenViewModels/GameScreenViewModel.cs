using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;
using ViewModel.GameViewModels;

namespace ViewModel.ScreenViewModels
{
    public class GameScreenViewModel : ScreenViewModel
    {
        public ICell<IGame> Game { get; }
        public IGame ReplayGame { get; }
        public GameViewModel GameViewModel { get; }
        public List<Vector2D> Moves { get; set; } = new List<Vector2D>();

        public GameScreenViewModel(IGame game, ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            Game = Cell.Create(game);
            ReplayGame = game;
            GameViewModel = new GameViewModel(Game, this);
            ReplayGameCommand = new ActionCommand(ReplayGameCommandExe);
            ExitGameCommand = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(game, this.CurrentScreen));
        }

        public ICommand ReplayGameCommand { get; }
        public ICommand ExitGameCommand { get; }

        private void ReplayGameCommandExe()
        {
            if (Game.Value.Status == GameStatus.Lost || Game.Value.Status == GameStatus.Won)
            {
                CurrentScreen.Value = new ReplayScreenViewModel(ReplayGame, Moves, this.CurrentScreen);
            }
        }
    }
}
