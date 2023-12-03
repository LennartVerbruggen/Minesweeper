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
using ViewModel.ScreenViewModels;

namespace ViewModel.GameViewModels
{
    public class SquareViewModel
    {
        public ICell<Square> square { get; }
        public ICommand Uncover { get; }

        public ICommand Flag { get; }

        public ICell<bool> MineAndLost { get;}

        public SquareViewModel(ICell<IGame> game, Vector2D position, ScreenViewModel gameViewModel)
        {
            square = game.Derive(g => g.Board[position]);
            Uncover = new UncoverSquareCommand(game, position, gameViewModel);
            Flag = new FlagSquareCommand(game, position);
            MineAndLost = game.Derive(g => g.Status == GameStatus.Lost && g.Mines.Contains(position));
        }

        
    }    
}
