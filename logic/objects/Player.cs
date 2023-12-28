namespace TicTacToe.logic.objects;

internal class Player
{
    private static int _nextId = 1;
    public string Name { get; private set; }
    private readonly Symbol _playerSymbol;

    public Player(Symbol playerSymbol, string playerName = "Player")
    {
        Name = playerName.Equals("Player") ? $"{playerName} {_nextId}" : playerName;
        _nextId++;
        if (_nextId == 3) _nextId = 1;
        
        _playerSymbol = playerSymbol;
    }
    
    public void SetName(string name) => Name = name;
    
    private char GetPlayerSymbol() => _playerSymbol.GetValue();
    
    public bool MakeATurn(Board board, int position)
    {
        Console.WriteLine($"{Name}, it's your turn.");
        if (!board.CheckOccupancy(position))
        {
            Console.WriteLine("This position is already occupied!");
            return false;
        }
        
        var symbol = new Symbol(GetPlayerSymbol(), position);
        
        board.SetOccupied(position, symbol);
        
        return true;
    }
}