using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProjectChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            RunRook();
            
        }


        static void RunRook()
        {
            var rook = new RookMovement("d5");

            List<string> stPiecies = new List<string>();

            stPiecies.Add("0 g5");         
            stPiecies.Add("0 d2");
            stPiecies.Add("1 d7");

            foreach (var currPiece in stPiecies)
                rook.AddPiece( Convert.ToInt32(currPiece.Substring(0, 1)), currPiece.Substring(2));

            var lstAnswer = rook.GetMovements();
            var answer = lstAnswer.OrderBy(x => x);

            foreach (var currMove in answer)
                Console.WriteLine(currMove);

            Console.Read();

        }
    }
}
