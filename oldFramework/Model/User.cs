namespace Framework
{
    class User
    {
        private string username;

        public User(string username)
        {
            this.username = username;
        }

        public string GetLogin()
        {
            return username;
        }
    }
}
