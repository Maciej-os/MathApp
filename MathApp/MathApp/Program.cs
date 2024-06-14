using MathApp;


Test.Introduction();
var stringVer = new StringVerificator();

Console.WriteLine("Podaj swoje imię: ");
Console.WriteLine("------------------");
string name = stringVer.CleanWhiteMarks(Console.ReadLine());

if (name == "q" || name == "Q")
{

    return;
}

Console.WriteLine();
Console.WriteLine("Podaj swoje nazwisko: ");
Console.WriteLine("----------------------");
string surname = stringVer.CleanWhiteMarks(Console.ReadLine());

if (surname == "q" || name == "Q")
{

    return;
}

Console.WriteLine();
Console.WriteLine("Na jakich studiach jesteś?");
Console.WriteLine("---------------------------");
Console.WriteLine("1 - oznacza Studia DZIENNE");
Console.WriteLine("2 - oznacza Studia ZAOCZNE");

string studyTime = stringVer.CleanWhiteMarks(Console.ReadLine());
bool isValidAnswer = false;

do
{
    switch (studyTime)
    {
        case "1":
            {
                var student01 = new StudentFullTime(name, surname);
                student01.StartTest();
                isValidAnswer = true;
                break;
            }

        case "2":
            {
                var student01 = new StudentPartTime(name, surname);
                student01.StartTest();
                isValidAnswer = true;
                break;
            }
        case "q":
        case "Q":
            return;
        default:
            while (studyTime != "1" && studyTime != "2" && studyTime != "q" && studyTime != "Q")
            {
                Console.WriteLine("Wprowadź ponownie: ");
                studyTime = stringVer.CleanWhiteMarks(Console.ReadLine());
            }
            break;
    }
} while (!isValidAnswer);
