namespace TicTacToe.Console;

public class Player
{
    public Token Token { get; }
    public string MatchPlayerWin { get; }
    public string WinMessage;
    public bool IsWinner;
    public bool IsMyTurn;
    private const string PlayerXWinMessage = "Player X Win";
    private const string PlayerOWinMessage = "Player O Win";

    private Player(Token token, string matchPlayerWin, string playerWinMessage, bool isMyTurn)
    {
        Token = token;
        MatchPlayerWin = matchPlayerWin;
        WinMessage = playerWinMessage;
        IsMyTurn = isMyTurn;
    }

    public static Player Create(Token token, string matchPlayerWin)
    {
        return token.Equals(Token.X) ? new Player(token, matchPlayerWin, PlayerXWinMessage, true) : new Player(token, matchPlayerWin, PlayerOWinMessage, false);
    }
}