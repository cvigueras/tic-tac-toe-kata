namespace TicTacToe.Console;

public class Player
{
    public Token Token { get; }
    public string MatchPlayerWin { get; }

    private Player(Token token, string matchPlayerWin)
    {
        Token = token;
        MatchPlayerWin = matchPlayerWin;
    }

    public static Player Create(Token token, string matchPlayerWin)
    {
        return new Player(token,matchPlayerWin);
    }
}