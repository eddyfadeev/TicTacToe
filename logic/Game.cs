using TicTacToe.logic.objects;

namespace TicTacToe.logic;

public class Game
{
    private Player _player1;
    private Player _player2;
    private Board _board;
    private bool _xIsChosen;
    private bool _isGameFinished;
    private bool _player1Turn = true;
    private int _totalRounds = 1;
    
    
    public void Start()
    {
        Console.WriteLine("Welcome to TicTacToe!");

        char player1Symbol = ChoosePlayerSymbol();
        
        if (player1Symbol.Equals('X')) _xIsChosen = true;
        char player2Symbol = _xIsChosen ? 'O' : 'X';

        Console.Write("Player 1. ");
        _player1 = CreatePlayer(player1Symbol);
        
        Console.Write($"Player 2. You will play with '{player2Symbol}'. ");
        _player2 = CreatePlayer(player2Symbol);

        _board = new Board();
        
        Console.Clear();

        ShowMenu();
        
        var input = GameUtils.GetInput(1,2);

        switch (input)
        {
            case 1:
                StartGame();
                break;
            case 2:
                Environment.Exit(0);
                break;
        }  
    }

    private Player CreatePlayer(char playerSymbol)
    {
        Console.WriteLine($"Please, enter a player name or hit enter for the default name:");
        string name = Console.ReadLine();

        if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            return new Player(playerSymbol, name);
            
        return new Player(playerSymbol);
    }
    
    private char ChoosePlayerSymbol()
    {
        Console.Write("Please choose a symbol you want to play with (X or O): ");
        
        char playerSymbol = GameUtils.GetInput(['X', 'O']);
        
        return playerSymbol;
    }

    private void ShowMenu()
    {
        Console.WriteLine("1. Start a new game");
        Console.WriteLine("2. Exit");
    }

    private void StartGame()
    {
        while (!_isGameFinished)
        {
            Console.Clear();
            Console.WriteLine($"Round: {_totalRounds}");
            _board.DrawAField();
            if (_player1Turn)
            {
                Console.Write($"{_player1.Name}, it's your turn: ");
                _player1.MakeATurn(_board, GameUtils.GetInput(1, 9));
                _player1Turn = false;
            }
            else
            {
                Console.Write($"{_player2.Name}, it's your turn: ");
                _player2.MakeATurn(_board, GameUtils.GetInput(1, 9));
                _player1Turn = true;
            }
            Console.Clear();
            _board.DrawAField();
            _totalRounds++;

            if (_totalRounds >= 4)
            {
                char winnerSymbol = _board.GetWinnerSymbol();
                if (winnerSymbol.Equals(' ') && _totalRounds == 10)
                {
                    Console.WriteLine("It's a draw!");
                    _isGameFinished = true;
                }
                
                if (!winnerSymbol.Equals(' '))
                {
                    string winnerName = winnerSymbol.Equals(_player1.GetPlayerSymbol()) ? _player1.Name : _player2.Name;
                    Console.WriteLine($"The winner is {winnerName}!");
                    _isGameFinished = true;
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }// end of while loop.
    } // end of StartGame() method.
} // end of Game class.