using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamGame
{
    class YellowVirus : Enemy
    {
        protected Game myGame;
        //Constructor YellowVirus
        public YellowVirus(int newX, int newY, Game g) : base(200, 400)
        {
            LoadSequence(LEFT,
                new string[]  { "data/Enemigos/EnemigoAmarillo/MoverIzquierda/MoverIzquierda01.png", "data/Enemigos/EnemigoAmarillo/MoverIzquierda/MoverIzquierda02.png"
                    , "data/Enemigos/EnemigoAmarillo/MoverIzquierda/MoverIzquierda03.png" , "data/Enemigos/EnemigoAmarillo/MoverIzquierda/MoverIzquierda04.png"});
            LoadSequence(RIGHT,

                new string[] { "data/Enemigos/EnemigoAmarillo/MoverDerecha/MoverDerecha01.png", "data/Enemigos/EnemigoAmarillo/MoverDerecha/MoverDerecha02.png"
                    , "data/Enemigos/EnemigoAmarillo/MoverDerecha/MoverDerecha03.png" , "data/Enemigos/EnemigoAmarillo/MoverDerecha/MoverDerecha04.png"});
            ChangeDirection(LEFT);


            x = newX;
            y = newY;
            xSpeed = 3;
            ySpeed = 3;
            width = 50;
            height = 45;
            stepsTillNextFrame = 5;

            myGame = g;
        }


        //Metodo Move YellowVirus
        public override void Move()
        {
            // TO DO: Avoid magic numbers
            if ((x > 1024 - width) || (x < 0) || (!myGame.IsValidMove(
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

