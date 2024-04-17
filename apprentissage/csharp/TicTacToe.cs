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