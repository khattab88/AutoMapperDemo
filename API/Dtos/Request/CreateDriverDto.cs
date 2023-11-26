namespace API.Dtos.Request
{
    public class CreateDriverDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DriverNumber { get; set; }
        public int Trophies { get; set; }
    }
}
