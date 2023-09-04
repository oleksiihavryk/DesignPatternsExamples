namespace FlyweightPattern;
internal class MapViewer
{
    private readonly Map _map;

    public MapViewer(Map map)
    {
        _map = map;
    }

    public void Show()
    {
        for (int i = 0; i < _map.Particles.GetLength(0); i++)
        {
            for (int j = 0; j < _map.Particles.GetLength(1); j++)
            {
                var part = _map.Particles[i, j];
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = part.Info.Color;
                Console.Write(part.Info.Character);
                Console.ForegroundColor = prev;
            }
            Console.WriteLine();
        }
    }
}