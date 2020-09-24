using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLich.Common
{
    public abstract class BaseScreen : UserControl
    {
        public ScreenState screenState = ScreenState.SHOWDETAIL_OBJECT;
        public abstract void UpdateComponentState();
        public void UpdateScreenState(ScreenState screenState)
        {
            this.screenState = screenState;
            UpdateComponentState();

        }
    }
    public enum ScreenState
    {
        SHOWDETAIL_OBJECT,
        CREATING_NEW_OBJECT,
        UPDATE_OBJECT,
        UPDATE_OBJECT_SAVED
    }

}
