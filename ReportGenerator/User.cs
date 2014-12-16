namespace ReportGenerator
{
    public class User
    {
        public string Email { get; set; }

        public string Name { get; set; }

        protected bool Equals(User other)
        {
            return string.Equals(Email, other.Email) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Email != null ? Email.GetHashCode() : 0)*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}