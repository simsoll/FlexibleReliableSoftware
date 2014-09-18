using System;

namespace Breakthrough
{
    public class StandardMovementStrategy : IMovementStrategy
    {
        public bool IsMoveValid(int fromRow, int fromColumn, int toRow, int toColumn, PieceType fromPieceType,
            PieceType toPieceType, PlayerType playerInTurn)
        {
            if (IsJumping(fromRow, fromColumn, toRow, toColumn)) return false;
            if (!IsOriginValid(fromPieceType, playerInTurn)) return false;
            if (!IsMovingForward(fromRow, toRow, playerInTurn)) return false;

            return IsDestinationValid(fromColumn, toColumn, toPieceType, playerInTurn);
        }

        private bool IsDestinationValid(int fromColumn, int toColumn, PieceType toPieceType, PlayerType playerInTurn)
        {
            switch (playerInTurn)
            {
                case PlayerType.Black:
                    if (fromColumn != toColumn && toPieceType != PieceType.Black) return true;
                    if (fromColumn == toColumn && toPieceType == PieceType.None) return true;
                    break;
                case PlayerType.White:
                    if (fromColumn != toColumn && toPieceType != PieceType.White) return true;
                    if (fromColumn == toColumn && toPieceType == PieceType.None) return true;
                    break;
            }
            return false;
        }

        private bool IsMovingForward(int fromRow, int toRow, PlayerType playerInTurn)
        {
            if (playerInTurn == PlayerType.Black && fromRow < toRow) return true;
            if (playerInTurn == PlayerType.White && toRow < fromRow) return true;
            return false;
        }

        private bool IsOriginValid(PieceType fromPieceType, PlayerType playerInTurn)
        {
            switch (playerInTurn)
            {
                case PlayerType.Black:
                    if (fromPieceType != PieceType.Black) return false;
                    break;
                case PlayerType.White:
                    if (fromPieceType != PieceType.White) return false;
                    break;
            }
            return true;
        }

        private bool IsJumping(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            if (Math.Abs(fromRow - toRow) > 1) return true;
            if (Math.Abs(fromColumn - toColumn) > 1) return true;
            return false;
        }
    }
}