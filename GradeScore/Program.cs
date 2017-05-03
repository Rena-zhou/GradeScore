using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace GradeScore
{
    public class Program
    {
        /// <summary>
        /// read file, transfer data format and then save into a List
        /// </summary>
        public static List<NameAndScore> ReadFileAndSaveIntoList(String filePath)
        {
            List<NameAndScore> listOfNameAndScore = new List<NameAndScore>();
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        NameAndScore nameAndScore = new NameAndScore();
                        String[] items = line.Split(',');
                        nameAndScore.FirstName = items[0];
                        nameAndScore.LastName = items[1];
                        nameAndScore.Score = Convert.ToInt32(items[2]);
                        listOfNameAndScore.Add(nameAndScore);
                    }
                }
              return listOfNameAndScore;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// bubble sort by score, last name and first name
        /// </summary>
        public static List<NameAndScore> SortByScoreAndName(List<NameAndScore> inputList)
        {
            if (inputList != null)
            {
                for (int i = 1; i < inputList.Count; i++)
                {
                    NameAndScore tmp;
                    for (int j = 0; j < inputList.Count - i; j++)
                    {
                        if (compareScoreAndName(inputList[j], inputList[j+1]))
                        {
                            tmp = inputList[j + 1];
                            inputList[j + 1] = inputList[j];
                            inputList[j] = tmp;
                        }
                    }
                }
            }
            return inputList;
        }

        /// <summary>
        /// Orders the names by their score. If scores are the same, order by their last name followed by
        //// first name
        /// </summary>
        public static Boolean compareScoreAndName(NameAndScore item1, NameAndScore item2)
        {
            return (item1.Score < item2.Score) || (item1.Score == item2.Score && string.Compare(item1.LastName, item2.LastName) < 0) || (item1.Score == item2.Score && string.Compare(item1.LastName, item2.LastName) == 0 && string.Compare(item1.FirstName, item2.FirstName) < 0);
        }

        /// <summary>
        /// write sorted result list into a file
        /// </summary>
        public static void WriteResultIntoFile(List<NameAndScore> sortedList)
        {
            try
            {
                System.IO.FileStream NewText = File.Create(@"D:\names-graded.txt");

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(NewText))
                {
                    sortedList.ForEach(line => sw.WriteLine(line.ToString()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Finished: created names-graded.txt");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            string path = args[0];

            List<NameAndScore> listOfNameAndScore = ReadFileAndSaveIntoList(path);
            List<NameAndScore> sortedListOfNameAndScore = SortByScoreAndName(listOfNameAndScore);
            if (sortedListOfNameAndScore != null)
            {
                sortedListOfNameAndScore.ForEach(item => Console.WriteLine(item.ToString()));
                WriteResultIntoFile(sortedListOfNameAndScore);
            }
            Console.ReadLine();
        }
    }
}
