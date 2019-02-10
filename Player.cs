using System;

namespace Hangman
{
    class Player{

        private string nick;
        private int attempts;
        private long time;
        private int life;

        public Player(string playerName){
            nick = playerName;
            attempts = 0;
            time = 0;
            life = 10;
        }

        public string getNick(){
            return nick;
        }

        public void setNick(string nick){
            this.nick = nick;
        }

        public int getLife(){
            return life;
        }

        public void setLife(int life){
            this.life = life;
        }

        public void setAttempts(int attempts){
            this.attempts = attempts;
        }

         public int getAttempts(){
            return attempts;
        }

        public void setTime(long time){
            this.time = time;
        }

         public long getTime(){
            return time;
        }
    }
}