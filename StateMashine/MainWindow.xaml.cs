﻿using System;
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
using StateMashine.States;
using StateMashine.FormsInterfaces;

namespace StateMashine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IStateMashine, IScreenJumper
    {
        public IFormsState _resetState;
        public IFormsState _activeState;
        

        private IFormsState _state;
        
        public MainWindow()
        {
            InitializeComponent();

            _resetState = new BeginState(this);
            _activeState = new ActiveState(this);
            

            this._state = _resetState;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _state.Activate();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            _state.ChangeScene();
        }

        public void SetState(IFormsState state)
        {
            this._state = state;
        }

        public void ActivateForm()
        {
            SetJumpButtonEnabled(true);
        }

        private void SetJumpButtonEnabled(bool enable)
        {
            this.Button2.IsEnabled = enable;
        }

        public void ChangeScreen()
        {
            var confirm = new ConfirmWindow();
            confirm.Show();
            this.Hide();

            SetJumpButtonEnabled(false);            
        }
        
        public IFormsState GetResetState()
        {
            return _resetState;
        }

        public IFormsState GetActiveState()
        {
            return _activeState;
        }
    }
}
