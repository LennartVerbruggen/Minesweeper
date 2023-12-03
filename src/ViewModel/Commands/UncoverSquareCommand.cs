using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.GameViewModels;
using ViewModel.ScreenViewModels;

namespace ViewModel.Commands
{
    public class UncoverSquareCommand : ICommand
    {
        public ICell<IGame> Game { get; set; }
        public Vector2D Position { get; set; }

        public GameScreenViewModel GameScreenViewModel { get; set; }

        public UncoverSquareCommand(ICell<IGame> game, Vector2D position, ScreenViewModel gameViewModel)
        {
            Game = game;
            Position = position;
            if (gameViewModel is GameScreenViewModel)
            {
                GameScreenViewModel = (GameScreenViewModel)gameViewModel;
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (Game.Value.Board[Position].Status == SquareStatus.Covered && Game.Value.Status == GameStatus.InProgress)
            { 
                GameScreenViewModel.Moves.Add(Position);
                Game.Value = Game.Value.UncoverSquare(Position);
            }
        }
    }
}
