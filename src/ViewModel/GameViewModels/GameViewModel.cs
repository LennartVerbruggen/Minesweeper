using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;
using ViewModel.Commands;
using ViewModel.ScreenViewModels;

namespace ViewModel.GameViewModels
{
    public class GameViewModel
    {
        public ICell<IGame> Game { get; }
        public IGame ReplayGame { get; }

        public GameBoardViewModel Board { get; }
        
        public List<Vector2D> moves = new List<Vector2D>();


        public GameViewModel(ICell<IGame> game, ScreenViewModel currentScreen)
        {
            Game = game;
            ReplayGame = Game.Value;
            Board = new GameBoardViewModel(Game, currentScreen);
        }
    }
}