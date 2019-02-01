using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProjectChallenges
{
    public class EnigmaMachine
    {
        //Encryption/Decryption of Enigma Machine
        //https://www.codingame.com/ide/puzzle/encryptiondecryption-of-enigma-machine/

        int inStartNum;
        Dictionary<int, char[]> dRotars;

        public EnigmaMachine(int StartNum, Dictionary<int, string> Rotars)
        {

            this.inStartNum = StartNum;
            dRotars = new Dictionary<int, char[]>();
            foreach (var currRotar in Rotars)
                this.dRotars.Add(currRotar.Key, currRotar.Value.ToCharArray());
            
        }

        public string EncodeMessage(string stMessage)
        {
            var stAnswer = "";
            var NewString = GetOffsetString(true, stMessage);

            for(int x = 0; x < dRotars.Count; x++)
            {
                NewString = stGetNewString(NewString,x);
                
            }
            stAnswer = NewString.ToString();

            return stAnswer;
        }

        public string DecodeMessage(string stMessage)
        {
            var stAnswer = "";            

            return stAnswer;
        }

        public string GetOffsetString(bool stEncode, string chOrig)
        {
            var stReturnChar = "";
            var arChar = chOrig.ToCharArray();
            var inCount = 0;
            foreach(var currChar in arChar)
            {
                if (stEncode)
                    stReturnChar += stGetChar(currChar, inStartNum, inCount);                                   
                else
                    stReturnChar += stGetChar(currChar, (inStartNum * -1), inCount);                

                inCount += 1;
            }
            return stReturnChar;
        }
        private char stGetChar(char chChar,int inStartNum, int inCount)
        {
            int intNum = (int)chChar - 65 + inStartNum + inCount;
            intNum = intNum % 26;
            
            return (char)(intNum + 65);
        }

        private string stGetNewString(string stMessage,int inRotar)
        {
            var stReturn = "";
            char[] stInput = stMessage.ToCharArray();

            for (int i = 0; i < stInput.Length; i++)
            {
                stReturn += GetNewChar(stInput[i], inRotar);
            }
            return stReturn;
        }

        private char GetNewChar(char chOrigChar,int inRoaterNum)
        {
            int inArryPos = (int)chOrigChar - 65;
            var te = dRotars[inRoaterNum];

            return dRotars[inRoaterNum][inArryPos];
        }
    }
}
