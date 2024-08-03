namespace PrototypeHomework.Entity;

/// <summary>
/// Человек
/// </summary>
public class Person : IMyCloneable<Person>, ICloneable
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Пол
    /// </summary>
    public Sex Sex { get; }

    public Person(Guid id, string name, Sex sex)
    {
        Id = id;
        Name = name;
        Sex = sex;
    }

    public Person CloneEntity() => new(Id, Name, Sex);

    public virtual object Clone() => MemberwiseClone();

    public override string ToString() => $"Person: Id = {Id}, Name = {Name}, Sex = {Sex}";
}
