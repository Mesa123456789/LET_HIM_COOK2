using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using MonoGame.Extended.ViewportAdapters;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.ComponentModel;
using System.Net.NetworkInformation;
using LET_HIM_COOK.Screen;
using LET_HIM_COOK.Sprite;
using LET_HIM_COOK;


namespace LET_HIM_COOK.Screen
{
    public class GameplayScreen : screen
    {
        RestauarntScreen res;
        Texture2D texture;
        AnimatedTexture SpriteTexture;
        public static Player player;
        Enemy enemy;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        TiledMapObjectLayer _platformTiledObj;
        private readonly List<IEntity> _entities = new List<IEntity>();
        public readonly CollisionComponent _collisionComponent;
        Game1 game;

        public RectangleF Bounds = new RectangleF(new Vector2(750, 440), new Vector2(40, 64));
        Texture2D foodTexture, crabmeat;
        Texture2D hippo, hippomeat;
        Texture2D chicken, chickenmeat;
        Texture2D rat, cheese, pig, pork;
        Texture2D slime, rainbowsmilemeat;
        Texture2D pinkslime, pinksmilemeat, cowmeat, sheepmeat, sheep;
        Texture2D icebear, wipcream;
        Texture2D jellyfish;
        Texture2D popup;
        Texture2D enemytex, enemytexbag, QuestUI, milk, CrispyPork;
        bool Istrue;
        Food[] food = new Food[5];
        ///***new
        Texture2D coriander, grass, greendimon, hippowing, jeelyfishmeat, lemon, meatball, icecream;
        Texture2D Mendrek, noodle, pinkdimon, seafood, shumai, smileeggs;
        Texture2D stone, suki, tempura, purpledimon, Board, BoardInteract;

        

        Vector2 playerPos;// = new Vector2(player.Bounds.Position.X, player.Bounds.Position.Y);
        public GameplayScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            QuestUI = game.Content.Load<Texture2D>("QuestUI");
            Board = game.Content.Load<Texture2D>("Board_");
            BoardInteract = game.Content.Load<Texture2D>("BoardInteract");

            coriander = game.Content.Load<Texture2D>("ingre/coriander");
            grass = game.Content.Load<Texture2D>("ingre/grass");
            greendimon = game.Content.Load<Texture2D>("ingre/greendimon");
            hippowing = game.Content.Load<Texture2D>("ingre/hippowing");
            lemon = game.Content.Load<Texture2D>("ingre/lemon");
            meatball = game.Content.Load<Texture2D>("ingre/meatball");
            Mendrek = game.Content.Load<Texture2D>("ingre/Mendrek");
            noodle = game.Content.Load<Texture2D>("ingre/noodle");
            pinkdimon = game.Content.Load<Texture2D>("ingre/pinkdimon");
            seafood = game.Content.Load<Texture2D>("ingre/seafood");
            shumai = game.Content.Load<Texture2D>("ingre/shumai");
            smileeggs = game.Content.Load<Texture2D>("ingre/smileeggs");
            stone = game.Content.Load<Texture2D>("ingre/stone");
            tempura = game.Content.Load<Texture2D>("ingre/tempura");
            purpledimon = game.Content.Load<Texture2D>("ingre/purpledimon");
            //***new
            milk = game.Content.Load<Texture2D>("ingre/milk");
            popup = game.Content.Load<Texture2D>("popup");
            pinkslime = game.Content.Load<Texture2D>("pinksmaile");
            hippo = game.Content.Load<Texture2D>("hippo");
            chicken = game.Content.Load<Texture2D>("chicken");
            pig = game.Content.Load<Texture2D>("pig");
            pork = game.Content.Load<Texture2D>("ingre/pork");
            rat = game.Content.Load<Texture2D>("rat");
            slime = game.Content.Load<Texture2D>("slime");
            icebear = game.Content.Load<Texture2D>("icebear");
            jellyfish = game.Content.Load<Texture2D>("jellyfish");
            hippomeat = game.Content.Load<Texture2D>("ingre/hippomeat");
            chickenmeat = game.Content.Load<Texture2D>("ingre/chickenmeat");
            cheese = game.Content.Load<Texture2D>("ingre/cheese");
            rainbowsmilemeat = game.Content.Load<Texture2D>("ingre/rainbowsmilemeat");
            pinksmilemeat = game.Content.Load<Texture2D>("ingre/pinksmilemeat");
            wipcream = game.Content.Load<Texture2D>("ingre/wipcream");
            jeelyfishmeat = game.Content.Load<Texture2D>("ingre/jeelyfishmeat");
            ///****
            icecream = game.Content.Load<Texture2D>("ingre/icecream");
            CrispyPork = game.Content.Load<Texture2D>("ingre/Crispy Pork");
            cowmeat = game.Content.Load<Texture2D>("ingre/cow_meat");
            sheepmeat = game.Content.Load<Texture2D>("ingre/sheepmeat");
            sheep = game.Content.Load<Texture2D>("sheep");
            ///

