namespace PrototypeHomework.Entity;

/// <summary>
/// Кошка
/// </summary>
public sealed class Cat : Pet, IEquatable<Cat>, IMyCloneable<Cat>
{
    /// <summary>
    /// Короткошерстность
    /// </summary>
    public bool IsShorthaired { get; private set; }

    /// <summary>
    /// Вислоухость
    /// </summary>
    public bool IsLopEared { get; private set; }

    public Cat(Guid id, string breed, string name, Sex sex, Owner owner, bool isShorthaired, bool isLopEared)
        : base(id, breed, name, sex, owner)
    {
        IsShorthaired = isShorthaired;
        IsLopEared = isLopEared;
    }

    public bool Equals(Cat other)
    {
        if (other is null) return false;

        bool isOwnerEquals = Owner is null ? other.Owner is null : Owner.Equals(other.Owner);

        return Id == other.Id &&
               Name == other.Name &&
               Breed == other.Breed &&
               Sex == other.Sex &&
               IsLopEared == other.IsLopEared &&
               IsShorthaired == other.IsShorthaired &&
               isOwnerEquals;
    }

    public override bool Equals(object obj) => Equals(obj as Cat);

    public override int GetHashCode() => 
        Id.GetHashCode() ^ Name.GetHashCode() ^ Breed.GetHashCode() ^ Sex.GetHashCode() ^ IsLopEared.GetHashCode() ^ IsShorthaired.GetHashCode() ^ Owner.GetHashCode();

    public Cat CloneEntity()
    {
        Owner owner = Owner?.CloneEntity();

        return new Cat(Id, Breed, Name, Sex, owner, IsShorthaired, IsLopEared);
    }

    public override object Clone()
    {
        var clone = base.Clone() as Cat;
        clone.IsShorthaired = IsShorthaired;
        clone.IsLopEared = IsLopEared;

        return clone;
    }

    public override string ToString() => 
        $"Cat: Id = {Id}, Breed = {Breed}, Name = {Name}, Sex = {Sex}, Owner = {Owner}, IsShorthaired = {IsShorthaired}, IsLopEared = {IsLopEared}";
}
