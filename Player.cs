using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

public class Player
	{
		// Propiedades
		public Vector2 playerPosition { get; set; }

		public float playerPositionX, playerPositionY;
		public float radius {get; set; }
		public Raylib_cs.Color color {get; set; }

		private float gravityValue {get; set; }

		private float walkSpeed {get; set; }

		private float jumpSpeed {get; set; }

		private bool onFloor {get; set; }

		private float maxGravity {get; set;}
		private float sumGravity {get; set;}


		// Constructor
		public Player(Vector2 playerPosition, float radius)
		{
			this.playerPositionX = playerPosition.X;
			this.playerPositionY = playerPosition.Y;
			this.playerPosition = new Vector2(this.playerPositionX,this.playerPositionY);
			this.radius = radius;
			this.color = new Raylib_cs.Color(0,150,100,255);
			this.gravityValue = 0f;
			this.maxGravity = 9.8f;
			this.sumGravity = 0.15f;
			this.walkSpeed = 5.0f;
			this.onFloor = false;
			this.jumpSpeed = 50f;
			
		}

		private void Input()
		{
			if (IsKeyDown(KeyboardKey.A)){
				this.playerPositionX -= this.walkSpeed;
			}
			if (IsKeyDown(KeyboardKey.D)){
				this.playerPositionX += this.walkSpeed;
			}

			if (IsKeyDown(KeyboardKey.Space) && onFloor){
				this.playerPositionY -= this.jumpSpeed;
			}
		}
		// Método
		private void Draw()
		{
			DrawCircle((int)playerPosition.X,(int)playerPosition.Y,this.radius,this.color);
		}

		private void Gravity()
		{
			if (!onFloor){
				if (this.gravityValue <= this.maxGravity){
					this.gravityValue += this.sumGravity;
					this.playerPositionY += gravityValue; 
				}
				else if (this.gravityValue > this.maxGravity){
					this.gravityValue = this.maxGravity;
				}

			}
			else {
				{
					this.gravityValue = 0;

				}
			}
		}

		private void Collisions(Raylib_cs.Rectangle rect){

			if (CheckCollisionCircleRec(this.playerPosition,this.radius,rect))
			{
				this.onFloor = true;
			}
			else
				{
				this.onFloor =false;
			}
		}

		private void UpdatePosition(){

			this.playerPosition = new Vector2(this.playerPositionX,this.playerPositionY);
		}
		public void Update(Raylib_cs.Rectangle rect)
		{
			Console.WriteLine($"gravedad actual {this.gravityValue} ");
			this.Input();
			this.Collisions(rect);
			this.Gravity();
			this.UpdatePosition();
			this.Draw();
		}
	}
