using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chess
{
    public class Position
    {
        private const int BoardRows = 8;
        private const int BoardColumns = 8;

        /** return an iterator that will return all positions
          * that a knight may reach from a given starting position.
          */

        public static IEnumerable<Position> GetKnightPositionIterator(Position p)
        {
            for (var x = -2; x <= 2; x++)
            {
                for (var y = -2; y <= 2; y++)
                {
                    if (Math.Abs(x) + Math.Abs(y) != 3)
                    {
                        continue;
                    }

                    var newPosition = new Position(p.X + x, p.Y + y);

                    if (IsValid(newPosition))
                    {
                        yield return newPosition;
                    }
                }
            }
        }

        public static IEnumerable<Position> GetRookPositionIterator(Position p)
        {
            for (var x = -BoardRows; x <= BoardRows; x++)
            {
                if (x == 0)
                {
                    continue;
                }

                var newPosition = new Position(p.X + x, p.Y);

                if (IsValid(newPosition))
                {
                    yield return newPosition;
                }
            }

            for (var y = -BoardColumns; y <= BoardColumns; y++)
            {
                if (y == 0)
                {
                    continue;
                }

                var newPosition = new Position(p.X, p.Y + y);

                if (IsValid(newPosition))
                {
                    yield return newPosition;
                }
            }
        }

        public static IEnumerable<Position> GetBishopPositionIterator(Position p)
        {
            for (var x = -BoardRows; x <= BoardRows; x++)
            {
                if (x == 0)
                {
                    continue;
                }

                var newPosition = new Position(p.X + x, p.Y + x);

                if (IsValid(newPosition))
                {
                    yield return newPosition;
                }

                newPosition = new Position(p.X + x, p.Y - x);

                if (IsValid(newPosition))
                {
                    yield return newPosition;
                }
            }
        }

        public static IEnumerable<Position> GetQueenPositionIterator(Position p)
        {
            return GetRookPositionIterator(p).Concat(GetBishopPositionIterator(p));
        }



        public static bool IsValid(Position p)
        {
            return 0 <= p.X && p.X <= BoardRows
                   && 0 <= p.Y && p.Y <= BoardColumns;
        }

        /** create a position. 
          * @param x the row
          * @param y the column
          */
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected readonly int X;
        protected readonly int Y;

        /** get the row represented by this position.
          * @return the row.
          */
        public int GetRow()
        {
            return X;
        }

        /** get the column represented by this position.
          * @return the column.
          */

        public int GetColumn()
        {
            return Y;
        }

        public override bool Equals(Object o)
        {
            if (o.GetType() != GetType())
            {
                return false;
            }
            var other = (Position) o;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            // works ok for positions up to columns == 479
            return 479*X + Y;
        }

        public override string ToString()
        {
            return "[" + X + "," + Y + "]";
        }
    }
}