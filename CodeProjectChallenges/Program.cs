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

            stPiecies.Add("0 c1");         
            stPiecies.Add("1 e8");

            foreach (var currPiece in stPiecies)
                rook.AddPiece( Convert.ToInt32(currPiece.Substring(0, 1)), currPiece.Substring(2));

            var stAnswer = rook.GetMovements();

            var arAnswer = stAnswer.Split(' ');
            for (int x = 0; x < arAnswer.Length; x++)
            {
                Console.WriteLine(arAnswer[x].Trim(' '));
            }
            Console.Read();

        }
    }
}
