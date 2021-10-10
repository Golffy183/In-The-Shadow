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
        Texture2D Background;
        Texture2D Box;
        Game1 game;

        AnimatedTexture Player;
        bool filpPlayer = false;
        bool walkR = false;
        bool walkL = false;
        Vector2 PlayerPos = new Vector2(300, 506);
        Vector2 velocity;
        bool Jump = false;

        KeyboardState keyboardState;
        KeyboardState old_keyboardState;

        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;

        private static readonly TimeSpan TimeJump = TimeSpan.FromMilliseconds(200);
        private TimeSpan _TimeJump;

        // Box Position
        Vector2 Box1Pos = new Vector2(200, 532);

        public GameplayScreen(Game1 game, EventHandler theScreenEvent)
        : base(theScreenEvent)
        {
            //Load the background texture for the screen
            Background = game.Content.Load<Texture2D>("Backgrund800X600");
            Box = game.Content.Load<Texture2D>("woodbox");
            Player = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            Player.Load(game.Content, "shadow2", 8, 1, 15);

            Player.Pause(0, 0);

            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            float elapsed = (float)theTime.ElapsedGameTime.TotalSeconds;
            keyboardState = Keyboard.GetState();
            Player.UpdateFrame(elapsed);

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


            Rectangle charRectangle = new Rectangle((int)PlayerPos.X + 12, (int)PlayerPos.Y, 27, 48);
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
            Rectangle Box1 = new Rectangle((int)Box1Pos.X, (int)Box1Pos.Y, 24, 24);

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

            if (charRectangle.Intersects(Platform1))
            {
                velocity.Y = 0f;
                Jump = false;
                PlayerPos.Y = 506;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Jump == false)
            {
                Jump = true;
                // ปรับแรงกระโดด
                velocity.Y = 8f;

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
            Player.DrawFrame(theBatch, PlayerPos, filpPlayer);
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
                    if (x < 48)
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
    }

}
