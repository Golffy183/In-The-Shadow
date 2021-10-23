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
    public class GameplayScreen2 : screen
    {

        Game1 game;

        Texture2D Background;
        Texture2D Box;
        Texture2D Button;
        Texture2D DoorRed;
        Texture2D DoorGreen;
        Texture2D Key;
        Texture2D Gate;
        Texture2D Trap;

        KeyboardState keyboardState;
        KeyboardState old_keyboardState;

        Vector2 velocity;
        AnimatedTexture Player;
        AnimatedTexture Security;
        int ButtonChange = 0;
        int ButtonChange2 = 0;
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
        Vector2 Box1Pos = new Vector2(166, 456);
        Vector2 Box2Pos = new Vector2(142, 240);
        Vector2 Box3Pos = new Vector2(648, 264);

        // Door Position
        Vector2 Door1Pos = new Vector2(654, 46);
        Vector2 Door2Pos = new Vector2(640, 309);

        // Button Position
        Vector2 Button1Pos = new Vector2(48, 540);
        Vector2 Button2Pos = new Vector2(720, 268);

        // Key Position
        Vector2 Key1Pos = new Vector2(720, 360);

        // Gate Position
        Vector2 Gate1Pos = new Vector2(682, 60);

        // Trap Position
        Vector2 Trap1Pos = new Vector2(500, 144);
        Vector2 Trap2Pos = new Vector2(626, 144);

        // Sec Position
        Vector2 Sec1Pos = new Vector2(312, 422);
        int SecDi1 = 2;
        bool Sec1Flip = false;

        public GameplayScreen2(Game1 game, EventHandler theScreenEvent)
        : base(theScreenEvent)
        {
            //Load the background texture for the screen
            Background = game.Content.Load<Texture2D>("Level_2");
            Box = game.Content.Load<Texture2D>("woodbox");
            Player = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            Security = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            Security.Load(game.Content, "Security", 5, 1, 10);
            Player.Load(game.Content, "shadow2", 8, 1, 15);
            Button = game.Content.Load<Texture2D>("tileset (botton)");
            DoorRed = game.Content.Load<Texture2D>("DoorRed");
            DoorGreen = game.Content.Load<Texture2D>("DoorGreenRed");
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
            Rectangle Platform2 = new Rectangle((int)622, (int)528, 122, 24);
            Rectangle Platform3 = new Rectangle((int)142, (int)480, 432, 24);
            Rectangle Platform4 = new Rectangle((int)240, (int)456, 72, 24);
            Rectangle Platform5 = new Rectangle((int)480, (int)456, 24, 24);
            Rectangle Platform6 = new Rectangle((int)172, (int)406, 24, 24);
            Rectangle Platform7 = new Rectangle((int)548, (int)408, 24, 24);
            Rectangle Platform8 = new Rectangle((int)144, (int)384, 24, 24);
            Rectangle Platform9 = new Rectangle((int)624, (int)384, 120, 24);
            Rectangle Platform10 = new Rectangle((int)98, (int)360, 24, 24);
            Rectangle Platform11 = new Rectangle((int)72, (int)336, 24, 24);
            Rectangle Platform12 = new Rectangle((int)48, (int)312, 24, 24);
            Rectangle Platform13 = new Rectangle((int)240, (int)312, 312, 24);
            Rectangle Platform14 = new Rectangle((int)624, (int)288, 120, 24);
            Rectangle Platform15 = new Rectangle((int)120, (int)264, 96, 24);
            Rectangle Platform16 = new Rectangle((int)266, (int)192, 24, 24);
            Rectangle Platform17 = new Rectangle((int)312, (int)168, 24, 24);
            Rectangle Platform18 = new Rectangle((int)360, (int)144, 24, 24);
            Rectangle Platform19 = new Rectangle((int)408, (int)120, 24, 24);
            Rectangle Platform20 = new Rectangle((int)448, (int)120, 44, 24);
            Rectangle Platform21 = new Rectangle((int)528, (int)120, 96, 24);
            Rectangle Platform22 = new Rectangle((int)654, (int)120, 96, 24);
            Rectangle Platform23 = new Rectangle((int)500, (int)168, 24, 24);
            Rectangle Platform24 = new Rectangle((int)628, (int)168, 24, 24);
            Rectangle Platform25 = new Rectangle((int)654, (int)144, 96, 24);

            //Box
            Rectangle Box1 = new Rectangle((int)Box1Pos.X - 2, (int)Box1Pos.Y - 2, 28, 30);
            Rectangle Box2 = new Rectangle((int)Box2Pos.X - 2, (int)Box2Pos.Y - 2, 28, 30);
            Rectangle Box3 = new Rectangle((int)Box3Pos.X - 2, (int)Box3Pos.Y - 2, 32, 30);

            // Button
            Rectangle Button1 = new Rectangle((int)Button1Pos.X - 2, (int)Button1Pos.Y + 12, 32, 18);
            Rectangle Button2 = new Rectangle((int)Button2Pos.X - 2, (int)Button2Pos.Y + 12, 32, 18);

            // Door
            Rectangle Door1 = new Rectangle((int)Door1Pos.X, (int)Door1Pos.Y, 16, 76);
            Rectangle Door2 = new Rectangle((int)Door2Pos.X, (int)Door2Pos.Y, 16, 76);

            // Key
            Rectangle Key1 = new Rectangle((int)Key1Pos.X, (int)Key1Pos.Y, 24, 24);

            // Gate
            Rectangle Gate1 = new Rectangle((int)Gate1Pos.X, (int)Gate1Pos.Y, 60, 60);

            // Trap 
            Rectangle Trap1 = new Rectangle((int)Trap1Pos.X - 2, (int)Trap1Pos.Y + 12, 32, 18);
            Rectangle Trap2 = new Rectangle((int)Trap2Pos.X - 2, (int)Trap2Pos.Y + 12, 24, 16);

            // Sec
            Rectangle Sec1 = new Rectangle((int)Sec1Pos.X + 12, (int)Sec1Pos.Y, 27, 48);

            if (PlayerPos.Y > 508)
            {
                PlayerPos.Y = 506;
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

            Platform(charRectangle, Platform2, 622, 528);
            Platform(charRectangle, Platform3, 142, 480);
            Platform(charRectangle, Platform4, 240, 456);
            Platform(charRectangle, Platform5, 480, 456);
            Platform(charRectangle, Platform6, 172, 406);
            Platform(charRectangle, Platform7, 548, 408);
            Platform(charRectangle, Platform8, 144, 384);
            Platform(charRectangle, Platform9, 624, 384);
            Platform(charRectangle, Platform10, 98, 360);
            Platform(charRectangle, Platform11, 72, 336);
            Platform(charRectangle, Platform12, 48, 312);
            Platform(charRectangle, Platform13, 240, 312);
            Platform(charRectangle, Platform14, 624, 288);
            Platform(charRectangle, Platform15, 120, 264);
            Platform(charRectangle, Platform16, 266, 192);
            Platform(charRectangle, Platform17, 312, 168);
            Platform(charRectangle, Platform18, 360, 144);
            Platform(charRectangle, Platform19, 408, 120);
            Platform(charRectangle, Platform20, 448, 120);
            Platform(charRectangle, Platform21, 528, 120);
            Platform(charRectangle, Platform22, 654, 120);
            Platform(charRectangle, Platform23, 500, 168);
            Platform(charRectangle, Platform24, 628, 168);
            Platform(charRectangle, Platform25, 654, 144);


            //Box
            BoxCheck(charRectangle, Box1, (int)Box1Pos.X, (int)Box1Pos.Y);
            Box1Pos.Y += 2;
            if (Box1Pos.Y >= 532)
            {
                Box1Pos.Y = 532;
            }
            if (Box1.Intersects(Platform3))
            {
                Box1Pos.Y -= 2;
            }
            if (charRectangle.Intersects(Box1))
            {
                if (PlayerPos.Y >= Box1Pos.Y - 48 && PlayerPos.Y <= Box1Pos.Y - 38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = Box1Pos.Y - 48;
                }
                else if (walkL)
                {
                    Box1Pos.X -= 2;
                    if (Box1Pos.X < 48)
                    {
                        Box1Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                }
                else if (walkR)
                {
                    Box1Pos.X += 2;
                    if (Box1.Intersects(Platform4))
                    {
                        Box1Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (Box1.Intersects(Platform2))
                    {
                        Box1Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (Box1.Intersects(Box2))
                    {
                        Box1Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (Box1.Intersects(Box3))
                    {
                        Box1Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                }
            }

            //Box2
            BoxCheck(charRectangle, Box2, (int)Box2Pos.X, (int)Box2Pos.Y);
            Box2Pos.Y += 2;
            if (Box2Pos.Y >= 532)
            {
                Box2Pos.Y = 532;
            }
            if (Box2.Intersects(Platform15) || Box2.Intersects(Platform13) || Box2.Intersects(Platform12) || Box2.Intersects(Platform11) || Box2.Intersects(Platform7) || Box2.Intersects(Platform2)
                || Box2.Intersects(Platform3) || Box2.Intersects(Platform5) || Box2.Intersects(Box3) || Box2.Intersects(Box1))
            {
                Box2Pos.Y -= 2;
            }
            if (Box2.Intersects(Box3) && Box2.Intersects(Platform3))
            {
                Box2Pos.Y += 2;
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
                    if (Box2.Intersects(Platform15) && Box2.Intersects(Platform13))
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box2.Intersects(Platform11) && Box2.Intersects(Platform12))
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box2.Intersects(Platform3) && Box2.Intersects(Platform5))
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box2.Intersects(Platform3) && Box2.Intersects(Platform13))
                    {
                        Box2Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box2.Intersects(Box1))
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
                    if (Box2.Intersects(Platform3) && Box2.Intersects(Platform5))
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
            if (Box3Pos.Y >= 532)
            {
                Box3Pos.Y = 532;
            }
            if (Box3.Intersects(Platform14) || Box3.Intersects(Platform12) || Box3.Intersects(Platform11) || Box3.Intersects(Platform7) || Box3.Intersects(Platform2)
                || Box3.Intersects(Platform3) || Box3.Intersects(Platform5) || Box3.Intersects(Box2))
            {
                Box3Pos.Y -= 2;
            }
            if (Box3.Intersects(Box2) && Box3.Intersects(Platform3))
            {
                Box3Pos.Y += 2;
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
                    if (Box3.Intersects(Platform13))
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box3.Intersects(Platform3) && Box3.Intersects(Platform5))
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box3.Intersects(Platform3) && Box3.Intersects(Platform13))
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box3.Intersects(Box1))
                    {
                        Box3Pos.X += 2;
                        PlayerPos.X += 2;
                    }
                    if (Box3.Intersects(Box2))
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
                    if (Box3.Intersects(Platform3) && Box3.Intersects(Platform5))
                    {
                        Box3Pos.X -= 2;
                        PlayerPos.X -= 2;
                    }
                    if (Box3.Intersects(Platform7))
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

            ButtonChange = 0;
            ButtonChange2 = 0;
            // Button1
            if (Button1.Intersects(Box3))
            {
                ButtonChange2 = 1;
            }
            if (Button1.Intersects(Box2))
            {
                ButtonChange2 = 1;
            }
            if (Button1.Intersects(Box1))
            {
                ButtonChange2 = 1;
            }

            // Button2
            if (Button2.Intersects(Box3))
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
            if (charRectangle.Intersects(Door2) && ButtonChange2 == 0)
            {
                if (charRectangle.Right > Door2.Left)
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
                    game.Exit();
                }
            }

            // Trap
            if (charRectangle.Intersects(Trap1))
            {
                ResetGame();
            }
            if (charRectangle.Intersects(Trap2) && charRectangle.Intersects(Platform25) == false)
            {
                ResetGame();
            }

            // Sec
            Sec1Pos.X += SecDi1;
            if (Sec1.Left < Platform4.Right + 14)
            {
                Sec1Flip = false;
                SecDi1 = 2;
            }
            if (Sec1.Intersects(Platform5) || Sec1.Intersects(Box2) || Sec1.Intersects(Box3))
            {
                Sec1Flip = true;
                SecDi1 = -2;
            }
            if (charRectangle.Intersects(Sec1))
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
            theBatch.Draw(Button, Button1Pos, new Rectangle(24 * ButtonChange2, 48, 24, 24), Color.White);
            theBatch.Draw(Button, Button2Pos, new Rectangle(24 * ButtonChange, 24, 24, 24), Color.White);
            if (ButtonChange == 0)
            {
                theBatch.Draw(DoorRed, Door1Pos, Color.White);
            }
            if (ButtonChange2 == 0)
            {
                theBatch.Draw(DoorGreen, Door2Pos, Color.White);
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
            theBatch.Draw(Trap, Trap2Pos, new Rectangle(24, 0, 24, 24), Color.White);
            Player.DrawFrame(theBatch, PlayerPos, filpPlayer);
            Security.DrawFrame(theBatch, Sec1Pos, Sec1Flip);
            base.Draw(theBatch);
        }

        public void Platform(Rectangle P_rectangle, Rectangle Plat_rectangle, int x, int y)
        {
            if (P_rectangle.Intersects(Plat_rectangle))
            {
                if (PlayerPos.Y >= y - 48 && PlayerPos.Y <= y - 38)
                {
                    velocity.Y = 0f;
                    Jump = false;
                    PlayerPos.Y = y - 48;
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

        public void ResetGame()
        {
            filpPlayer = false;
            walkR = false;
            walkL = false;
            PlayerPos = new Vector2(300, 506);
            Jump = false;
            GetKey = false;
            ButtonChange = 0;
            ButtonChange2 = 0;

            Box1Pos = new Vector2(166, 456);
            Box2Pos = new Vector2(142, 240);
            Box3Pos = new Vector2(648, 264);

            // Door Position
            Door1Pos = new Vector2(654, 46);
            Door2Pos = new Vector2(640, 309);

            // Button Position
            Button1Pos = new Vector2(48, 540);
            Button2Pos = new Vector2(720, 268);

            // Key Position
            Key1Pos = new Vector2(720, 360);

            // Gate Position
            Gate1Pos = new Vector2(682, 60);

            // Trap Position
            Trap1Pos = new Vector2(500, 144);
            Trap2Pos = new Vector2(626, 144);

            // Sec Position
            Sec1Pos = new Vector2(312, 422);
        }
    }

}
