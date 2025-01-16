namespace Music_App.Models
{
    public abstract class Entity<T>
        where T : struct
    {
        public T Id { get; set; }
    }
}