            Game1.enemyList.Add(new Enemy("hippo", hippo, new Food[2] { new Food("hippomeat", hippomeat, new Rectangle(0, 0, 32, 32), true), new Food("hippowing", hippowing, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("pinksmaile", pinkslime, new Food[2] { new Food("pork", pork, new Rectangle(0, 0, 32, 32), true), new Food("smileeggs", smileeggs, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("slime", slime, new Food[1] { new Food("rainbowsmilemeat", rainbowsmilemeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("chicken", chicken, new Food[1] { new Food("chickenmeat", chickenmeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("icebear", icebear, new Food[3] { new Food("cowmeat", cowmeat, new Rectangle(0, 0, 32, 32), false), new Food("milk", milk, new Rectangle(0, 0, 32, 32), false), new Food("stone", stone, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("rat", rat, new Food[1] { new Food("cheese", cheese, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("pig", pig, new Food[1] { new Food("CrispyPork", CrispyPork, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.enemyList.Add(new Enemy("sheep", sheep, new Food[1] { new Food("sheepmeat", sheepmeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            Game1.BagList.Add(new Food("grass", grass, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("greendimon", greendimon, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("lemon", lemon, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("Mendrek", Mendrek, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("noodle", noodle, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("pinkdimon", pinkdimon, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("shumai", shumai, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("stone", stone, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("tempura", tempura, new Vector2(1230, 545)));
            Game1.BagList.Add(new Food("icecream", icecream, new Vector2(1230, 545)));



            var viewportadapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 450);
            Game1._camera = new OrthographicCamera(viewportadapter);//******//
            game._bgPosition = new Vector2(400, 225);//******//
            game._cameraPosition = new Vector2(400, 200);
            SpriteTexture = new AnimatedTexture(new Vector2(16, 16), 0, 2f, 1f);
            SpriteTexture.Load(game.Content, "Player-Sheet", 5, 4, 10);
            player = new Player(SpriteTexture, new Vector2(1500, 400), game, Bounds);
            player.Load(game.Content, "Sword");
            player.Load(game.Content, "Effect");
            //Load the background texture for the screen
            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 1600, 900));
            _tiledMap = game.Content.Load<TiledMap>("Tile_FrontRestaurant");
            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Tile_Wall_Frontres")
                {
                    _platformTiledObj = layer;
                }
            }
            foreach (TiledMapObject obj in _platformTiledObj.Objects)
            {
                Vector2 position = new Vector2(obj.Position.X, obj.Position.Y);
                _entities.Add(new PlatformEntity(game, new RectangleF(position, obj.Size)));
            }

            _entities.Add(player);
            foreach (IEntity entity in _entities)
            {
                _collisionComponent.Insert(entity);
            }
            this.game = game;
        }
        RectangleF doorRec = new RectangleF(750, 400, 100, 20);
        RectangleF SeaMapRec = new RectangleF(700, 880, 100, 10);
        RectangleF CandyMapRec = new RectangleF(0, 400, 50, 100);
        RectangleF mouseRec;
        RectangleF BoardInteractRec = new RectangleF(900, 400, 96, 64);
        Vector2 popupPos;
        public static Vector2 mousepos;
        public static Vector2 posMouse;
        public static RectangleF mouseCheck;
        public static bool EnterDoor = false;
        bool questInteract = false;
        public static bool openQuest = false;
        bool onRandom = true;
        bool onQuest = false;
        static Random randomQuest = new Random();
        public override void Update(GameTime theTime)
        {
            MouseState ms = Mouse.GetState();
            mousepos = Mouse.GetState().Position.ToVector2();
            posMouse = new Vector2(mousepos.X + (game._cameraPosition.X), mousepos.Y + (game._cameraPosition.Y));
            mouseCheck = new Rectangle((int)posMouse.X, (int)posMouse.Y, 24, 24);

            popupPos = new Vector2(700, 400);
            popupRec = new Rectangle(700, 400, 100, 50);
            //if (mouseCheck.Intersects(popupRec) && ms.LeftButton == ButtonState.Pressed)
            //{
            //    popupRec.X += 10;
            //}
            if (!player.Bounds.Intersects(doorRec) && !player.Bounds.Intersects(CandyMapRec) && !player.Bounds.Intersects(SeaMapRec))
            {
                GameplayScreen.EnterDoor = false;
            }
            if (player.Bounds.Intersects(doorRec) && !EnterDoor)
            {
                EnterDoor = true;
                RestauarntScreen.IsCooking = true;
                ScreenEvent.Invoke(game.RestauarntScreen, new EventArgs());
                return;
            }
            if (player.Bounds.Intersects(CandyMapRec) && !EnterDoor)
            {
                EnterDoor = true;
                ScreenEvent.Invoke(game.CandyScreen, new EventArgs());
                game._cameraPosition = new Vector2(800, 200);
                return;
            }
            if (player.Bounds.Intersects(SeaMapRec) && !EnterDoor)
            {
                EnterDoor = true;
                ScreenEvent.Invoke(game.SeaScreen, new EventArgs());
                // player.Bounds.Position = new Vector2(780, 64);
                game._cameraPosition = new Vector2(440, 0);
                return;
            }

            if (player.Bounds.Intersects(BoardInteractRec))
            {
                questInteract = true;
                if (mouseCheck.Intersects(BoardInteractRec) && ms.LeftButton == ButtonState.Pressed)
                {
                    openQuest = true;
                    Game1.closeXBox = false;
                }
            }
            else
            {
                onRandom = false;
                openQuest = false;
                questInteract = false;
            }
            if (openQuest == true)
            {

                onQuest = randomQuest.Next(0, 2) == 0;
                if (onQuest && !onRandom)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        int getQuest = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        int getQuest2 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        int getQuest3 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        if (getQuest == getQuest2 || getQuest == getQuest3)
                        {
                            getQuest = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        }
                        if (getQuest2 == getQuest3 || getQuest2 == getQuest)
                        {
                            getQuest2 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        }
                        if (getQuest3 == getQuest2 || getQuest == getQuest3)
                        {
                            getQuest3 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        }
                        RestauarntScreen.QuestList[getQuest] = true;
                        Console.WriteLine(RestauarntScreen.QuestList);
                        Console.WriteLine(getQuest);
                        Console.WriteLine(getQuest2);
                        Console.WriteLine(getQuest3);

                    }
                    onRandom = true;
                }
            }

            for (int i = Game1.enemyList.Count - 1; i >= 0; i--)
            {
                player.Attack(Game1.enemyList[i]);
            }
            for (int i = Game1.enemyList.Count - 1; i >= 0; i--)
            {
                Game1.enemyList[i].Follow(player);
            }
            for (int i = 0; i < Game1.BagList.Count; i++)
            {
                Game1.BagList[i].Update(theTime);
            }

            for (int i = Game1.foodList.Count - 1; i >= 0; i--)
            {
                Game1.foodList[i].Update(theTime);
            }
            for (int i = Game1.enemyList.Count - 1; i >= 0; i--)
            {
                Game1.enemyList[i].Update(theTime);
            }

            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);

            Game1._camera.LookAt(game._bgPosition + game._cameraPosition);//******//
            player.Update(theTime);
            base.Update(theTime);
        }
        Rectangle popupRec;

        public override void Draw(SpriteBatch _spriteBatch)
        {

            var transformMatrix = Game1._camera.GetViewMatrix();//******//
            _tiledMapRenderer.Draw(transformMatrix);//******//
            _spriteBatch.End();
            _spriteBatch.Begin(transformMatrix: transformMatrix, samplerState: SamplerState.PointClamp);//******//
            _spriteBatch.Draw(Board, new Rectangle(900, 400, 96, 64), Color.White);
            if (questInteract)
            {
                _spriteBatch.Draw(BoardInteract, new Rectangle(900, 400, 96, 64), Color.White);
            }

            //_spriteBatch.Draw(popup,popupRec, Color.White);
            foreach (Food food in Game1.foodList)
            {
                for (int i = 0; i < Game1.foodList.Count; i++)
                {
                    Game1.foodList[i].Draw(_spriteBatch);
                }
            }
            foreach (Enemy enemy in Game1.enemyList)
            {
                for (int i = 0; i < Game1.enemyList.Count; i++)
                {
                    Game1.enemyList[i].Draw(_spriteBatch);
                }
            }
            player.Draw(_spriteBatch);
            //_spriteBatch.Draw(crabmeat,new Rectangle(700,400,32,32), Color.White);




        }


    }
}