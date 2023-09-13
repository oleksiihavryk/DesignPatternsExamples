namespace StatePattern;
internal class GetRandomNumbersUIState : IUIState
{
    public IUIState GetNext()
    {
        IUIState? next = null;
        var numbers = GetRandomNumbers();
        do
        {
            Console.Clear();
            Console.WriteLine("--------Random numbers--------" + Environment.NewLine +
                              $"Random numbers - {string.Join(", ", numbers)}" + Environment.NewLine +
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

    private int[] GetRandomNumbers()
    {
        var numbers = new int[5];
        int i = numbers.Length;
        while (i --> 0)
        {
            numbers[i] = Random.Shared.Next(0, 9);
        }
        return numbers;
    }
}