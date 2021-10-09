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
        Game1 game;

        AnimatedTexture Player;
        bool filpPlayer = false;
        Vector2 PlayerPos = new Vector2(500, 505);

        KeyboardState keyboardState;
        KeyboardState old_keyboardState;

        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;

        public GameplayScreen(Game1 game, EventHandler theScreenEvent)
        : base(theScreenEvent)
        {
            //Load the background texture for the screen
            Background = game.Content.Load<Texture2D>("Backgrund800X600");
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
                Player.Play();
            }
            else if (old_keyboardState.IsKeyDown(Keys.Left) && keyboardState.IsKeyUp(Keys.Left))
            {
                Player.Pause(0, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                filpPlayer = false;
                PlayerPos.X += 2;
                Player.Play();
            }
            else if (old_keyboardState.IsKeyDown(Keys.Right) && keyboardState.IsKeyUp(Keys.Right))
            {
                Player.Pause(0, 0);
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

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(Background, Vector2.Zero, Color.White);
            Player.DrawFrame(theBatch, PlayerPos, filpPlayer);
            base.Draw(theBatch);
        }
    }

}
