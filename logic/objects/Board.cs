using System.Text;
using TicTacToe.logic.objects;

namespace TicTacToe;

internal class Board
{
    private readonly char[,] _fieldArray;
    
    public Board()
    {
        _fieldArray = new char[3,3];
        for (int i = 0; i < _fieldArray.Rank + 1; i++)
        {
            for (int j = 0; j < _fieldArray.Rank + 1; j++)
            {
                _fieldArray[i, j] = ' ';
            }
        }
    }

    internal void DrawAField()
    {
        Console.Clear();
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < _fieldArray.Rank + 1; i++)
        {
            sb.Append("-----+-----+-----\n");
            for (int j = 0; j < _fieldArray.Rank + 1; j++)
            {
                sb.Append($"  {_fieldArray[i, j]}  ");
                if (j is 0 or 1) sb.Append("|");
                if (j is 2) sb.Append("\n");
            }
        }
        sb.Append("-----+-----+-----");
        Console.WriteLine(sb.ToString());
    }

    internal bool CheckOccupancy(int x, int y) => !_fieldArray[x, y].Equals(' ');

    internal void SetOccupied(int x, int y, char symbol) => _fieldArray[x, y] = symbol;
    
    internal char GetWinnerSymbol()
    {
        // Rows check.
        for (int row = 0; row < 3; row++)
        {
            if ((_fieldArray[row, 0] == _fieldArray[row, 1] && _fieldArray[row, 1] == _fieldArray[row, 2]) && (_fieldArray[row, 0] != ' '))
                return _fieldArray[row, 0];
        }
        // Columns check.
        for (int col = 0; col < 3; col++)
        {
            if ((_fieldArray[0, col] == _fieldArray[1, col] && _fieldArray[1, col] == _fieldArray[2, col]) && (_fieldArray[0, col] != ' '))
                return _fieldArray[0, col];
        }
        // Main diagonal check.
        if ((_fieldArray[0, 0] == _fieldArray[1, 1] && _fieldArray[1, 1] == _fieldArray[2, 2]) && _fieldArray[0, 0] != ' ')
            return _fieldArray[0, 0];
        // Second diagonal check.
        if ((_fieldArray[0, 2] == _fieldArray[1, 1] && _fieldArray[1, 1] == _fieldArray[2, 0]) && (_fieldArray[0, 2] != ' '))
            return _fieldArray[0, 2];
        
        return ' ';
    }
    
}