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
            VerticalLayout layout2 = new VerticalLayout(new Point(10, 10),
                                        new UIElement[] { new Label("Hello!", null, Point.Zero, Color.White), new Label("Hello again!", null, Point.Zero, Color.White) }, 20);
            HorizontalLayout layout3 = new HorizontalLayout(new Point(10, 10),
                                        new UIElement[] { new Label("Hello!", null, Point.Zero, Color.White), new Label("Hello again!", null, Point.Zero, Color.White) }, 20);
            layout = new VerticalLayout(new Point(10, 10),
                                        new UIElement[] { new Label("Hello!", UIResources.openSansBold, Point.Zero, Color.White), layout2, layout3, 
                                            new Button(Point.Zero, new Vector2(60, 25), Exit, UIResources.openSansBold, "Exit", Color.DarkCyan, Color.Blue, Color.DarkBlue, Color.White),
                                            new Label("Hello again!", null, Point.Zero, Color.White) });
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || InputManager.IsKeyDown(Keys.Escape))
                Exit();

            layout.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            layout.Render(spriteBatch);
            if (InputManager.IsKeyDown(Keys.Tab)) drawDebug = !drawDebug;
            if (drawDebug) layout.RenderDebug(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
