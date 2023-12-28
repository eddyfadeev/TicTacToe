namespace TicTacToe.logic.objects;

internal class Symbol(char symbolValue, int position = 0)
{
    private char SymbolValue { get; } = symbolValue;
    private int Position { get; set; } = position;

    public int GetCurrentPosition() => Position;

    public char GetValue() => SymbolValue;
    
    public void SetPosition(int position) => Position = position;
}