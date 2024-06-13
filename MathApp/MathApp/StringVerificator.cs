namespace MathApp
{
    public class StringVerificator()
    {
        public string CleanWhiteMarks(string input)
        {
            while (String.IsNullOrEmpty(input.Trim()))
            {
                Console.WriteLine("Wprowadź ponownie: ");
                input = Console.ReadLine();

            }
            return input.Trim();
        }
    }
              
}
