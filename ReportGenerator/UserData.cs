namespace ReportGenerator
{
    public class UserData
    {
        public UserData(bool isSpecial)
        {
            IsSpecial = isSpecial;
        }

        public bool IsSpecial { get; private set; }
    }
}