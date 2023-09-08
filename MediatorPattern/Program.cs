using MediatorPattern;

/*
 * In most use cases the Mediator using for remove direct dependencies from other interfaces
 * and rework classes for use only one unified interface for all dependent classes - mediator.
*/

//In this example class Messenger and his interface IMessenger is the Mediator pattern.
var messenger = new Messenger();
var user1 = User.RegisterUser(messenger, "Pacific");
var user2 = User.RegisterUser(messenger, "PRev");

/*
 * As you can see instead of having dependencies from IUserRepository, IMessageRepository
 * and ILogger and using bunch of methods from this dependencies in SendMessageTo method a user
 * only have dependency to mediator and use only one method from this mediator.
 * This is the most powerful side of mediator pattern.
*/
user1.SendMessageTo(user2, "I love burgers");
void Separator() => Console.WriteLine("-------------------------");
foreach (var m in user2.ReceivedMessages)
{
    Separator();
    Console.WriteLine($"" +
                      $"From [{m.From.Username}] To [{m.To.Username}] | " +
                      $"{m.Text} ({TimeOnly.FromDateTime(m.Date)})");
    Separator();
}

messenger.DeleteUser(user1);
messenger.DeleteUser(user2);

//

