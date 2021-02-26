﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using PDT.Input;

namespace PDT.UI
{
    public class Checkbox : Hoverable
    {
        public Color bgColor, bgHoveredColor, selectColor;

        public bool Selected
        {
            get { return selected; }
            set { SetSelected(value); }
        }

        private bool selected;

        public Checkbox(Point pos, Vector2 size, Color bgColor, Color bgHoveredColor, Color selectColor)
            : base(pos, size)
        {
            this.bgColor        = bgColor;
            this.bgHoveredColor = bgHoveredColor;
            this.selectColor    = selectColor;

            // Minimum size for it to look any good.
            if (this.size.X < 12) this.size.X = 12;
            if (this.size.Y < 12) this.size.Y = 12;
        }

        public void SetSelected(bool value)
        {
            selected = value;
        }

        public override void Update()
        {
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