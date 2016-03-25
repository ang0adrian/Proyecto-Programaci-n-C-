using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamGame
{
    class Heart : Objects
    {
        protected Game myGame;

        

        //Constructor no coje el tipo game;
        public Heart(int newX, int newY, Game g): base (200,200)
        {
            Image Corazon1Vida = new Image("data/Objetos/Corazon/Corazon1Vida.png");
        
            x = newX;
            y = newY;
            xSpeed = 0;
            ySpeed = 0;
            width = 15;
            height = 16;
            myGame=g;
        
            Hardware.DrawHiddenImage(Corazon1Vida, 100, 200);
        }

    }
}
