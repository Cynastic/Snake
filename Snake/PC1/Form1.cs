namespace PC1
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Player playerObj;
        Fruit fruitObj;

        Brush playerColor;
        Brush fruitColor;
        Brush gridColor;
        Brush tailColor;

        int tileSize;
        int gridSize;

        Stack<Point> positions = new Stack<Point>();

        System.Windows.Forms.Timer gameTick;

        int TicksPassed = 0;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            playerObj = new Player();
            fruitObj = new Fruit();

            playerColor = new SolidBrush(Color.White);
            gridColor = new SolidBrush(Color.Black);
            fruitColor = new SolidBrush(Color.Orange);
            tailColor = new SolidBrush(Color.Gray);

            tileSize = 10;
            gridSize = 30;

            fruitObj.MoveTo(RandomPos());

            gameTick = new System.Windows.Forms.Timer();
            gameTick.Interval = 100;
            gameTick.Tick += GameTick_Tick;
            gameTick.Start();
        }

        private void GameTick_Tick(object? sender, EventArgs e)
        {
            Point pos = playerObj.GetPosition();

            bool canMoveX = pos.x + playerObj.moveX >= 10 && pos.x + playerObj.moveX <= 300;
            bool canMoveY = pos.y + playerObj.moveY >= 10 && pos.y + playerObj.moveY <= 300;
            if (canMoveX && canMoveY)
            {
                playerObj.Move();
            }
            else
            {
                PlayerDeath();
            }
            if (playerObj.GetPosition() == fruitObj.GetPosition())
            {
                fruitObj.MoveTo(RandomPos());
                playerObj.Points++;
                playerObj.Tailparts.Add(new TailPart());
            }
            foreach (TailPart p in playerObj.Tailparts)
            {
                if (playerObj.x == p.x && playerObj.y == p.y)
                {
                    PlayerDeath();
                    break;
                }
            }

            TicksPassed++;
            ScoreLabel.Text = "Score: " + playerObj.Tailparts.Count.ToString();
            TimerLabel.Text = "Time: " + TicksPassed / 10;

            this.Invalidate();
        }

        private void Form_Draw(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            //Draw Grid
            Rectangle Grid = new Rectangle(10, 10, gridSize * tileSize, gridSize * tileSize);
            graphics.DrawRectangle(new Pen(gridColor), Grid);
            graphics.FillRectangle(gridColor, Grid);

            //Draw Player
            Rectangle PlayerRect = new Rectangle((playerObj.x * tileSize) + 10, (playerObj.y * tileSize) + 10, 10, 10);
            graphics.FillRectangle(playerColor, PlayerRect);

            //Draw Fruit
            Rectangle FruitRect = new Rectangle((fruitObj.x * tileSize) + 10, (fruitObj.y * tileSize) + 10, 10, 10);
            graphics.FillRectangle(fruitColor, FruitRect);

            //Draw Tail
            foreach (TailPart tail in playerObj.Tailparts)
            {
                Rectangle tailRect = new Rectangle((tail.x * 10) + 10, (tail.y * 10) + 10, 10, 10);
                graphics.FillRectangle(tailColor, tailRect);
            }
        }

        public Point RandomPos()
        {
            Random r = new Random();
            Point p = new Point();
            p = new Point(r.Next(0, gridSize), r.Next(0, gridSize));
            while (p == playerObj.GetPosition())
            {
                r = new Random();
                p = new Point(r.Next(0, gridSize), r.Next(0, gridSize));
            }
            return p;
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    playerObj.moveX = 1;
                    playerObj.moveY = 0;
                    break;
                case Keys.Left:
                    playerObj.moveX = -1;
                    playerObj.moveY = 0;
                    break;
                case Keys.Up:
                    playerObj.moveX = 0;
                    playerObj.moveY = -1;
                    break;
                case Keys.Down:
                    playerObj.moveX = 0;
                    playerObj.moveY = 1;
                    break;
            }
        }

        public void PlayerDeath()
        {
            gameTick.Stop();
            if (MessageBox.Show("You died with a Score of " + playerObj.Tailparts.Count.ToString()) == DialogResult.OK)
            {
                playerObj.Tailparts.Clear();
                playerObj.x = 0;
                playerObj.y = 0;
                playerObj.moveX = 0;
                playerObj.moveY = 0;
                TicksPassed = 0;
                fruitObj.MoveTo(RandomPos());
                gameTick.Start();
            }
        }

        private void ScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void TimerLabel_Click(object sender, EventArgs e)
        {

        }
    }

    public class Fruit
    {

        public int x;
        public int y;

        public void MoveTo(int Ix, int Iy)
        {
            x = Ix;
            y = Iy;
        }
        public void MoveTo(Point I)
        {
            x = I.x;
            y = I.y;
        }

        public Point GetPosition()
        {
            return new Point((x * 10) + 10, (y * 10) + 10);
        }
    }

    public class TailPart
    {
        public int x = -100;
        public int y = -100;

        public void moveTo(int Ix, int Iy)
        {
            x = Ix;
            y = Iy;
        }
    }

    public class Player
    {
        public int Points = 1;

        public int x;
        public int y;

        public int moveX;
        public int moveY;

        public List<TailPart> Tailparts = new List<TailPart>();

        public Player()
        {

        }

        public void Move()
        {
            Point lastPoint = new Point(x, y);
            x += moveX;
            y += moveY;
            for (int i = Tailparts.Count - 1; i >= 0; i--)
            {
                TailPart curTail = Tailparts[i];
                if (i - 1 >= 0) curTail.moveTo(Tailparts[i - 1].x, Tailparts[i - 1].y);
                else curTail.moveTo(lastPoint.x, lastPoint.y);
            }
        }

        public Point GetPosition()
        {
            return new Point((x * 10) + 10, (y * 10) + 10);
        }

    }

    public struct Point
    {
        public int x = 0;
        public int y = 0;

        public Point(int Ix, int Iy)
        {
            x = Ix;
            y = Iy;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1.x == p2.x && p1.y == p2.y);
        }
    }
}