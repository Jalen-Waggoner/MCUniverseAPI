namespace MCUniverse.Services
{
    internal class AuthenticateResponse
    {
        private object student;
        private object jwtToken;
        private object value;

        public AuthenticateResponse(object student, object jwtToken, object value)
        {
            this.student = student;
            this.jwtToken = jwtToken;
            this.value = value;
        }
    }
}