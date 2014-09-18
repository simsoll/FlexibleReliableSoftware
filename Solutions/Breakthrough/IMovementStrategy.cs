namespace Breakthrough
{
    public interface IMovementStrategy
    {
        bool IsMoveValid(int fromRow, int fromColumn,
            int toRow, int toColumn, PieceType fromPieceType, PieceType toPieceType, PlayerType playerInTurn);
    }
}