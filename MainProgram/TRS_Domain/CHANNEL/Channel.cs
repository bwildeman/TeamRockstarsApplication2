namespace TRS_Domain.CHANNEL
{
    public abstract class Channel
    {
        public int Id;
        public string Name;
        public string Description;

        protected Channel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}