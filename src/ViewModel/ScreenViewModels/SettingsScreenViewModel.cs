using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;
using ViewModel.GameViewModels;

namespace ViewModel.ScreenViewModels
{
    public class SettingsScreenViewModel : ScreenViewModel
    {
        public SettingsScreenViewModel(IGame game,ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {

            this.Game = game;
            FloodingEnabled = true;
            BoardSize = game.Board.Height;
            BombProbability = 0.1;

            StartGameCommand = new ActionCommand(() => StartGame(game));
            DefaultGameCommand = new ActionCommand(() => DefaultGame());
            EasyGame = new ActionCommand(() => EasyGameStart());
            MediumGame = new ActionCommand(() => MediumGameStart());
            HardGame = new ActionCommand(() => HardGameStart());
            ExtremeGame = new ActionCommand(() => ExtremeGameStart());
        }

        public int BoardSize { get; set; }

        public double BombProbability { get; set; }
        public bool FloodingEnabled { get; set; }

        public IGame Game;

        public int MaxBoardSize { get; set; } = IGame.MaximumBoardSize;
        public int MinBoardSize { get; set; } = IGame.MinimumBoardSize;

        public double MaxBombProbability { get; set; } = IGame.MaxMineProb;
        public double MinBombProbability { get; set; } = IGame.MinMineProb;

        public ICommand StartGameCommand { get; }
        public ICommand DefaultGameCommand { get; }
        public ICommand EasyGame { get; }
        public ICommand MediumGame { get; }
        public ICommand HardGame { get; }
        public ICommand ExtremeGame { get; }

        private void StartGame(IGame game)
        {
            game = IGame.CreateRandom(BoardSize, BombProbability, FloodingEnabled);
            CurrentScreen.Value = new GameScreenViewModel(game, this.CurrentScreen);
        }

        private void DefaultGame()
        {
            CurrentScreen.Value = new GameScreenViewModel(this.Game, this.CurrentScreen);
        }

        private void EasyGameStart()
        {
            var game = IGame.CreateRandom(5, 0.1, true);
            CurrentScreen.Value = new GameScreenViewModel(game, this.CurrentScreen);
        }

        private void MediumGameStart()
        {
            var game = IGame.CreateRandom(10, 0.2, true);
            CurrentScreen.Value = new GameScreenViewModel(game, this.CurrentScreen);
        }

        private void HardGameStart()
        {
            var game = IGame.CreateRandom(15, 0.3, true);
            CurrentScreen.Value = new GameScreenViewModel(game, this.CurrentScreen);
        }

        private void ExtremeGameStart()
        {
            var game = IGame.CreateRandom(20, 0.4, false);
            CurrentScreen.Value = new GameScreenViewModel(game, this.CurrentScreen);
        }

    }
}
