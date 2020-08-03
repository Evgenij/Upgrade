using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class Block
    {
        protected int id_record;

        protected FlowLayoutPanel flowPanel;
        protected Panel panel;
        protected PictureBox box_top;
        protected PictureBox box_center;
        protected PictureBox box_bottom;
        protected TextBox textLabel;

        protected Block() 
        {
            panel = new Panel();
            box_top = new PictureBox();
            box_center = new PictureBox();
            box_bottom = new PictureBox();
            textLabel = new TextBox();
        }
    }
}
