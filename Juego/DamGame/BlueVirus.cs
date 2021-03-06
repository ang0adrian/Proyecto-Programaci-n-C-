﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamGame
{
    class BlueVirus : Enemy
    {
        protected Game myGame;
        //Constructor RedVirus
        public BlueVirus(int newX, int newY, Game g) : base(200, 400)
        {
            LoadSequence(LEFT,
                new string[]  { "data/Enemigos/EnemigoAzul/MoverIzquierda/MoverIzquierda01.png", "data/Enemigos/EnemigoAzul/MoverIzquierda/MoverIzquierda02.png"
                    , "data/Enemigos/EnemigoAzul/MoverIzquierda/MoverIzquierda03.png" , "data/Enemigos/EnemigoAzul/MoverIzquierda/MoverIzquierda04.png"});
            LoadSequence(RIGHT,

                new string[] { "data/Enemigos/EnemigoAzul/MoverDerecha/MoverDerecha01.png", "data/Enemigos/EnemigoAzul/MoverDerecha/MoverDerecha02.png"
                    , "data/Enemigos/EnemigoAzul/MoverDerecha/MoverDerecha03.png" , "data/Enemigos/EnemigoAzul/MoverDerecha/MoverDerecha04.png"});
            ChangeDirection(LEFT);


            x = newX;
            y = newY;
            xSpeed = 6;
            ySpeed = 3;
            width = 50;
            height = 45;
            stepsTillNextFrame = 5;

            myGame = g;
        }


        //Metodo Move RedVirus
        public override void Move()
        {
            // TO DO: Avoid magic numbers
            if ((x > 2409 - width) || (x < 0) || (!myGame.IsValidMove(
                    x + xSpeed, y, x + width + xSpeed, y + height)))
                xSpeed = -xSpeed;
            x = (short)(x + xSpeed);

            if (xSpeed < 0)
                ChangeDirection(LEFT);
            else
                ChangeDirection(RIGHT);

            NextFrame();
        }
    }
}
