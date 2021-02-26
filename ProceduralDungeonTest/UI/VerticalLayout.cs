using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PDT.UI
{
    public class VerticalLayout : UIElement
    {
        public List<UIElement> elements;
        public int verticalSpacing;

        public VerticalLayout(Point pos, int spacing = 5)
            : base(pos, new Vector2(0, 0))
        {
            verticalSpacing = spacing;
            elements = new List<UIElement>();
        }

        public VerticalLayout(Point pos, UIElement[] elements, int spacing = 5)
            : base(pos, new Vector2(0, 0))
        {
            verticalSpacing = spacing;
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
            int x = Position.X;
            int cumulativeY = Position.Y;
            float largestXSize = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (i != 0) cumulativeY += verticalSpacing;
                elements[i].Position = new Point(x, cumulativeY);
                cumulativeY += (int)elements[i].Size.Y;

                if (elements[i].Size.X > largestXSize) largestXSize = elements[i].Size.X;
            }

            size = new Vector2(largestXSize, cumulativeY - Position.Y);
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
