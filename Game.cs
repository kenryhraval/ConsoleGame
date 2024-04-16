using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


/*********
Divdimensiju masīvs
Kur ir 10% iespēja, ka būs dārgumi.
X - 100
H - 20
O - ceļš

V - lietotājs



VOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOO
OOOOOOOOOK

Šeit nekā nav, turpini meklēt


Tu atradi zelta gabalu - dabūji 100 dālderus

Tu atradi sudraba gabalu, dabūji 20 dālderus

1. Uztaisīt 2D masīvu
2. Uzģenerēt dictionary dārgumus (x, y) iekš dictionary kā key, un dārgumus kā value
3. Dārgumiem ir sava klase, izmantojam mantošanos un ir iespēja, ka tas ir slazts
4. Staigāt pa 2D masīvu
**********/


namespace GameDatabase
{
    public class Game
    {
        
        public char[,] Grid;
        public int PlayerX;
        public int PlayerY;
        public int points;

        public Game()
        {
            points = 0;
            Grid = new char[10, 10];

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (random.Next(0, 10) == 1)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            Grid[i, j] = 'X';
                        }
                        else
                        {
                            Grid[i, j] = 'H';
                        }
                    }
                    else
                    {
                        Grid[i, j] = 'O';
                    }
                   
                }
            }

            PlayerX = 0;
            PlayerY = 0;
            Grid[PlayerX, PlayerY] = 'V';
        }

        public void PrintGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Grid[i, j] == 'V')
                    {
                        Console.Write("V");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Tev ir {points} punkti!");
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            int newX = PlayerX + deltaX;
            int newY = PlayerY + deltaY;

            Console.Clear();

            if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
            {
                
                int pointsToAdd = GetValue(Grid[newX, newY]);

                points += pointsToAdd;
                
                Grid[PlayerX, PlayerY] = 'O';
                PlayerX = newX;
                PlayerY = newY;
                Grid[PlayerX, PlayerY] = 'V';

                PrintGrid();
                if (pointsToAdd == 20)
                {
                    Console.WriteLine("Tu atradi sudraba gabalu, dabūji 20 dālderus!");
                }
                else if (pointsToAdd == 100)
                {
                    Console.WriteLine("Tu atradi zelta gabalu, dabūji 100 dālderus!");
                }
            }

            else
            {
                PrintGrid();
                Console.WriteLine("Tev nebūs pārkāpt spēles laukuma robežu!");
            }

            

        }

        public Dictionary<char, int> Treasures = new Dictionary<char, int>
        {
            { 'X', 100 },
            { 'H', 20 }
        };

        public int GetValue(char treasureType)
        {
            return Treasures.ContainsKey(treasureType) ? Treasures[treasureType] : 0;
        }

        public class PickableObjects
        {
            public int X { get; set; }
            public int Y { get; set; }
            public char Symbol { get; set; }
            public string Name {get; set;}
            public virtual void ActionOnPickup() { }
        }

        public class Treasure : PickableObjects
        {
            public int Points { get; set;}
            public override void ActionOnPickup()
            {
                Console.WriteLine($"Tu atradi {Name}. Tu saņēmi {Points} punktus!");
            }
        }
    }
}


  