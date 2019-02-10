using System;

namespace Hangman
{
    class View{
        //TopScores topScores = new TopScores();

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
    }
}