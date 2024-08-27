using System;
using System.IO;

namespace Birthday_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Projects\\C#\\Birthday_Finder\\Birthday_Finder\\pi.txt"; //use pi file
            string pi = File.ReadAllText(path); //beware exceptions
            int nplus1;
            int nplus2;
            string candidate;

            Dictionary<string, int> BirthDay3 = Make_Dic_3();
            Dictionary<string, int> BirthDay4 = Make_Dic_4();

            //Console.WriteLine($"{pi[102]}");

            for (int n = 1;n <= 99998;n++) //3digit - like 4/19, 3/01...
            {
                if (pi[n] != '0')
                {
                    nplus1 = pi[n+1] - '0';
                    if (nplus1 < 4)
                    {
                        candidate = $"{pi[n]}{pi[n + 1]}{pi[n + 2]}";

                        if (BirthDay3.ContainsKey(candidate) && BirthDay3[candidate] == 0)
                        {
                            BirthDay3[candidate] = n;
                        }
                    }
                }
            }

            for (int n = 1;n <= 99997;n++) //4digit - like 12/25,10/09...
            {
                if (pi[n] == '1')
                {
                    nplus1 = pi[n + 1] - '0';
                    if (nplus1 < 3)
                    {
                        nplus2 = pi[n + 2] - '0';
                        if (nplus2 < 4)
                        {
                            candidate = $"{pi[n]}{pi[n + 1]}{pi[n + 2]}{pi[n + 3]}";

                            if (BirthDay4.ContainsKey(candidate) && BirthDay4[candidate] == 0)
                            {
                                BirthDay4[candidate] = n;
                            }
                        }
                    }
                }
            }

            for (int i = 0;i < 273;i++)
            {
                Console.WriteLine($"{BirthDay3.ElementAt(i).Key}: {BirthDay3.ElementAt(i).Value}");
            }
            for (int i = 0; i < 92; i++)
            {
                Console.WriteLine($"{BirthDay4.ElementAt(i).Key}: {BirthDay4.ElementAt(i).Value}");
            }

            Console.ReadKey();
        }

        static Dictionary<string,int> Make_Dic_3()
        {
            int[] dates = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30};

            Dictionary<string,int> BirthDay3 = new Dictionary<string,int>();

            for (int i = 1; i <= 9;i++)
            {
                for (int j = 1;j <= dates[i];j++)
                {
                    if (j < 10)
                    {
                        BirthDay3.Add($"{i}0{j}", 0);
                    }
                    else
                    {
                        BirthDay3.Add($"{i}{j}", 0);
                    }
                }
            }

            return BirthDay3;
        }

        static Dictionary<string, int> Make_Dic_4()
        {
            int[] dates = { 31, 30, 31 };

            Dictionary<string, int> BirthDay4 = new Dictionary<string,int>();

            for (int i = 0;i < 3;i++)
            {
                for (int j = 1;j <= dates[i];j++)
                {
                    if (j < 10)
                    {
                        BirthDay4.Add($"{i+10}0{j}", 0);
                    }
                    else
                    {
                        BirthDay4.Add($"{i+10}{j}", 0);
                    }
                }
            }

            return BirthDay4;
        }
    }
}
