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
            (window as IActivatingItem).ActivateForm();
            ((IStateMashine)window ).SetState(((IActivatingItem)window).GetActiveState());


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
         //   this.window.
        }

        public void ChangeScene()
        {
            
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
