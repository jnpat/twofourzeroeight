using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
        }

        private void UpdateTile(Label l, int i)
        {
            sc.Text = model.getScore().ToString();
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.LightSteelBlue;
                    break;
                case 2:
                    l.BackColor = Color.PaleVioletRed;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Sienna;
                    break;
                default:
                    l.BackColor = Color.DarkOliveGreen;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
        }
        
        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }
        
        
        private void btnRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Left:
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    break;
                case (char)Keys.Right:
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    break;
                case (char)Keys.Up:
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    break;
                case (char)Keys.Down:
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    break;
            }
            if (model.GameOver())
            {
                popGameOver();
            }
        }

        private void btnRight_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    break;
                case Keys.Right:
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    break;
                case Keys.Up:
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    break;
                case Keys.Down:
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    break;
                
            }
            if (model.GameOver())
            {
                popGameOver();
            }
            
        }
        private void popGameOver()
        {
            MessageBox.Show("GAMEOVER","",MessageBoxButtons.OK);
        }
    }
}
