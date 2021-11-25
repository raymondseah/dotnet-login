namespace dotnet_login.Dtos
{
    public class ReadProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string PictureUrl { get; set; }
        // public int UserId { get; set; }
    }
}