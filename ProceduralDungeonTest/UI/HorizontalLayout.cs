using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PDT.UI
{
    public class HorizontalLayout : UIElement
    {
        public List<UIElement> elements;
        public int horizontalSpacing;

        public HorizontalLayout(Point pos, int spacing = 5)
            : base(pos, new Vector2(0, 0))
        {
            horizontalSpacing = spacing;
            elements = new List<UIElement>();
        }

        public HorizontalLayout(Point pos, UIElement[] elements, int spacing = 5)
            : base(pos, new Vector2(0, 0))
        {
            horizontalSpacing = spacing;
            this.elements = new List<UIElement>(elements);
            Layout();
        }

        public void AddElement(UIElement element)
        {
            elements.Add(element);
            Layout();
        }

        public void RemoveElement(UIElement element)
        {
            elements.Remove(element);
            Layout();
        }

        public void RemoveElementAt(int index)
        {
            elements.RemoveAt(index);
            Layout();
        }

        public void ClearElements()
        {
            elements.Clear();
        }

        public void Layout()
        {
            int y = Position.Y;
            int cumulativeX = Position.X;
            float largestYSize = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (!elements[i].active) continue;
                if (i != 0) cumulativeX += horizontalSpacing;
                elements[i].Position = new Point(cumulativeX, y);
                cumulativeX += (int)elements[i].Size.X;

                if (elements[i].Size.Y > largestYSize) largestYSize = elements[i].Size.Y;
            }

            size = new Vector2(cumulativeX - position.X, largestYSize);
        }

        public override void SetPosition(Point newPos)
        {
            base.SetPosition(newPos);
            Layout();
        }

        public override void SetSize(Vector2 newSize)
        {
            base.SetSize(newSize);
            Layout();
        }

        public override void Update()
        {
            if (!active) return;
            foreach (UIElement element in elements)
            {
                element.Update();
            }
        }

        public override void Render(SpriteBatch sb)
        {
            if (!active) return;
            foreach (UIElement element in elements)
            {
                element.Render(sb);
            }
        }

        public override void RenderDebug(SpriteBatch sb)
        {
            if (!active) return;
            base.RenderDebug(sb);   
            foreach (UIElement element in elements)
            {
                element.RenderDebug(sb);
            }
        }
    }
}
