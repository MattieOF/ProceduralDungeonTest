using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace PDT.Input
{
    public static class InputManager
    {
        private static KeyboardState keyboardState, previousKeyboardState;
        private static MouseState    mouseState, previousMouseState;

        public static void Update()
        {
            if (keyboardState != null) previousKeyboardState = keyboardState;
            if (mouseState    != null) previousMouseState    = mouseState;

            keyboardState = Keyboard.GetState();
            mouseState    = Mouse.GetState();
        }

        public static bool IsKey(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key) && !(previousKeyboardState.IsKeyDown(key));
        }

        public static bool IsKeyUp(Keys key)
        {
            return !(keyboardState.IsKeyDown(key)) && previousKeyboardState.IsKeyDown(key);
        }

        public static bool IsMouseButton(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return mouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return mouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return mouseState.MiddleButton == ButtonState.Pressed;
            }

            return false;
        }

        public static bool IsMouseButtonDown(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return mouseState.LeftButton == ButtonState.Pressed && !(previousMouseState.LeftButton == ButtonState.Pressed);
                case MouseButton.Right:
                    return mouseState.RightButton == ButtonState.Pressed && !(previousMouseState.RightButton == ButtonState.Pressed);
                case MouseButton.Middle:
                    return mouseState.MiddleButton == ButtonState.Pressed && !(previousMouseState.MiddleButton == ButtonState.Pressed);
            }

            return false;
        }

        public static bool IsMouseButtonUp(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return !(mouseState.LeftButton == ButtonState.Pressed) && previousMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return !(mouseState.RightButton == ButtonState.Pressed) && previousMouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return !(mouseState.MiddleButton == ButtonState.Pressed) && previousMouseState.MiddleButton == ButtonState.Pressed;
            }

            return false;
        }

        public static Point GetMousePos()
        {
            return mouseState.Position;
        }
    }
}
