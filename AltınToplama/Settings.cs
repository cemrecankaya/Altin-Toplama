using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınToplama
{
    class Settings
    {
        private int boardSize_x;   //Tahtanın genişliği (kare)
        private int boardSize_y;   //Tahtanın yüksekliği (kare)
        private int coinRate;      //Altınların toplam kare sayısına oranı
        private int hiddenCoinRate;//Gizli altınların tüm altınlara oranı
        private int startCoin;     //Oyuncuların başlangıç altın miktarı
        private int maxMoveCount;  //Oyuncuların bir turdaki max hareket hakkı
        
        private int A_MovePrice;   //A Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        private int B_MovePrice;   //B Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        private int C_MovePrice;   //C Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        private int D_MovePrice;   //D Oyuncusunun her bir hamle için ödemesi gereken altın miktarı
        
        private int A_TargetPrice; //A Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        private int B_TargetPrice; //B Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        private int C_TargetPrice; //C Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı
        private int D_TargetPrice; //D Oyuncusunun hedef belirleme için ödemesi gereken altın miktarı

        public Settings() {
        
            boardSize_x = 20;      // 20 kare
            boardSize_y = 20;      // 20 kare
            coinRate = 20;        // %20
            hiddenCoinRate = 10;  // %10
            startCoin = 200;      // 200 altın
            maxMoveCount = 3;     // 3 hamle hakkı

            A_MovePrice = 5;
            B_MovePrice = 5;
            C_MovePrice = 5;
            D_MovePrice = 5;

            A_TargetPrice = 5;
            B_TargetPrice = 10;
            C_TargetPrice = 15;
            D_TargetPrice = 20;

        }

        //------------------------------  Gets  --------------------------------
        public int get_boardSize_x() {
            return this.boardSize_x;
        }
        public int get_boardSize_y() {
            return this.boardSize_y;
        }
        public int get_coinRate() {
            return this.coinRate;
        }
        public int get_hiddenCoinRate() {
            return this.hiddenCoinRate;
        }
        public int get_startCoin() {
            return this.startCoin;
        } 
        public int get_maxMoveCount() {
            return this.maxMoveCount;
        }
        public int get_A_MovePrice() {
            return this.A_MovePrice;
        }
        public int get_B_MovePrice() {
            return this.B_MovePrice;
        }
        public int get_C_MovePrice() {
            return this.C_MovePrice;
        }
        public int get_D_MovePrice() {
            return this.D_MovePrice;
        }
        public int get_A_TargetPrice() {
            return this.A_TargetPrice;
        }
        public int get_B_TargetPrice() {
            return this.B_TargetPrice;
        }
        public int get_C_TargetPrice() {
            return this.C_TargetPrice;
        }
        public int get_D_TargetPrice() {
            return this.D_TargetPrice;
        }

        //------------------------------  Sets  --------------------------------
        public void set_boardSize_x(int boardSize_x)
        {
            this.boardSize_x = boardSize_x;
        }
        public void set_boardSize_y(int boardSize_y)
        {
            this.boardSize_y = boardSize_y;
        }
        public void set_coinRate(int coinRate)
        {
            this.coinRate = coinRate;
        }
        public void set_hiddenCoinRate(int hiddenCoinRate)
        {
            this.hiddenCoinRate = hiddenCoinRate;
        }
        public void set_startCoin(int startCoin)
        {
            this.startCoin = startCoin;
        }
        public void set_maxMoveCount(int maxMoveCount)
        {
            this.maxMoveCount = maxMoveCount;
        }
        public void set_A_MovePrice(int A_MovePrice)
        {
            this.A_MovePrice = A_MovePrice;
        }
        public void set_B_MovePrice(int B_MovePrice)
        {
            this.B_MovePrice = B_MovePrice;
        }
        public void set_C_MovePrice(int C_MovePrice)
        {
            this.C_MovePrice = C_MovePrice;
        }
        public void set_D_MovePrice(int D_MovePrice)
        {
            this.D_MovePrice = D_MovePrice;
        }
        public void set_A_TargetPrice(int A_TargetPrice)
        {
            this.A_TargetPrice = A_TargetPrice;
        }
        public void set_B_TargetPrice(int B_TargetPrice)
        {
            this.B_TargetPrice = B_TargetPrice;
        }
        public void set_C_TargetPrice(int C_TargetPrice)
        {
            this.C_TargetPrice = C_TargetPrice;
        }
        public void set_D_TargetPrice(int D_TargetPrice)
        {
            this.D_TargetPrice = D_TargetPrice;
        }

        //----------------------------  Default  ------------------------------
        public void set_Default()
        {
            this.boardSize_x = 20;
            this.boardSize_y = 20;
            this.coinRate = 20;
            this.hiddenCoinRate = 10;
            this.startCoin = 200;
            this.maxMoveCount = 3;
            this.A_MovePrice = 5;
            this.A_TargetPrice = 5;
            this.B_MovePrice = 5;
            this.B_TargetPrice = 10;
            this.C_MovePrice = 5;
            this.C_TargetPrice = 15;
            this.D_MovePrice = 5;
            this.D_TargetPrice = 20;
        }


    }
}
