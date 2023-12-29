namespace TicTacToe.logic.objects;

internal class Player
{
    private static int _nextId = 1;
    public string Name { get; private set; }
    private readonly char _playerSymbol;

    public Player(char playerSymbol, string playerName = "Player")
    {
        Name = playerName.Equals("Player") ? $"{playerName} {_nextId}" : playerName;
        _nextId++;
        if (_nextId == 3) _nextId = 1;
        
        _playerSymbol = playerSymbol;
    }
    
    public void SetName(string name) => Name = name;
    
    internal char GetPlayerSymbol() => _playerSymbol;
    
    public void MakeATurn(Board board, int position)
    {
        bool isTurnMade = false;

        while (!isTurnMade)
        {
            var point = position switch
            {
                1 => (0, 0),
                2 => (0, 1),
                3 => (0, 2),
                4 => (1, 0),
                5 => (1, 1),
                6 => (1, 2),
                7 => (2, 0),
                8 => (2, 1),
                9 => (2, 2),
            };
            
            if (board.CheckOccupancy(point.Item1, point.Item2))
            {
                Console.WriteLine("This position is already occupied!");
                Console.Write("Please, choose another position: ");
                isTurnMade = false;

                position = GameUtils.GetInput(1, 9);
            }
            else
            {
                var symbol = GetPlayerSymbol();
                board.SetOccupied(point.Item1, point.Item2, symbol);
                isTurnMade = true;
            }
        }
    }
}