using ChordGeneratorMAUI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.Views
{
    public class MyWindow : Window
    {
        public MyWindow() : base()
        {
        }

        public MyWindow(Page page) : base(page)
        {
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            Task.WaitAll(TrackManager.SaveAllTracksAsync());
        }


    }
}
