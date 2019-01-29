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

        private string origLoc = "";
        private int currXPos;
        private int currYPos;


        public RookMovement(string position)
        {
            origLoc = position;

            currXPos = (int)position.Substring(0, 1).ToCharArray()[0] - 96;
            currYPos = Convert.ToInt32(position.Substring(1, 1));
        }

        public void AddPiece(int color, string location)
        {            
            var intX = (int)location.Substring(0, 1).ToCharArray()[0] - 96;
            var intY = Convert.ToInt32(location.Substring(1, 1));

            if ( intX == currXPos || intY == currYPos)
            {
                Board[intX, intY] = color + 1;
            }            
        }

        private string GetColFormat(int xPos, int yPos,bool capture)
        {
            var chReturn = "";

            chReturn = "R" + origLoc;
            chReturn += capture ? "x" : "-";
            chReturn += getCharValue(xPos) + yPos.ToString();

            return chReturn;
        }

        public string GetBack()
        {
            var chReturn = "";

            for (int i = currXPos - 1; i > 0; i--)
            {
                if (Board[i, currYPos] == 1)
                    return chReturn;
                else if (Board[i, currYPos] == 2)
                {
                    chReturn = GetColFormat(i, currYPos, true) + " " + chReturn;
                    return chReturn;
                }
                else
                    chReturn = GetColFormat(i, currYPos, false) + " " + chReturn;                
            }

            chReturn = chReturn.Trim(' ');
            return chReturn;
        }

        public string GetForward()
        {
            var chReturn = "";

            for (int i = currXPos + 1; i < 9;i++)
            {
                if (Board[i, currYPos] == 1)
                    return chReturn;
                else if (Board[i, currYPos] == 2)
                {
                    chReturn += " " + GetColFormat(i, currYPos, true);
                    return chReturn;
                }
                else
                    chReturn += " " + GetColFormat(i, currYPos, false);
            }
            chReturn = chReturn.Trim(' ');
            return chReturn;
        }

        public string GetUp()
        {
            var chReturn = "";

            for (int i = currYPos + 1; i < 9; i++)
            {
                if (Board[currXPos, i] == 1)
                    return chReturn;
                else if (Board[currXPos, i] == 2)
                {
                    chReturn += " " + GetColFormat(currXPos, i, true);
                    return chReturn;
                }
                else
                    chReturn += " " + GetColFormat(currXPos, i, false);
            }
            chReturn = chReturn.Trim(' ');
            return chReturn;
        }

        public string GetDown()
        {
            var chReturn = "";

            for (int i = currYPos - 1; i > 0; i--)
            {
                if (Board[currXPos, i] == 1)
                    return chReturn;
                else if (Board[currXPos, i] == 2)
                {
                    chReturn = GetColFormat(currXPos, i, true) + " " + chReturn;
                    return chReturn;
                }
                else
                    chReturn = GetColFormat(currXPos, i, false) + " " + chReturn;
            }
            chReturn = chReturn.Trim(' ');
            return chReturn;
        }


        private string getCharValue(int inPos)
        {
            switch (inPos)
            {
                case 1:
                    return "a";
                case 2:
                    return "b";
                case 3:
                    return "c";
                case 4:
                    return "d";
                case 5:
                    return "e";
                case 6:
                    return "f";
                case 7:
                    return "g";
                case 8:
                    return "h";                    
            }
            return "";

        }

        public string GetMovements()
        {
            var chReturn = "";
            chReturn = GetBack() + " " + GetDown() + " " + GetUp() + " " + GetForward();                      

            return chReturn;
        }

        

    }
}
