using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamGame
{
    class EnemyEye : Enemy
    {
        protected Game myGame;
        //Constructor EnemyEye
        public EnemyEye(int newX, int newY, Game g) : base(200, 400)
        {
            LoadSequence(LEFT,
                new string[]  { "data/Enemigos/EnemigoOjo/MoverIzquierda/MoverIzquierda1.png", "data/Enemigos/EnemigoOjo/MoverIzquierda/MoverIzquierda2.png"
                    , "data/Enemigos/EnemigoOjo/MoverIzquierda/MoverIzquierda3.png" , "data/Enemigos/EnemigoOjo/MoverIzquierda/MoverIzquierda4.png"});
            LoadSequence(RIGHT,

                new string[] { "data/Enemigos/EnemigoOjo/MoverDerecha/MoverDerecha1.png", "data/Enemigos/EnemigoOjo/MoverDerecha/MoverDerecha2.png"
                    , "data/Enemigos/EnemigoOjo/MoverDerecha/MoverDerecha3.png" , "data/Enemigos/EnemigoOjo/MoverDerecha/MoverDerecha4.png"});
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


        //Metodo Move EnemyEye
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

