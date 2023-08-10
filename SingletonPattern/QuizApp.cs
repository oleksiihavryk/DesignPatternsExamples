using System.Globalization;

namespace SingletonPattern;
internal class QuizApp
{
    public const int LowerNumber = 1;
    public const int HigherNumber = 5;
    public const int NumbersCount = 10;
    public const int GuessedNumbersForWin = 5;

    private readonly Random _random = new Random();
    private readonly int[] _numbers = new int[NumbersCount];   

    public static readonly QuizApp Instance = new QuizApp();

    private QuizApp()
    {
        for (int i = 0; i < NumbersCount; i++)
            _numbers[i] = _random.Next(LowerNumber - 1, HigherNumber + 1);
    }

    public void Start()
    {
        StartMessage();
        
        Console.ReadKey();
        Console.Clear();

        var countOfRightAnswers = 0;
        for (int i = 1; i <= _numbers.Length; i++)
        {
            var userAnswer = GetUserAnswer(i);
            if (userAnswer == _numbers[i - 1]) countOfRightAnswers++;
        }

        Console.WriteLine(countOfRightAnswers >= GuessedNumbersForWin ? "You win!" : "You lose!");
        Console.WriteLine($"Your score is - {countOfRightAnswers}");
    }

    private void StartMessage()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Greeting you in the \"QuizApp\"!");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"You need to guess {GuessedNumbersForWin} of {NumbersCount} random number between {LowerNumber} and {HigherNumber}. " + Environment.NewLine +
                          "If you do it, you win!" + Environment.NewLine +
                          "Okay, for starting press any key!");
    }
    private int GetUserAnswer(int number)
    {
        var userNumber = 0;
        while (userNumber is < LowerNumber or > HigherNumber)
        {
            Console.WriteLine($"{number}. Your answer is - ");
            try
            {
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out var parsedInt))
                    userNumber = parsedInt;
            }
            catch (FormatException) { }
            Console.Clear();
        }
        return userNumber;
    }
}