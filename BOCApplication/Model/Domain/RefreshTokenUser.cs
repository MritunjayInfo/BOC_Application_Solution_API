namespace BOCApplication.Model.Domain
{
    public class RefreshTokenUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public User User { get; set; }
    }
}
