using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDT
{
    public static class UIResources
    {
        public static SpriteFont openSansRegular, openSansBold;

        public static void LoadUIResources(ContentManager content)
        {
            openSansRegular = content.Load<SpriteFont>("Fonts/OpenSans");
            openSansBold = content.Load<SpriteFont>("Fonts/OpenSansBold");
        }
    }
}
