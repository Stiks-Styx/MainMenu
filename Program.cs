using System;
using ConsoleGameEngine;

namespace MainMenu
{
    class Program : ConsoleGame
    {
        int option = 0;
        private static FigletFont font;
        bool isMainStart = true;
        private int i = 0;

        private static void Main(string[] args)
        {
            int width = Console.WindowWidth * 2;
            int height = Console.WindowHeight * 2;
            new Program().Construct(width,height, 1, 1, FramerateMode.Unlimited);
        }

        public override void Create()
        {
            Console.SetBufferSize(Console.WindowWidth*4, Console.WindowHeight*4);
            Engine.SetPalette(Palettes.Pico8);
            Engine.Borderless();
            Console.Title = "Console Game";
            font = FigletFont.Load("3d.flf");
        }

        public override void Render()
        {
            MenuStart();
        }

        public override void Update()
        {
            if (Engine.GetKeyDown(ConsoleKey.Escape))
                Environment.Exit(0);
        }

        public void MenuStart()
        {
            Engine.ClearBuffer();
            int colorValue = 1; // Starting color value

            while (true)
            {
                for (i = 0; i <= 3; i++)
                {
                    Engine.ClearBuffer(); // Clear the buffer to redraw

                    // Write the text with the current color value
                    Engine.WriteFiglet(new Point(0, i), "Looking", font, colorValue);
                    Engine.WriteFiglet(new Point(0, i + 10), "for one", font, colorValue + 1);
                    Engine.WriteFiglet(new Point(0, i + 20), "Member", font, colorValue + 2);
                    Engine.WriteFiglet(new Point(0, i + 30), "ITEC-102", font, colorValue + 3);
                    Engine.DisplayBuffer();

                    System.Threading.Thread.Sleep(500); // Adjust the speed of the animation

                    // Increment colorValue and wrap around if it exceeds 10
                    colorValue++;
                    if (colorValue > 5)
                        colorValue = 2;
                }

                if (Engine.GetKeyDown(ConsoleKey.Enter))
                    break; // Exit the animation loop when Enter is pressed
            }
        }
    }
}