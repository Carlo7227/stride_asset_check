using Stride.Engine;

namespace MyGame
{
    class MyGameApp
    {
        static void Main(string[] args)
        {
            try
            {
                using (var game = new Game())
                {
                    game.Run();
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                System.Console.ReadLine(); // This will wait for you to press enter before removing the console
            }
        }
    }
}
