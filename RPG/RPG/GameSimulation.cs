using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RPG
{
    public class GameSimulation
    {
        public Organization jointStaff;
        public ObservableCollection<Character> characterList;
        public Character SelectedCharacter { get; set; }
        public GameEnvironment GameEnvironment { get; private set; }
        public int Tour { get; private set; }

        private static GameSimulation instance;
        public static GameSimulation Instance 
        {
            get
            {
                if(GameSimulation.instance == null)
                    GameSimulation.instance = new GameSimulation();
                return GameSimulation.instance;
            }
        }

        private GameSimulation()
        {
            this.characterList = new ObservableCollection<Character>();
            this.jointStaff = new Organization();
        }

        public void CreateGameBoard()
        {
            this.GameEnvironment = new GameEnvironment(new GameBoardFactory());
        }

        public void CreateLabyrinth()
        {
            this.GameEnvironment = new GameEnvironment(new LabyrinthFactory());
        }

        public void CreateCharacter(AbstractGameBoard agb)
        {
            Knight Arnaud = new Knight(agb, "Arnaud le terrible");
            Assassin Jacques = new Assassin(agb, "Jacques a dit");
            Archer Thierry = new Archer(agb, "Thierry la fronde");
            characterList.Add(Arnaud);
            characterList.Add(Jacques);
            characterList.Add(Thierry);

            Princess Fiona = new Princess(agb, "Fiona la belle");
            characterList.Add(Fiona);

            this.SelectedCharacter = this.characterList.First();
        }

        public void AddCharacterOnGameBoard()
        {
            if (null != this.GameEnvironment.GameBoard)
            {
                Random random = new Random();
                foreach (Character c in this.characterList)
                {
                    int row = random.Next(0, this.GameEnvironment.GameBoard.GetRowCount() - 1);
                    int column = random.Next(0, this.GameEnvironment.GameBoard.GetColumnCount() - 1);
                    this.GameEnvironment.GameBoard.GetAbstractZone(row, column).TrySetContent(c);
                }
            }
        }

        public void NextTour()
        {
            this.Tour++;
        }

        public string ShowAll()
        {
            var result = new StringBuilder("Characters :\n");
            foreach (var character in characterList)
            {
                result.AppendLine("- " + character.Show());
            }
            return result.ToString();
        }

        public string EmitSoundAll()
        {
            var result = new StringBuilder("Emit a sound :\n");
            foreach (var character in characterList)
            {
                result.AppendLine("- " + character.EmitSound());
            }
            return result.ToString();
        }

        public string StartFight()
        {
            var result = new StringBuilder("Fight :\n");
            foreach (var character in this.characterList)
            {
                result.AppendLine("- " + character.Fight());
            }
            return result.ToString();
        }

        internal void ChangerComportement()
        {
            this.characterList[0].FightBehavior = new ComportementApiedAvecHache();
        }
    }
}
