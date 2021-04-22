using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Actor;
using PokemonClone.Engine;
using PokemonClone.GameUI;
using PokemonClone.Model;
using System;
using System.Collections.Generic;


namespace PokemonClone.Screen
{
    public class World : IScreen
    {

        private Player player;
        private Trainer trainer;
        private Layer grassLayer;
        public Layer treeLayer;
        private Layer sandLayer;
        private Layer flowerLayer;
        public Layer worldObjectLayer; //testing
        private Camera camera;
        private DialogBox dialogBox;
        private GUI gui;
        private Sprite smallHouse;

        public List<Layer> tileMap;
     
 
        public List<Trainer> trainerList;

        public World()
        {
            trainerList = new List<Trainer>();
            tileMap = new List<Layer>();
            gui = new GUI();
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager content)
        {
            TextureRegion grassTexture = new TextureRegion(content.Load<Texture2D>("TileSet\\grass_tileset"), 16, 16);
            TextureRegion treeTexture = new TextureRegion(content.Load<Texture2D>("TileSet\\tree_tileset"), 16, 16);
            TextureRegion sandGround = new TextureRegion(content.Load<Texture2D>("TileSet\\yellow_ground"), 16, 16);
            TextureRegion playerTexture = new TextureRegion(content.Load<Texture2D>("Actor\\red_walking"), 18, 22);
            TextureRegion flowerTilset = new TextureRegion(content.Load<Texture2D>("TileSet\\flower_tileset"), 16, 16);
            TextureRegion worldObjectTileset = new TextureRegion(content.Load<Texture2D>("TileSet\\object"), 16, 16);
            smallHouse = new Sprite(content.Load<Texture2D>("small_house"), new Rectangle(212,45,73,65));
            
            camera = new Camera();
            player = new Player(this, playerTexture, new Vector2(32, 64));
            player.GetParty(content);
            trainer = new Trainer(this, playerTexture, new Vector2(185, 210),1);
            gui.LoadContent(content);

            grassLayer = new Layer(grassTexture);
            grassLayer.GenerateCustomMap(20, 20, 0, 4);

            sandLayer = new Layer(sandGround);
            sandLayer.GenerateMapFromFile("Map\\sand_map.txt");

            worldObjectLayer = new Layer(worldObjectTileset);
            worldObjectLayer.GenerateMapFromFile("Map\\world_object.txt");

            treeLayer = new Layer(treeTexture);
            treeLayer.GenerateMapFromFile("Map\\tree_map.txt");

            flowerLayer = new Layer(flowerTilset);
            flowerLayer.GenerateMapFromFile("Map\\flower_map.txt");

            tileMap.Add(treeLayer);
            tileMap.Add(worldObjectLayer);

        }

        public void UnloadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            trainer.Update(gameTime);
            camera.Follow(player);
            gui.Update(gameTime);
            flowerLayer.Animate(1,5,150,gameTime);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, camera.transform);
            grassLayer.Draw(spriteBatch);
            sandLayer.Draw(spriteBatch);
            worldObjectLayer.Draw(spriteBatch);
            treeLayer.Draw(spriteBatch);
           
            trainer.Draw(spriteBatch);
            smallHouse.Draw(spriteBatch);
            flowerLayer.Draw(spriteBatch);
            player.Draw(spriteBatch);
         
            spriteBatch.End();

            gui.Draw(spriteBatch);
        }
    }
}
