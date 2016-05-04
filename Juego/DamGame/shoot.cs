using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamGame
{

    class Shot : Sprite
    {
        protected Game myGame;

        public Shot(Game g, int x, int y, int xSpeed)
        {
            LoadSequence(LEFT,
                new string[] { "data/Disparos/izquierda/disparo1.png",
                                "data/Disparos/izquierda/disparo5.png",
                                    "data/Disparos/izquierda/disparo6.png",
                                        "data/Disparos/izquierda/disparo7.png",
                                            "data/Disparos/izquierda/disparo8.png" });
            LoadSequence(RIGHT,
                new string[] { "data/Disparos/derecha/disparo1.png",
                                "data/Disparos/derecha/disparo5.png",
                                    "data/Disparos/derecha/disparo6.png",
                                        "data/Disparos/derecha/disparo7.png",
                                            "data/Disparos/derecha/disparo8.png" });

            startX = x;
            this.x = x;
            this.y = y+11;
            this.xSpeed = xSpeed;
            if (xSpeed > 0)
                currentDirection = RIGHT;
            else
                currentDirection = LEFT;
            width = 16;
            height = 16;
            myGame = g;
        }

        public override void Move()
        {
            if (!visible)
                return;

            if ((myGame.IsValidMove(x + xSpeed, y, x + width + xSpeed, y + height))
                && (x > 0) && (x < 2409))
            // TO DO: Avoid magic number 1024
            {

                if ((x - startX == 10)||(x - startX == -10))
                    NextFrame();

                if ((x - startX == 50)|| (x - startX == -50))
                    NextFrame();

                if ((x - startX == 60)|| (x - startX == -60))
                    NextFrame();

                if ((x - startX == 70)|| (x - startX == -70))
                    NextFrame();

                x += xSpeed;
            }
            else
                Hide();
        }
    }
}
