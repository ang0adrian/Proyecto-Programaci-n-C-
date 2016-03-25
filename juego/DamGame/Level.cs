namespace DamGame
{
    class Level
    {
        byte tileWidth, tileHeight;
        byte levelWidth, levelHeight;
        byte leftMargin, topMargin;
        string[] levelDescription;

        Image fondo, superior, inferior, izquierda, derecha, fondopared, esquinainferiorderecha
                , esquinainferiorizquierda, endScreen, puertaderecha1, puertaderecha2, puertaderecha3
                     , puertaderechaderecha1, puertaderechaderecha2, puertaderechaderecha3, isla1, isla2, isla3, isla4
                        , muroDeCarne1, muroDeCarne2, muroDeCarne3;


        public Level()
        {
            tileWidth = 16;
            tileHeight = 16;
            levelWidth = 150;
            levelHeight = 38;
            leftMargin = 80;
            topMargin = 50;

            levelDescription = new string[38]
            {
                "------------------------------------------------------------------------------------------------------------------------------------------------------",
                "--____________________________________________________________________________________________-----________________________----_____________________--",
                "->                                                                                            <--->                        <-->                     <-",
                "->                                                                                            <--->                        <-->                     <-",
                "->                                                                                            <--->                        <-->                     <-",
                "->                                                                                            <--->                        <-->                     <-",
                "->                                                                                            <--->                        <-->                     <-",
                "->                                                                                            <--->       q11w             <-->                     <-",
                "->                                                                                            <--->       <-->             <-->                     <-",
                "->                                                                                            <--->       <-->             <-->                     <-",
                "->                                                                                        q1112---311111112-->             <-->                     <-",
                "->                                                                                        <------------------>             <-->                     <-",
                "->                                                                                        <------------------>             <-->                     <-",
                "->                                                                                        e__________________r             <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                                         <-->                     <-",
                "->                                                                                                          q111111111111112-->                     <-",
                "->        q11w                                                                                              <----------------->        q11w         <-",
                "->        <-->                                                                                              <----------------->        <-->         <-",
                "->        <-->                                                                                              <----------------->        <-->         <-",
                "-3111111112-->                      q1111111111111111111111111w                                             <-----------------3111111112-->         <-",
                "------------->                      <------------------------->                                             9cvvvvvvvvv<------------------>         <-",
                "------------->                      <------------------------->                                             8xbbbbbbbbb<------------------>         <-",
                "--___________r                      <------------------------->                                             7znnnnnnnnn<-----_____________r         <-",
                "->                                  <------------------------->                                                        <---->                       <-",
                "->                                  <------------------------->                                                        e____r                       <-",
                "->                                  <------___________________r                                                                                     <-",
                "->                                  <----->                                                                                                         <-",
                "->                  q11w            <----->                                                                                                         <-",
                "->                  <-->            <----->                                                                                                         <-",
                "->                  <-->            <----->                                                                                                         <-",
                "-31111111111111111112--31111111111112-----31111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111112-",
                "------------------------------------------------------------------------------------------------------------------------------------------------------",
            };
            esquinainferiorderecha = new Image("data\\EsquinaInferiorDerecha.png");
            esquinainferiorizquierda = new Image("data\\EsquinaInferiorIzquierda.png");
            fondo = new Image("data\\Fondo.png");
            superior = new Image("data\\Superior.png");
            inferior = new Image("data\\Inferior.png");
            izquierda = new Image("data\\Izquierda.png");
            derecha = new Image("data\\Derecha.png");
            fondopared = new Image("data\\FondoPared.png");
            endScreen = new Image("data\\welcomeText.png");
            //Hueco que simula una puerta
            puertaderecha1 = new Image("data\\PuertaDerecha1.png");
            puertaderecha2 = new Image("data\\PuertaDerecha2.png");
            puertaderecha3 = new Image("data\\PuertaDerecha3.png");
            //Muro he hay entre la "puerta" y el muro
            puertaderechaderecha1 = new Image("data\\PuertaDerechaDerecha1.png");
            puertaderechaderecha2 = new Image("data\\PuertaDerechaDerecha2.png");
            puertaderechaderecha3 = new Image("data\\PuertaDerechaDerecha3.png");
            //Muro 
            muroDeCarne1 = new Image("data\\MuroCarne\\PuertaDerechaDerecha1.png");
            muroDeCarne2 = new Image("data\\MuroCarne\\PuertaDerechaDerecha2.png");
            muroDeCarne3 = new Image("data\\MuroCarne\\PuertaDerechaDerecha3.png");
            //Islas 
            //Partiendo de abajo
            //Esquina superior Izquierda.
            isla1 = new Image("data\\IslaAbajo1.png");
            //Esquina superior derecha.
            isla2 = new Image("data\\IslaAbajo2.png");
            //Partiendo desde los laterales 
            isla3 = new Image("data\\IslaAbajo3.png");
            isla4 = new Image("data\\IslaAbajo4.png");
        }

        public void DrawOnHiddenScreen()
        {
            for (int row = 0; row < levelHeight; row++)
                for (int col = 0; col < levelWidth; col++)
                {
                    int xPos = leftMargin + col * tileWidth;
                    int yPos = topMargin + row * tileHeight;
                    switch (levelDescription[row][col])
                    {
                        case '-': Hardware.DrawHiddenImage(fondopared, xPos, yPos); break;
                        case '_': Hardware.DrawHiddenImage(superior, xPos, yPos); break;
                        case '1': Hardware.DrawHiddenImage(inferior, xPos, yPos); break;
                        case '>': Hardware.DrawHiddenImage(izquierda, xPos, yPos); break;
                        case '<': Hardware.DrawHiddenImage(derecha, xPos, yPos); break;
                        case ' ': Hardware.DrawHiddenImage(fondo, xPos, yPos); break;
                        case '2': Hardware.DrawHiddenImage(esquinainferiorderecha, xPos, yPos); break;
                        case '3': Hardware.DrawHiddenImage(esquinainferiorizquierda, xPos, yPos); break;
                        //Puerta
                        case '7': Hardware.DrawHiddenImage(puertaderecha1, xPos, yPos); break;
                        case '8': Hardware.DrawHiddenImage(puertaderecha2, xPos, yPos); break;
                        case '9': Hardware.DrawHiddenImage(puertaderecha3, xPos, yPos); break;
                        //Entre la puerta y el muro
                        case 'c': Hardware.DrawHiddenImage(puertaderechaderecha1, xPos, yPos); break;
                        case 'x': Hardware.DrawHiddenImage(puertaderechaderecha2, xPos, yPos); break;
                        case 'z': Hardware.DrawHiddenImage(puertaderechaderecha3, xPos, yPos); break;
                        //  Isla Partiendo de abajo: La base es el 2;
                        case 'w': Hardware.DrawHiddenImage(isla1, xPos, yPos); break;
                        case 'q': Hardware.DrawHiddenImage(isla2, xPos, yPos); break;
                        case 'e': Hardware.DrawHiddenImage(isla3, xPos, yPos); break;
                        case 'r': Hardware.DrawHiddenImage(isla4, xPos, yPos); break;
                        //Muro de Carne
                        case 'v': Hardware.DrawHiddenImage(muroDeCarne1, xPos, yPos); break;
                        case 'b': Hardware.DrawHiddenImage(muroDeCarne2, xPos, yPos); break;
                        case 'n': Hardware.DrawHiddenImage(muroDeCarne3, xPos, yPos); break;
                    }
                }
        }

        public bool IsValidMove(int xMin, int yMin, int xMax, int yMax)
        {
            for (int row = 0; row < levelHeight; row++)
                for (int col = 0; col < levelWidth; col++)
                {
                    char tileType = levelDescription[row][col];
                    // If we don't need to check collisions with this tile, we skip it
                    if ((tileType == ' '))  // Empty space  
                        continue;
                    // Otherwise, lets calculate its corners and check rectangular collisions
                    int xPos = leftMargin + col * tileWidth;
                    int yPos = topMargin + row * tileHeight;
                    int xLimit = leftMargin + (col + 1) * tileWidth;
                    int yLimit = topMargin + (row + 1) * tileHeight;

                    if (Sprite.CheckCollisions(
                            xMin, yMin, xMax, yMax,  // Coords of the sprite
                            xPos, yPos, xLimit, yLimit)) // Coords of current tile
                        return false;
                }
            //If we have not collided with anything... then we can move
            return true;
        }
    }
}
