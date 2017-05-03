using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeScore
{
    /*
    * the class represents the data of one line in the text file 
    */
    public class NameAndScore
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }

        public NameAndScore()
        {

        }

        public NameAndScore(String firstName, String lastName, int score)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = score;
        }

        override public String ToString()
        {
            string returnStr = FirstName.ToString() + "," + LastName.ToString() + "," + Score.ToString();
            return returnStr;
        }

        public override bool Equals(object obj)
        {
            var other = obj as NameAndScore;
            if (other == null)
            {
                return false;
            }
            return FirstName == other.FirstName && LastName == other.LastName && Score == other.Score;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
