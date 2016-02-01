using StateMashine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMashine.FormsInterfaces
{
   public interface IScreenJumper
    {

        void ActivateForm();
        void DisactivateForm();
        void ChangeScreen();

        IFormsState GetResetState();
        IFormsState GetActiveState();
       
    }

    public interface IScreenJumperExtended: IScreenJumper
    {
        void CheckCondition();
        IFormsState GetConditionCheckingState();
    }
}
