using System;

namespace Hangman
{
    class Player{

        private string nick;
        private int score;
        private int life;

        public Player(string playerName){
            nick = playerName;
            score = 0;
            life = 10;
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

          public int getLife(){
            return life;
        }

        public void setLife(int life){
            this.life = life;
        }
    }
}