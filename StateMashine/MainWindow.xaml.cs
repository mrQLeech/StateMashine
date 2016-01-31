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
    public partial class MainWindow : Window, IActivatingItem, IStateMashine, IScreenChanger
    {
        public IFormsState beginState;
        public IFormsState activeForm;
        public IFormsState sceneChanged;

        private IFormsState _state;
        
        public MainWindow()
        {
            InitializeComponent();

            beginState = new BeginState(this);
            activeForm = new ActiveState(this);
            sceneChanged = new SceneChangedState(this);

            this._state = beginState;
        }

        

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _state.Activate();
        }

        public void ActivateForm()
        {
            this.Button2.IsEnabled = true;
        }

        public void SetState(IFormsState state)
        {
            this._state = state;
        }

        public void ChangeScreen()
        {
            var confirmWindow = new ConfirmWindow();
            confirmWindow.Show();
        }

        public IFormsState GetActiveState()
        {
            return activeForm;
        }
    }
}
