using System;
using System.Collections.Generic;



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
            stMessage = GetOffsetString(true, stMessage);

            for (int x = 0; x < dRotars.Count; x++)
            {
                char[] stInput = stMessage.ToCharArray();
                var stConsolidate = "";
                for (int i = 0; i < stInput.Length; i++)
                {
                    int inArryPos = (int)stInput[i] - 65;
                    stConsolidate += dRotars[x][inArryPos];
                }
                stMessage = stConsolidate;               
            }
            stAnswer = stMessage;

            return stAnswer;
        }

        public string DecodeMessage(string stMessage)
        {
            var stAnswer = "";
            var stCurr = "";

            for (var x = this.dRotars.Count - 1;x >= 0; x--)
            {                
                for(int i = 0;i < stMessage.Length;i++)
                {
                    stCurr += GetCharacterinRotar(stMessage[i], x);
                }
                stMessage = stCurr;
                stCurr = "";
            }
            
            stAnswer = GetOffsetString(false, stMessage);
            
            return stAnswer;
        }

        private char GetCharacterinRotar(char chChar, int inRotar)
        {
            var chReturn = ' ';
            for (var i = 0; i < this.dRotars[inRotar].Length;i++)
                if (chChar == this.dRotars[inRotar][i])
                    chReturn = (char)(i + 65);
                
            return chReturn;
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
                    stReturnChar += stGetChar(currChar, (inStartNum * -1), (inCount * -1));                

                inCount += 1;
            }
            return stReturnChar;
        }

        private char stGetChar(char chChar,int inStartNum, int inCount)
        {
            int intNum = (int)chChar - 65 + inStartNum + inCount;

            if (intNum < 0)
            {
                intNum = Math.Abs(intNum) % 26;
                return (char)(91 - intNum);                
            }
            else
            {
                intNum = intNum % 26;
                return (char)(intNum + 65);
            }                                        
        }

    }
}
