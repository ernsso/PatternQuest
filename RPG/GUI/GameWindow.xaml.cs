using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using RPG;

namespace GUI
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private DispatcherTimer GameTimer = new DispatcherTimer();

        public GameSimulation GameSimulation { get; private set; }

        AbstractGameBoard GameBoard
        {
            get { return (AbstractGameBoard)TryFindResource("myGameBoard"); }
        }
        
        public GameWindow(int gameBoardType)
        {
            InitializeComponent();
            this.GameSimulation = GameSimulation.Instance;
            if (gameBoardType == 2)
            {
                this.GameSimulation.CreateLabyrinth();
            }
            else if (gameBoardType == 3)
            {
                this.GameSimulation.CreateGameBoard();
            }
            else
            {
                this.GameSimulation.CreateGameBoard();
            }
            this.GameSimulation.CreateCharacter(this.GameSimulation.GameEnvironment.GameBoard);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Resources.Add("myGameBoard", this.GameSimulation.GameEnvironment.GameBoard);
            GameBoard.PropertyChanged += gameBoard_PropertyChanged;

            try
            {
                GameBoard.Load(10, 10);
                this.GameSimulation.AddItemOnGameBoard();
                //this.GameSimulation.createFinishPoint(this.GameSimulation.GameEnvironment.GameBoard);
                GameInfo_ListView.ItemsSource = this.GameSimulation.characterList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem loading game. " + ex.StackTrace);
            }

            //GameTimer.Tick += new EventHandler(GameTimer_Tick);
            //GameTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //GameTimer.Start();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameBoard != null)
            {
                if (GameBoard.GameBoardState == GameBoardState.Running)
                {
                    if (this.GameSimulation.SelectedCharacter.HP > 0)
                    {
                        switch (e.Key)
                        {
                            /*g */
                        }
                    }
                    else { MessageBox.Show(this.GameSimulation.SelectedCharacter.Name + " est mort"); }
                }
            }
        }

        private void gameBoard_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "GameBoardState":
                    UpdateGameBoardDisplay();
                    break;
            }
        }

        private void UpdateGameBoardDisplay()
        {
            grid_Game.Children.Clear();
            grid_Game.RowDefinitions.Clear();
            grid_Game.ColumnDefinitions.Clear();

            AbstractZone currentZone = GameBoard.GetFirstZone();
            int rowCount = GameBoard.GetRowCount();
            int columnCount = GameBoard.GetColumnCount();

            for (int row = 0; row < rowCount; row++)
            {
                grid_Game.RowDefinitions.Add(new RowDefinition());
                for (int column = 0; column < columnCount; column++)
                {
                    grid_Game.ColumnDefinitions.Add(new ColumnDefinition());

                    AbstractZone cell = GameBoard.GetAbstractZone(row, column);
                    cell.PropertyChanged += cell_PropertyChanged;

                    Button button = new Button();
                    button.Focusable = false;
                    button.DataContext = cell;
                    button.Background = Brushes.Red;
                    button.Padding = new Thickness(0, 0, 0, 0);
                    button.Style = (Style)Resources["Cell"];

                    Grid.SetColumn(button, column);
                    Grid.SetRow(button, row);
                    grid_Game.Children.Add(button);
                }
            }

            grid_Game.DataContext = this.GameSimulation.GameEnvironment.GameBoard;
            grid_Game.Focus();
        }

        private void cell_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;
            if (e.PropertyName == "CellContents")
            {
                if (cell.Content is Knight)
                {
                }
                else if (cell.Content is Weapon)
                {
                }
            }
        }

        private void Move_Button_Click(object sender, RoutedEventArgs e)
        {
            if (GameBoard != null)
            {
                if (GameBoard.GameBoardState == GameBoardState.Running)
                {
                    Random r = new Random();
                    int maxNb = 4;
                    int Nb = 0;
                    //foreach (Character c in this.GameSimulation.characterList)
                    for (int i=0; i< this.GameSimulation.characterList.Count();i++)
                    {
                        
                            if (this.GameSimulation.f2.Location.RowNumber > this.GameSimulation.characterList[i].Location.RowNumber)
                            {
                                Nb = 2;
                                //MessageBox.Show(this.GameSimulation.characterList[i].Name + " down");

                            }
                            else
                            {
                                if (this.GameSimulation.f2.Location.RowNumber < this.GameSimulation.characterList[i].Location.RowNumber)
                                {
                                    Nb = 1;
                                    //MessageBox.Show(this.GameSimulation.characterList[i].Name + " up");
                                }
                                else 
                                {
                                    //MessageBox.Show(this.GameSimulation.characterList[i].Name + " same");
                                    if (this.GameSimulation.f2.Location.RowNumber == this.GameSimulation.characterList[i].Location.RowNumber && this.GameSimulation.f2.Location.ColumnNumber != this.GameSimulation.characterList[i].Location.ColumnNumber)
                                    {

                                        if (this.GameSimulation.f2.Location.ColumnNumber > this.GameSimulation.characterList[i].Location.ColumnNumber)
                                        {
                                            Nb = 4;
                                            //MessageBox.Show(this.GameSimulation.characterList[i].Name + " right");
                                        }
                                        else if (this.GameSimulation.f2.Location.ColumnNumber < this.GameSimulation.characterList[i].Location.ColumnNumber)
                                        {
                                            Nb = 3;
                                            //MessageBox.Show(this.GameSimulation.characterList[i].Name + " left");
                                        }
                                    }
                                    
                                    
                                }
                            }

                            if (this.GameSimulation.f2.Location.RowNumber == this.GameSimulation.characterList[i].Location.RowNumber && this.GameSimulation.f2.Location.ColumnNumber == this.GameSimulation.characterList[i].Location.ColumnNumber)
                            {
                                MessageBox.Show(this.GameSimulation.characterList[i].Name + " Finished");
                            }
                            else
                            {
                               // MessageBox.Show(this.GameSimulation.characterList[i].Name + " ee");
                             if (this.GameSimulation.characterList[i].HP > 0)
                                {

                                    switch (Nb)
                                    {
                                        case 1:
                                            this.GameSimulation.characterList[i].Move(Direction.Up);
                                            break;
                                        case 2:
                                            this.GameSimulation.characterList[i].Move(Direction.Down);
                                            break;
                                        case 3:
                                            this.GameSimulation.characterList[i].Move(Direction.Left);
                                            break;
                                        case 4:
                                            this.GameSimulation.characterList[i].Move(Direction.Right);
                                            break;
                                    }
                                }
                                else if (this.GameSimulation.characterList[i].State)
                                {
                                    // this.GameSimulation.characterList[i].Move(Direction.Up);
                                    MessageBox.Show(this.GameSimulation.characterList[i].Name + " est mort");
                                    this.GameSimulation.characterList[i].State = false;
                                    //this.GameSimulation.characterList.Remove(this.GameSimulation.characterList[i]);


                                }
                            }
                    }
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
        }
    }
}
