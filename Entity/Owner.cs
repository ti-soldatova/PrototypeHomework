namespace PrototypeHomework.Entity;

/// <summary>
/// Хозяин питомца
/// </summary>
public sealed class Owner : Person, IEquatable<Owner>, IMyCloneable<Owner>
{
    public Owner(Guid id, string name, Sex sex)
        : base(id, name, sex)
    { }

    public bool Equals(Owner other)
    => other != null &&
       Id == other.Id &&
       Name == other.Name &&
       Sex == other.Sex;

    public override bool Equals(object obj) => Equals(obj as Owner);

    public override int GetHashCode() => Id.GetHashCode() ^ Name.GetHashCode() ^ Sex.GetHashCode();

    public new Owner CloneEntity() => new(Id, Name, Sex);

    public override string ToString() => $"Owner: Id = {Id}, Name = {Name}, Sex = {Sex}";
}
