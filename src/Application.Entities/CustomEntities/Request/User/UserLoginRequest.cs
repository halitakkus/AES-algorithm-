namespace Application.Entities.CustomEntities.Request.User
{
    public class UserLoginRequest
    {
        /// <summary>
        /// Email alanı
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// şifre alanı
        /// </summary>
        public string Password { get; set; }
    }
}
