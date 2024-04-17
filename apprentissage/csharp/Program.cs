using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);
        Console.Write("Entrez un nombre entier entre 1 et 100: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int count=0;
        while (number != randomNumber)
        {
            count++ ;
            if (number > randomNumber)
            {
                Console.WriteLine("Le Nombre a trouver est plus petit");
            }
            else
            {
                Console.WriteLine("Le Nombre a trouver est plus grand");
            }
            number = Convert.ToInt32(Console.ReadLine());
        }

        // Message de fin
        Console.WriteLine("vous avez trouvez le nombre " + number+" en " + count+" tour.");
    }
}
