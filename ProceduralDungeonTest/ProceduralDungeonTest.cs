using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame;
using System;
using PDT.UI;
using PDT.Input;

namespace PDT
{
    public class ProceduralDungeonTest : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool drawDebug = false;

        public static Random globalRandom;

        VerticalLayout layout;
        LabelledCheckbox checkbox;

        public ProceduralDungeonTest()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            globalRandom = new Random();
        }

        protected override void Initialize()
        {
            Window.Title = "Procedural Dungeon Test";
            Window.AllowUserResizing = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            UIResources.LoadUIResources(Content);
            checkbox = new LabelledCheckbox(Point.Zero, new Vector2(20, 20), "Draw Debug", UIResources.openSansRegular, Color.Cyan, Color.DarkCyan, Color.White, Color.White, 8, SetDebugVisible);
            layout = new VerticalLayout(new Point(10, 10),
                                        new UIElement[] { new Label("Procedural Dungeon Test", UIResources.openSansBold, Point.Zero, Color.White),
                                        checkbox,
                                        new Button(Point.Zero, new Vector2(100, 25), Generate, UIResources.openSansBold, "Generate", Color.DarkCyan, Color.Blue, Color.DarkBlue, Color.White),
                                        new Button(Point.Zero, new Vector2(60, 25), Exit, UIResources.openSansBold, "Exit", Color.DarkCyan, Color.Blue, Color.DarkBlue, Color.White)});
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || InputManager.IsKeyDown(Keys.Escape))
                Exit();

            if (InputManager.IsKeyDown(Keys.Tab))
            {
                drawDebug = !drawDebug;
                checkbox.Selected = drawDebug;
            }

            layout.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            layout.Render(spriteBatch);
            if (drawDebug) layout.RenderDebug(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Generate()
        {

        }

        public void SetDebugVisible(bool value)
        {
            drawDebug = value;
        }

    }
}
