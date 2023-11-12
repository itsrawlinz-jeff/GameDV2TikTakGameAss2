using System;

class Program
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char currentPlayer = 'X';

    static void Main()
    {
        do
        {
            Console.Clear();
            PrintBoard();
            GetPlayerMove();
        } while (!IsGameWon() && !IsBoardFull());

        Console.Clear();
        PrintBoard();

        if (IsGameWon())
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }

        Console.ReadLine();
    }

    static void PrintBoard()
    {
        Console.WriteLine("Tic-Tac-Toe\n");

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write($" {board[row, col]} ");
                if (col < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (row < 2) Console.WriteLine("-----------");
        }
        Console.WriteLine();
    }

    static void GetPlayerMove()
    {
        bool validMove = false;

        do
        {
            Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
            if (int.TryParse(Console.ReadLine(), out int move) && move >= 1 && move <= 9)
            {
                if (IsMoveValid(move))
                {
                    MakeMove(move);
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number between 1 and 9.");
            }

        } while (!validMove);
    }

    static bool IsMoveValid(int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        return board[row, col] != 'X' && board[row, col] != 'O' && move >= 1 && move <= 9;
    }

    static void MakeMove(int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        board[row, col] = currentPlayer;
        SwitchPlayer();
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool IsGameWon()
    {
        // Check rows, columns, and diagonals for a win
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer ||
                board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;
            }
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
            board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }

        return false;
    }

    static bool IsBoardFull()
    {
        foreach (var cell in board)
        {
            if (cell != 'X' && cell != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
