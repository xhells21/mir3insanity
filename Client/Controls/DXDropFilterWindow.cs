using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Envir;
using Client.UserModels;
using Library;
using C = Library.Network.ClientPackets;

namespace Client.Controls
{
    public sealed class DXDropFilterWindow : DXWindow
    {
        public DXCheckBox CommonCheckBox, SuperiorCheckBox, EliteCheckBox;

        public override WindowType Type => WindowType.None;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => false;

        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            base.OnIsVisibleChanged(oValue, nValue);

            Location = new Point((Config.GameSize.Width - Size.Width) / 2, (Config.GameSize.Height - Size.Height) / 2);

            if (!CEnvir.Loaded || !IsVisible) return;
        }

        public DXDropFilterWindow()
        {
            TitleLabel.Text = "Drop Filter";
            CloseButton.Visible = true;

            SetClientSize(new Size(130, 65));

            int i = 8;
            int gap = 16;
            Point CheckBoxRightPoint = new Point(100, 0);

            CommonCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Common:" },
                Visible = true
            };
            CommonCheckBox.Location = new Point(CheckBoxRightPoint.X - CommonCheckBox.Size.Width, ClientArea.Y + i);
            CommonCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.DropFilterToggle { Grade = Rarity.Common });
            };
            i += gap;

            SuperiorCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Superior:" },
                Visible = true
            };
            SuperiorCheckBox.Location = new Point(CheckBoxRightPoint.X - SuperiorCheckBox.Size.Width, ClientArea.Y + i);
            SuperiorCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.DropFilterToggle { Grade = Rarity.Superior });
            };
            i += gap;

            EliteCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Elite:" },
                Visible = true
            };
            EliteCheckBox.Location = new Point(CheckBoxRightPoint.X - EliteCheckBox.Size.Width, ClientArea.Y + i);
            EliteCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.DropFilterToggle { Grade = Rarity.Elite });
            };
            i += gap;
        }
    }    
}