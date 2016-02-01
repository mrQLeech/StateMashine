using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StateMashine.FormsInterfaces;

namespace StateMashine.States

{
    public interface IFormsState
    {
        void Activate();
        void JumpBetweenScenes();

        void Disactivate();
    }

    public class BeginState : IFormsState
    {
        Window window;

        public BeginState(Window window)
        {
            this.window = window;
        }

        public void Activate()
        {
            var jumper = (window as IScreenJumper);
            jumper.ActivateForm();
            ((IStateMashine)window).SetState(jumper.GetActiveState());
        }

        public void JumpBetweenScenes()
        {
            
        }

        public void Disactivate()
        {
            
        }
    }

    public class ActiveState : IFormsState
    {
        Window window;

        public ActiveState(Window window)
        {
            this.window = window;
        }

        public void Activate()
        {
          
        }

        public void JumpBetweenScenes()
        {
            var jumper = (window as IScreenJumper);
            jumper.ChangeScreen();
            ((IStateMashine)window).SetState(jumper.GetResetState());
        }

        public void Disactivate()
        {
            var jumper = (window as IScreenJumper);
            jumper.DisactivateForm();
            ((IStateMashine)window).SetState(jumper.GetResetState());
        }
    }
}
