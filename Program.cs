using System;
using graphics.game;
using OpenTK.Windowing.Desktop;

class Program
{
    static void Main(string[] args)
    {
        using (Game game = new Game(1024, 768, "Test Window")) {
            game.Run();
        }
    }
}