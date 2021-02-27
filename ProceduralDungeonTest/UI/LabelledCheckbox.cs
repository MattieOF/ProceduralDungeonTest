using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PDT.UI
{
    public class LabelledCheckbox : HorizontalLayout
    {
        private Checkbox checkbox;
        private Label    label;

        public bool Selected
        {
            get { return checkbox.Selected; }
            set { checkbox.Selected = value; }
        }
        
        public LabelledCheckbox(Point pos, Vector2 checkboxSize, string text, SpriteFont font, Color bgColor, Color bgHoveredColor, Color selectColor, Color textColor, int spacing = 8, Checkbox.OnSelectionChanged onSelectionChanged = null)
            : base(pos, spacing)
        {
            checkbox = new Checkbox(Point.Zero, checkboxSize, bgColor, bgHoveredColor, selectColor, onSelectionChanged);
            label = new Label(text, font, Point.Zero, textColor);
            AddElement(checkbox);
            AddElement(label);
        }

        public LabelledCheckbox(Point pos, Vector2 checkboxSize, string text, SpriteFont font, ColorScheme scheme, int spacing = 8, Checkbox.OnSelectionChanged onSelectionChanged = null)
            : this(pos, checkboxSize, text, font, scheme.bgColor, scheme.bgHoveredColor, scheme.selectedColor, scheme.textColor, spacing, onSelectionChanged)
        { }
    }
}
