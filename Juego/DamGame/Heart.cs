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
        Image Corazon1Vida = new Image("data/Objetos/Corazon/Corazon1Vida.png");

        public override void drawHeart  ()
        {
            Hardware.DrawHiddenImage(Corazon1Vida, x, y);
        }

        protected int x = 0;
        protected int y = 0;
        protected int height = 0;
        protected int width = 0;

        //Constructor no coje el tipo game;
        public Heart(int newX, int newY, Game g): base (200,200)
        {
            LoadSequence(LEFT,
                new string[]  { "data/Objetos/Corazon/Corazon1Vida.png" });
            x = newX;
            y = newY;
            width = 15;
            height = 16;
            myGame = g;


        }

    }
}
