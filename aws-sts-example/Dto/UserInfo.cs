namespace aws_sts_example.Domain
{
    internal class UserInfo
    {
        public UserInfo()
        {
        }

        public UserInfo(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
