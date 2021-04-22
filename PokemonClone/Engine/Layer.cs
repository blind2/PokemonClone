using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PokemonClone.Engine
{
    public class Layer
    {
        private TextureRegion textureRegion;
        private Sprite transparentTile;
        public List<Tile> tileList;

        public Layer(TextureRegion textureRegion)
        {
            this.textureRegion = textureRegion;
            tileList = new List<Tile>();
        }

        public void Generate()
        {

        }
        public void GenerateMapFromFile(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string grilleDimenssion = sr.ReadLine();
                    string[] dimenssion = grilleDimenssion.Split(',');
                    int tabX = Convert.ToInt32(dimenssion[0]);
                    int tabY = Convert.ToInt32(dimenssion[1]);

                    for (int x = 0; x < tabX; x++)
                    {
                        string ligne = sr.ReadLine();
                        string[] charTab = ligne.Split(' ');

                        for (int y = 0; y < tabY; y++)
                        {
                            int[,] map = new int[tabX, tabY];
                            map[x, y] = Convert.ToInt32(charTab[y]);

                            int tileIndex = map[x, y];


                            if (tileIndex != 0)
                            {
                                //Si la tuile a une collision

                                tileList.Add(new Tile(new Vector2(y * 16, x * 16), tileIndex, true));

                            }
                            else if (tileIndex == 0)
                            {
                                //Aucune tile n'est afficher
                            }

                            else
                            {
                                //Si la tuile n'a pas de collision 
                                //tileList.Add(new StaticTile(new Vector2(y * 16, x * 16), tileIndex, false));



                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Le fichier n'a pas été trouvée");
            }
        }

        public void GenerateCustomMap(int xSize, int ySize, int minValue, int maxValue)
        {
            Random random = new Random();

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    //Index du tableau qui corespond à la tuile
                    int tuileIndex = random.Next(minValue, maxValue);

                    tileList.Add(new Tile(new Vector2(x * 16, y * 16), tuileIndex, false));
                }
            }
        }



        public void Animate(int min, int max, float delay, GameTime gameTime)
        {
            foreach (Tile tile in tileList)
            {
                tile.Animate(min, max, delay, gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tileList)
            {
                tile.Draw(spriteBatch, textureRegion);
            }
        }
    }
}
