namespace MathApp
{
    public abstract class StudentBase : IStudent
    {
        public delegate void TestCompletedDelegate(object sender, EventArgs args);
       
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
     
        }
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void StartTest();
    }
}
