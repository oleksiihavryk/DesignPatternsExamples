using DecoratorPattern;

/*
 Pattern "Decorator" is simply change previous functionality
 and add some new to the class that has been "decorated".
 There is Notifier is prime object in system, with event inside of MessageReceiver.
*/
var notifier = new Notifier();
/*
 For adding new functionality we add decorator for that class.
 Decorator is the some sort of wrap of default object, which is allowed to use 
 previous stale configuration in system.
*/
var notifierDecorator = new ConsoleNotifierDecorator(notifier);
/*
 And because our decorator is inherit a default class of notifier, 
 we can replace notifier with our decorator.
 */
var messageReceiver = MessageReceiver.CreateReceiver(notifierDecorator);

messageReceiver.ReceiveMessage("Some very important message!");