namespace TicTacToe.Console;

public class Player
{
    public Token Token { get; }
    public string MatchPlayerWin { get; }
    private const string PlayerXWinMessage = "Player X Win";
    private const string PlayerOWinMessage = "Player O Win";
    public string WinMessage;

    private Player(Token token, string matchPlayerWin, string playerWinMessage)
    {
        Token = token;
        MatchPlayerWin = matchPlayerWin;
        WinMessage = playerWinMessage;
    }

    public static Player Create(Token token, string matchPlayerWin)
    {
        return token.Equals(Token.X) ? new Player(token, matchPlayerWin, PlayerXWinMessage) : new Player(token, matchPlayerWin, PlayerOWinMessage);
    }
}