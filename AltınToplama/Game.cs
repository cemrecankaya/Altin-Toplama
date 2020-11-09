using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltınToplama
{
    class location
    {
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public location parent;
    }
    public partial class Game : Form
    {
        
        Form menu;                //Ana menüye geri dönmek için
        Bitmap bitmapBoard;       //Sadece oyun tahtasının çizdirilmiş hali 
        Bitmap bitmap;                //Altın,oyuncu gibi çizimlerin bitmapBoard üzerine eklenip saklandığı hali
        Graphics g;               //Grafik çizim
        Random rd = new Random(); //Random
        Image[] coinImages = new Image[4]; // Altın resimleri
        int[,] board;             //Oyun tahtası içerisinde altınların, gizli altınların ve oyuncu başlangıç noktalarının tutulduğu matris
        int[,] boardCoinValue;    //Oyun tahtası matrisi ile aynı boyutta altınların değerine göre resimlerinin tutulduğu matris
        int squareHeight = 50;    //Kare kenar uzunluğu (pixel)
        int boardSize_x;          //Tahtanın genişliği (kare)
        int boardSize_y;          //Tahtanın yüksekliği (kare)
        int coinRate;           //Altınların toplam kare sayısına oranı
        int hiddenCoinRate;       //Gizli altınların tüm altınlara oranı
        int startCoin;            //Oyuncuların başlangıç altın miktarı
        int maxMoveCount;         //Oyuncuların bir turdaki max hareket hakkı
        int[,] boardSquareNum;

        int A_MovePrice;   //A Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        int B_MovePrice;   //B Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        int C_MovePrice;   //C Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        int D_MovePrice;   //D Oyuncusunun her bir hamle için ödemesi gereken altın miktarı

        int A_TargetPrice; //A Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        int B_TargetPrice; //B Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        int C_TargetPrice; //C Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        int D_TargetPrice; //D Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        
        int coinCount;       // Tahtada bulunan toplam altın miktarı
        int hiddenCoinCount; // Tahtada bulunan gizli altınlar
        int tempx, tempy;    // Matris x y koordinatları geçici tutmak için

        public Game(Form menu,List<int> stlist)
        {
            this.menu = menu;

            this.boardSize_x = stlist[0];
            this.boardSize_y = stlist[1];
            this.coinRate = stlist[2];
            this.hiddenCoinRate = stlist[3];
            this.startCoin = stlist[4];
            this.maxMoveCount = stlist[5];
            this.coinCount = ((boardSize_x * boardSize_y) * coinRate) / 100;
            this.hiddenCoinCount = coinCount / hiddenCoinRate;

            this.A_MovePrice = stlist[6];
            this.B_MovePrice = stlist[7];
            this.C_MovePrice = stlist[8];
            this.D_MovePrice = stlist[9];

            this.A_TargetPrice = stlist[10];
            this.B_TargetPrice = stlist[11];
            this.C_TargetPrice = stlist[12];
            this.D_TargetPrice = stlist[13];
            this.board = new int[boardSize_x, boardSize_y];
            /*  
                board=0   =>> Boş
                board=1   =>> Altın
                board=2   =>> Gizli altın
                board=3   =>> Oyuncu kareleri
            */
            this.boardCoinValue = new int[boardSize_x, boardSize_y];
            /*  
                boardCoinValue=1    =>> 5 altın
                boardCoinValue=2   =>> 10 altın
                boardCoinValue=3   =>> 15 altın
                boardCoinValue=4   =>> 20 altın
            */
            this.boardSquareNum = new int[boardSize_x * boardSize_y,2];
            /*
                numarası  |   x   |   y   | x,y koordinatındaki karenin numarası
                   0      |   0   |   0   | boardSquareNum[0,0]=x,boardSquareNum[0,1]=y
                   1      |   0   |   1   | boardSquareNum[1,0]=x,boardSquareNum[1,1]=y
             */
            coinImages[0] = global::AltınToplama.Properties.Resources.coin5;
            coinImages[1] = global::AltınToplama.Properties.Resources.coin10;
            coinImages[2] = global::AltınToplama.Properties.Resources.coin15;
            coinImages[3] = global::AltınToplama.Properties.Resources.coin20;
            InitializeComponent();
        }
        public int randImg()
        {
            return rd.Next(1, 5);
        }
        public int randx()
        {
            return rd.Next(0, boardSize_x);
        }
        public int randy()
        {
            return rd.Next(0, boardSize_y);
        }
        public void gameBoardSetup()
        {
            Console.WriteLine("coin : " + coinCount + "    hiddencoin : " + hiddenCoinCount);
            // Tahtanın her köşesinde oyuncuların başlangıç noktaları
            board[0, 0] = 3;
            board[0, boardSize_y-1] = 3;
            board[boardSize_x-1,0] = 3;
            board[boardSize_x-1,boardSize_y-1] = 3;
            
            // Altınların rastgele yerleştirilmesi
            for(int i = 0; i < coinCount - hiddenCoinCount; i++)
            {
                tempx = randx();
                tempy = randy();
                while (board[tempx, tempy] == 1 || board[tempx, tempy]==3)
                {
                    tempx = randx(); tempy = randy();
                }
                board[tempx, tempy] = 1;
                boardCoinValue[tempx, tempy] = randImg();
            }

            // Gizli altınların rastgele yerleştirilmesi
            for (int i = 0; i < hiddenCoinCount; i++)
            {
                tempx = randx();
                tempy = randy();
                while (board[tempx, tempy] == 1 || board[tempx, tempy] == 2 || board[tempx, tempy] == 3)
                {
                    tempx = randx();tempy = randy();
                }
                board[tempx, tempy] = 2;
                boardCoinValue[tempx, tempy] = randImg();
            }

            int k = -1;
            for (int i = 0; i < boardSize_x; i++)
            {
                for (int j = 0; j < boardSize_y; j++)
                {
                    k++;
                    boardSquareNum[k,0]=i;//0=x
                    boardSquareNum[k,1]=j;//1=y
                }
            }
            Console.WriteLine("K : "+k);

            for (int i = 0; i < boardSize_x; i++)
            {
                for(int j = 0; j < boardSize_y; j++)
                {
                    Console.Write(board[i,j].ToString());
                    if (j + 1 != boardSize_y)
                        Console.Write("-");
                }
                Console.Write("  |  ");
                for (int j = 0; j < boardSize_y; j++)
                {
                    Console.Write(boardCoinValue[i, j].ToString());
                    if (j + 1 != boardSize_y)
                        Console.Write("-");
                }
                Console.WriteLine();
            }




        }
        public void gameBoardDraw()
        {
            bitmapBoard = new Bitmap(gameBoard.Width, gameBoard.Height);
            g = Graphics.FromImage(bitmapBoard);
            Color color1 = Color.FromArgb(200, 200, 200);
            Color color2 = Color.White;
            for (int i = 0; i < boardSize_x; i++)
            {
                if (i % 2 == 0)
                {
                    color1 = Color.FromArgb(200, 200, 200);
                    color2 = Color.White;
                }
                else
                {
                    color2 = Color.FromArgb(200, 200, 200);
                    color1 = Color.White;
                }
                SolidBrush blackBrush = new SolidBrush(color1);
                SolidBrush whiteBrush = new SolidBrush(color2);
                for (int j = 0; j < boardSize_y; j++)
                {
                    if (j % 2 == 0)
                        g.FillRectangle(blackBrush, squareHeight * i, squareHeight * j, squareHeight, squareHeight);
                    else
                        g.FillRectangle(whiteBrush, squareHeight * i, squareHeight * j, squareHeight, squareHeight);
                }
            }
            int x = ((panel2.Width - gameBoard.Width) / 2);
            int y = ((panel2.Height - gameBoard.Height) / 2);
            gameBoard.Location = new Point(x, y);
            gameBoard.Image = bitmapBoard;

        }
        public void gameBoardCoinDraw()
        {
            bm = bitmapBoard;
            g = Graphics.FromImage(bm);

            for (int i = 0; i < boardSize_x; i++)
            {
                for (int j = 0; j < boardSize_y; j++)
                {
                    if (board[i, j] == 1)
                        g.DrawImage(images[boardCoinValue[i, j] - 1], squareHeight * i, squareHeight * j, squareHeight, squareHeight);
                }
            }
            //g.DrawImage(bm, 0, 0);
            gameBoard.Image = bm;
        }
       
        private void Game_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            gameBoardSetup();

            if (squareHeight * boardSize_x > gameBoard.Width)
                squareHeight = gameBoard.Width / boardSize_x;
            if (squareHeight * boardSize_y > gameBoard.Height)
                squareHeight = gameBoard.Height / boardSize_y;

            gameBoard.Width = squareHeight * boardSize_x;
            gameBoard.Height = squareHeight * boardSize_y;

            gameBoardDraw();
            gameBoardCoinDraw();
            AStarPathFinder(3,3,7,10);
        }
        public void AStarPathFinder(int start_x, int start_y, int target_x, int target_y)
        {
            location start = new location { X = start_x, Y = start_y };
            location target = new location { X = target_x, Y = target_y };
            location current = null;
            List<location> openList = new List<location>();
            List<location> closedList = new List<location>();
            int g = 0;

            char[,] startTarget = new char[boardSize_x, boardSize_y];

            for(int i = 0; i < boardSize_x; i++)
            {
                for(int j = 0; j < boardSize_y; j++)
                {
                    startTarget[i, j] = ' ';
                }
            }
            startTarget[start_x, start_y] = 'A';
            startTarget[target_x, target_y] = 'B';

            for (int i = 0; i < boardSize_x; i++)
            {
                for (int j = 0; j < boardSize_y; j++)
                {
                    Console.Write(startTarget[i, j]);
                }
                Console.WriteLine();
            }

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowest = openList.Min(l => l.F);
                current = openList.First(l => l.F == lowest);

                closedList.Add(current);
                openList.Remove(current);

                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;
                
                var adjacentSquares = GetMoveArea(current.X, current.Y, startTarget);
                g++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) != null)
                        continue;

                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) == null)
                    {
                        adjacentSquare.G = g;
                        adjacentSquare.H = heuristic(target.X, target.Y, adjacentSquare.X, adjacentSquare.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.parent = current;

                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.parent = current;
                        }
                    }
                }
            }
            while (current != null)
            {
                Console.Write("[" + current.X + "-" + current.Y + "]");
                current = current.parent;
            }
        }
        public List<location> GetMoveArea(int x, int y, char[,] map)
        {
            List<location> allWay = new List<location>();

            if (y - 1 != -1)
                allWay.Add(new location { X = x, Y = y - 1 });
            if (y + 1 != boardSize_y + 1)
                allWay.Add(new location { X = x, Y = y + 1 });
            if (x - 1 != -1) 
                allWay.Add(new location { X = x - 1, Y = y });
            if (x + 1 != boardSize_x + 1) 
                allWay.Add(new location { X = x + 1, Y = y });
            

            return allWay.Where(l => map[l.X,l.Y] == ' ' || map[l.X,l.Y] == 'B').ToList();
        }
        public int heuristic(int target_x, int target_y, int x, int y)
        {
            return Math.Abs(target_x - x) + Math.Abs(target_y - y);
        }
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
