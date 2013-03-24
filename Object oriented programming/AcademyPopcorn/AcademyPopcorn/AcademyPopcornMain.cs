using System;
using System.Linq;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 21;
        const int WorldCols = 20;
        const int RacketLength = 4;
        const int GameSpeed = 50;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

			// Roof
			for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock indestructibleRoof = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(indestructibleRoof);
            }

			// Walls
			for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock indestructibleLeftWall = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock indestructibleRightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols-1));
                engine.AddObject(indestructibleLeftWall);
                engine.AddObject(indestructibleRightWall);
            }

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

			TrailObject trailObject = new TrailObject(new MatrixCoords(startRow + 3, 5), 20);
			engine.AddObject(trailObject);

			for (int i = startCol+3; i < endCol-3; i++)
            {
                UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(startRow+6, i));
                engine.AddObject(currBlock);
            }

			ExplodingBlock explodingBlock = new ExplodingBlock(new MatrixCoords(WorldRows - 3, WorldCols / 2+1));
			engine.AddObject(explodingBlock);

			// Add gift object
			//Gift gift = new Gift(new MatrixCoords(-3, 10), 3);
            //engine.AddObject(gift);

			MeteoriteBall meteor = new MeteoriteBall(new MatrixCoords(WorldRows - 4, WorldCols / 2),
                new MatrixCoords(-1, 1));
			engine.AddObject(meteor);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols/2 - RacketLength), RacketLength);
            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, GameSpeed);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
