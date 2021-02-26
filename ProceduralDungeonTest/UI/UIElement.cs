using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;

namespace PDT.UI
{
    public class UIElement
    {
        public Vector2 Size
        {
            get { return size; }
            set { SetSize(value); }
        }

        public Point Position
        {
            get { return position; }
            set { SetPosition(value); }
        }

        protected  Point    position;
        protected  Vector2  size;
        public     Color    debugDrawColor = Color.Green;
        public     bool     active = true;

        public Rectangle BoundingRect
        {
            get { return new Rectangle(position, size.ToPoint()); }
        }

        public UIElement(Point pos, Vector2 size)
        {
            position = pos;
            this.size = size;

            debugDrawColor = new Color(ProceduralDungeonTest.globalRandom.Next(255), ProceduralDungeonTest.globalRandom.Next(255), ProceduralDungeonTest.globalRandom.Next(255));
        }

        public virtual void SetSize(Vector2 newSize)
        {
            size = newSize;
        }

        public virtual void SetPosition(Point newPos)
        {
            position = newPos;
        }

        public virtual void Update()
        {
            if (!active) return;
        }

        public virtual void Render(SpriteBatch sb)
        {
            if (!active) return;
        }

        public virtual void RenderDebug(SpriteBatch sb)
        {
            if (!active) return;
            sb.DrawRectangle(BoundingRect, debugDrawColor, 1f);
        }
    }
}
