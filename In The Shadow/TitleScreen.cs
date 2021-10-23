using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_The_Shadow
{
    public class TitleScreen : screen
    {
        Texture2D menuTexture;
        Vector2 menuPosition = new Vector2(175, 100);
        Texture2D select;
        int currentMenu = 0;
        bool keyActiveUp = false;
        bool keyActiveDown = false;
        Game1 game;
        public TitleScreen(Game1 game, EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
            //Load BG
            menuTexture = game.Content.Load<Texture2D>("IN-THE");
            select = game.Content.Load<Texture2D>("New&Quit");
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Up))
            {
                if (keyActiveUp == true)
                {
                    if (currentMenu > 1)
                    {
                        currentMenu = currentMenu - 1;
                        keyActiveUp = false;
                    }

                }
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                if (keyActiveDown == true)
                {
                    if (currentMenu < 2)
                    {
                        currentMenu = currentMenu + 1;
                        keyActiveDown = false;
                    }
                }
            }
            //checkKey
            if (keyboard.IsKeyUp(Keys.Up))
            {
                keyActiveUp = true;
            }
            if (keyboard.IsKeyUp(Keys.Down))
            {
                keyActiveDown = true;
            }

            //cheng Gui
            if (currentMenu == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
                {
                    ScreenEvent.Invoke(game.mGameplayScreen, new EventArgs());
                    return;
                }

            }
            if (currentMenu == 2)
            {
                //Exit
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {

            theBatch.Draw(menuTexture, menuPosition, new Rectangle(0, 0, 441, 218), Color.White);
            if (currentMenu == 1)
            {
                theBatch.Draw(select, new Vector2(350, 400), new Rectangle(0, 0, 96, 24), Color.White);
            }
            else
            {
                theBatch.Draw(select, new Vector2(350, 400), new Rectangle(96, 0, 96, 24), Color.White);
            }
            if (currentMenu == 2)
            {
                theBatch.Draw(select, new Vector2(350, 450), new Rectangle(0, 24, 96, 24), Color.White);
            }
            else
            {
                theBatch.Draw(select, new Vector2(350, 450), new Rectangle(96, 24, 96, 24), Color.White);
            }
            base.Draw(theBatch);
        }
    }
}
