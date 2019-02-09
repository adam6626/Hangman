using System;

namespace Hangman
{
    class Player{

        private string nick;
        private int score;

        public Player(string playerName){
            nick = playerName;
            score = 0;
        }

        public string getNick(){
            return nick;
        }

        public void setNick(string nick){
            this.nick = nick;
        }

        public int getScore(){
            return score;
        }

        public void setScore(int score){
            this.score = score;
        }
    }
}