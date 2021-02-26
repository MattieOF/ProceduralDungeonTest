using System;
using PDT;

namespace PDTDesktop
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ProceduralDungeonTest())
                game.Run();
        }
    }
}
