using System;
using System.Collections.Generic;
namespace DamGame
{
    class Game
    {
        private Objects items;
        private Font font18;
        private Player player;
        List<Enemy> enemies = new List<Enemy>();
        List<Objects> objects = new List<Objects>();
        private Level currentLevel;
        private bool finished;
        //private int numEnemies;

        long score = 0;

        private int numItems;

        private byte lives = 0;

//Shot --------------------------------------------------
        private Shot myShot;
        private char direction;
//----------------------------------------------------------
        public Game()
        {
            font18 = new Font("data/Joystix.ttf", 18);
            player = new Player(this);


            Random rnd = new Random();

            items= new Heart(300,200,this);

            currentLevel = new Level(this);

            enemies = currentLevel.GetEnemies();
            objects = currentLevel.GetObjects();

            finished = false;
            myShot = new Shot(this, 0, 0, 0);
            myShot.Hide();
            direction = 'R';
        }


        // Update screen
        public void DrawElements()
        {
            Hardware.ClearScreen();

            currentLevel.DrawOnHiddenScreen();
            Hardware.WriteHiddenText("Score: "+ score,
                40, 7,
                0xCC, 0xCC, 0xCC,
                font18);

            currentLevel.DrawOnHiddenScreen();
            Hardware.WriteHiddenText("Lives: "+ lives,
                40, 25,
                0xCC, 0xCC, 0xCC,
                font18);

            player.DrawOnHiddenScreen();

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].DrawOnHiddenScreen();

            for (int i = 0; i < objects.Count; i++)
                objects[i].drawHeart();

            myShot.DrawOnHiddenScreen();

            Hardware.ShowHiddenScreen();
        }


        // Check input by the user
        public void CheckKeys()
        {
            if (Hardware.KeyPressed(Hardware.KEY_UP))
            {
                if (Hardware.KeyPressed(Hardware.KEY_RIGHT))
                {
                    player.JumpRight();
                    //Guardo direccion de disparo
                    direction = 'R';
                    //--------------------------------------------------------
                }
                else
                if (Hardware.KeyPressed(Hardware.KEY_LEFT))
                {
                    player.JumpLeft();
//Guardo direccion de disparo
                    direction = 'L';
//--------------------------------------------------------
                }
                else
                    player.Jump();
            }

            else if (Hardware.KeyPressed(Hardware.KEY_RIGHT))
            {
                player.MoveRight();
//Guardo direccion de disparo
                direction = 'R';
                Console.WriteLine(player.GetX());
//--------------------------------------------------------
            }

            else if (Hardware.KeyPressed(Hardware.KEY_LEFT))
            {
                player.MoveLeft();
//Guardo direccion de disparo
                direction = 'L';
 //--------------------------------------------------------
            }

            //if (Hardware.KeyPressed(Hardware.KEY_DOWN))
            //    player.MoveDown();

             if ((Hardware.KeyPressed(Hardware.KEY_SPC)) && (!myShot.IsVisible()))
            {
                if (direction == 'R')
                    myShot = new Shot(this, player.GetX() + 20, player.GetY(), 10);
                else
                    myShot = new Shot(this, player.GetX(), player.GetY(), -10);
            }

            if (Hardware.KeyPressed(Hardware.KEY_ESC))
                finished = true;
        }

        // Move enemies, animate background, etc 
        public void MoveElements()
        {
            myShot.Move();
            player.Move();
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Move();
        }


        // Check collisions and apply game logic
        public void CheckCollisions()
        {
            for (int i = 0; i < enemies.Count; i++)
                if (enemies[i].CollisionsWith(myShot))
                {
                    enemies[i].Hide();

                    //Doy puntpos segun el enemigo
                    string [] typeEnemi = Convert.ToString(enemies[i].GetType()).Split('.');

                    Console.WriteLine(typeEnemi[1]);
                    switch (typeEnemi[1])
                    {
                        case  "RedVirus":
                            score += 30;
                            break;
                        case "BlueVirus":
                            score += 10;
                            break;
                        case "YellowVirus":
                            score += 50;
                            break;
                        case "EnemyEye":
                            score += 100;
                            break;


                    }
                    myShot.Hide();
                }

            for (int i = 0; i < objects.Count; i++)
                if (objects[i].CollisionsWith(player))
                {
                    objects[i].Hide();

                    //Distingo que tipo de onjeto es 
                    string[] typeObject = Convert.ToString(objects.GetType()).Split('.');

                    Console.WriteLine(typeObject[1]);
                    switch (typeObject[1])
                    {
                        case "Heart":
                            lives += 1;
                            break;
                    }
                }

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
            for (int i = 0; i < enemies.Count; i++)
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
