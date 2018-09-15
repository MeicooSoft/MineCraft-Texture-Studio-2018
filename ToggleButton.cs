using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MinecraftTextureStudio
{
    public delegate void ToggleChangedHandler(EventArgs args);

    public class ToggleButton : Button
    {
        private bool toggled;

        public ToggleButton()
        {
            this.toggled = false;
            this.MouseClick += new MouseEventHandler(ToggleButton_MouseClick);
            this.Font = new Font("Arial", 10);
        }

        void ToggleButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.toggled = !this.toggled;
            refreshToggle();
        }

        private void refreshToggle()
        {
            if (this.toggled)
            {
                this.FlatStyle = FlatStyle.Standard;
                this.ForeColor = Color.White;
                this.BackColor = Color.Green;
            }
            else
            {
                this.FlatStyle = FlatStyle.System;
                this.ForeColor = Color.Black;
                this.BackColor = SystemColors.Control;
            }

            OnToggleChanged(new EventArgs());
        }

        public bool Toggled
        {
            get
            {
                return this.toggled;
            }

            set
            {
                this.toggled = value;
                refreshToggle();
            }
        }

        public event ToggleChangedHandler ToggleChanged;

        protected void OnToggleChanged(EventArgs args)
        {
            if (ToggleChanged != null)
            {
                ToggleChanged(args);
            }
        }
    }
}
