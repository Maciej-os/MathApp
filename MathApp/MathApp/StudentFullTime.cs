namespace MathApp
{
    public class StudentFullTime: StudentBase
    {
        public StudentFullTime(string name, string surname) : base(name, surname)
        {

        }

        public override void StartTest()
        {
            var test01 = new Test(this.Name, this.Surname);
            test01.TestPerform(4);
        }        
    }
}
