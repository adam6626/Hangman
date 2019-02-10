using System;

namespace Hangman
{
    class View{
        
        public void topPlayers(string[] sortedScore){
            int topTenScore = 0;
            Console.WriteLine("\nTop 10 players");
            Console.WriteLine("\nName\t|\tTime\t|\tAttempts");
            Console.WriteLine("\n-----------------------------------------");
            for(int i = 1; i < sortedScore.Length; i++){
                if(topTenScore < 10){
                    Console.WriteLine(sortedScore[i]);
                    topTenScore++;
                }
            }
        }

        public void hangmanArt(int life, string capital){
            if (life == 9) {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("___|___");
            }
            
            if (life == 8) {
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("___|___");
            }
            if (life == 7) {
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("___|___");
            }
            if (life == 6) {
               Console.WriteLine("   _______");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("___|___");
            }
            if (life == 5) {
               Console.WriteLine("   ____________");
               Console.WriteLine("   |           |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("___|___");
            }
            if (life == 4) {
               Console.WriteLine("   ____________");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         /   \\");
               Console.WriteLine("   |        |     |");
               Console.WriteLine("   |         \\_ _/");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("   |");
               Console.WriteLine("___|___");
            }
            if (life == 3) {
               Console.WriteLine("   ____________");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         /   \\");
               Console.WriteLine("   |        |     |");
               Console.WriteLine("   |         \\_ _/");
               Console.WriteLine("   |           |");
               Console.WriteLine("   |           |");
               Console.WriteLine("   |");
               Console.WriteLine("___|___");
            }
            if (life == 2) {
               Console.WriteLine("   ____________");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         /   \\");
               Console.WriteLine("   |        |     |");
               Console.WriteLine("   |         \\_ _/");
               Console.WriteLine("   |           |");
               Console.WriteLine("   |           |");
               Console.WriteLine("   |          / \\ ");
               Console.WriteLine("___|___      /   \\");
            }
            if (life == 1) {
               Console.WriteLine("   ____________");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         /   \\");
               Console.WriteLine("   |        |     |");
               Console.WriteLine("   |         \\_ _/");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         / | \\");
               Console.WriteLine("   |          / \\ ");
               Console.WriteLine("___|___      /   \\");
            }
            if (life <= 0) {
               Console.WriteLine("   ____________");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         /x  x\\");
               Console.WriteLine("   |        |   _  |");
               Console.WriteLine("   |         \\_ _ /");
               Console.WriteLine("   |          _|_");
               Console.WriteLine("   |         / | \\");
               Console.WriteLine("   |          / \\ ");
               Console.WriteLine("___|___      /   \\");
               Console.WriteLine("GAME OVER! The password was " + capital);
            }
        }
        public void printIfLetterNotInWord(char guess){
            Console.Clear();
            Console.WriteLine ("\n" + guess + " is not in the password\nYou lose one life");
        }

        public void printIfWrongWord(string guess){
            Console.Clear();
            Console.WriteLine ("\n" + guess + " is not a password\nYou lose two lifes");
        }

        public void printIfLetterAlreadyEntered(char guess){
            Console.Clear();
            Console.WriteLine ("\nYou already entered: " + guess);
        }

        public void printIfLetterInWord(char guess){
            Console.Clear();
            Console.WriteLine ("\nBravo\n" + guess + " is in the password");
        }

        public void printCountryHint(string country){
            Console.WriteLine("\nHINT!");
            Console.WriteLine("\nThe capital of " + country);
        }

        public void preGameInfo(){
            Console.WriteLine("\nWelcome in the hangman game");
            Console.WriteLine("\nYou have to guess a random choosed capital of some country");
            Console.WriteLine("\nYou have 10 lifes");
            Console.WriteLine("\nWrong letter guess takes one life");
            Console.WriteLine("and wrong word guess takes two lifes");
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void header(){
            Console.WriteLine("888");                                                           
            Console.WriteLine("888");                                                           
            Console.WriteLine("888");                                                           
            Console.WriteLine("88888b.   8888b. .88888b. .d88bBB. 888b.88b.888b.  8888b. .88888b.");
            Console.WriteLine("888  88b      88 b88   88 bd8  88P 88b  888  8b8       88 b88   88");
            Console.WriteLine("888  888.d888888 888   88 888   88 88    8    88. d888888 888   88");
            Console.WriteLine("888  888 888  88 888   88 Y88b  88 88         88  888  88 888   88");
            Console.WriteLine("888  888  Y88888 888   88   Y88888 88         88   Y88888 888   88");
            Console.WriteLine("                               888                              ");
            Console.WriteLine("                          Y8b d88P                              ");
            Console.WriteLine("                            Y88P     ");
        }
    }
}