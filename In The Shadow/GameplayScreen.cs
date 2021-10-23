using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_The_Shadow
{
    public class GameplayScreen : screen
    {

        Game1 game;

        Texture2D Background;
        Texture2D Box;
        Texture2D Button;
        Texture2D DoorRed;
        Texture2D Key;
        Texture2D Gate;
        Texture2D Trap;

        KeyboardState keyboardState;
        KeyboardState old_keyboardState;

        Vector2 velocity;
        AnimatedTexture Player;
        AnimatedTexture Security;
        int ButtonChange = 0;
        bool filpPlayer = false;
        bool walkR = false;
        bool walkL = false;
        Vector2 PlayerPos = new Vector2(300, 506);
        bool Jump = false;
        bool GetKey = false;

        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;

        private static readonly TimeSpan TimeJump = TimeSpan.FromMilliseconds(200);
        private TimeSpan _TimeJump;

        // Box Position
        Vector2 Box1Pos = new Vector2(200, 532);
        Vector2 Box2Pos = new Vector2(100, 358);
        Vector2 Box3Pos = new Vector2(432, 358);

        // Door Position
        Vector2 Door1Pos = new Vector2(656, 46);

        // Button Position
        Vector2 Button1Pos = new Vector2(710, 536);

        // Key Position
        Vector2 Key1Pos = new Vector2(718, 288);

        // Gate Position
        Vector2 Gate1Pos = new Vector2(682, 60);

        // Trap Position
        Vector2 Trap1Pos = new Vector2(672, 288);

        // Sec Position
        Vector2 Sec1Pos = new Vector2(60, 498);
        int SecDi1 = 2;
        bool Sec1Flip = false;

        public GameplayScreen(Game1 game, EventHandler theScreenEvent)
        : base(theScreenEvent)
        {
            //Load the background texture for the screen
            Background = game.Content.Load<Texture2D>("Backgrund800X600");
            Box = game.Content.Load<Texture2D>("woodbox");
            Player = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            Security = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            Security.Load(game.Content, "Security", 5, 1, 10);
            Player.Load(game.Content, "shadow2", 8, 1, 15);
            Button = game.Content.Load<Texture2D>("tileset (botton)");
            DoorRed  = game.Content.Load<Texture2D>("DoorRed");
            Key = game.Content.Load<Texture2D>("key");
            Gate = game.Content.Load<Texture2D>("prison (1)");
            Trap = game.Content.Load<Texture2D>("Trap");

            Player.Pause(0, 0);

            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            float elapsed = (float)theTime.ElapsedGameTime.TotalSeconds;
            keyboardState = Keyboard.GetState();
            Player.UpdateFrame(elapsed);
            Security.UpdateFrame(elapsed);

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                ResetGame();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                PlayerPos.X -= 2;
                filpPlayer = true;
                walkL = true;
                Player.Play();
            }
            else if (old_keyboardState.IsKeyDown(Keys.Left) && keyboardState.IsKeyUp(Keys.Left))
            {
                Player.Pause(0, 0);
                walkL = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                filpPlayer = false;
                PlayerPos.X += 2;
                walkR = true;
                Player.Play();
            }
            else if (old_keyboardState.IsKeyDown(Keys.Right) && keyboardState.IsKeyUp(Keys.Right))
            {
                Player.Pause(0, 0);
                walkR = false;
            }
            old_keyboardState = keyboardState;

            if (PlayerPos.X >= 710)
            {
                PlayerPos.X -= 2;
            }
            if (PlayerPos.X <= 40)
            {
                PlayerPos.X += 2;
            }
            if (PlayerPos.Y < 44)
            {
                velocity.Y = 0f;
            }
            PlayerPos.Y += 2;
            if (!Jump)
            {
                PlayerPos.Y += 2;
            }

            Rectangle charRectangle = new Rectangle((int)PlayerPos.X + 12, (int)PlayerPos.Y, 24, 48);
            Rectangle Platform1 = new Rectangle((int)48, (int)553, 703, 43);
            Rectangle Platform2 = new Rectangle((int)550, (int)503, 26, 53);
            Rectangle Platform3 = new Rectangle((int)576, (int)528, 120, 28);
            Rectangle Platform4 = new Rectangle((int)384, (int)480, 24, 24);
            Rectangle Platform5 = new Rectangle((int)336, (int)456, 24, 24);
            Rectangle Platform6 = new Rectangle((int)288, (int)432, 24, 24);
            Rectangle Platform7 = new Rectangle((int)240, (int)408, 24, 24);
            Rectangle Platform8 = new Rectangle((int)48, (int)384, 164, 24);
            Rectangle Platform9 = new Rectangle((int)408, (int)384, 192, 24);
            Rectangle Platform10 = new Rectangle((int)264, (int)312, 98, 24);
            Rectangle Platform11 = new Rectangle((int)456, (int)312, 24, 24);
            Rectangle Platform12 = new Rectangle((int)504, (int)264, 24, 24);
            Rectangle Platform13 = new Rectangle((int)552, (int)216, 24, 24);
            Rectangle Platform14 = new Rectangle((int)600, (int)168, 24, 24);
            Rectangle Platform15 = new Rectangle((int)648, (int)120, 98, 24);
            Rectangle Platform16 = new Rectangle((int)624, (int)312, 120, 24);

            //Box
            Rectangle Box1 = new Rectangle((int)Box1Pos.X - 2, (int)Box1Pos.Y - 2, 32, 30);
            Rectangle Box2 = new Rectangle((int)Box2Pos.X - 2, (int)Box2Pos.Y - 2, 32, 30);
            Rectangle Box3 = new Rectangle((int)Box3Pos.X - 2, (int)Box3Pos.Y - 2, 32, 30);

            // Button
            Rectangle Button1 = new Rectangle((int)Button1Pos.X - 2, (int)Button1Pos.Y + 12, 32, 18);

            // Door
            Rectangle Door1 = new Rectangle((int)Door1Pos.X, (int)Door1Pos.Y, 16, 76);

            // Key
            Rectangle Key1 = new Rectangle((int)Key1Pos.X, (int)Key1Pos.Y, 24, 24);

            // Gate
            Rectangle Gate1 = new Rectangle((int)Gate1Pos.X, (int)Gate1Pos.Y, 60, 60);

            // Trap 
            Rectangle Trap1 = new Rectangle((int)Trap1Pos.X - 2, (int)Trap1Pos.Y + 12, 32, 18);

            // Sec
            Rectangle Sec1 = new Rectangle((int)Sec1Pos.X +12, (int)Sec1Pos.Y, 27, 48);

            // Sec
            Sec1Pos.X += SecDi1;
            if (Sec1Pos.X <= 40)
            {
                Sec1Flip = false;
                SecDi1 = 2;
            }
            if (Sec1.Intersects(Platform2) || Sec1.Intersects(Box1))
            {
                Sec1Flip = true;
                SecDi1 = -2;
            }
            if (charRectangle.Intersects(Sec1))
            {
                ResetGame();
            }

            if (_TimeJump + TimeJump < theTime.TotalGameTime)
            {
                if (charRectangle.Intersects(Platform1))
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = 506;
                }
            }
            if (charRectangle.Intersects(Platform2))
            {
                if (PlayerPos.Y >= 455 && PlayerPos.Y <= 465)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = 455;
                }
                else if (walkL)
                {
                    PlayerPos.X += 2;
                }
                else if (walkR)
                {
                    PlayerPos.X -= 2;
                }
            }
            if (charRectangle.Intersects(Platform3))
            {
                if (PlayerPos.Y >= 480 && PlayerPos.Y <= 490)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = 480;
                }
                else if (walkL)
                {
                    PlayerPos.X += 2;
                }
                else if (walkR)
                {
                    PlayerPos.X -= 2;
                }
            }

            Platform(charRectangle, Platform4, 384, 480);
            Platform(charRectangle, Platform5, 336, 456);
            Platform(charRectangle, Platform6, 288, 432);
            Platform(charRectangle, Platform7, 240, 408);
            Platform(charRectangle, Platform8, 48, 384);
            Platform(charRectangle, Platform9, 408, 384);
            Platform(charRectangle, Platform10, 264, 312);
            Platform(charRectangle, Platform11, 456, 312);
            Platform(charRectangle, Platform12, 504, 264);
            Platform(charRectangle, Platform13, 552, 216);
            Platform(charRectangle, Platform14, 600, 168);
            Platform(charRectangle, Platform15, 648, 120);
            Platform(charRectangle, Platform16, 624, 312);

            //Box
            BoxCheck(charRectangle, Box1, (int)Box1Pos.X, (int)Box1Pos.Y);
            Box1Pos.X = BoxMove(charRectangle, Box1, Platform2,(int)Box1Pos.X, (int)Box1Pos.Y);

            //Box2
            BoxCheck(charRectangle, Box2, (int)Box2Pos.X, (int)Box2Pos.Y);
            Box2Pos.Y += 2;
            if (Box2.Intersects(Platform4) || Box2.Intersects(Platform5) || Box2.Intersects(Platform6) || Box2.Intersects(Platform7) || Box2.Intersects(Platform8))
            {
                Box2Pos.Y -= 2;
            }
            if (charRectangle.Intersects(Box2))
            {    
                if (PlayerPos.Y >= Box2Pos.Y - 48 && PlayerPos.Y <= Box2Pos.Y - 38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = Box2Pos.Y - 48;
                }
                else if (walkL)
                {
                    Box2Pos.X -= 2;
                    if (Box2.Intersects(Platform2))
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box2.Left < Platform8.Right + 6 && Box2.Intersects(Platform7))
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box2Pos.X < 48)
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                }
                else if (walkR)
                {
                    Box2Pos.X += 2;
                    if (Box2.Intersects(Platform2))
                    {
                        Box2Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (Box2Pos.X > 724)
                    {
                        Box2Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                }
            }

            //Box3
            BoxCheck(charRectangle, Box3, (int)Box3Pos.X, (int)Box3Pos.Y);
            Box3Pos.Y += 2;
            if (Box3.Intersects(Platform4) || Box3.Intersects(Platform5) || Box3.Intersects(Platform3) || Box3.Intersects(Platform1) || Box3.Intersects(Platform9))
            {
                Box3Pos.Y -= 2;
            }
            if (charRectangle.Intersects(Box3))
            {
                if (PlayerPos.Y >= Box3Pos.Y - 48 && PlayerPos.Y <= Box3Pos.Y - 38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = Box3Pos.Y - 48;
                }
                else if (walkL)
                {
                    Box3Pos.X -= 2;
                    if (Box3.Left < Platform2.Right + 2 && Box3.Intersects(Platform2))
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box3.Left < Platform5.Right + 2 && Box3.Intersects(Platform5))
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box3Pos.X < 48)
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                }
                else if (walkR)
                {
                    Box3Pos.X += 2;
                    if (Box3.Intersects(Platform2))
                    {
                        Box3Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (Box3Pos.X > 724)
                    {
                        Box3Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                }
            }

            // Button1
            if (Button1.Intersects(Box3))
            {
                ButtonChange = 1;
            }

            // Door
            if (charRectangle.Intersects(Door1) && ButtonChange == 0)
            {
                if (charRectangle.Right > Door1.Left)
                {
                    PlayerPos.X -= 2;
                }
            }

            // Key
            if (charRectangle.Intersects(Key1))
            {
                GetKey = true;
            }

            if (charRectangle.Intersects(Platform1))
            {
                velocity.Y = 0f;
                Jump = false;
                PlayerPos.Y = 506;
            }

            // Gate
            if (GetKey)
            {
                if (charRectangle.Intersects(Gate1))
                {
                    ScreenEvent.Invoke(game.mGameplayScreen2, new EventArgs());
                }
            }

            // Trap
            if (charRectangle.Intersects(Trap1))
            {
                ResetGame();
            }
           
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Jump == false)
            {
                Jump = true;
                // ปรับแรงกระโดด
                velocity.Y = 6f;

                _TimeJump = theTime.TotalGameTime;
            }

            if (Jump == true)
            {
                PlayerPos.Y -= velocity.Y;
                float i = 1;
                velocity.Y -= 0.15f * i;
            }

            if (Jump == false)
            {
                velocity.Y = 0f;
            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(Background, Vector2.Zero, Color.White);
            theBatch.Draw(Box, Box1Pos, new Rectangle(0, 0, 24, 24), Color.White);
            theBatch.Draw(Box, Box2Pos, new Rectangle(24, 0, 24, 24), Color.White);
            theBatch.Draw(Box, Box3Pos, new Rectangle(24 * 2, 0, 24, 24), Color.White);
            theBatch.Draw(Button, Button1Pos, new Rectangle(24 * ButtonChange, 24, 24, 24), Color.White);
            if (ButtonChange == 0)
            {
                theBatch.Draw(DoorRed, Door1Pos, Color.White);
            }
            if (!GetKey)
            {
                theBatch.Draw(Key, Key1Pos, Color.White);
            }
            if (GetKey)
            {
                theBatch.Draw(Gate, Gate1Pos, new Rectangle(60, 0, 60, 60), Color.White);
            }
            else
            {
                theBatch.Draw(Gate, Gate1Pos, new Rectangle(0, 0, 60, 60), Color.White);
            }
            theBatch.Draw(Trap, Trap1Pos, new Rectangle(24, 0, 24, 24), Color.White);
            Player.DrawFrame(theBatch, PlayerPos, filpPlayer);
            Security.DrawFrame(theBatch, Sec1Pos, Sec1Flip);
            base.Draw(theBatch);
        }

        public void Platform(Rectangle P_rectangle, Rectangle Plat_rectangle, int x, int y)
        {
            if (P_rectangle.Intersects(Plat_rectangle))
            {
                if (PlayerPos.Y >= y-48 && PlayerPos.Y <= y-38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = y-48;
                }
                else if (walkL)
                {
                    PlayerPos.X += 2;
                }
                else if (walkR)
                {
                    PlayerPos.X -= 2;
                }
                if (P_rectangle.Top < Plat_rectangle.Bottom)
                {
                    velocity.Y = 0f;
                }
            }
        }

        public void BoxCheck(Rectangle P_rectangle, Rectangle Box_rectangle, int x, int y)
        {
            if (P_rectangle.Intersects(Box_rectangle))
            {
                if (PlayerPos.Y >= y - 48 && PlayerPos.Y <= y - 38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = y - 48;
                }
            }
        }

        public int BoxMove(Rectangle P_rectangle, Rectangle Box_rectangle, Rectangle Plat_rectangle, int x, int y)
        {
            if (P_rectangle.Intersects(Box_rectangle))
            {
                if (PlayerPos.Y >= y - 48 && PlayerPos.Y <= y - 38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = y - 48;
                }
                else if (walkL)
                {
                    x -= 2;
                    if (Box_rectangle.Intersects(Plat_rectangle))
                    {
                        x += 2;
                        PlayerPos.X += 2;
                    }
                    if (x < 96)
                    {
                        x += 2;
                        PlayerPos.X += 2;
                    }
                }
                else if (walkR)
                {
                    x += 2;
                    if (Box_rectangle.Intersects(Plat_rectangle))
                    {
                        x -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (x > 724)
                    {
                        x -= 2;
                        PlayerPos.X -= 2;
                    }
                }
            }
            return x;
        }

        public void ResetGame()
        {
            ButtonChange = 0;
            filpPlayer = false;
            walkR = false;
            walkL = false;
            PlayerPos = new Vector2(300, 506);
            Jump = false;
            GetKey = false;

            Box1Pos = new Vector2(200, 532);
            Box2Pos = new Vector2(100, 358);
            Box3Pos = new Vector2(432, 358);

            // Door Position
            Door1Pos = new Vector2(656, 46);

            // Button Position
            Button1Pos = new Vector2(710, 536);

            // Key Position
            Key1Pos = new Vector2(718, 288);

            // Gate Position
            Gate1Pos = new Vector2(682, 60);

            // Trap 
            Rectangle Trap1 = new Rectangle((int)Trap1Pos.X - 2, (int)Trap1Pos.Y + 12, 32, 18);

            // Sec Position
            Sec1Pos = new Vector2(60, 498);
            SecDi1 = 2;
            Sec1Flip = false;
        }
    }

}
