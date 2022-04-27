using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsWeek4
{
    class Program
    {
        static void Main(string[] args)
        {
			UseStatistics();
			//В примере из файла ошибка.   Общий счётчик слов считает лишние пробелы и точки.
			//От этого общий счетчик слов в примере файла LAB_C_week_4 = 45. Фактических слов - 36.

			Console.Read();
		}
        private static void UseStatistics()
        {
			Dictionary<string, int> wordCount = new Dictionary<string, int> { };
			string supplem1 = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане" +
				" хранится В доме, Который построил Джек.А это веселая птица-синица, Которая часто ворует" +
				" пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";
			string[] supplem12 = supplem1.Split(new[] { ',', '.', ' ' });

			(string, int) WordAndCount;
			int totalWords = 0;
			foreach(string elem in supplem12)
            {
				if (elem != "")
				{
					if (wordCount.ContainsKey(elem))
					{
						WordAndCount.Item1 = elem;
						wordCount.TryGetValue(elem, out WordAndCount.Item2);
						WordAndCount.Item2++;
						wordCount.Remove(elem);
						wordCount.Add(WordAndCount.Item1, WordAndCount.Item2);
					}
					else
					{
						wordCount.Add(elem, 1);
					}
					totalWords++;
				}
			}
			int counterForLoop = 1;
            Console.WriteLine("\t\t\tWord:\t\tCount:");
			foreach(var val in wordCount)
            {
                Console.WriteLine($"{counterForLoop}.\t\t{val.Key}\t\t\t{val.Value}");
				counterForLoop++;
            }
            Console.WriteLine($"Total words: {totalWords}, from these unique: {wordCount.Count}");
		}
    }
}
