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
        Game1 game;
        public TitleScreen(Game1 game, EventHandler theScreenEvent)
        : base(theScreenEvent)
        {
            //Load the background texture for the screen
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {

            base.Draw(theBatch);
        }
    }
}
