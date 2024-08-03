namespace PrototypeHomework.Entity;

/// <summary>
/// Абстрактный класс Питомец
/// </summary>
public abstract class Pet : ICloneable
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Порода
    /// </summary>
    public string Breed { get; }

    /// <summary>
    /// Кличка
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Пол
    /// </summary>
    public Sex Sex { get; }

    /// <summary>
    /// Хозяин
    /// </summary>
    public Owner Owner { get; private set; }

    protected Pet(Guid id, string breed, string name, Sex sex, Owner owner)
    {
        Id = id;
        Breed = breed;
        Name = name;
        Sex = sex;
        Owner = owner;
    }

    /// <summary>
    /// Дать имя
    /// </summary>
    /// <param name="name">Имя</param>
    public void SetName(string name)
    {
        Name = name; 
    }

    /// <summary>
    /// Задать хозяина
    /// </summary>
    /// <param name="owner">Хозяин</param>
    public void SetOwner(Owner owner)
    {
        Owner = owner;
    }

    public virtual object Clone() => MemberwiseClone();

    public override string ToString() => $"Pet: Id = {Id}, Breed = {Breed}, Name = {Name}, Sex = {Sex}, Owner = {Owner}";

    public bool ReferenceEquals(Pet other) => ReferenceEquals(Owner, other.Owner) || ReferenceEquals(this, other);
}
