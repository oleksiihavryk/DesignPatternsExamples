namespace ProtoPattern;
internal interface IPrototype<T> where T: class
{
    T Clone();
}