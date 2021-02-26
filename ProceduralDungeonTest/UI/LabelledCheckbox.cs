using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PDT.UI
{
    // TODO refactor this as inheriting horizontal layout
    public class LabelledCheckbox : UIElement
    {
        private HorizontalLayout layout;
        private Checkbox         checkbox;
        private Label            label;

        public bool Selected
        {
            get { return checkbox.Selected; }
            set { SetSelected(value); }
        }

        public new Vector2 Size
        {
            get { return layout.Size; }
            set { layout.Size = value; }
        }

        public new Point Position
        {
            get { return layout.Position; }
            set { layout.Position = value; }
        }

        public LabelledCheckbox(Point pos, Vector2 size, string text, SpriteFont font, Color bgColor, Color bgHoveredColor, Color selectColor, Color textColor)
            : base (pos, size)
        {
            layout = new HorizontalLayout(pos, 8);
            checkbox = new Checkbox(Point.Zero, size, bgColor, bgHoveredColor, selectColor);
            layout.AddElement(checkbox);
            label = new Label(text, font, Point.Zero, textColor);
            layout.AddElement(label);
        }

        public void SetSelected(bool value)
        {
            checkbox.SetSelected(value);
        }

        public override void Update()
        {
            base.Update();
            layout.Update();
        }

        public override void Render(SpriteBatch sb)
        {
            base.Render(sb);
            layout.Render(sb);
        }
    }
}
