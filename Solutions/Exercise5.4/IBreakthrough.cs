using System;

namespace Exercise5._4
{
    /** Enumeration of the three types of 'pieces' that
    is possible on a given location on the chess board:
    black, white, or no piece */
    public enum PieceType { Black, White, None };
    /** Enumeration of the two types of players in the game,
        either white or black */
    public enum PlayerType { Black, White };

    public interface IBreakthrough
    {

        /** Return the type of piece on a given (row,column) on
            the chess board.
            @return the type of piece on the location.
        */
        PieceType GetPieceAt(int row, int column);

        /** Return the player that is in turn, i.e. allowed
            to move.
            @return the player that may move a piece next 
        */
        PlayerType GetPlayerInTurn();

        /** Return the winner of the game.
            @return the winner of the game or null in case no winner
            has been found yet. */
        PlayerType? GetWinner();

        /** Validate a move from a given location (fromRow, fromColumn) to a
            new location (toRow, toColumn). A move is invalid if you try to
            move your opponent's pieces or the move does not follow the
            rules, see the exercise specification.  PRECONDITION: the
            (row,column) coordinates are valid posititions, that is, all
            between (0..7).
            @return true if the move is valid, false otherwise
        */

        bool IsMoveValid(int fromRow, int fromColumn,
            int toRow, int toColumn);

        /** Move a piece from a given location (fromRow, fromColumn) to a
            new location (toRow, toColumn). PRECONDITION: the move is valid
            on the given board, that is, a previous call to isMoveValid was
            true.
        */

        void Move(int fromRow, int fromColumn,
            int toRow, int toColumn);
    }
}