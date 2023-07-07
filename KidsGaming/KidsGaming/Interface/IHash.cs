namespace KidsGaming.Interface
{
    public interface IHash
    {
        public string Hash(string pwd, string salt);

        public bool verify(string pwd,string hashedPwd, string salt);
    }
}
