namespace MathApp
{
    public class StudentPartTime : StudentBase
    {
        public StudentPartTime(string name, string surname) : base(name, surname) 
        {

            
        }

        public override void StartTest()
        {
            var test01 = new Test(this.Name, this.Surname);
            test01.TestPerform(2);
           
        }

    }
}
