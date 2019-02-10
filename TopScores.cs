using System;
using System.Collections.Generic;
using System.IO;

namespace Hangman
{
    class TopScores{
        public List<string> playerScores = new List<string>();

        public void topPlayers(){
            using (StreamReader sr = new StreamReader("scores.txt")){
                string line;
                while((line = sr.ReadLine()) != null){
                    playerScores.Add(line);
                }
        }

    }

     public string[] bestPlayerSort(){
            string temp;
            string[] sortedScore = new string[playerScores.Count];
            for(var i = 0 ; i < sortedScore.Length; ++i)
                sortedScore[i] = playerScores[i].ToString();

            for(int i = 0; i < sortedScore.Length; i++){ 
                for(int j = 1; j < sortedScore.Length; j++){
                    int playerAttempts = playerGuessAttempts(sortedScore[j-1]);
                    int nextPlayerAttempts = playerGuessAttempts(sortedScore[j]);
                    if(playerAttempts > nextPlayerAttempts){
                        if(playerAttempts != nextPlayerAttempts){ 
                            temp = sortedScore[j-1];  
                            sortedScore[j-1] = sortedScore[j];  
                            sortedScore[j] = temp;
                        }
                    }else if(playerAttempts == nextPlayerAttempts){
                        int playerTime = playerGuessTime(sortedScore[j-1]);
                        int nextPlayerTime = playerGuessTime(sortedScore[j]);
                        if(playerTime > nextPlayerTime){
                            temp = sortedScore[j-1];  
                            sortedScore[j-1] = sortedScore[j];  
                            sortedScore[j] = temp;
                        }
                    }
                }
            }
            return sortedScore;
        }

        public int playerGuessAttempts(string playerScore){
            int attempts;
            int attemptsIdx = 2;
            string[] playerScoreSplit = playerScore.Split('|');
            Int32.TryParse(playerScoreSplit[attemptsIdx], out attempts);
            return attempts;
        }

        public int playerGuessTime(string playerScore){
            int time;
            int timeIdx = 1;
            string[] playerScoreSplit = playerScore.Split('|');
            Int32.TryParse(playerScoreSplit[timeIdx], out time);
            return time;
        }
    }
}