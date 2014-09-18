using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace Breakthrough
{
    public class Breakthrough : IBreakthrough
    {
        private const int TotalRows = 16;
        private const int TotalColumns = 16;
        private const int RowsOfPieces = 2;
        private PieceType[,] _board;
        private PlayerType _currentPlayer;


        public Breakthrough()
        {
            InitializeBoard();
            _currentPlayer = PlayerType.White;
        }

        public PieceType GetPieceAt(int row, int column)
        {
            return _board[row, column];
        }

        public PlayerType GetPlayerInTurn()
        {
            return _currentPlayer;
        }

        public PlayerType? GetWinner()
        {
            switch (GetPlayerInTurn())
            {
                case PlayerType.White:
                    for (var column = 0; column < TotalColumns; column++)
                    {
                        if (GetPieceAt(0, column) == PieceType.White) return PlayerType.White;
                    }
                    break;
                case PlayerType.Black:
                    for (var column = 0; column < TotalColumns; column++)
                    {
                        if (GetPieceAt(TotalColumns - 1, column) == PieceType.Black) return PlayerType.Black;
                    }
                    break;
            }

            return null;
        }

        public bool IsMoveValid(int fromRow, int fromColumn,
            int toRow, int toColumn)
        {
            if (IsOutOfBounds(fromRow, fromColumn, toRow, toColumn)) return false;
            if (IsJumping(fromRow, fromColumn, toRow, toColumn)) return false;
            if (!IsOriginValid(fromRow, fromColumn)) return false;
            if (!IsMovingForward(fromRow, toRow)) return false;

            return IsDestinationValid(fromColumn, toRow, toColumn);
        }

        public void Move(int fromRow, int fromColumn,
            int toRow, int toColumn)
        {
            if (IsMoveValid(fromRow, fromColumn, toRow, toColumn))
            {
                _board[toRow, toColumn] = GetPieceAt(fromRow, fromColumn);
                _board[fromRow, fromColumn] = PieceType.None;
            }
        }

        private void InitializeBoard()
        {
            _board = new PieceType[TotalRows, TotalColumns];

            for (var row = 0; row < TotalRows; row++)
            {
                var pieceType = PieceType.None;

                if (row < RowsOfPieces)
                {
                    pieceType = PieceType.Black;
                }
                else if (TotalColumns - RowsOfPieces - 1 < row)
                {
                    pieceType = PieceType.White;
                }

                for (var column = 0; column < TotalColumns; column++)
                {
                    _board[row, column] = pieceType;
                }
            }
        }

        private bool IsDestinationValid(int fromColumn, int toRow, int toColumn)
        {
            switch (GetPlayerInTurn())
            {
                case PlayerType.Black:
                    if (fromColumn != toColumn && GetPieceAt(toRow, toColumn) != PieceType.Black) return true;
                    if (fromColumn == toColumn && GetPieceAt(toRow, toColumn) == PieceType.None) return true;
                    break;
                case PlayerType.White:
                    if (fromColumn != toColumn && GetPieceAt(toRow, toColumn) != PieceType.White) return true;
                    if (fromColumn == toColumn && GetPieceAt(toRow, toColumn) == PieceType.None) return true;
                    break;
            }
            return false;
        }

        private bool IsMovingForward(int fromRow, int toRow)
        {
            if (GetPlayerInTurn() == PlayerType.Black && fromRow < toRow) return true;
            if (GetPlayerInTurn() == PlayerType.White && toRow < fromRow) return true;
            return false;
        }

        private bool IsOriginValid(int fromRow, int fromColumn)
        {
            switch (GetPlayerInTurn())
            {
                case PlayerType.Black:
                    if (GetPieceAt(fromRow, fromColumn) != PieceType.Black) return false;
                    break;
                case PlayerType.White:
                    if (GetPieceAt(fromRow, fromColumn) != PieceType.White) return false;
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

        private bool IsOutOfBounds(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            if (fromRow < 0 || TotalRows <= fromRow) return true;
            if (toRow < 0 || TotalRows <= toRow) return true;
            if (fromColumn < 0 || TotalColumns <= fromColumn) return true;
            if (toColumn < 0 || TotalColumns <= toColumn) return true;
            return false;
        }
    }
}