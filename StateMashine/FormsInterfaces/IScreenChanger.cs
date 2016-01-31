using StateMashine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMashine.FormsInterfaces
{
    interface IScreenChanger
    {
        void ChangeScreen();

        IFormsState GetSceneChangedState();
    }
}
