﻿
using LET_HIM_COOK.Screen;
using LET_HIM_COOK.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LET_HIM_COOK
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public GameplayScreen GameplayScreen;
        public CandyScreen CandyScreen;
        public SeaScreen SeaScreen;

        public RestauarntScreen RestauarntScreen;
        public TitleScreen TitleScreen;
        public screen mCurrentScreen;
        public Vector2 _bgPosition;
        Player player;
        public static Vector2 move;
        public static OrthographicCamera _camera;
        public Vector2 _cameraPosition;
        ///****/
        public Texture2D book;
        Texture2D ui;
        public Texture2D uiHeart;
        Texture2D inventory;
        Texture2D popup;
        Texture2D FridgeUi;
        Texture2D bookUi;
        public Texture2D QuestUI;
        public Texture2D Quest;
        public RectangleF questboxRec;
        public RectangleF bagRec;
        public Texture2D bag,ok;
        Texture2D interact , craft, hippomeat, hippo, lemon;
        Texture2D ayinomoto, chili, oil, milk, salt2, sauce2, rice, sugar, seafood,suki,bin, coriander;
        bool Istrue;
        public static List<Food> BagList = new List<Food>();
        public static List<Food> foodList = new();
        public static List<Enemy> enemyList = new();
        public static List<Food> CraftList = new List<Food>();
        public static Texture2D Uni;
        public static List<Food> ingredentList = new List<Food>();
        public static List<Food> seasoningList = new List<Food>();
        public static List<Food> MenuList = new List<Food>();
        public static List<Vector2> inventBox = new();

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 450;
            //_graphics.ToggleFullScreen();
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }
        AnimatedTexture SpriteTexture;
        Vector2 playerPos;
        Game1 game;
        public RectangleF Bounds = new RectangleF(new Vector2(750, 440), new Vector2(40, 60));
        protected override void Initialize()
        {
            GotMenu = false;
            havQ = false;
            base.Initialize();
        }
        public static int currentHeart;

        protected override void LoadContent()
        {
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 2f, 1f);
            SpriteTexture.Load(Content, "PlayerIdel", 5, 4, 5);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            lemon = Content.Load<Texture2D>("ingre/lemon");
            bin = Content.Load<Texture2D>("bin");
            ui = Content.Load<Texture2D>("ui");
            uiHeart = Content.Load<Texture2D>("uiHeart");
            interact = Content.Load<Texture2D>("interact");
            book = Content.Load<Texture2D>("book");
            Quest = Content.Load<Texture2D>("Quest");
            bag = Content.Load<Texture2D>("bag");
            FridgeUi = Content.Load<Texture2D>("FridgeUI");
            bookUi = Content.Load<Texture2D>("BookUI");
            QuestUI = Content.Load<Texture2D>("QuestUI");
            inventory = Content.Load<Texture2D>("inventory");
            popup = Content.Load<Texture2D>("popup");
            craft = Content.Load<Texture2D>("craft");
            Uni = Content.Load<Texture2D>("Uni");
            ayinomoto = Content.Load<Texture2D>("ingre/ayinomoto");
            chili = Content.Load<Texture2D>("ingre/chili");
            oil = Content.Load<Texture2D>("ingre/oil");
            salt2 = Content.Load<Texture2D>("ingre/salt2");
            sauce2 = Content.Load<Texture2D>("ingre/sauce2");
            rice = Content.Load<Texture2D>("ingre/rice");
            sugar = Content.Load<Texture2D>("ingre/sugar");
            suki = Content.Load<Texture2D>("ingre/suki");
            seafood = Content.Load<Texture2D>("ingre/seafood");
            ok = Content.Load<Texture2D>("button");
            coriander = Content.Load<Texture2D>("ingre/coriander");
            //**
            hippomeat = Content.Load<Texture2D>("ingre/hippomeat");
            hippo = Content.Load<Texture2D>("hippo");
            //**
            inventBox.Add(new Vector2(161, 250));
            inventBox.Add(new Vector2(161 + 52, 250));
            inventBox.Add(new Vector2(161 + (52 * 2), 250));
            inventBox.Add(new Vector2(161 + (52 * 3), 250));
            inventBox.Add(new Vector2(161 + (52 * 4), 250));
            inventBox.Add(new Vector2(161 + (52 * 5), 250));
            inventBox.Add(new Vector2(161 + (52 * 6), 250));
            inventBox.Add(new Vector2(161 + (52 * 7), 250));
            inventBox.Add(new Vector2(161 + (52 * 8), 250));
            inventBox.Add(new Vector2(161 + (52 * 9), 250));
            inventBox.Add(new Vector2(161, 305));
            inventBox.Add(new Vector2(161 + 52, 305));
            inventBox.Add(new Vector2(161 + (52 * 2), 305));
            inventBox.Add(new Vector2(161 + (52 * 3), 305));
            inventBox.Add(new Vector2(161 + (52 * 4), 305));
            inventBox.Add(new Vector2(161 + (52 * 5), 305));
            inventBox.Add(new Vector2(161 + (52 * 6), 305));
            inventBox.Add(new Vector2(161 + (52 * 7), 305));
            inventBox.Add(new Vector2(161 + (52 * 8), 305));
            inventBox.Add(new Vector2(161 + (52 * 9), 305));
            inventBox.Add(new Vector2(161, 361));
            inventBox.Add(new Vector2(161 + 52, 361));
            inventBox.Add(new Vector2(161 + (52 * 2), 361));
            inventBox.Add(new Vector2(161 + (52 * 3), 361));
            inventBox.Add(new Vector2(161 + (52 * 4), 361));
            inventBox.Add(new Vector2(161 + (52 * 5), 361));
            inventBox.Add(new Vector2(161 + (52 * 6), 361));
            inventBox.Add(new Vector2(161 + (52 * 7), 361));
            inventBox.Add(new Vector2(161 + (52 * 8), 361));
            inventBox.Add(new Vector2(161 + (52 * 9), 361));
            inventBox.Add(new Vector2(161, 430));
            inventBox.Add(new Vector2(161 + 52, 430));
            inventBox.Add(new Vector2(161 + (52 * 2), 430));
            inventBox.Add(new Vector2(161 + (52 * 3), 430));
            inventBox.Add(new Vector2(161 + (52 * 4), 430));
            inventBox.Add(new Vector2(161 + (52 * 5), 430));
            inventBox.Add(new Vector2(161 + (52 * 6), 430));
            inventBox.Add(new Vector2(161 + (52 * 7), 430));
            inventBox.Add(new Vector2(161 + (52 * 8), 430));
            inventBox.Add(new Vector2(161 + (52 * 9), 430));
            inventBox.Add(new Vector2(161 + (52 * 10), 430));
            inventBox.Add(new Vector2(161 + (52 * 11), 430));
            ///Texture2D ayinomoto, chili, oil, milk, salt2, sauce2, rice, sugar;
            seasoningList.Add(new Food("ayinomoto", ayinomoto, false, new Vector2(271, 195), new Rectangle(271, 183, 32, 32)));
            seasoningList.Add(new Food("chili", chili, false, new Vector2(271 + 52, 183), new Rectangle(271 + 52 , 183, 32, 32)));
            seasoningList.Add(new Food("oil", oil, false, new Vector2(271 + (52 * 2), 183), new Rectangle(271 + (52*2), 183, 32, 32)));
            seasoningList.Add(new Food("lemon", lemon, false, new Vector2(271 + (52 * 2), 183), new Rectangle(271 + (52 * 3), 183, 32, 32)));
            seasoningList.Add(new Food("salt2", salt2, false, new Vector2(271 + (52 * 4), 183), new Rectangle(271 + (52 * 4), 183, 32, 32)));
            seasoningList.Add(new Food("sauce2", sauce2, false, new Vector2(271, 237), new Rectangle(271, 237, 32, 32)));
            seasoningList.Add(new Food("coriander", coriander, false, new Vector2(271 + 52, 237), new Rectangle(271 + 52, 237, 32, 32)));
            seasoningList.Add(new Food("sugar", sugar, false, new Vector2(271 + (52 * 2)), new Rectangle(271 + (52 * 2), 237, 32, 32)));
            seasoningList.Add(new Food("suki", suki, false, new Vector2(271 + (52 * 3)), new Rectangle(271 + (52 * 3), 237, 32, 32)));
            seasoningList.Add(new Food("seafood", seafood, false, new Vector2(271 + (52 * 4)), new Rectangle(271 + (52 * 4), 237, 32, 32)));

            ///***สุตรโกง
            //BagList.Add(new Food("ayinomoto", ayinomoto, false, new Vector2(271, 195), new Rectangle(271, 183, 32, 32)));
            //BagList.Add(new Food("chili", chili, false, new Vector2(271 + 52, 183), new Rectangle(271 + 52, 183, 32, 32)));
            //BagList.Add(new Food("oil", oil, false, new Vector2(271 + (52 * 2), 183), new Rectangle(271 + (52 * 2), 183, 32, 32)));
            //BagList.Add(new Food("milk", milk, false, new Vector2(271 + (52 * 3), 183), new Rectangle(273 + (52 * 3), 183, 32, 32)));
            //BagList.Add(new Food("salt2", salt2, false, new Vector2(271 + (52 * 4), 183), new Rectangle(271 + (52 * 4), 183, 32, 32)));
            //BagList.Add(new Food("sauce2", sauce2, false, new Vector2(271, 237), new Rectangle(271, 237, 32, 32)));
            //BagList.Add(new Food("rice", rice, false, new Vector2(271 + 52, 237), new Rectangle(271 + 52, 237, 32, 32)));
            //BagList.Add(new Food("sugar", sugar, false, new Vector2(271 + (52 * 2)), new Rectangle(271 + (52 * 2), 237, 32, 32)));
  


            ///***///
            TitleScreen = new TitleScreen(this, new EventHandler(GameplayScreenEvent));
            RestauarntScreen = new RestauarntScreen(this, new EventHandler(GameplayScreenEvent));
            GameplayScreen = new GameplayScreen(this, new EventHandler(GameplayScreenEvent));
            CandyScreen = new CandyScreen(this, new EventHandler(GameplayScreenEvent));
            SeaScreen = new SeaScreen(this, new EventHandler(GameplayScreenEvent));
            
            mCurrentScreen = TitleScreen;
            currentHeart = CandyScreen.uiHeart.Width - 10;
        }
        public RectangleF bookRec;
        public RectangleF mouseRec;
        public RectangleF XboxQ;
        public RectangleF xBox;
        bool OnCursor1;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
           Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
            if (mCurrentScreen != TitleScreen)
            {
                UpDateUI(gameTime);
            }
            mCurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            mCurrentScreen.Draw(_spriteBatch);
            _spriteBatch.End();
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            if (mCurrentScreen != TitleScreen)
            {
                DrawUiGameplay(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }
        public void UpdateCamera(Vector2 move)
        {
            _camera.LookAt(_bgPosition + _cameraPosition);//******//
            _cameraPosition += move;
        }
        public float GetCameraPosX()
        {
            return _cameraPosition.X;
        }
        public float GetCameraPosY()
        {
            return _cameraPosition.Y;
        }
        bool OncursorXBOX = false;
        bool OncursorxboxQ = false;
        public static bool closeXBox = false;
        bool closeXBoxQuest = false;
        public bool ShowInventory = false;
        public static bool IsPopUp = false;
        public static RectangleF doorRec = new RectangleF(120, 40, 200, 20);
        bool IssendMenuInterect = false;
        bool IsInterect = false;
        public static bool Ontable = false;
        public static bool GotMenu = false;
        bool Crafting = false;
        int MenuPopup;
        bool IsFrigeInterect = false;
         public static bool sendingMenu = false;
        public static bool getUni;
        Rectangle craftBox;
        Rectangle xBoxFride;
        bool xBoxFrideCursor;
        int rotationMenuBG;
        public static bool finsihcraft;
        public static bool havQ;
        public void UpdateUIRest(Player player , GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            mouseRec = new RectangleF(ms.X, ms.Y, 50, 50);
            RectangleF FrigeRec = new RectangleF(352, 115, 40, 50);
            RectangleF tableBox = new RectangleF(450, 150, 130, 20);
            RectangleF sendMenu = new RectangleF(600, 240, 40, 30);
            RectangleF equal = new RectangleF(345, 140, 120, 50);
            Rectangle xBoxFride = new Rectangle(560,87,35,35);
            if (player.Bounds.Intersects(FrigeRec))
            {
                IsFrigeInterect = true;
                if (mouseRec.Intersects(FrigeRec) && ms.LeftButton == ButtonState.Pressed)
                {
                    openFridgeUI = true;
                }
            }
            if (mouseRec.Intersects(xBoxFride) && ms.LeftButton == ButtonState.Pressed || !player.Bounds.Intersects(FrigeRec))
            {
                openFridgeUI = false;
            }
            if (mouseRec.Intersects(xBoxFride))
            {
                xBoxFrideCursor = true;
            }
            else
            {
                xBoxFrideCursor = false;
            }

            if (player.Bounds.Intersects(tableBox))
            {
                IsInterect = true;
                if (ms.LeftButton == ButtonState.Pressed && mouseRec.Intersects(tableBox))
                {
                    Ontable = true;
                }
            }
            else
            {
                IsInterect = false;
                Ontable = false;
            }

            if (player.Bounds.Intersects(sendMenu))
            {
                IssendMenuInterect = true;
                if (mouseRec.Intersects(sendMenu) && ms.LeftButton == ButtonState.Pressed && GotMenu == true)
                {
                    sendingMenu = true;
                }
            }
            else
            {
                IssendMenuInterect = false;
            }
            if (rotationMenuBG < 360)
            {
                rotationMenuBG++;
            }
            if (rotationMenuBG == 360)
            {
                rotationMenuBG = 0;
            }
        }
        public void DrawUIRest(SpriteBatch _spriteBatch)
        {

            if (openFridgeUI == true)
            {
                _spriteBatch.Draw(FridgeUi, new Vector2(0, 0), Color.White);
                for (int i = 0; i < Game1.seasoningList.Count; i++)
                {
                    _spriteBatch.Draw(seasoningList[i].foodTexBag, seasoningList[i].foodRec, Color.White);
                }
                if (xBoxFrideCursor == false)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(560, 87), new Rectangle(745 + 64, 81, 64, 40), Color.White);
                }
                if (xBoxFrideCursor == true)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(560, 87), new Rectangle(745, 81, 64, 40), Color.White);
                }

            }
           
        }
        MouseState ms, msPre;
        public void UpDateUI(GameTime gameTime)
        {
            ms = Mouse.GetState();
            mouseRec = new RectangleF(ms.X, ms.Y, 50, 50);
            bagRec = new Rectangle(750, 25, 25, 20);
            bookRec = new RectangleF(755, 100, 25, 15);
            questboxRec = new Rectangle(750, 150, 25, 20);//680, 30
            xBox = new Rectangle(650, 75, 30, 30);
            XboxQ = new Rectangle(680, 30, 30, 30);
            Rectangle qBox1 = new Rectangle(152, 144, 145, 180);
            Rectangle qBox2 = new Rectangle(326, 144, 145, 180);
            Rectangle qBox3 = new Rectangle(511, 144, 145, 180);

            if (mouseRec.Intersects(bookRec) && ms.LeftButton == ButtonState.Pressed)
            {
                closeXBoxQuest = false;
                closeXBox = false;
                openbookUI = true;
                openQuestUI = false;
                ShowInventory = false;
            }
            else { OnCursor1 = false; }
            if (mouseRec.Intersects(questboxRec) && ms.LeftButton == ButtonState.Pressed)
            {
                closeXBox = false;
                openQuestUI = true;
                ShowInventory = false;
                openbookUI = false;
            }
            else { OnCursor2 = false; }
            if (mouseRec.Intersects(bagRec))
            {
                OnCursor = true;
                if (ms.LeftButton == ButtonState.Pressed && mouseRec.Intersects(bagRec))
                {
                    closeXBox = false;
                    ShowInventory = true;
                    openQuestUI = false;
                    openbookUI = false;
                }
            }
            else { OnCursor = false; }
            if (mouseRec.Intersects(xBox) && ms.LeftButton == ButtonState.Pressed)
            {
                closeXBox = true;
                openbookUI = false;
                ShowInventory = false;
                openQuestUI = false;
            }
            if (mouseRec.Intersects(XboxQ) && ms.LeftButton == ButtonState.Pressed)
            {
                GameplayScreen.openQuest = false;
                closeXBoxQuest = true;
                closeXBox = false;
                openbookUI = false;
                ShowInventory = false;
                openQuestUI = false;
            }
            if (mouseRec.Intersects(xBox)) { OnCursorXBOX = true; }
            else { OnCursorXBOX = false; }
            if (mouseRec.Intersects(XboxQ)) { OncursorxboxQ = true; }
            else { OncursorxboxQ = false; }
            if (mouseRec.Intersects(bookRec)) { OnCursor1 = true; }
            else { OnCursor1 = false; }
            if (mouseRec.Intersects(questboxRec)) { OnCursor2 = true; }
            else { OnCursor2 = false; }
            if (ShowInventory) { OnCursor1 = false; OnCursor2 = false; }
            if (openbookUI) { OnCursor = false; OnCursor2 = false; }
            if (openQuestUI) { OnCursor = false; OnCursor1 = false; }
            if (currentHeart < 60) { color = Color.Red; }
            else { color = Color.White; }
            
            Rectangle binRec = new Rectangle(685, 250,50,80);
            if (mouseRec.Intersects(binRec)) 
            { 
                bincursor = true;

                if (ms.LeftButton == ButtonState.Pressed && msPre.LeftButton == ButtonState.Released)
                {
                    if (mouseRec.Intersects(binRec))
                    {
                        openBin = !openBin;
                    }
                }
            }
            else
            {
                bincursor =  false;
            }
            if (ShowInventory == true)
            {
                for(int i = 0; i < BagList.Count; i++)
                {
                    foreach (Food food in BagList)
                    {
                        BagList[i].foodPosition = inventBox[i];
                        
                    }
                    Rectangle inventoryBox = new Rectangle((int)inventBox[i].X - 7, (int)inventBox[i].Y - 93, 32, 32);
                    if (mouseRec.Intersects(inventoryBox) && ms.LeftButton == ButtonState.Released && msPre.LeftButton == ButtonState.Pressed && openBin == true)
                    {
                        foreach(Food food in BagList)
                        {
                            BagList.RemoveAt(i);
                            break;
                        }
                    }
                    
                }
            }  
            if (mouseRec.Intersects(qBox1))
            {
                cursorQuest = true;
            }
            else
            {
                cursorQuest = false;
            }
            if (mouseRec.Intersects(qBox2))
            {
                cursorQuest2 = true;
            }
            else
            {
                cursorQuest2 = false;
            }
            if (mouseRec.Intersects(qBox3))
            {
                cursorQuest3 = true;
            }
            else
            {
                cursorQuest3 = false;
            }
            if (GameplayScreen.openQuest == true)
            {
                RestauarntScreen.QuestList[GameplayScreen.getQuest].QuestRec = qBox1;
                RestauarntScreen.QuestList[GameplayScreen.getQuest2].QuestRec = qBox2;
                RestauarntScreen.QuestList[GameplayScreen.getQuest3].QuestRec = qBox3;
                count++;
                if (count > 20 && havQ == false)
                {
                    Select = true;
                    Console.WriteLine(havQ);
                }
            }
            else
            {
                count = 0;
                Select = false;
            }
            if (!havQ)
            {
                for (int i = 0; i < RestauarntScreen.QuestList.Count; i++)
                {
                    if (mouseRec.Intersects(RestauarntScreen.QuestList[i].QuestRec) && ms.LeftButton == ButtonState.Released && msPre.LeftButton == ButtonState.Pressed && Select == true)
                    {
                        RestauarntScreen.QuestList[i].Menuname = true;
                        bool[] menu = new bool[27];
                        menu[i] = RestauarntScreen.QuestList[i].Menuname;
                        GameplayScreen.Oncraft(menu[i], i);
                        Selected = true;
                        Console.WriteLine(RestauarntScreen.QuestList[i].Menuname + "" + i);
                        havQ = true;
                    }
                }
            }
            msPre = ms;
            UpdateFream((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
        public static bool Menu1;
        int count;
        public static bool Select,Selected;
        bool cursorQuest, cursorQuest2, cursorQuest3;
        bool openBin, click;
        bool throwbin;
        bool bincursor;
        bool drawBag1, drawBag2;
        Color color = Color.White;
        bool OnCursor = false;
        bool OnCursor2 = false;
        bool OnCursorXBOX = false;
        bool openbookUI = false;
        bool openQuestUI = false;
        public static bool openFridgeUI = false;
        int mouse_state = 1;
  
        public void DrawUiGameplay(SpriteBatch _spriteBatch)
        {
            //for (int i = 0; i < MenuList.Count; i++)
            //{
            //    _spriteBatch.Draw(MenuList[i].foodTexBag, MenuList[i].foodRec, new Rectangle(189, 160, 32, 32), Color.White);
            //}
           
            foreach (Food food in BagList)
            {
                if (IsPopUp == true)
                {
                    for (int i = 0; i < BagList.Count; i++)
                    {
                        _spriteBatch.Draw(popup, new Vector2(635, 170), Color.White);
                        _spriteBatch.Draw(BagList[i].foodTexBag, new Rectangle(653, 180, 32,32), new Rectangle(0,0,32,32), Color.White);
                        if (BagList[i].Two == true)
                        {
                            _spriteBatch.Draw(hippomeat, new Rectangle(653 + 40, 180, 32, 32), new Rectangle(0, 0, 32, 32), Color.White);
                        }
                    }
                    CountTime(1000);
                }
            }

            if (GameplayScreen.openQuest)
            {
                _spriteBatch.Draw(QuestUI, new Vector2(0, 0), new Rectangle(0, 0, 700, 400), Color.White);
                for(int i = 0; i < RestauarntScreen.QuestList.Count; i++)
                {
                    _spriteBatch.Draw(RestauarntScreen.QuestList[GameplayScreen.getQuest].quest1, new Vector2(161 - 9, 144), new Rectangle(0, 0, 145, 180), Color.White);
                    if (cursorQuest)
                    {
                        _spriteBatch.Draw(RestauarntScreen.QuestList[GameplayScreen.getQuest].quest2, new Vector2(161 - 9, 144), new Rectangle(0, 0, 145, 180), Color.White);
                    }
                    _spriteBatch.Draw(RestauarntScreen.QuestList[GameplayScreen.getQuest2].quest1, new Vector2(336-9, 144), new Rectangle(0, 0, 145, 180), Color.White);
                    if (cursorQuest2)
                    {
                        _spriteBatch.Draw(RestauarntScreen.QuestList[GameplayScreen.getQuest2].quest2, new Vector2(336 - 9, 144), new Rectangle(0, 0, 145, 180), Color.White);
                    }
                    _spriteBatch.Draw(RestauarntScreen.QuestList[GameplayScreen.getQuest3].quest1, new Vector2(511 - 9, 144), new Rectangle(0, 0, 145, 180), Color.White);
                    if (cursorQuest3)
                    {
                        _spriteBatch.Draw(RestauarntScreen.QuestList[GameplayScreen.getQuest3].quest2, new Vector2(511 - 9, 144), new Rectangle(0, 0, 145, 180), Color.White);
                    }
                }
                if (closeXBox == false)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(655, 35), new Rectangle(745 + 64, 81, 64, 40), Color.White);
                }
                if (OnCursorXBOX == true)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(655, 35), new Rectangle(745 , 81, 64, 40), Color.White);
                }
            }
            if (openbookUI == true)
            {
                _spriteBatch.Draw(bookUi, new Vector2(150, 0), new Rectangle(153, 0, 800, 500), Color.White);
                if (OncursorxboxQ == false)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(683, 20), new Rectangle(745 + 64, 81, 64, 40), Color.White);
                }
                if (OncursorxboxQ == true)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(683, 20), new Rectangle(745, 81, 64, 40), Color.White);
                }
            }
            if (ShowInventory == true)
            {
                _spriteBatch.Draw(inventory, new Vector2(123, 125), Color.White);
                if (openBin == false)
                {
                    _spriteBatch.Draw(bin, new Vector2(685, 250 + 38), new Rectangle(0, 38, 50, 42), Color.White);
                }
                else if (openBin)
                {
                    _spriteBatch.Draw(bin, new Vector2(685, 250), new Rectangle(50 * frame, 0, 50, 80), Color.White);
                }

                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTexBag, new Vector2( inventBox[i].X-7, inventBox[i].Y-93), new Rectangle(0, 0, 32, 32), Color.White);
                }
                if (closeXBox == false)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(650, 60), new Rectangle(745 + 64, 81, 64, 40), Color.White);
                }
                if (OnCursorXBOX == true)
                {
                    _spriteBatch.Draw(QuestUI, new Vector2(650, 60), new Rectangle(745, 81, 64, 40), Color.White);
                }
            }
            _spriteBatch.Draw(bag, new Vector2(735, 15), new Rectangle(64, 0, 48, 44), Color.White);
            if (OnCursor == true || ShowInventory)
            {
                _spriteBatch.Draw(bag, new Vector2(735 - 2, 15), new Rectangle(1, 0, 63, 44), Color.White);
            }
            _spriteBatch.Draw(book, new Vector2(735, 65), new Rectangle(64, 0, 48, 44), Color.White);
            if (OnCursor1 == true || openbookUI)
            {
                _spriteBatch.Draw(book, new Vector2(735-2, 65), new Rectangle(1, 0, 63, 44), Color.White);
            }
            _spriteBatch.Draw(Quest, new Vector2(735, 115), new Rectangle(64, 0, 48, 44), Color.White);
            if (OnCursor2 == true || openQuestUI == true)
            {
                _spriteBatch.Draw(Quest, new Vector2(735-2, 115), new Rectangle(1, 0, 63, 44), Color.White);
            }
            _spriteBatch.Draw(uiHeart, new Vector2(110, 22),
new Rectangle(0, 0, currentHeart + 10, 18), color);
            _spriteBatch.Draw(ui, new Vector2(6, 6), Color.White);
            SpriteTexture.DrawFrame(_spriteBatch, new Vector2(23, 25), 1);

        }
        public int countPopUp;
        public void CountTime(int timePopup)
        {
            countPopUp += 1;
            {
                if (countPopUp > timePopup)
                {
                    countPopUp = 0;
                    IsPopUp = false;

                }
            }
        }
        public int frame;
        public int framePerSec;
        public float totalElapsed;
        public float timePerFream;
        void UpdateFream(float elapsed)
        {
            framePerSec = 6;
            //timePerFream = (float)1 / framePerSec;
            //totalElapsed += elapsed;
            frame = frame + 1;
            if(frame >= 4)
            {
                frame = 4;
            }
            //if (totalElapsed > timePerFream)
            //{
            //    frame = (frame + 1) % 5;
            //    totalElapsed -= timePerFream;
            //}
        }



    }
}
