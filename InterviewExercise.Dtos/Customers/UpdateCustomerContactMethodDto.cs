namespace InterviewExercise.Dtos.Customers
{
    public class UpdateCustomerContactMethodDto: DtoBase
    {
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
    }
}
