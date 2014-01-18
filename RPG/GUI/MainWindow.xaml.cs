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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPG;

namespace GUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameSimulation GameSimulation { get; private set; }
        AbstractGameBoard GameBoard
        {
            get { return (AbstractGameBoard)TryFindResource("myGameBoard"); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.GameSimulation = GameSimulation.Instance;
            this.GameSimulation.CreateGameBoard();
            this.GameSimulation.CreateCharacter(this.GameSimulation.GameEnvironment.GameBoard);
            this.Resources.Add("myGameBoard", this.GameSimulation.GameEnvironment.GameBoard);
            GameBoard.PropertyChanged += gameBoard_PropertyChanged;

            try
            {
                GameBoard.Load(10, 10);
                this.GameSimulation.AddCharacterOnGameBoard();
                GameInfo_ListView.ItemsSource = this.GameSimulation.characterList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem loading game. " + ex.StackTrace);
            }
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
                            case Key.Up:
                                this.GameSimulation.SelectedCharacter.Move(Direction.Up);
                                break;
                            case Key.Down:
                                this.GameSimulation.SelectedCharacter.Move(Direction.Down);
                                break;
                            case Key.Left:
                                this.GameSimulation.SelectedCharacter.Move(Direction.Left);
                                break;
                            case Key.Right:
                                this.GameSimulation.SelectedCharacter.Move(Direction.Right);
                                break;
                        }
                        this.UpdateGameBoardDisplay();
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
					button.Padding = new Thickness(0, 0, 0, 0);
					button.Style = (Style)Resources["Cell"];
                    
					Grid.SetColumn(button, column);
					Grid.SetRow(button, row);
					grid_Game.Children.Add(button);
				}
			}

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
                    foreach (Character c in this.GameSimulation.characterList)
                    {
                        if (c.HP > 0)
                        {
                            switch (r.Next(4))
                            {
                                case 1:
                                    c.Move(Direction.Up);
                                    break;
                                case 2:
                                    c.Move(Direction.Down);
                                    break;
                                case 3:
                                    c.Move(Direction.Left);
                                    break;
                                case 4:
                                    c.Move(Direction.Right);
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show(c.Name + " est mort");
                        }
                    }
                    this.UpdateGameBoardDisplay();
                }
            }
        }
    }
}
