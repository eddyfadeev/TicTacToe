using TicTacToe.logic.objects;

namespace TicTacToe.logic;

public class Game
{
    private Player Player1;
    private Player Player2;
    private Board Board;
    private bool _xIsChosen;
    private bool _isGameFinished;
    private bool _player1Turn;
    
    
    public void Start()
    {
        Console.WriteLine("Welcome to TicTacToe!");

        Symbol player1Symbol = ChoosePlayerSymbol();
        
        if (player1Symbol.GetValue().Equals('X')) _xIsChosen = true;
        Symbol player2Symbol = new Symbol(_xIsChosen ? 'O' : 'X');

        Console.Write("Player 1. ");
        Player1 = CreatePlayer(player1Symbol);
        
        Console.Write($"Player 2. You will play with '{player2Symbol.GetValue()}'. ");
        Player2 = CreatePlayer(player2Symbol);

        Board = new Board();
        
        Console.Clear();

        while (true)
        {
            ShowMenu();
            
        }
    }

    private Player CreatePlayer(Symbol playerSymbol)
    {
        Console.WriteLine($"Please, enter a player name or hit enter for the default name:");
        string name = Console.ReadLine();

        if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            return new Player(new Symbol(playerSymbol.GetValue()), name);
            
        return new Player(new Symbol(playerSymbol.GetValue()));
    }
    
    private Symbol ChoosePlayerSymbol()
    {
        Console.Write("Please choose a symbol you want to play with (X or O): ");
        
        char playerSymbol = GameUtils.GetInput(['X', 'O']);
        
        return new Symbol(playerSymbol);
    }

    private Symbol GetWinnerSymbol(Board gameBoard)
    {
        Symbol winnerSymbol;

        winnerSymbol = new Symbol(' ');
        
        
        
        return winnerSymbol;
    }

    private void ShowMenu()
    {
        Console.WriteLine("1. Start a new game");
        Console.WriteLine("2. Change player names");
        Console.WriteLine("3. Exit");
    }
}