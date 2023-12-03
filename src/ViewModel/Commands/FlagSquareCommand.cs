using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class FlagSquareCommand : ICommand
    {

        public ICell<IGame> Game { get; set; }
        public Vector2D Position { get; set; }

        public FlagSquareCommand(ICell<IGame> game, Vector2D position) 
        {
            Game = game;
            Position = position;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            IGame game = Game.Value;
            game = game.ToggleFlag(Position);
            Game.Value = game;
        }
    }
}
