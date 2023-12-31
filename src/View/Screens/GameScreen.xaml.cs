﻿using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewModel.GameViewModels;
using ViewModel.ScreenViewModels;

namespace View.Screens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameScreen : UserControl
    { 
        private DispatcherTimer timer;
        private TimeSpan elapsed;

        public GameScreen()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(DataContext is GameScreenViewModel)
            {
                GameScreenViewModel gameScreenViewModel = (GameScreenViewModel)DataContext;
                if (gameScreenViewModel != null && gameScreenViewModel.Game.Value.Status == GameStatus.Lost)
                {
                    timer.Stop();
                }
                elapsed += TimeSpan.FromSeconds(1);
                TimeElapsedTextBlock.Text = elapsed.ToString(@"hh\:mm\:ss");
            }
            
        }

    }
}
