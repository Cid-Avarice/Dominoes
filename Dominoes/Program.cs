using System;

namespace Dominoes
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Hey there!
            //What a great time!
            using (var game = new Game1())
                game.Run();
        }
    }
}
