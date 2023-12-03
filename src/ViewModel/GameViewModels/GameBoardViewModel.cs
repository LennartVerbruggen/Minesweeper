using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ScreenViewModels;

namespace ViewModel.GameViewModels
{
    public class GameBoardViewModel
    {

        private readonly ICell<IGameBoard> Board;
        public IEnumerable<RowViewModel> rows { get; }
        public GameBoardViewModel(ICell<IGame> game, ScreenViewModel gameViewModel)
        {
            Board = game.Derive(g => g.Board);
            rows = Rows(game, gameViewModel);
        }

        IEnumerable<RowViewModel> Rows(ICell<IGame> game, ScreenViewModel gameViewModel)
        {
            var result = new List<RowViewModel>();
            //Get all rows
            for (int i = 0; i < Board.Value.Height; i++)
            {
                result.Add(Row(i, game, gameViewModel));
            }
            return result;
        }

        RowViewModel Row(int row, ICell<IGame> game, ScreenViewModel gameViewModel)
        {
            //Get all squares in the row
            var finalResult = new RowViewModel(game, row, gameViewModel);
            return finalResult;
        }
    }
}
