namespace PrototypeHomework;

public interface IMyCloneable<out T> where T : class
{
    T CloneEntity();
}