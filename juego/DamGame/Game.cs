using System;

namespace DamGame
{
    class Game
    {
        private Objects items;
        private Font font18;
        private Player player;
        private Enemy[] enemies;
        private Level currentLevel;
        private bool finished;
        private int numEnemies;
        private int numItems;
        private int lives = 0;

        public Game()
        {
            font18 = new Font("data/Joystix.ttf", 18);
            player = new Player(this);


            // Objetos
            Random rnd = new Random();
            //numItems = 1;
            //items = new Objects[numItems];
            //for (int i = 0; i < numEnemies ; i++)
            //{
            //    items[i] = new Heart(300,200, this);
            //    items[i].Show();
            //}
            items= new Heart(300,200,this);
            //Enemigos
            numEnemies = 6;
            enemies = new Enemy[numEnemies];
            for (int i = 0; i < numEnemies-2; i++)
            {
                if ((i <= 2)&&(i!=0))
                {
                    enemies[i] = new YellowVirus(rnd.Next(200, 800), rnd.Next(50, 600), this);
                    enemies[i].SetSpeed(rnd.Next(1, 5), 0);
                }
                else
                {
                    enemies[i] = new RedVirus(rnd.Next(200, 800), rnd.Next(50, 600),this);
                    enemies[i].SetSpeed(rnd.Next(1, 5), 0);
                }
                enemies[4] = new BlueVirus(rnd.Next(200, 800), rnd.Next(50, 600), this);
                enemies[4].SetSpeed(rnd.Next(1, 5), 0);

                enemies[5] = new EnemyEye(rnd.Next(200, 800), rnd.Next(50, 600), this);
                enemies[5].SetSpeed(rnd.Next(1, 5), 0);
            }

            currentLevel = new Level();
            finished = false;
        }


        // Update screen
        public void DrawElements()
        {
            Hardware.ClearScreen();

            currentLevel.DrawOnHiddenScreen();
            Hardware.WriteHiddenText("Score: ",
                40, 7,
                0xCC, 0xCC, 0xCC,
                font18);

            currentLevel.DrawOnHiddenScreen();
            Hardware.WriteHiddenText("Lives: "+ lives,
                40, 25,
                0xCC, 0xCC, 0xCC,
                font18);

            player.DrawOnHiddenScreen();
            for (int i = 0; i < numEnemies; i++)
                enemies[i].DrawOnHiddenScreen();
            Hardware.ShowHiddenScreen();
        }


        // Check input by the user
        public void CheckKeys()
        {
            if (Hardware.KeyPressed(Hardware.KEY_UP))
            {
                if (Hardware.KeyPressed(Hardware.KEY_RIGHT))
                    player.JumpRight();
                else
                if (Hardware.KeyPressed(Hardware.KEY_LEFT))
                    player.JumpLeft();
                else
                    player.Jump();
            }

            else if (Hardware.KeyPressed(Hardware.KEY_RIGHT))
                player.MoveRight();

            else if (Hardware.KeyPressed(Hardware.KEY_LEFT))
                player.MoveLeft();

            //if (Hardware.KeyPressed(Hardware.KEY_DOWN))
            //    player.MoveDown();

            if (Hardware.KeyPressed(Hardware.KEY_ESC))
                finished = true;
        }


        // Move enemies, animate background, etc 
        public void MoveElements()
        {
            player.Move();
            for (int i = 0; i < numEnemies; i++)
                enemies[i].Move();
        }


        // Check collisions and apply game logic
        public void CheckCollisions()
        {

            if (lives<0)
            {
                finished = true;
            }

            //Comprobar si cojo un objeto.

              // if (items[0].CollisionsWith(player)&&(items[0].IsVisible()))
              //  {
              //    items[0].Hide();
              //  }

            //Comprobar Colisiones con los enemigos
            for (int i = 0; i < numEnemies; i++)
                if (enemies[i].CollisionsWith(player))
                {
                    player.RestartPosition(lives);
                    lives--;

                }
                               
        }

        public void PauseTillNextFrame()
        {
            // Pause till next frame (20 ms = 50 fps)
            Hardware.Pause(20);
        }

        public void Run()
        {
            // Game Loop
            while (!finished)
            {
                DrawElements();
                CheckKeys();
                MoveElements();
                CheckCollisions();
                PauseTillNextFrame();
            }
        }

        public bool IsValidMove(int xMin, int yMin, int xMax, int yMax)
        {
            return currentLevel.IsValidMove(xMin, yMin, xMax, yMax);
        }
    }
}
