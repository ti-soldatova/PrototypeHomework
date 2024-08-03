using PrototypeHomework.Entity;

namespace PrototypeHomework;

internal static class Test
{
    public static void CatClone()
    {
        // Простое копирование
        Console.WriteLine("----Simple cat cloning---");

        Cat cat = new(Guid.NewGuid(), "street", "Murka", Sex.Woman, null, false, false);
        Cat catEntityClone = cat.CloneEntity();
        Cat catClone = cat.Clone() as Cat;

        CheckClonesEquals(cat, catEntityClone, true);
        CheckClonesEquals(cat, catClone, false);

        // Глубокое копирование
        Console.WriteLine("----Deep cat cloning---");

        Owner owner = new(Guid.NewGuid(), "Good Man", Sex.Man);
        cat.SetOwner(owner);
        catEntityClone = cat.CloneEntity();
        catClone = cat.Clone() as Cat;

        CheckClonesEquals(cat, catEntityClone, true);
        CheckClonesEquals(cat, catClone, false);
    }

    public static void DogClone()
    {
        // Простое копирование
        Console.WriteLine("----Simple dog cloning---");

        Dog dog = new(Guid.NewGuid(), "Dalmatian", "Sharik", Sex.Man, null, true, false);
        Dog dogEntityClone = dog.CloneEntity();
        Dog dogClone = dog.Clone() as Dog;

        CheckClonesEquals(dog, dogEntityClone, true);
        CheckClonesEquals(dog, dogClone, false);

        // Глубокое копирование
        Console.WriteLine("----Deep dog cloning---");

        Owner owner = new(Guid.NewGuid(), "Good Man", Sex.Man);
        dog.SetOwner(owner);
        dogEntityClone = dog.CloneEntity();
        dogClone = dog.Clone() as Dog;

        CheckClonesEquals(dog, dogEntityClone, true);
        CheckClonesEquals(dog, dogClone, false);
    }

    private static void CheckClonesEquals(Pet pet, Pet petClone, bool isMyCloning)
    {
        Console.WriteLine(isMyCloning ? "IMyCloneable" : "ICloneable");

        Console.WriteLine(pet);
        
        bool isEquals = pet.Equals(petClone);
        bool isReferenceEquals = pet.ReferenceEquals(petClone);

        Console.WriteLine($"Равенство по значению: {isEquals}");
        Console.WriteLine($"Равенство по ссылке: {isReferenceEquals}");
        Console.WriteLine();
    }
}
