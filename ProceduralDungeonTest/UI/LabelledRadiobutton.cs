using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PDT.UI
{
    public class LabelledRadiobutton : HorizontalLayout
    {
        private Radiobutton radiobutton;
        private Label label;

        public bool Selected
        {
            get { return radiobutton.Selected; }
            set { radiobutton.Selected = value; }
        }

        public LabelledRadiobutton(Point pos, float radiobuttonRadius, string text, SpriteFont font, Color bgColor, Color bgHoveredColor, Color selectColor, Color textColor, int spacing = 8, Checkbox.OnSelectionChanged onSelectionChanged = null)
            : base(pos, spacing)
        {
            radiobutton = new Radiobutton(Point.Zero, radiobuttonRadius, bgColor, bgHoveredColor, selectColor, onSelectionChanged);
            label = new Label(text, font, Point.Zero, textColor);
            AddElement(radiobutton);
            AddElement(label);
        }

        public LabelledRadiobutton(Point pos, float radiobuttonRadius, string text, SpriteFont font, ColorScheme scheme, int spacing = 8, Checkbox.OnSelectionChanged onSelectionChanged = null)
            : this(pos, radiobuttonRadius, text, font, scheme.bgColor, scheme.bgHoveredColor, scheme.selectedColor, scheme.textColor, spacing, onSelectionChanged)
        { }
    }
}
