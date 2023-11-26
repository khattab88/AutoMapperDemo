namespace API.Dtos.Response
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int DriverNumber { get; set; }
        public int Trophies { get; set; }
    }
}
