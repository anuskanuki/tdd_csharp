
namespace Application.Domain.AuctionFolder
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public User(string name) : this(0, name)
        {
        }

        public User(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != obj.GetType())
            {
                return false;
            }

            User otheruser = (User)obj;

            return otheruser.Id == this.Id && otheruser.Name.Equals(this.Name);
        }
    }
}
