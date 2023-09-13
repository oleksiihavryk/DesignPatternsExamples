using System.Diagnostics;

namespace StatePattern;
internal class MainUIState : IUIState
{
    public IUIState GetNext()
    {
        IUIState? next = null;
        do
        {
            Console.Clear();
            Console.WriteLine("------Main menu------" + Environment.NewLine +
                              "1.Get random numbers." + Environment.NewLine +
                              "2.Get PI value." + Environment.NewLine +
                              "3.Exit.");

            int answer;
            
            try
            {
                var s = Console.ReadLine() ?? string.Empty;
                answer = int.Parse(s);
            }
            catch
            {
                continue;
            }

            next = answer switch
            {
                1 => new GetRandomNumbersUIState(),
                2 => new GetPIValueUIState(),
                3 => new ExitUIState(),
                _ => null
            };
        }
        while (next is null);

        return next;
    }
}