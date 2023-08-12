using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();

        Random random = new Random();

        Move theTwoHundreddIqMove = moves[random.Next(moves.Length)];

        foreach (var move in moves)
        {
            if (CheckIfCanCheckMate(board, move)){
                theTwoHundreddIqMove = move;
                break;
            }
        }
        return theTwoHundreddIqMove;
    }


    private bool CheckIfCanCheckMate(Board board, Move move) {
        board.MakeMove(move);
        bool ggwp = board.IsInCheckmate();
        board.UndoMove(move);
        return ggwp;

    }
}