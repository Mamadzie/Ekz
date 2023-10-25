using System;

class program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;

    static void Main(String[] args)
    {
        int Vibor;
        bool Vod;
        do
        {
            Console.Clear();
            Console.WriteLine(" Крестики-Нолики");
            Console.WriteLine(" Игрок 1: X и Игрок 2: O\n" + (player % 2 == 0 ? " Ходит игрок 2 (O)" : " Ходит игрок 1 (X)"));
            Board();

            Vod = false;
            do
            {
                Console.WriteLine("Введите номер ячейки куда хотите ходить (1-9): ");
                Vod = int.TryParse(Console.ReadLine(), out Vibor);

                if (Vod)
                {
                    if (Vibor < 1 || Vibor > 9)
                    {
                        Vod = false;
                    }
                }

                if (!Vod)
                {
                    Console.WriteLine("Некорректный ввод.Введите число от 1 до 9");
                }
                else
                {
                    if (Destvitelnaya_yacheika(Vibor))
                    {
                        Raspolojenie(Vibor);
                        player = (player == 1) ? 2 : 1;   
                    }
                    else
                    {
                        Console.WriteLine("Эта ячейка уже занята. Выберите другую.");
                        Vod = false;
                    }
                }


            } while (!Vod);


        } while (!ProverkanaPobed() && !Nichya());


        Board();
        int pobeditel = (player == 1) ? 2 : 1;
        if (ProverkanaPobed())
        {
            Console.WriteLine("Игрок " + pobeditel + " выиграли");
        }
        else if (Nichya()) {
            Console.WriteLine("Ничья!");
        }

    }

    static void Board()
    {
        Console.WriteLine($"  {board[0]} | {board[1]} | {board[2]}");
        Console.WriteLine(" ---+---+---");
        Console.WriteLine($"  {board[3]} | {board[4]} | {board[5]}");
        Console.WriteLine(" ---+---+---");
        Console.WriteLine($"  {board[6]} | {board[7]} | {board[8]}");
    }

    static bool Destvitelnaya_yacheika(int choice)
    {
        return (board[choice - 1] != 'X' && board[choice - 1] != 'O');
    }

    static void Raspolojenie(int choice)
    {
        char mark = (player == 1) ? 'X':'O';
        board[choice - 1] = mark;
    }

    static bool ProverkanaPobed()
    {
        for (int a = 0; a < 8; a++)
        {
            string line = null;
            switch (a)
            {
                case 0:
                    line = board[0].ToString() + board[1].ToString() + board[2].ToString();
                    break;
                case 1:
                    line = board[3].ToString() + board[4].ToString() + board[5].ToString();
                    break;
                case 2:
                    line = board[6].ToString() + board[7].ToString() + board[8].ToString();
                    break;
                case 3:
                    line = board[0].ToString() + board[3].ToString() + board[6].ToString();
                    break;
                case 4:
                    line = board[1].ToString() + board[4].ToString() + board[7].ToString();
                    break;
                case 5:
                    line = board[2].ToString() + board[5].ToString() + board[8].ToString();
                    break;
                case 6:
                    line = board[0].ToString() + board[4].ToString() + board[8].ToString();
                    break;
                case 7:
                    line = board[2].ToString() + board[4].ToString() + board[6].ToString();
                    break;
            }
            if (line == "XXX" || line == "OOO")
            {
                return true;

            }
        }
        return false;
    }


    static bool Nichya()
    {
        for (int a = 0; a < board.Length; a++)
        {
            if (board[a] != 'X' && board[a] != 'O')
                return false;
        }
        return true;
    }
}