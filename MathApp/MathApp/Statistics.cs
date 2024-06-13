namespace MathApp
{
    public class Statistics
    {

        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }
                
        public float Avg
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public char AvgLetter
        {
            get
            {
                switch (this.Avg)
                {
                    case var avg when avg >= 2.4f:
                        return 'A';
                    case var avg when avg >= 2.0f:
                        return 'B';
                    case var avg when avg >= 1.5f:
                        return 'C';
                    case var avg when avg >= 1.0f:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = int.MaxValue;
            this.Max = int.MinValue;
        }

        public void AddGrade(int grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);

        }

        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);

        }

    }
}
