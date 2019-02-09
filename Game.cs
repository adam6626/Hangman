using System;

namespace Hangman
{
    class Game{

        private string nick;
        
        public void start(){
            Console.Write("\nEnter your name: ");
            nick = Console.ReadLine();
            Player player = new Player(nick);
            while(player.getLife() > 0){
                 Console.WriteLine("\nHello world");
            }
        }
    }
}