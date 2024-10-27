using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace LET_HIM_COOK.Screen
{
    public class screen
    {
        public OrthographicCamera _camera;
        public Vector2 _cameraPosition;
        public Vector2 _bgPosition;
        protected EventHandler ScreenEvent; public screen(EventHandler theScreenEvent)
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
