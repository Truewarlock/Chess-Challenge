using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();

        Random random = new Random();

        int[] pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };

        Move theTwoHundreddIqMove = moves[random.Next(moves.Length)];
        int highestValueCapture = 0;

        foreach (var move in moves)
        {
            if (CheckIfCanCheckMate(board, move))
            {
                theTwoHundreddIqMove = move;
                break;
            }

            Piece capturedPiece = board.GetPiece(move.TargetSquare);
            int capturedPieceValue = pieceValues[(int)capturedPiece.PieceType];

            if (capturedPieceValue > highestValueCapture)
            {
                theTwoHundreddIqMove = move;
                highestValueCapture = capturedPieceValue; 
            }
        }
        return theTwoHundreddIqMove;
    }


    private bool CheckIfCanCheckMate(Board board, Move move)
    {
        board.MakeMove(move);
        bool ggwp = board.IsInCheckmate();
        board.UndoMove(move);
        return ggwp;

    }

    private void MonteCarloSearch(Board board, Move move) { 
        //1. Selection

        //2. Expansion

        //3.Rollout

        //4.BackPropagation
    }
}