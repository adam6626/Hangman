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
        private string wordGuess;

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
                capitalWithTypedLetters = getCapitalWithTypedLetters();
                Console.WriteLine("\n"+ capitalWithTypedLetters);

                if(checkIfWin()){
                    break;
                }else if(!wordOrLetter()){
                    char userInput = userGuess();
                        
                    if(!typedLetters.Contains(userInput)){
                        typedLetters.Add(userInput);
                    }else{
                        continue;
                    }
                }
                if(!checkGuess(userInput)){
                    player.setLife(player.getLife()-1);
                }else{
                    wordGuess = wholeWordGuess();
                    if(checkIfWin()){
                        break;
                    }else{
                        player.setLife(player.getLife()-2);
                        continue;
                    }
                }
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

        public string getCapitalWithTypedLetters(){
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

        public bool checkGuess(char guess){
            bool validGuess = false;
            foreach(char c in capital){
                if(c == guess){
                    validGuess = true;
                }
            }
            return validGuess;
        }

        public bool wordOrLetter(){
            bool choosedOption = false;
            char wordOrLetter;
            char wordOrLetterUpper;
            do{
                Console.Write("\nDo you want to guess whole word[W] or one letter[L]: ");
                wordOrLetter = Console.ReadKey().KeyChar;
                wordOrLetterUpper = Char.ToUpper(wordOrLetter);
                if(wordOrLetterUpper == 'W'){
                    choosedOption = true;
                }else if (wordOrLetterUpper == 'L'){
                    choosedOption = false;
                }else{
                    Console.WriteLine("\nPlease enter only W or L.");
                }
            }while(wordOrLetterUpper!='W' && wordOrLetterUpper!='L');
            return choosedOption;
        }

        public string wholeWordGuess(){
            Console.Write("\nEnter a word: ");
            string input = Console.ReadLine();
            return input.ToUpper();
        }
    }
}