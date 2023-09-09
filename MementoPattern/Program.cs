/*
 * The Memento pattern allows to the client extract a snapshot of the object and apply
 * this snapshot to an object at any stage of execution.
 * In most use cases of the memento pattern it is a crucial part of a "history" mechanism.
 */

using MementoPattern;

var ns = new NumbersStorage(new[] { 1, 2, 3 });
var history = new History(ns);

Console.WriteLine("Collection as created");
Show(ns);

Separator();

Console.WriteLine("Add 4");
ns.Add(4);
history.MakeSave();
Show(ns);

Separator();

Console.WriteLine("Add 5");
ns.Add(5);
history.MakeSave();
Show(ns);

Separator();

Console.WriteLine("Add 6");
ns.Add(6);
history.MakeSave();
Show(ns);

Separator();

Console.WriteLine("Previous save");
history.Back();
Show(ns);

Separator();

Console.WriteLine("Previous save");
history.Back();
Show(ns);

Separator();

Console.WriteLine("Next save");
history.Forward();
Show(ns);

Separator();

Console.WriteLine("Add 100");
ns.Add(100);
history.MakeSave();
Show(ns);





void Show<T>(ICollection<T> coll)
{
    Console.WriteLine($"Number collection: " +
                      $"{string.Join(", ", coll.Select(i => i.ToString()))}");
}
void Separator() => Console.WriteLine(Environment.NewLine + Environment.NewLine);

    