using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Game{

        private string nick;
        private string capital;
        private string countryHint;
        private string dashCapital;
        private List<char> typedLetters = new List<char>();
        private string capitalWithTypedLetters;

        public void start(){
            Console.Write("\nEnter your name: ");
            nick = Console.ReadLine();
            Player player = new Player(nick);
            randomCapitalSelection();
            dashCapital = convertStrToDash(capital);

            while(player.getLife() > 0){
                Console.WriteLine("\nYour life: " + player.getLife());
                if(player.getLife() == 1){
                    Console.WriteLine("\nHINT!");
                    Console.WriteLine("\nThe capital of " + countryHint);
                }
                capitalWithTypedLetters = capitalWithTypedLetters();
                Console.WriteLine("\n"+ capitalWithTypedLetters);

                if(checkIfWin()){
                    break;
                }

                char userInput = userGuess();
                if(!typedLetters.Contains(userInput)){
                    typedLetters.Add(userInput);
                }
               
        
                player.setLife(0);
            }
        }

        public void randomCapitalSelection(){
            int countryIdx = 0;
            int capitalIdx = 1;
            string randomCapital = "";
            string countryHint = "";

            Random rnd = new Random();
            List<string> capitals = new List<string>();
            List<string> countries = new List<string>();

            using (StreamReader sr = new StreamReader("countries_and_capitals.txt")){
                string line;
                while((line = sr.ReadLine()) != null){
                    string[] dataSplit = line.Split('|');
                    countries.Add(dataSplit[countryIdx]);
                    capitals.Add(dataSplit[capitalIdx]);
                    if(sr.ReadLine() == null){
                        int index = rnd.Next(capitals.Count);
                        randomCapital = capitals[index].ToUpper();
                        countryHint = countries[index].ToUpper();
                    }
                }
            }
            
            this.capital = randomCapital;
            this.countryHint = countryHint;
        }

        public string convertStrToDash(string word){
            char[] dashWord = new char[word.Length];

            for (int i = 0; i < word.Length; i++) {
                if(word[i] == ' '){
                    dashWord[i] = ' ';
                }else{
                    dashWord[i] = '_';
                }
            }
            string dashString = new string(dashWord);
            return dashString;
        }

        public char userGuess(){
            Console.Write("\nEnter a letter: ");
            char input = Console.ReadKey().KeyChar;
            return Char.ToUpper(input);
        }

        public string capitalWithTypedLetters(){
            StringBuilder sb = new StringBuilder(dashCapital);
            for(int i = 0; i < typedLetters.Count; i++){
                for(int j = 0; j < capital.Length; j++){
                    if(typedLetters[i] == capital[j]){
                        sb[j] = typedLetters[i];
                    }
                }
            }
            string capitalWithGuessLetters = sb.ToString();
            return capitalWithGuessLetters;
        }

        public bool checkIfWin(){
            if(capital.Equals(capitalWithTypedLetters)){
                Console.Clear();
                Console.WriteLine("\nCONGRATULATIONS, YOU WIN!!!");
                Console.WriteLine("\nThe password was " + capital);
                return true;
            }
            return false;
        }
    }
}