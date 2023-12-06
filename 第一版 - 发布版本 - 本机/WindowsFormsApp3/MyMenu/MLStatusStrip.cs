using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMenu
{
    public partial class MLStatusStrip : Component
    {
        public MLStatusStrip()
        {
            InitializeComponent();
        }

        public MLStatusStrip(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
