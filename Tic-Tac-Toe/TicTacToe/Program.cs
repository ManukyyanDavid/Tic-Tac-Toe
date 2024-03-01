using System.Numerics;

namespace TicTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            TicTacToe TicTacToe = new TicTacToe();
            TicTacToe.ChooseGameMood(out string mood);
            while (TicTacToe.Status == "Draw" && TicTacToe.Step < 9)
            {
                TicTacToe.Print();
                if (mood == "1")
                {
                    TicTacToe.AskForP1Input();
                    TicTacToe.CheckStatus();
                    if ((TicTacToe.Status == "Player 2 Won" || TicTacToe.Status == "Player 1 Won") || TicTacToe.Step == 9)
                    {
                        break;
                    }
                    TicTacToe.Print();
                    TicTacToe.AskForP2Input();
                }
                else if (mood == "2")
                {
                    TicTacToe.AskForP1Input();
                    TicTacToe.CheckStatus();
                    if ((TicTacToe.Status != "Player 1 Won" || TicTacToe.Status != "Player 2 Won") && TicTacToe.Step! < 9)
                    {

                        TicTacToe.AIMove();
                    }

                }
                TicTacToe.CheckStatus();

            }
            TicTacToe.Print();
            Console.WriteLine("The game is over " + TicTacToe.Status + "!");
            Console.WriteLine("Press any Key to continue!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
