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
using System.Windows.Shapes;
using StateMashine.States;
using StateMashine.FormsInterfaces;

namespace StateMashine
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ConfirmWindow : Window, IStateMashine, IScreenJumper
    {
        private Window _parent; 

        private IFormsState _resetState;
        private IFormsState _activeState;

        private IFormsState _state;

        private string resetLabelText = "Hi!";
        private string activeLabelText = "Thank you";

        public ConfirmWindow(Window parent)
        {
            InitializeComponent();
            _parent = parent;

            _resetState = new BeginState(this);
            _activeState = new ActiveState(this);

            _state = _activeState;
        }
        

        public void SetState(IFormsState state)
        {
            _state = state;
        }

        public void ActivateForm()
        {
            SetJumpButtonEnabled(true);
            SetLabelTextActivity(true);
        }

        private void SetJumpButtonEnabled(bool enable)
        {
            Button1.IsEnabled = enable;
        }

        private void SetLabelTextActivity(bool activation)
        {
            Label1.Content = activation && !string.IsNullOrEmpty(textBox.Text)? 
                activeLabelText : resetLabelText;
        }

        public void DisactivateForm()
        {
            SetJumpButtonEnabled(false);
            SetLabelTextActivity(false);      
        }

        public void ChangeScreen()
        {
            _parent.Show();
            Close();
        }

        public IFormsState GetResetState()
        {
            return _resetState;
        }

        public IFormsState GetActiveState()
        {
            return _activeState;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _state.JumpBetweenScenes();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            var text = (sender as TextBox).Text;
            if (text.ToLower() == "hello" || string.IsNullOrEmpty(text))
            {
                _state.Activate();
            }
            else
            {
                _state.Disactivate();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_parent.IsVisible)
            {

                var res = MessageBox.Show(this, "You want to close the application?", "Closing", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
                if (res == MessageBoxResult.Cancel){
                    e.Cancel = true;
                    return;
                }
                else 
                {
                    if (res == MessageBoxResult.Yes)
                    {
                        _parent.Close();
                        return;
                    }
                }
                _parent.Show();
            }
        }


      
    }
}
