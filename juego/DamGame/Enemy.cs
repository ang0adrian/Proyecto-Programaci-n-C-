namespace DamGame
{
    class Enemy : Sprite
    {
        //Este string es apra saber que tipo de enemigo es 
        protected string type = "";

        public Enemy(int newX, int newY)
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

        }

        public override void Move()
        {
            // TO DO: Avoid magic numbers
            if ((x > 2409 - width) || (x < 0))
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
