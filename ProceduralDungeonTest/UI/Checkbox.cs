using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using PDT.Input;

namespace PDT.UI
{
    public class Checkbox : Hoverable
    {
        public Color              bgColor, bgHoveredColor, selectColor;
        public OnSelectionChanged selectionChanged;

        public delegate void OnSelectionChanged(bool newValue);

        public bool Selected
        {
            get { return selected; }
            set { SetSelected(value); }
        }

        protected bool selected;

        public Checkbox(Point pos, Vector2 size, Color bgColor, Color bgHoveredColor, Color selectColor, OnSelectionChanged onSelectionChanged = null)
            : base(pos, size)
        {
            this.bgColor          = bgColor;
            this.bgHoveredColor   = bgHoveredColor;
            this.selectColor      = selectColor;
            this.selectionChanged = onSelectionChanged;

            // Minimum size for it to look any good.
            if (this.size.X < 12) this.size.X = 12;
            if (this.size.Y < 12) this.size.Y = 12;
        }

        public Checkbox(Point pos, Vector2 size, ColorScheme scheme, OnSelectionChanged onSelectionChanged = null)
            : this(pos, size, scheme.bgColor, scheme.bgHoveredColor, scheme.selectedColor, onSelectionChanged)
        {}

        public void SetSelected(bool value)
        {
            selected = value;
            if (selectionChanged != null) selectionChanged(value);
        }

        public override void Update()
        {
            if (!active) return;
            base.Update();
            if (hovered && InputManager.IsMouseButtonDown(MouseButton.Left)) SetSelected(!selected);
        }

        public override void Render(SpriteBatch sb)
        {
            if (!active) return;
            base.Render(sb);
            sb.FillRectangle(BoundingRect, hovered ? bgHoveredColor : bgColor);
            if (selected) sb.FillRectangle(position.ToVector2() + new Vector2(4, 4), size - new Vector2(8, 8), selectColor);
        }

    }
}
