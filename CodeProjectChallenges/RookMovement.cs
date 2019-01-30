using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProjectChallenges
{    
    public class RookMovement
    {
        //Puzzle Page
        //https://www.codingame.com/ide/puzzle/rooks-movements
        //

        private const int BoardLayout = 9;
        private int[,] Board = new int[BoardLayout, BoardLayout];
        private RookPiece RookPosition;

        public RookMovement(string position)
        {
            RookPosition = new RookPiece(position);
        }

        public void AddPiece(int color, string location)
        {            
            var intX = RookPiece.ConvertLetterInt(location);
            var intY = Convert.ToInt32(location.Substring(1, 1));

            if ( intX == RookPosition.X || intY == RookPosition.Y)
            {
                Board[intX, intY] = color + 1;
            }            
        }

        private string GetColFormat(int xPos, int yPos,bool capture)
        {
            var chReturn = "";

            var charCap = capture ? "x" : "-";
            var EndPos = RookPiece.getCharValue(xPos) + yPos.ToString();

            chReturn = $"R{RookPosition.OrigId}{charCap}{EndPos}";
            
            return chReturn;
        }

        public void GetBack(ref List<string> stList)
        {
            for (int i = RookPosition.X - 1; i > 0; i--)
            {
                if (Board[i, RookPosition.Y] == 1)
                    return;
                else if (Board[i, RookPosition.Y] == 2)
                {
                    stList.Add(GetColFormat(i, RookPosition.Y, true));                    
                    return;
                }
                else
                    stList.Add(GetColFormat(i, RookPosition.Y, false));                    
            }
            return;
        }

        public void GetForward(ref List<string> stList)
        {
            for (int i = RookPosition.X + 1; i < 9;i++)
            {
                if (Board[i, RookPosition.Y] == 1)
                    return;
                else if (Board[i, RookPosition.Y] == 2)
                {
                    stList.Add(GetColFormat(i, RookPosition.Y, true));
                    return;
                }
                else
                    stList.Add(GetColFormat(i, RookPosition.Y, false));                    
            }
            return;
        }

        public void GetUp(ref List<string> stList)
        {

            for (int i = RookPosition.Y + 1; i < 9; i++)
            {
                if (Board[RookPosition.X, i] == 1)
                    return;
                else if (Board[RookPosition.X, i] == 2)
                {
                    stList.Add(GetColFormat(RookPosition.X, i, true));
                    return;
                }
                else
                    stList.Add(GetColFormat(RookPosition.X, i, false));                    
            }
            return;
        }

        public void GetDown(ref List<string> stList)
        {
            for (int i = RookPosition.Y - 1; i > 0; i--)
            {
                if (Board[RookPosition.X, i] == 1)
                    return;
                else if (Board[RookPosition.X, i] == 2)
                {
                    stList.Add(GetColFormat(RookPosition.X, i, true));
                    return;
                }
                else
                    stList.Add(GetColFormat(RookPosition.X, i, false));
            }
            return;
        }
        
        public List<string> GetMovements()
        {
            List<string> stList = new List<string>();
            GetBack(ref stList);
            GetDown(ref stList);
            GetUp(ref stList);
            GetForward(ref stList);

            return stList;
        }
    }

    public class RookPiece
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string OrigId { get; set; }

        public RookPiece(string OrigId)
        {
            this.OrigId = OrigId;
            this.X = ConvertLetterInt(OrigId);
            this.Y = Convert.ToInt32(OrigId.Substring(1, 1));
        }

        public static int ConvertLetterInt(string stInput)
        {
            return ConvertLetterInt(stInput.Substring(0, 1).ToCharArray()[0]);
        }

        public static int ConvertLetterInt(char stInput)
        {
            return (int)stInput - 96;
        }

        public static string getCharValue(int inPos)
        {
            var stRt = (char)(inPos + 96);
            return stRt.ToString();           
        }
    }

}
