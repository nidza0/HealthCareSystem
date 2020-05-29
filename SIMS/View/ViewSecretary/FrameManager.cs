using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SIMS.View.ViewSecretary
{
    class FrameManager
    {
        private Frame centralFrame;
        private Frame sideFrame;

        private static FrameManager instance = null;

        public Frame CentralFrame { get => centralFrame; set => centralFrame = value; }
        public Frame SideFrame { get => sideFrame; set => sideFrame = value; }

        public static FrameManager getInstance()
        {
            if(instance == null)
            {
                instance = new FrameManager();
            }
            return instance;
        }
        private FrameManager() { }


    }
}
