using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_The_Shadow
{
    public class screen
    {
        protected EventHandler ScreenEvent;
        public screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public virtual void Update(GameTime theTime)
        {
        }
        public virtual void Draw(SpriteBatch theBatch)
        {
        }
    }

}
