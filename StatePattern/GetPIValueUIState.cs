namespace StatePattern;
internal class GetPIValueUIState : IUIState
{
    public IUIState GetNext()
    {
        IUIState? next = null;
        do
        {
            Console.Clear();
            Console.WriteLine("--------Get PI--------" + Environment.NewLine +
                              $"PI - {Math.PI}" + Environment.NewLine +
                              "1.Exit");

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
                1 => new MainUIState(),
                _ => null
            };
        }
        while (next is null);

        return next;
    }
}