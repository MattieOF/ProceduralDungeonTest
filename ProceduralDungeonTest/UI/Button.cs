using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using PDT.Input;

namespace PDT.UI
{
    public class Button : Hoverable
    {
        public  OnButtonPressed      onButtonPressedCallback;
        public  OnButtonPressedDown  onButtonPressedDownCallback;
        private Label                label;
        
        public string           text;
        public SpriteFont       font;
        public Color            buttonColor, buttonHoveredColor, buttonPressedColor, textColor;

        public delegate void OnButtonPressed();
        public delegate void OnButtonPressedDown();

        public Button(Point pos, Vector2 size, OnButtonPressed onButtonPressed, SpriteFont font, string text,
                      Color buttonColor, Color buttonHoveredColor, Color buttonPressedColor, Color textColor)
            : base(pos, size)
        {
            onButtonPressedCallback  = onButtonPressed;
            this.buttonColor         = buttonColor;
            this.buttonHoveredColor  = buttonHoveredColor;
            this.buttonPressedColor  = buttonPressedColor;
            this.textColor           = textColor;
            this.font                = font;
            this.text                = text;

            label = new Label(text, font, Point.Zero, textColor);
            PositionLabel();
        }

        public void PositionLabel()
        {
            Vector2 textSize = font.MeasureString(text);
            if (size.X < textSize.X) size.X = textSize.X;
            if (size.Y < textSize.Y) size.Y = textSize.Y;

            Vector2 halfSize = size / 2;
            Vector2 halfLabelSize = label.Size / 2;
            label.Position = position;
            label.Position += halfSize.ToPoint();
            label.Position -= halfLabelSize.ToPoint();
        }

        public override void Update()
        {
            if (!active) return;
            base.Update();
            if (hovered && InputManager.IsMouseButtonUp(MouseButton.Left) && onButtonPressedCallback != null)        onButtonPressedCallback();
            if (hovered && InputManager.IsMouseButtonDown(MouseButton.Left) && onButtonPressedDownCallback != null)  onButtonPressedDownCallback();
        }

        public override void Render(SpriteBatch sb)
        {
            if (!active) return;
            base.Render(sb);

            Color color;
            if (hovered)
            {
                if (InputManager.IsMouseButton(MouseButton.Left))
                    color = buttonPressedColor;
                else
                    color = buttonHoveredColor;
            }
            else color = buttonColor;

            sb.FillRectangle(BoundingRect, color);
            label.Render(sb);
        }

        public override void RenderDebug(SpriteBatch sb)
        {
            base.RenderDebug(sb);
            label.RenderDebug(sb);
        }

        public override void SetPosition(Point newPos)
        {
            base.SetPosition(newPos);
            PositionLabel();
        }

        public override void SetSize(Vector2 newSize)
        {
            base.SetSize(newSize);
            PositionLabel();
        }
    }
}
