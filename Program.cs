using GameDatabase;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.PrintGrid();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W or ConsoleKey.UpArrow:
                    game.MovePlayer(-1, 0);
                    break;
                case ConsoleKey.S or ConsoleKey.DownArrow:
                    game.MovePlayer(1, 0);
                    break;
                case ConsoleKey.A or ConsoleKey.LeftArrow:
                    game.MovePlayer(0, -1);
                    break;
                case ConsoleKey.D or ConsoleKey.RightArrow:
                    game.MovePlayer(0, 1);
                    break;
                default:
                    continue;
            }
        }
    }
}