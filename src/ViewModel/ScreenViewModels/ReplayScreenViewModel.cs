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
    public class ReplayScreenViewModel : ScreenViewModel
    {

        public int Index { get; set; }
        public ICell<IGame> Game { get; }
        public GameBoardViewModel GameBoard { get; }
        public List<Vector2D> Moves { get; set; } 

        public ReplayScreenViewModel(IGame game, List<Vector2D> moves, ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            Game = Cell.Create(game);
            Index = 0;
            GameBoard = new GameBoardViewModel(Game, this);
            Moves = moves;
            NextMove = new ActionCommand(NextMoveCommand);
            BackToSettings = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(game, this.CurrentScreen));
        }

        public ICommand NextMove { get; set; }
        public ICommand BackToSettings { get; set; }

        private void NextMoveCommand()
        {
            if (Index >= Moves.Count) return;
            Game.Value = Game.Value.UncoverSquare(Moves[Index]);
            Index++;
        }
    }
}
