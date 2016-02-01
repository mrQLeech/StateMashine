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
        void ChangeScene();
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

        public void ChangeScene()
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

        public void ChangeScene()
        {
            var jumper = (window as IScreenJumper);
            jumper.ChangeScreen();
            ((IStateMashine)window).SetState(jumper.GetActiveState());
        }
    }

    public class SceneChangedState : IFormsState
    {
        Window window;

        public SceneChangedState(Window window)
        {
            this.window = window;
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void ChangeScene()
        {
            throw new NotImplementedException();
        }
    }
}
