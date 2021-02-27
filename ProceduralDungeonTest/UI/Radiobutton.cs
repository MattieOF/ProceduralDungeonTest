using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame;
using System;

namespace PDT.UI
{
    public class Radiobutton : Checkbox
    {
        public float Radius
        {
            get { return radius;    }
            set { SetRadius(value); }
        }

        protected float radius    = 0f;
        protected int   sideCount = 20;

        // TODO create circular bounds, and check if mouse pos intersects circular bounds too only once we know it intersects rectangular bounds for more precise hovering

        public Radiobutton(Point pos, float radius, Color bgColor, Color bgHoveredColor, Color selectColor, OnSelectionChanged onSelectionChanged = null)
            : base(pos, new Vector2(radius * 2, radius * 2), bgColor, bgHoveredColor, selectColor, onSelectionChanged)
        {
            if (radius < 8) radius = 8;
            SetRadius(radius);
        }

        public Radiobutton(Point pos, float radius, ColorScheme colorScheme, OnSelectionChanged onSelectionChanged = null)
            : this(pos, radius, colorScheme.bgColor, colorScheme.bgHoveredColor, colorScheme.selectedColor, onSelectionChanged)
        { }

        public void SetRadius(float newRadius)
        {
            radius = newRadius;
            size = new Vector2(radius * 2, radius * 2);
            sideCount = (int) Math.Max(radius, 20);
        }

        public override void Render(SpriteBatch sb)
        {
            if (!active) return;
            Vector2 pos = position.ToVector2();
            pos += size / 2;
            sb.FillCircle(pos, radius, sideCount, hovered ? bgHoveredColor : bgColor);
            if (selected) sb.FillCircle(pos, radius - 6, sideCount - 10, selectColor);
        }
    }
}
