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
    public partial class ConfirmWindow : Window, IActivatingItem, IStateMashine
    {
        public IFormsState beginState;
        public IFormsState activeForm;
        public IFormsState sceneChanged;

        public ConfirmWindow()
        {
            InitializeComponent();
        }


        public void ActivateForm()
        {
            throw new NotImplementedException();
        }

        public void SetState(IFormsState state)
        {
            throw new NotImplementedException();
        }

        public IFormsState GetActiveState()
        {
            throw new NotImplementedException();
        }
    }
}
