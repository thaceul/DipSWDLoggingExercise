using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Factorialiser.Classes;

namespace Factorialiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            logger.Trace("Main Window Loaded");
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check if textboxInput.Text is empty (or only contains white space), 
                // if this is the case then throw a NullValueException
                if (string.IsNullOrWhiteSpace(textBoxInput.Text))
                {
                    throw new NullValueException();
                }

                //declare a variable here called input or datatype int
                int input;

                try
                {
                    input = Int32.Parse(textBoxInput.Text);

                    logger.Debug("MainForm.buttonCalculate_Click: input successfully parsed");
                    // try and parse the text input into textboxInput into an integer and assign it to input
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input successfully parsed"
                }
                catch
                {
                    logger.Debug("MainForm.buttonCalculate_Click: input parse failed");
                    throw new NotIntegerException(textBoxInput.Text);
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input parse failed"
                    // throw a NotIntegerException 
                }

                int factorial = Calculator.Factorial(input);
                // pass the input to the Calculator.Factorial method and store the retuen value in a variable
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: Calculate.Factorial suceeded"
                logger.Debug("MainForm.buttonCalculate_Click: Calculate.Factorial suceeded");
                // change the text of labelOutput to reflect
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: labelOutput successfully updated"
                labelOutput.Content = factorial;

                logger.Debug("MainForm.buttonCalculate_Click: labelOutput successfully updated");


            }
            catch (NullValueException)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                labelOutput.Content = null;
                textBoxInput.Text = null;
                logger.Error("MainForm.buttonCalculate_Click: NullValueException message displayed");
                MessageBox.Show("Nothing Entered - Please enter an integer", "NullValueException");
            }

            catch (NotIntegerException)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                labelOutput.Content = null;
                textBoxInput.Text = null;
                logger.Error("MainForm.buttonCalculate_Click: NotIntegerException message displayed");
                MessageBox.Show("Non-Integer Entered - Please enter an integer", "NotIntegerException");
            }
            catch (NumberTooLowException)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                labelOutput.Content = null;
                textBoxInput.Text = null;
                logger.Error("MainForm.buttonCalculate_Click: NumberTooLowException message displayed");
                MessageBox.Show("Number Too Low - Please enter an number greater than 0", "NumberTooLowException");
            }

            catch (NumberTooHighException)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                labelOutput.Content = null;
                textBoxInput.Text = null;
                logger.Error("MainForm.buttonCalculate_Click: NumberTooHighException message displayed");
                MessageBox.Show("Number Too High - Please enter an number less than 30", "NumberTooHighException");
            }

            catch (Exception ex)
            {

                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Unknown Error")
                // log the event as an Fatal Level log 
                // with the message ("MainForm.buttonCalculate_Click: Unknown Error : " + ex.message)

                labelOutput.Content = null;
                textBoxInput.Text = null;
                MessageBox.Show("Unknown Error", "UnknownErrorException");
                logger.Fatal("MainForm.buttonCalculate_Click: Unknown Error : " + ex.Message);

            }

        }

        private void OnClose(object sender, EventArgs e)
        {
            logger.Trace("Main Window Closed");
        }
    }
}




