using System.Diagnostics;

int userDifficulty = 1;
int userAttempts = 0;
bool play = true;
int userInput = 1;
string userPlay = "y";
bool repeat = true;
int errorCounter = 0;
string userDecide = "";
bool newRandom = true;
int number = 1;
Stopwatch stopWatch = new Stopwatch();

string font = @"

██╗    ██╗██╗██╗     ██╗     ██╗  ██╗ ██████╗ ███╗   ███╗███╗   ███╗███████╗███╗   ██╗    ██████╗ ███████╗██╗       
██║    ██║██║██║     ██║     ██║ ██╔╝██╔═══██╗████╗ ████║████╗ ████║██╔════╝████╗  ██║    ██╔══██╗██╔════╝██║       
██║ █╗ ██║██║██║     ██║     █████╔╝ ██║   ██║██╔████╔██║██╔████╔██║█████╗  ██╔██╗ ██║    ██████╔╝█████╗  ██║       
██║███╗██║██║██║     ██║     ██╔═██╗ ██║   ██║██║╚██╔╝██║██║╚██╔╝██║██╔══╝  ██║╚██╗██║    ██╔══██╗██╔══╝  ██║       
╚███╔███╔╝██║███████╗███████╗██║  ██╗╚██████╔╝██║ ╚═╝ ██║██║ ╚═╝ ██║███████╗██║ ╚████║    ██████╔╝███████╗██║       
 ╚══╝╚══╝ ╚═╝╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝    ╚═════╝ ╚══════╝╚═╝       
                                                                                                                    
███╗   ██╗██╗   ██╗███╗   ███╗██████╗ ███████╗██████╗      ██████╗ ██╗   ██╗███████╗███████╗███████╗███████╗██████╗ 
████╗  ██║██║   ██║████╗ ████║██╔══██╗██╔════╝██╔══██╗    ██╔════╝ ██║   ██║██╔════╝██╔════╝██╔════╝██╔════╝██╔══██╗
██╔██╗ ██║██║   ██║██╔████╔██║██████╔╝█████╗  ██████╔╝    ██║  ███╗██║   ██║█████╗  ███████╗███████╗█████╗  ██████╔╝
██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██╔══██╗    ██║   ██║██║   ██║██╔══╝  ╚════██║╚════██║██╔══╝  ██╔══██╗
██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██████╔╝███████╗██║  ██║    ╚██████╔╝╚██████╔╝███████╗███████║███████║███████╗██║  ██║
╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝     ╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝
                                                                                                 
";
Console.WriteLine(font);
Console.WriteLine("Drücken Sie Leertaste um zu spielen");
while (Console.ReadKey().Key != ConsoleKey.Spacebar)
{
    Console.Write("\b \b");
}
Console.Clear();

while (play == true)
{
    while (repeat == true)
    {
        newRandom = true;
        if (errorCounter == 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Geben Sie die gewünschte Zahlenmenge ein. (1 - 2147483647)");
        }
        Console.WriteLine("Oder geben sie 'random' ein, um eine zufällige Zahlenmenge zu setzen.");
        Console.ForegroundColor = ConsoleColor.White;

        userDecide = Console.ReadLine();
        Console.Clear();
        if (userDecide == "random")
        {
            userDifficulty = 2147483646;
            repeat = false;
        }
        else
        {
            try
            {
                repeat = false;
                userDifficulty = Convert.ToInt32(userDecide);
            }
            catch
            {
                errorCounter++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bitte geben Sie eine gültige Zahl ein. (1 - 2147483647)");
                repeat = true;
            }
        }
    }

    if (newRandom == true)
    {
        if (userDifficulty == 2147483647)
        {
            Random rnd = new Random();
            number = rnd.Next(1, userDifficulty);
        }
        else
        {
            userDifficulty++;
            Random rnd = new Random();
            number = rnd.Next(1, userDifficulty);
            userDifficulty--;
        }
        stopWatch.Restart();
        Console.Clear();
        newRandom = false;
        Console.WriteLine($"Geben Sie eine Zahl zwischen 1 und {userDifficulty} ein.");
    }

    try
    {
        userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput < 1 || userInput > userDifficulty)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Bitte geben Sie eine Zahl zwischen 1 und {userDifficulty} ein.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            if (userInput == number)
            {
                userAttempts++;
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                errorCounter = 0;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                if (userAttempts == 1)
                {
                    Console.WriteLine($"Glückwunsch, du hast die Nummer erraten! ({userInput})");
                    Console.WriteLine($"Du hast {userAttempts} Versuch und {elapsedTime} gebraucht.");
                }
                else
                {
                    Console.WriteLine($"Glückwunsch, du hast die Nummer erraten! ({userInput})");
                    Console.WriteLine($"Du hast {userAttempts} Versuche und {elapsedTime} gebraucht.");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Möchten Sie nochmal Spielen? [y / n]");
                do
                {
                    userPlay = Console.ReadLine();
                    if (userPlay == "y")
                    {
                        play = true;
                        repeat = true;
                        Console.Clear();
                        userAttempts = 0;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (userPlay == "n")
                    {
                        play = false;
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    if (userPlay != "y" && userPlay != "n")
                    {
                        Console.Clear();
                        userPlay = "x";
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geben Sie y oder n ein.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while (userPlay == "x");
            }
            else if (userInput > number)
            {
                userAttempts++;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Zu hoch! ({userInput})");
                Console.WriteLine($"Geben Sie eine neue Zahl zwischen 1 und {userDifficulty} ein.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (userInput < number)
            {
                userAttempts++;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Zu tief! ({userInput})");
                Console.WriteLine($"Geben Sie eine neue Zahl zwischen 1 und {userDifficulty} ein.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    catch
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Geben Sie eine Zahl zwischen 1 und {userDifficulty} ein.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}