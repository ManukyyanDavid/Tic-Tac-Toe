using System;
using System.Linq;

namespace TicTacToe;

public class TicTacToe
{
    public string Status { get; set; } = "Draw";
    public int Step { get; set; } = 0;
    public string[,] Array { get; set; } = {
        { "1","2","3" },
        { "4","5","6" },
        { "7","8","9" }
    };
    public List<int> AvailableIndexes { get; set; } = new List<int>();
    public TicTacToe()
    {
        AvailableIndexes.Add(5);
        AvailableIndexes.Add(1);
        AvailableIndexes.Add(3);
        AvailableIndexes.Add(7);
        AvailableIndexes.Add(9);
        AvailableIndexes.Add(2);
        AvailableIndexes.Add(4);
        AvailableIndexes.Add(6);
        AvailableIndexes.Add(8);
    }
    static int onerep = 0;
    static int onerep2 = 0;

    public bool IsNumber(int i, int j)
    {
        for (int k = 1; k <= 9; k++)
        {
            if (Array[i, j] == k.ToString())
            {
                return true;
            }

        }
        return false;
    }
    public bool IsNumber(string i)
    {
        for (int k = 1; k <= 9; k++)
        {
            if (i == k.ToString())
            {
                return true;
            }

        }
        return false;
    }
    public void CheckStatus()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Array[0, i] == Array[1, i] && Array[0, i] == Array[2, i])
            {
                if (Array[0, i] == "P1")
                {
                    Status = "Player 1 Won";
                }
                else if (Array[0, i] == "P2")
                {
                    Status = "Player 2 Won";
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (Array[i, 0] == Array[i, 1] && Array[i, 0] == Array[i, 2])
            {
                if (Array[i, 0] == "P1")
                {
                    Status = "Player 1 Won";
                }
                else if (Array[i, 0] == "P2")
                {
                    Status = "Player 2 Won";
                }
            }
        }
        if (Array[0, 0] == Array[1, 1] && Array[0, 0] == Array[2, 2])
        {
            if (Array[1, 1] == "P1")
            {
                Status = "Player 1 Won";
            }
            else if (Array[1, 1] == "P2")
            {
                Status = "Player 2 Won";
            }
        }
        if (Array[0, 2] == Array[1, 1] && Array[0, 2] == Array[2, 0])
        {
            if (Array[1, 1] == "P1")
            {
                Status = "Player 1 Won";
            }
            else if (Array[1, 1] == "P2")
            {
                Status = "Player 2 Won";
            }
        }
    }
    public void ChooseGameMood(out string input)
    {
        Console.WriteLine("If you want to play with your friend write 1 ");
        Console.WriteLine("If you want to play against our AI tool, write 2 ");
        input = Console.ReadLine();
        if (!(input == "1" || input == "2"))
        {
            ChooseGameMood(out input);
        }
    }
    public void AskForP1Input()
    {
        Console.Write("Player 1 - ");


        try
        {
            string? input = Console.ReadLine();
            if (IsNumber(input))
            {
                int cellnumber = int.Parse(input) - 1;
                if (AvailableIndexes.Contains(cellnumber + 1))
                {
                    AvailableIndexes.Remove(cellnumber + 1);
                    int i = cellnumber / 3;
                    int j = cellnumber % 3;
                    Array[i, j] = "P1";
                    Step++;
                }
                else
                {
                    Print();
                    Console.WriteLine("Something is wrong");
                    AskForP1Input();
                }
            }
            else
            {
                Console.WriteLine("Input a valid  number");
                AskForP1Input();
            }

        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            AskForP1Input();
        }

    }
    public void AskForP2Input()
    {
        Console.Write("Player 2 - ");


        try
        {
            string? input = Console.ReadLine();
            if (IsNumber(input))
            {
                int cellnumber = int.Parse(input) - 1;
                if (AvailableIndexes.Contains(cellnumber + 1))
                {
                    AvailableIndexes.Remove(cellnumber + 1);
                    int i = cellnumber / 3;
                    int j = cellnumber % 3;
                    Array[i, j] = "P2";
                    Step++;
                }
                else
                {
                    Print();
                    Console.WriteLine("Something is wrong");
                    AskForP2Input();
                }
            }
            else
            {
                Console.WriteLine("Input a valid  number");
                AskForP2Input();
            }

        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");

            AskForP2Input();
        }

    }
    public void AIMove()
    {
        bool CanWin = CheckPotentialWin(out int i, out int j);
        bool CanCreatePossibleWin = CanCreateWinSituation(out int x, out int y);
        if (Step == 1)
        {
            if (Array[1, 1] == "5")
            {
                Array[1, 1] = "P2";
                AvailableIndexes.Remove(5);
                Console.WriteLine("Player 2 - "+ "5");
               

            }
            else
            {
                Array[0, 0] = "P2";
                AvailableIndexes.Remove(1);

                Console.WriteLine("Player 2 - " + "1");
                
            }
        }

        else
        {
            if (Array[2, 1] == "P1" && Array[1, 2] == "P1" && Array[1, 1] == "P2" && onerep2 == 0 &&
                IsNumber(Array[0, 0]) && IsNumber(Array[0, 1]) && IsNumber(Array[0, 2]) && IsNumber(Array[1, 0])
                && IsNumber(Array[2, 0]) && IsNumber(Array[2, 2]) && onerep == 0)
            {
                Array[2, 2] = "P2";
                AvailableIndexes.Remove(9);
                onerep2 = 1;
                Console.WriteLine("Player 2 - " + "9");
            }
            else if (((Array[1, 1] == "P2" && Array[0, 0] == "P1" && Array[2, 2] == "P1") ||
                (Array[1, 1] == "P2" && Array[0, 2] == "P1" && Array[2, 0] == "P1")) && onerep == 0
                )
            {
                Array[0, 1] = "P2";
                AvailableIndexes.Remove(2);
                onerep = 1;

                Console.WriteLine("Player 2 - " + "2");
            }
            else if (CanWin)
            {
                Array[i, j] = "P2";
                AvailableIndexes.Remove(ConverIntFromIndexes(i, j));

                Console.WriteLine("Player 2 - " + ConverIntFromIndexes(i, j));

            }
            else if (CanCreatePossibleWin)
            {
                Array[x, y] = "P2";
                AvailableIndexes.Remove(ConverIntFromIndexes(x, y));
                Console.WriteLine("Player 2 - " + ConverIntFromIndexes(x, y));

            }
            else
            {

                int n = AvailableIndexes[0];
                int index1 = ((n + 2) / 3) - 1;
                int index2 = n - index1 * 3 - 1;
                Array[index1, index2] = "P2";
                AvailableIndexes.Remove(ConverIntFromIndexes(index1, index2));
                Console.WriteLine("Player 2 - " + ConverIntFromIndexes(index1, index2));

            }
        }

        Step++;
    }
    public int ConverIntFromIndexes(int i, int j)
    {

        j++;
        return 3 * i + j++;
    }

    public bool CanCreateWinSituation(out int index1, out int index2)
    {
        index1 = 0;
        index2 = 0;
        if ((IsNumber(Array[1, 1]) && Array[2, 2] == "P2" && IsNumber(Array[0, 0])) ||
            (IsNumber(Array[2, 2]) && Array[1, 1] == "P2" && IsNumber(Array[0, 0])) ||
            (IsNumber(Array[1, 1]) && Array[0, 0] == "P2" && IsNumber(Array[2, 2])))
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsNumber(Array[i, i]))
                {
                    index1 = i;
                    index2 = i;
                    break;
                }
            }
            return true;
        }

        if ((IsNumber(Array[1, 1]) && Array[2, 0] == "P2" && IsNumber(Array[0, 2])) ||
            (IsNumber(Array[2, 0]) && Array[1, 1] == "P2" && IsNumber(Array[0, 2])) ||
            (IsNumber(Array[1, 1]) && Array[0, 2] == "P2" && IsNumber(Array[2, 0])))
        {

            if (IsNumber(Array[0, 2]))
            {
                index1 = 0;
                index2 = 2;
            }
            else if (IsNumber(Array[1, 1]))
            {
                index1 = 1;
                index2 = 1;
            }
            else if (IsNumber(Array[2, 0]))
            {
                index1 = 2;
                index2 = 0;
            }
            return true;
        }


        for (int i = 0; i < 3; i++)
        {
            if ((Array[2, i] == "P2" && IsNumber(Array[0, i]) && IsNumber(Array[1, i])) ||
                (Array[1, i] == "P2" && IsNumber(Array[0, i]) && IsNumber(Array[2, i])) ||
                (Array[0, i] == "P2" && IsNumber(Array[1, i]) && IsNumber(Array[2, i])))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsNumber(Array[j, i]))
                    {
                        index1 = j;
                        index2 = i;
                        break;
                    }
                }
                return true;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if ((Array[i, 0] == Array[i, 1] && Array[i, 2] == "P2" && IsNumber(Array[i, 0]) && IsNumber(Array[i, 1])) ||
                (Array[i, 0] == Array[i, 2] && Array[i, 1] == "P2" && IsNumber(Array[i, 0]) && IsNumber(Array[i, 2])) ||
                (Array[i, 1] == Array[i, 2] && Array[i, 0] == "P2" && IsNumber(Array[i, 1]) && IsNumber(Array[i, 2])))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsNumber(Array[i, j]))
                    {
                        index1 = i;
                        index2 = j;
                        break;
                    }
                }
                return true;
            }
        }

        return false;

    }

    //Check If the opponent can win in the next move
    public bool CheckPotentialWin(out int index1, out int index2)
    {
        index1 = 0;
        index2 = 0;
        for (int i = 0; i < 3; i++)
        {
            if ((Array[0, i] == Array[1, i] && IsNumber(Array[2, i])) ||
                (Array[0, i] == Array[2, i] && IsNumber(Array[1, i])) ||
                (Array[1, i] == Array[2, i] && IsNumber(Array[0, i])))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsNumber(Array[j, i]))
                    {
                        index1 = j;
                        index2 = i;
                        break;
                    }
                }
                return true;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if ((Array[i, 0] == Array[i, 1] && IsNumber(Array[i, 2])) ||
                (Array[i, 0] == Array[i, 2] && IsNumber(Array[i, 1])) ||
                (Array[i, 1] == Array[i, 2] && IsNumber(Array[i, 0])))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsNumber(Array[i, j]))
                    {
                        index1 = i;
                        index2 = j;
                        break;
                    }
                }
                return true;
            }
        }

        if (Array[0, 0] == Array[1, 1] && IsNumber(Array[2, 2]) ||
            Array[0, 0] == Array[2, 2] && IsNumber(Array[1, 1]) ||
            Array[2, 2] == Array[1, 1] && IsNumber(Array[0, 0]))
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsNumber(Array[i, i]))
                {
                    index1 = i;
                    index2 = i;
                    break;
                }
            }
            return true;
        }

        if (Array[0, 2] == Array[1, 1] && IsNumber(Array[2, 0]) ||
            Array[0, 2] == Array[2, 0] && IsNumber(Array[1, 1]) ||
            Array[2, 0] == Array[1, 1] && IsNumber(Array[0, 2]))
        {

            if (IsNumber(Array[0, 2]))
            {
                index1 = 0;
                index2 = 2;
            }
            else if (IsNumber(Array[1, 1]))
            {
                index1 = 1;
                index2 = 1;
            }
            else if (IsNumber(Array[2, 0]))
            {
                index1 = 2;
                index2 = 0;
            }
            return true;
        }

        return false;
    }
    public void Print()
    {
        Console.WriteLine();
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                if (IsNumber(i, j))
                {
                    Console.Write(Array[i, j]);
                }
                else if (Array[i, j] == "P1")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (Array[i, j] == "P2")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.Write(" | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
            Console.WriteLine();

    }
}
