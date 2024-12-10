using System.Drawing;
using System.Numerics;
using Raylib_cs;
using  static Raylib_cs.Raylib;

namespace csharp_raylib_primordial_test;


public class Program
{
	public static void Main()
	{
		InitWindow(800, 480, "Game");
		SetTargetFPS(60);

		Player player = new Player(new Vector2(50f,50f), 20f);
		Raylib_cs.Rectangle floor = new Raylib_cs.Rectangle(1,400,800,50);

		while (!WindowShouldClose())
		{
			BeginDrawing();
			ClearBackground(Raylib_cs.Color.White);

			player.Update(floor);
			DrawText("PLACEHOLDER", 12, 12, 20, Raylib_cs.Color.Black);
			DrawRectangleRec(floor,Raylib_cs.Color.Beige);

			EndDrawing();
		}

		CloseWindow();
	}
}

