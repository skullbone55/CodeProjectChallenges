using System;
using System.Linq;

namespace CodeProjectChallenges
{
    public class DigitalRiver
    {
        //Digital River 1
        //https://www.codingame.com/ide/puzzle/the-river-i-


        public static long GetMeetingPoint(long lgInputRiver1, long lgInputRiver2)
        {            
            if (lgInputRiver1 == lgInputRiver2)
                return lgInputRiver1;
                        
            do
            {
                if(lgInputRiver1 > lgInputRiver2)
                    lgInputRiver2 = GetNextSequence(lgInputRiver2);
                else
                    lgInputRiver1 = GetNextSequence(lgInputRiver1);

            } while (lgInputRiver1 != lgInputRiver2);
            
            return lgInputRiver1;
        }

        private static long GetNextSequence(long lgNumber)
        {
            var arNumber = lgNumber.ToString().ToArray();
            var inTotal = 0;
            foreach (var currNum in arNumber)
                inTotal += Convert.ToInt32(currNum.ToString());

            return lgNumber + inTotal;
        }

                
        //Idea taken from Top Solution:
        //Keep dividing by 10 taking the remainder. Better than string manipulation.    
        public static long BetterGetMeetingPoint(long lgInputRiver1, long lgInputRiver2)
        {
            if (lgInputRiver1 == lgInputRiver2)
                return lgInputRiver1;

            do
            {
                if (lgInputRiver1 > lgInputRiver2)
                    lgInputRiver2 += BetterNextSequence(lgInputRiver2);
                else
                    lgInputRiver1 += BetterNextSequence(lgInputRiver1);

            } while (lgInputRiver1 != lgInputRiver2);

            return lgInputRiver1;
        }

        private static long BetterNextSequence(long lgNumber)
        {
            
            long lgReturn = 0;
            while(lgNumber != 0)
            {
                lgReturn += lgNumber % 10;
                lgNumber /= 10;
            }

            return lgReturn;
        }
    }
}
