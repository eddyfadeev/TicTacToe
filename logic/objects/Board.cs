using System.Text;
using TicTacToe.logic.objects;

namespace TicTacToe;

internal class Board
{
    private readonly Symbol[] _fieldArray;
    
    public Board()
    {
        _fieldArray = new Symbol[9];
        for (int i = 0; i < _fieldArray.Length; i++)
        {
            _fieldArray[i] = new Symbol(' ', i);
        }
    }

    internal void DrawAField()
    {
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < _fieldArray.Length; i++)
        {
            if (i is 0) sb.Append("-----+-----+-----\n");
            
            if (i is 0 or 2 or 3 or 5 or 6 or 8 ) sb.Append($"  {_fieldArray[i].GetValue()}  ");
            else sb.Append($"|  {_fieldArray[i].GetValue()}  |");

            if (i is 2 or 5 or 8) sb.Append("\n-----+-----+-----\n");
        }
        Console.WriteLine(sb.ToString());
    }

    internal bool CheckOccupancy(int position) => _fieldArray[position].GetValue().Equals(' ');

    internal void SetOccupied(int position, Symbol symbol) => _fieldArray[position] = symbol;

    // TODO: Implement this method
    internal Symbol GetWinner()
    {
        for (int i = 0; i < _fieldArray.Length; i++)
        {
        }
        
        
        return new Symbol(' ');
    }

}