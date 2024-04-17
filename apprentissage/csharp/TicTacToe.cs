using System;

class Program
{
    static void Main(string[] args)
    {
        // Boucle pour permettre à l'utilisateur de saisir plusieurs valeurs
        bool continuer = true;
        while (continuer)
        {
            // Prompt pour saisir un nombre
            Console.Write("Entrez un nombre entier : ");
            int nombre = Convert.ToInt32(Console.ReadLine());

            // Vérification si le nombre est pair ou impair
            if (nombre % 2 == 0)
            {
                Console.WriteLine("Le nombre saisi est pair.");
            }
            else
            {
                Console.WriteLine("Le nombre saisi est impair.");
            }

            // Condition pour demander à l'utilisateur s'il veut continuer
            Console.Write("Voulez-vous saisir un autre nombre ? (O/N) : ");
            char reponse = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            // Si l'utilisateur répond non, sortir de la boucle
            if (reponse != 'O')
            {
                continuer = false;
            }
        }

        // Message de fin
        Console.WriteLine("Fin du programme.");
    }
}
Ce programme demande à l'utilisateur de saisir un nombre entier, vérifie s'il est pair ou impair, puis demande à l'utilisateur s'il souhaite saisir un autre nombre. Le programme continue de demander des nombres jusqu'à ce que l'utilisateur décide d'arrêter en répondant "N" à la question posée.



User
comment faire un random en c#
ChatGPT
En C#, vous pouvez utiliser la classe Random pour générer des nombres aléatoires. Voici un exemple simple :

csharp
Copy code
using System;

class Program
{
    static void Main(string[] args)
    {
        // Création d'une instance de Random
        Random random = new Random();

        // Génération d'un nombre aléatoire entre 1 et 100 inclus
        int randomNumber = random.Next(1, 101);

        // Affichage du nombre aléatoire généré
        Console.WriteLine("Nombre aléatoire : " + randomNumber);
    }
}
Dans cet exemple, random.Next(1, 101) génère un nombre aléatoire entre 1 et 100 inclus. Vous pouvez ajuster les valeurs passées à la méthode Next pour générer des nombres dans différentes plages.

User
fait un tic tac toe en c#
ChatGPT
Voici un exemple simple d'un jeu de tic-tac-toe en C# console. Ce code permet à deux joueurs de jouer tour à tour jusqu'à ce qu'il y ait un gagnant ou que la grille soit remplie.

csharp
Copy code
using System;

class Program
{
    static char[,] grille = new char[3, 3];

    static void Main(string[] args)
    {
        InitialiserGrille();

        while (true)
        {
            AfficherGrille();

            JouerCoup('X');

            if (VerifierGagnant('X'))
            {
                Console.WriteLine("Joueur X a gagné !");
                break;
            }

            if (EstMatchNul())
            {
                Console.WriteLine("Match nul !");
                break;
            }

            AfficherGrille();

            JouerCoup('O');

            if (VerifierGagnant('O'))
            {
                Console.WriteLine("Joueur O a gagné !");
                break;
            }

            if (EstMatchNul())
            {
                Console.WriteLine("Match nul !");
                break;
            }
        }
    }

    static void InitialiserGrille()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                grille[i, j] = ' ';
            }
        }
    }

    static void AfficherGrille()
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(grille[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void JouerCoup(char joueur)
    {
        while (true)
        {
            Console.WriteLine("Joueur " + joueur + ", entrez les coordonnées (ligne colonne) de votre coup : ");
            string[] input = Console.ReadLine().Split(' ');
            int ligne = int.Parse(input[0]);
            int colonne = int.Parse(input[1]);

            if (EstCoupValide(ligne, colonne))
            {
                grille[ligne, colonne] = joueur;
                break;
            }
            else
            {
                Console.WriteLine("Coup invalide. Veuillez réessayer.");
            }
        }
    }

    static bool EstCoupValide(int ligne, int colonne)
    {
        if (ligne < 0 || ligne >= 3 || colonne < 0 || colonne >= 3)
        {
            return false;
        }
        if (grille[ligne, colonne] != ' ')
        {
            return false;
        }
        return true;
    }

    static bool VerifierGagnant(char joueur)
    {
        for (int i = 0; i < 3; i++)
        {
            if (grille[i, 0] == joueur && grille[i, 1] == joueur && grille[i, 2] == joueur)
                return true;
            if (grille[0, i] == joueur && grille[1, i] == joueur && grille[2, i] == joueur)
                return true;
        }

        if (grille[0, 0] == joueur && grille[1, 1] == joueur && grille[2, 2] == joueur)
            return true;
        if (grille[0, 2] == joueur && grille[1, 1] == joueur && grille[2, 0] == joueur)
            return true;

        return false;
    }

    static bool EstMatchNul()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (grille[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}