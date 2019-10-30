using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairGame
{
    public partial class Form1 : Form
    {

        Label firstClicked = null; // first store nothing, after click it will store value
        Label secondClicked = null; // first store nothing, after click it will store value

        Random random = new Random();  //generate random icons 

        List<string> icons = new List<string>() //store icons
        {
            "!","!","N","N",",",",","k","k","b","b","v","v","w","w","z","z"
        };

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquaares();

        }



        private void AssignIconsToSquaares()
        { 
           
            foreach (Control control in tableLayoutPanel1.Controls)
            {
            
                 Label iconLabel = control as Label;
                  if(iconLabel != null)
                {
            
                         int randomNumber = random.Next(icons.Count);
                         iconLabel.Text =icons[randomNumber];


                         iconLabel.ForeColor = iconLabel.BackColor;
                         icons.RemoveAt(randomNumber);

                 }
           
             }

          }

        private void label_click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true) // it checks timer started or not
                return;


            Label clickedLabel = sender as Label;
            if(clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
               // clickedLabel.ForeColor = Color.Black;

               if(firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e) //dissapera time after 2 click if not match
        {
            timer1.Stop(); //it wont work till first click
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null; //reset variable again
            secondClicked = null; //reset variable again
        }
         
        private void CheckForWinner()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("You matched all icons!", "Congratulations and well done!");
            Close();
        }
    }
 }
