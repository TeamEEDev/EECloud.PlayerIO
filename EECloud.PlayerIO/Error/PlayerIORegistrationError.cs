namespace EECloud.PlayerIO
{
    public class PlayerIORegistrationError : PlayerIOError
    {
        public string CaptchaError
        {
            get;
            private set;
        }

        public string EmailError
        {
            get;
            private set;
        }

        public string PasswordError
        {
            get;
            private set;
        }

        public string UsernameError
        {
            get;
            private set;
        }

        public PlayerIORegistrationError(ErrorCode errorCode, string message, string usernameError, string passwordError, string emailError, string captchaError) : base(errorCode, message)
        {
            UsernameError = usernameError;
            PasswordError = passwordError;
            EmailError = emailError;
            CaptchaError = captchaError;
        }
    }
}
