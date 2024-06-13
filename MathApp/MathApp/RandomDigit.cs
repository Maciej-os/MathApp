namespace MathApp
{    
    public class RandomDigit
    {
        public RandomDigit()
        {
            
        }
        public int DigitGenerator(int minDigit, int maxDigit)
        {
            Random rand = new Random();
            int randomDigit = rand.Next(minDigit, maxDigit + 1);
            return randomDigit;
        }
    }

    
}
