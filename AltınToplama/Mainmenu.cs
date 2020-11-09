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
    public partial class AltınToplama : Form
    {
        Settings st = new Settings();
        
        public AltınToplama()
        {
            InitializeComponent();
        }
        public void get_Settings()
        {
            boardSize_x.Text = st.get_boardSize_x().ToString();
            boardSize_y.Text = st.get_boardSize_y().ToString();
            coinRate.Text = st.get_coinRate().ToString();
            hiddenCoinRate.Text = st.get_hiddenCoinRate().ToString();
            startCoin.Text = st.get_startCoin().ToString();
            maxMoveCount.Text = st.get_maxMoveCount().ToString();
            A_MovePrice.Text = st.get_A_MovePrice().ToString();
            A_TargetPrice.Text = st.get_A_TargetPrice().ToString();
            B_MovePrice.Text = st.get_B_MovePrice().ToString();
            B_TargetPrice.Text = st.get_B_TargetPrice().ToString();
            C_MovePrice.Text = st.get_C_MovePrice().ToString();
            C_TargetPrice.Text = st.get_C_TargetPrice().ToString();
            D_MovePrice.Text = st.get_D_MovePrice().ToString();
            D_TargetPrice.Text = st.get_D_TargetPrice().ToString();
        }
        public void set_Settings()
        {
            st.set_boardSize_x(int.Parse(boardSize_x.Text));
            st.set_boardSize_y(int.Parse(boardSize_y.Text));
            st.set_coinRate(int.Parse(coinRate.Text));
            st.set_hiddenCoinRate(int.Parse(hiddenCoinRate.Text));
            st.set_startCoin(int.Parse(startCoin.Text));
            st.set_maxMoveCount(int.Parse(maxMoveCount.Text));
            st.set_A_MovePrice(int.Parse(A_MovePrice.Text));
            st.set_A_TargetPrice(int.Parse(A_TargetPrice.Text));
            st.set_B_MovePrice(int.Parse(B_MovePrice.Text));
            st.set_B_TargetPrice(int.Parse(B_TargetPrice.Text));
            st.set_C_MovePrice(int.Parse(C_MovePrice.Text));
            st.set_C_TargetPrice(int.Parse(C_TargetPrice.Text));
            st.set_D_MovePrice(int.Parse(D_MovePrice.Text));
            st.set_D_TargetPrice(int.Parse(D_TargetPrice.Text));
        }
        public List<int> startGame()
        {
            List<int> stlist = new List<int>();
            stlist.Add(st.get_boardSize_x());
            stlist.Add(st.get_boardSize_y());
            stlist.Add(st.get_coinRate());
            stlist.Add(st.get_hiddenCoinRate());
            stlist.Add(st.get_startCoin());
            stlist.Add(st.get_maxMoveCount());
            stlist.Add(st.get_A_MovePrice());
            stlist.Add(st.get_A_TargetPrice());
            stlist.Add(st.get_B_MovePrice());
            stlist.Add(st.get_B_TargetPrice());
            stlist.Add(st.get_C_MovePrice());
            stlist.Add(st.get_C_TargetPrice());
            stlist.Add(st.get_D_MovePrice());
            stlist.Add(st.get_D_TargetPrice());
            return stlist;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            Game game = new Game(this,startGame());
            this.Visible = false;
            game.Show();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            get_Settings();
            Settings.Visible = true;
            Mainmenu.Visible = false;
        }
        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sett_back_Click(object sender, EventArgs e)
        {
            Mainmenu.Visible = true;
            Settings.Visible = false;
        }

        private void sett_apply_Click(object sender, EventArgs e)
        {
            set_Settings();
        }

        private void sett_default_Click(object sender, EventArgs e)
        {
            st.set_Default();
            get_Settings();
        }
    }
}
