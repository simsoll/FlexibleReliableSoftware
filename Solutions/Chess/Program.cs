using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = new Position(5, 5);
            Console.WriteLine("Starting position: " + position);

            var knightMoves = Position.GetKnightPositionIterator(position);

            Console.WriteLine("---- Knight moves ----");
            foreach (var p in knightMoves)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            var rookMoves = Position.GetRookPositionIterator(position);

            Console.WriteLine("---- Rook moves ----");
            foreach (var p in rookMoves)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            var bishopMoves = Position.GetBishopPositionIterator(position);

            Console.WriteLine("---- Bishop moves ----");
            foreach (var p in bishopMoves)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            var quennMoves = Position.GetQueenPositionIterator(position);

            Console.WriteLine("---- Queen moves ----");
            foreach (var p in quennMoves)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            Console.Read();
        }
    }
}
