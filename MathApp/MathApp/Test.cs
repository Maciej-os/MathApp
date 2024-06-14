using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MathApp
{
    public class Test
    {
        public Test(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int DigitOne { get; private set; }

        public int DigitTwo { get; private set; }

        public int ChanceCounter { get; private set; }

        public string FileName
        {
            get
            {
                return this.FileName = $"C:\\Raports\\{this.Name}_{this.Surname}_points.txt";
            }
            private set { }
        }

        public List<float> pointsInMemory = new List<float>();

        public static void Introduction()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("Witaj na teście z matematyki! Odpowiedz na poniższe pytania w najkrótyczm czasie!");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("-------ABY ZATRZYMAĆ PROGRAM WPROWADŹ Q LUB q ZAMIAST ODPOWIEDZI-----------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public void TestPerform(int number)
        {

            for (int i = 0; i < number; i++)
            {
                var answer = Run();
                bool isValidInput = false;
                this.ChanceCounter = 1;
                int studentPoints = 0;
                do
                {
                    try
                    {
                        AnswerAnalysis(answer);
                        studentPoints = AnswerPoints(this.ChanceCounter);
                        if (studentPoints == -1)
                        {
                            return;
                        }
                        isValidInput = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Spróbuj jeszcze raz...");
                        answer = Console.ReadLine();
                    }
                } while (!isValidInput);

                RecordPoints(studentPoints);
                this.pointsInMemory.Add(studentPoints);
                Console.WriteLine($"Uzyskałeś punktów: {studentPoints}");
                Console.WriteLine("----------------------");
                
            }

            var statistics = this.GetFileStatistics();
            Console.WriteLine();
            Console.WriteLine($"Wszystkie wyniki studenta {this.Name} {this.Surname} zdobyte do tej pory:");
            Console.WriteLine();
            Console.WriteLine($"Średnia: {statistics.Avg:N2}");
            Console.WriteLine($"Min: {statistics.Min}");
            Console.WriteLine($"Max: {statistics.Max}");
            Console.WriteLine($"Ocena: {statistics.AvgLetter}");

            statistics = this.GetMemoryStatistics();
            Console.WriteLine();
            Console.WriteLine($"Wyniki studenta {this.Name} {this.Surname} tylko z ostatniego testu");
            Console.WriteLine();
            Console.WriteLine($"Średnia: {statistics.Avg:N2}");
            Console.WriteLine($"Min: {statistics.Min}");
            Console.WriteLine($"Max: {statistics.Max}");
            Console.WriteLine($"Ocena: {statistics.AvgLetter}");


        }

        public string Run()
        {
            var rand = new RandomDigit();

            this.DigitOne = rand.DigitGenerator(0, 9);
            this.DigitTwo = rand.DigitGenerator(1, 9);

            Console.WriteLine();
            Console.WriteLine("Ile jest:");
            Console.WriteLine($"{this.DigitOne} * {this.DigitTwo} = ");

            return Console.ReadLine();

        }

        public void AnswerAnalysis(string answer)
        {
            int correctResult = this.DigitOne * this.DigitTwo;
            int number;
            bool isValidAnswer = false;

            while (!isValidAnswer)
            {
                if (int.TryParse(answer, out number))//czy jest to liczba?
                {
                    if (number == correctResult)//czy liczba jest poprawna?
                    {
                        isValidAnswer = true;
                        break;
                    }
                    this.ChanceCounter++;
                    Console.WriteLine("Niewłaściwa odpowiedź! Zastanów się jeszcze raz...");


                }
                else
                {
                    answer = answer.Trim();
                    if (answer == "q" || answer == "Q")//czy jest to wyjście?
                    {
                        this.ChanceCounter = -1;
                        return;
                    }
                    this.ChanceCounter++;
                    throw new Exception("Wprowadzono niewłaściwą wartość");
                }

                answer = Console.ReadLine();
            }

            Console.WriteLine("----------------------");
            Console.WriteLine("GRATULACJE!!!");

            ;

        }

        public int AnswerPoints(int chanceCounter)
        {
            switch (chanceCounter)
            {
                case var a when a >= 4:
                    return 0;
                case var a when a >= 2:
                    return 1;
                case var a when a >= 1:
                    return 3;
                default:
                    return -1;
            }
        }

        public void RecordPoints(int studentPoints)
        {

            if (studentPoints >= 0)
            {
                using (var writer = File.AppendText(this.FileName))
                {
                    writer.WriteLine(studentPoints);
                }

            }
        }
        public Statistics GetFileStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(this.FileName))
            {
                int lineCounter = 0;
                using (var reader = File.OpenText(this.FileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        lineCounter++;
                        if (int.TryParse(line, out int number))
                        {
                            statistics.AddGrade(number);
                        }
                        else

                        {
                            if (float.TryParse(line, out float numberFloat))
                            {
                                statistics.AddGrade(numberFloat);
                            }
                            else
                            {

                                Console.WriteLine();
                                Console.WriteLine($"Line nr {lineCounter} in file: {this.FileName} was omitted");
                                Console.WriteLine($"Line nr {lineCounter} does not contain number");

                            }
                        }
                        line = reader.ReadLine();

                    }
                }
            }
            return statistics;
        }

        public Statistics GetMemoryStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.pointsInMemory)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}