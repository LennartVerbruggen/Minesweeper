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
    public class RowViewModel
    {

        public IEnumerable<SquareViewModel> Squares { get; set; }

        public RowViewModel(ICell<IGame> game, int rowIndex, ScreenViewModel gameViewModel)
        {
            var squareViewModels = new List<SquareViewModel>();
            for (int i = 0; i < game.Value.Board.Width; i++)
            {
                squareViewModels.Add(new SquareViewModel(game, new Vector2D(i, rowIndex), gameViewModel));
            }
            Squares = squareViewModels;
        }

    }
}
