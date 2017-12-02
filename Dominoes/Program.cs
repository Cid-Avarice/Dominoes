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
            // Hey monkey!
            // Hey there!


            // I am ascending - Dardars 12/2/17

            //What a great time!


            // What a great time!

            using (var game = new Game1())
                game.Run();
        }
    }
}
