namespace DamGame
{
    class Player : Sprite
    {
        protected Game myGame;
        protected bool jumping, falling;
        protected int jumpXspeed;
        protected int jumpFrame;
        protected int[] jumpSteps = 
        {
            -10, -10, -8, -8, -6, -6, -4, -2, -1, -1, 0,
            0, 1, 1, 2, 4, 6, 6, 8, 8, 10, 10
        };

        public Player(Game g)
        {
            //Andar Izquierda
            LoadSequence(LEFT,
                new string[] { "data/Jugador/MoverIzquirda/PlayerIzquierda01.png" , "data/Jugador/MoverIzquirda/PlayerIzquierda02.png"
                    ,"data/Jugador/MoverIzquirda/PlayerIzquierda03.png", "data/Jugador/MoverIzquirda/PlayerIzquierda04.png", "data/Jugador/MoverIzquirda/PlayerIzquierda05.png"
                        ,"data/Jugador/MoverIzquirda/PlayerIzquierda01.png"});
            //Andar Derecha
            LoadSequence(RIGHT,
                new string[] { "data/Jugador/MoverDerecha/PlayerDerecha01.png", "data/Jugador/MoverDerecha/PlayerDerecha02.png"
                    ,"data/Jugador/MoverDerecha/PlayerDerecha03.png","data/Jugador/MoverDerecha/PlayerDerecha04.png","data/Jugador/MoverDerecha/PlayerDerecha05.png"
                        ,"data/Jugador/MoverDerecha/PlayerDerecha06.png"});

            LoadSequence(Death,
               new string[] { "data/Jugador/Muerte/Muerte01.png", "data/Jugador/Muerte/Muerte02.png", "data/Jugador/Muerte/Muerte03.png",
                    "data/Jugador/Muerte/Muerte04.png", "data/Jugador/Muerte/Muerte05.png", "data/Jugador/Muerte/Muerte06.png", "data/Jugador/Muerte/Muerte07.png",
                        "data/Jugador/Muerte/Muerte08.png", "data/Jugador/Muerte/Muerte09.png", "data/Jugador/Muerte/Muerte10.png", "data/Jugador/Muerte/Muerte11.png",
                            "data/Jugador/Muerte/Muerte12.png", "data/Jugador/Muerte/Muerte13.png", "data/Jugador/Muerte/Muerte14.png", "data/Jugador/Muerte/Muerte15.png",
                                "data/Jugador/Muerte/Muerte16.png","data/Jugador/Muerte/Muerte16.png"});


            ChangeDirection(LEFT);

            

            x = 200;
            y = 300;
            xSpeed = 6;
            ySpeed = 4;
            width = 35;
            height = 60;

            stepsTillNextFrame = 6;

            jumpXspeed = 0;
            jumping = false;
            jumpFrame = 0;
            falling = false;
            myGame = g;
        }
        public void RestartPosition (int lives)
        {
            if (lives>=1)
            {
                x = 200;
                y = 300;
                Hardware.ScrollTo(450, 0);
            }

            
        }

        public void death ()
        {
                ChangeDirection(Death);
                NextFrame();    
        }
        public void MoveRight()
        {
            if (myGame.IsValidMove(x + xSpeed, y, x + width + xSpeed, y + height))
            {
                Hardware.ScrollHorizontally((short)-xSpeed);
                x += xSpeed;
                ChangeDirection(RIGHT);
                NextFrame();
            }
        }

        public void MoveLeft()
        {
            Hardware.ScrollHorizontally((short)xSpeed);
            if (myGame.IsValidMove(x - xSpeed, y, x + width - xSpeed, y + height))
            {
                x -= xSpeed;
                ChangeDirection(LEFT);
                NextFrame();
            }
        }

        public void MoveUp()
        {
            // The player will not move up freely any longer, but jump
            // y -= ySpeed;
            Jump();
            // TO DO: Check if there is a stair or up down
        }

        public void MoveDown()
        {
            // The player will not move down freely any longer
            // y += ySpeed;
            // TO DO: Check if there is a stair or way down
        }


        // Starts the jump sequence
        public void Jump()
        {
            if (jumping || falling)
                return;
            jumping = true;
            jumpXspeed = 0;
        }


        // Starts the jump sequence to the right
        public void JumpRight()
        {
            Hardware.ScrollHorizontally(-3);
            Jump();
            jumpXspeed = xSpeed;
        }


        // Starts the jump sequence to the left
        public void JumpLeft()
        {
            Hardware.ScrollHorizontally(3);
            Jump();
            jumpXspeed = -xSpeed;
        }


        // Sometimes the player must be animated, eg. jumping
        public override void Move()
        {
            // If the player is not jumping, it might need to fall down
            if (!jumping)
            {
                if (myGame.IsValidMove(
                    x, y + ySpeed, x + width, y + height + ySpeed))
                {
                    y += ySpeed;
                }
            }
            else
            // If jumping, it must go on with the sequence
            {
                currentFrame = 0; // static frame for the jump at this moment

                // Let's calculate the next positions
                short nextX = (short)(x + jumpXspeed);
                short nextY = (short)(y + jumpSteps[jumpFrame]);

                // If the player can still move, let's do it
                if (myGame.IsValidMove(
                     nextX, nextY,
                     nextX + width, nextY + height))
                {
                    x = nextX;
                    y = nextY;
                    // NextFrame();
                }
                // If it cannot move, then it must fall
                else
                {
                    jumping = false;
                    jumpFrame = 0;
                }

                // And let's prepare the next frame, maybe with a different speed
                jumpFrame++;
                if (jumpFrame >= jumpSteps.Length)
                {
                    jumping = false;
                    jumpFrame = 0;
                }
            }
        }
    }
}
