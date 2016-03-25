using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamGame
{
    class RedVirus : Enemy
    {
        protected bool Dirt = true;
        protected Game myGame;
        //Constructor RedVirus
        public RedVirus(int newX, int newY, Game g): base (1024,400)
        {
            LoadSequence(LEFT,
                new string[]  { "data/Enemigos/EnemigoRojo/MoverIzquierda/MoverIzquierda01.png", "data/Enemigos/EnemigoRojo/MoverIzquierda/MoverIzquierda02.png"
                    , "data/Enemigos/EnemigoRojo/MoverIzquierda/MoverIzquierda03.png" , "data/Enemigos/EnemigoRojo/MoverIzquierda/MoverIzquierda04.png"});
            LoadSequence(RIGHT,

                new string[] { "data/Enemigos/EnemigoRojo/MoverDerecha/MoverDerecha01.png", "data/Enemigos/EnemigoRojo/MoverDerecha/MoverDerecha02.png"
                    , "data/Enemigos/EnemigoRojo/MoverDerecha/MoverDerecha03.png" , "data/Enemigos/EnemigoRojo/MoverDerecha/MoverDerecha04.png"});
            ChangeDirection(LEFT);

            myGame = g;
            x = newX;
            y = newY;
            xSpeed = 3;
            ySpeed = 10;
            width = 50;
            height = 45;
            stepsTillNextFrame = 5;
        }
        

        //Metodo Move RedVirus
        public override void Move()
        {
            //base.Move();
            // TO DO: Avoid magic numbers
            if ((x > 1024 - width) || (x < 0) || (!myGame.IsValidMove(x - xSpeed, y, x + width - xSpeed, y + height)))
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
