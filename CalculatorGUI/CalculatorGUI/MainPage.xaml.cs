﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CalculatorGUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool easterFlag = false;    //used to activate the easter egg

        public MainPage()
        {
            this.InitializeComponent();
        }        

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            //Get text box value, while checking for error
            double num1 = tryConvertTxtBoxNum1();  
            double num2 = tryConvertTxtBoxNum2();

            //Create Answer
            double answer = num1 + num2;
            txtAnswer.Text = Convert.ToString(answer);

            //This fails the easter eggg
            easterFlag = false;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e) {
            double num1 = tryConvertTxtBoxNum1();
            double num2 = tryConvertTxtBoxNum2();

            double answer = num1 - num2;
            txtAnswer.Text = Convert.ToString(answer);

            easterFlag = false;
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            double num1 = tryConvertTxtBoxNum1();
            double num2 = tryConvertTxtBoxNum2();

            double answer = num1 * num2;
            txtAnswer.Text = Convert.ToString(answer);

            easterFlag = false;
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            double num1 = tryConvertTxtBoxNum1();
            double num2 = tryConvertTxtBoxNum2();

            if (num2 != 0) {    //check not dividing by 0
                double answer = num1 / num2;
                txtAnswer.Text = Convert.ToString(answer);
                easterFlag = false;
            }
            else {  //cant divide by 0
                txtAnswer.Text = "Cannot / by 0";
                easterFlag = true; //the user can do the easter egg now
            }
        }

        private void btnPower_Click(object sender, RoutedEventArgs e) {
            double num1 = tryConvertTxtBoxNum1();
            double num2 = tryConvertTxtBoxNum2();

            double answer = Math.Pow(num1,num2); //num1^num2
            txtAnswer.Text = Convert.ToString(answer);
            easterFlag = false;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e) { //easter egg button
            if(easterFlag) {
                txtAnswer.Text = "Alex Gowans"; //easter egg show name
            }
            else {
                txtAnswer.Text = "Hello there"; //otherwise say hello
            }
        }

        private void btnAnsNum1_Click(object sender, RoutedEventArgs e) { //add previous answer to input box
            txtBoxNum1.Text = txtAnswer.Text;
        }

        private void btnAnsNum2_Click(object sender, RoutedEventArgs e) {
            txtBoxNum2.Text = txtAnswer.Text;
        }


        //Try to convert the text into a double, return 0 and ammend textbox if not able to convert
        private double tryConvertTxtBoxNum1() {
            double me;
            try {
                me = Convert.ToDouble(txtBoxNum1.Text);
            }
            catch (Exception) {
                me = 0.0;
                txtBoxNum1.Text = Convert.ToString(me);
            }
            return me;
        }

        private double tryConvertTxtBoxNum2() {
            double me;
            try {
                me = Convert.ToDouble(txtBoxNum2.Text);
            }
            catch (Exception) {
                me = 0.0;
                txtBoxNum2.Text = Convert.ToString(me);
            }
            return me;
        }

        //
    }
}
