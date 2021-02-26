using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PDT.UI
{
    public class Label : UIElement
    {
        public SpriteFont Font
        {
            get { return font; }
            set { SetFont(value); }
        }

        public string Text
        {
            get { return text; }
            set { SetText(value); }
        }

        private string      text;
        private SpriteFont  font;

        public  Color       color;

        public Label(string text, SpriteFont font, Point pos, Color color)
            : base(pos, new Vector2(0, 0))
        {
            if (font == null)  font  = UIResources.openSansRegular;
            if (color == null) color = Color.White;

            this.text  = text;
            this.font  = font;
            this.color = color;
            Size = font.MeasureString(text);
        }

        public void SetFont(SpriteFont newFont)
        {
            if (newFont == null) return;
            font = newFont;
            Size = font.MeasureString(text);
        }

        public void SetText(string newText)
        {
            text = newText;
            Size = font.MeasureString(text);
        }

        public override void Render(SpriteBatch sb)
        {
            if (!active) return;
            sb.DrawString(font, text, Position.ToVector2(), color);
        }
    }
}
