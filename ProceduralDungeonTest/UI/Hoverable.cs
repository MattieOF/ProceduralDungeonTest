using Microsoft.Xna.Framework;
using PDT.Input;

namespace PDT.UI
{
    public class Hoverable : UIElement
    {
        public bool hovered = false;

        public Hoverable(Point pos, Vector2 size)
            : base(pos, size)
        { }

        public override void Update()
        {
            base.Update();
            if (BoundingRect.Contains(InputManager.GetMousePos())) hovered = true;
            else hovered = false;
        }
    }
}
