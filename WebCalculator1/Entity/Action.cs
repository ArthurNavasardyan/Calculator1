namespace WebCalculator1.Entity
{
    public class Action
    {
       
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public double FirstNumber { get; set; }
                
        public string MathAction { get; set; } = string.Empty;

        public double SecondNumber { get; set; }

        public double Result { get; set; }


    }
}
