using System;

namespace AC1
{
    public class Program
    {
        public static void Main()
        {
            Score score = new Score();

            score.SetPlayer("John123");

            string? playerName = score.GetPlayer();
            if (playerName != null)
            {
                Console.WriteLine($"El nombre del jugador es: {playerName}");
            }
            else
            {
                Console.WriteLine("El nombre del jugador no es válido.");
            }

            score.SetPlayer("María@");

            playerName = score.GetPlayer();
            if (playerName != null)
            {
                Console.WriteLine($"El nombre del jugador es: {playerName}");
            }
            else
            {
                Console.WriteLine("El nombre del jugador no es válido.");
            }
        }
    }
}
