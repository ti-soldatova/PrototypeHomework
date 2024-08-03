namespace PrototypeHomework.Entity;

/// <summary>
/// Собака
/// </summary>
public sealed class Dog : Pet, IEquatable<Dog>, IMyCloneable<Dog>
{
    /// <summary>
    /// Короткошерстность
    /// </summary>
    public bool IsShorthaired { get; private set; }

    /// <summary>
    /// Обрезан ли хвост
    /// </summary>
    public bool IsBobtail { get; private set; }

    public Dog(Guid id, string breed, string name, Sex sex, Owner owner, bool isShorthaired, bool isBobtail)
        : base(id, breed, name, sex, owner)
    {
        IsShorthaired = isShorthaired;
        IsBobtail = isBobtail;
    }

    public bool Equals(Dog other)
    {
        if (other is null) return false;

        bool isOwnerEquals = Owner is null ? other.Owner is null : Owner.Equals(other.Owner);

        return Id == other.Id &&
               Name == other.Name &&
               Breed == other.Breed &&
               Sex == other.Sex &&
               IsShorthaired == other.IsShorthaired &&
               IsBobtail == other.IsBobtail &&
               isOwnerEquals;
    }

    public override bool Equals(object obj) => Equals(obj as Dog);

    public override int GetHashCode() =>
        Id.GetHashCode() ^ Name.GetHashCode() ^ Breed.GetHashCode() ^ Sex.GetHashCode() ^ 
        IsShorthaired.GetHashCode() ^ IsBobtail.GetHashCode() ^ Owner.GetHashCode();

    public Dog CloneEntity()
    {
        Owner owner = Owner?.CloneEntity();

        return new Dog(Id, Breed, Name, Sex, owner, IsShorthaired, IsBobtail);
    }

    public override object Clone()
    {
        var clone = base.Clone() as Dog;
        clone.IsShorthaired = IsShorthaired;
        clone.IsBobtail = IsBobtail;

        return clone;
    }

    public override string ToString() =>
        $"Dog: Id = {Id}, Breed = {Breed}, Name = {Name}, Sex = {Sex}, Owner = {Owner}, IsShorthaired = {IsShorthaired}, IsBobtail = {IsBobtail}";
}
