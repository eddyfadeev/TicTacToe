namespace TicTacToe;

// TODO: Implement this class.
public class Field
{
    private readonly char[,] _fieldArray;
    
    public Field()
    {
        _fieldArray = new char[3, 3];
        for (int i = 0; i < _fieldArray.GetLength(0); i++)
        {
            for (int j = 0; j < _fieldArray.GetLength(1); j++)
            {
                _fieldArray[i, j] = ' ';
            }
        }
    }

    // TODO: Implement this method.
    public void DrawField()
    {
        throw new NotImplementedException();
        Console.WriteLine("-----+-----+-----");
        for (int i = 0; i < _fieldArray.GetLength(0); i++)
        {
            Console.Write(" ");
            for (int j = 0; j < _fieldArray.GetLength(1); j++)
            {
                Console.WriteLine($"  {_fieldArray[i, j]}  |  {_fieldArray[0, 1]}  |  {_fieldArray[0, 2]}  ");
                
            }
        }
        Console.WriteLine("-----+-----+-----");
        Console.WriteLine($"  {_fieldArray[1, 0]}  |  {_fieldArray[1, 1]}  |  {_fieldArray[1, 2]}  ");
        Console.WriteLine("-----+-----+-----");
        Console.WriteLine($"  {_fieldArray[2, 0]}  |  {_fieldArray[2, 1]}  |  {_fieldArray[2, 2]}  ");
        Console.WriteLine("-----+-----+-----");
    }
}