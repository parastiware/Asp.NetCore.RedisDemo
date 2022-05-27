namespace RedisTest.Models
{
    public class KycFormPart1
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string DOBNepali { get; set; }
    }

    public class KycFormPart2
    {
        public string ParmanentAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string IdType { get; set; }

    }

    public class KycForm
    {
        public KycFormPart1 Part1 { get; set; }
        public KycFormPart2 Part2 { get; set; }
    }
}

  
    