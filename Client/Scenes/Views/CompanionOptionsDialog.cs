using System.Drawing;
using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using C = Library.Network.ClientPackets;

//Cleaned
namespace Client.Scenes.Views
{
    public sealed class CompanionOptionsDialog : DXWindow
    {
        #region Properties
        public override WindowType Type => WindowType.CompanionOptions;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;

        public DXLabel TypeFilterLabel, GradeFilterLabel;
        public Point CheckBoxRightPoint;
        public DXCheckBox GoldCheckBox, WeaponCheckBox, ArmourCheckBox, HelmetCheckBox, ShieldCheckBox, NecklaceCheckBox, BraceletCheckBox, RingCheckBox, ShoesCheckBox, BookCheckBox, PotionCheckBox, MeatCheckBox, CommonCheckBox, EliteCheckBox, SuperiorCheckBox;

        #endregion

        public CompanionOptionsDialog()
        {
            TitleLabel.Text = "Companion Options";
            SetClientSize(new Size(172, 341));
            Movable = false;

            TypeFilterLabel = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "Item Type Filter:",
            };
            TypeFilterLabel.Location = new Point(ClientArea.Left + 3, ClientArea.Y + 1);
            CheckBoxRightPoint = new Point(TypeFilterLabel.Size.Width, 0);
            int i = 22;
            int gap = 16;

            GoldCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Gold:" },
                Visible = true
            };
            GoldCheckBox.Location = new Point(CheckBoxRightPoint.X - GoldCheckBox.Size.Width, ClientArea.Y + i);
            GoldCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Gold });
            };
            i += gap;

            WeaponCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Weapon:" },                
                Visible = true
            };
            WeaponCheckBox.Location = new Point(CheckBoxRightPoint.X - WeaponCheckBox.Size.Width, ClientArea.Y + i);
            WeaponCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Weapon });
            };
            i += gap;

            ArmourCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Armour:" },
                Visible = true
            };
            ArmourCheckBox.Location = new Point(CheckBoxRightPoint.X - ArmourCheckBox.Size.Width, ClientArea.Y + i);
            ArmourCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Armour });
            };
            i += gap;

            HelmetCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Helmet:" },
                Visible = true
            };
            HelmetCheckBox.Location = new Point(CheckBoxRightPoint.X - HelmetCheckBox.Size.Width, ClientArea.Y + i);
            HelmetCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Helmet });
            };
            i += gap;

            ShieldCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Shield:" },
                Visible = true
            };
            ShieldCheckBox.Location = new Point(CheckBoxRightPoint.X - ShieldCheckBox.Size.Width, ClientArea.Y + i);
            ShieldCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Shield });
            };
            i += gap;

            NecklaceCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Necklace:" },
                Visible = true
            };
            NecklaceCheckBox.Location = new Point(CheckBoxRightPoint.X - NecklaceCheckBox.Size.Width, ClientArea.Y + i);
            NecklaceCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Necklace });
            };
            i += gap;

            BraceletCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Bracelet:" },
                Visible = true
            };
            BraceletCheckBox.Location = new Point(CheckBoxRightPoint.X - BraceletCheckBox.Size.Width, ClientArea.Y + i);
            BraceletCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Bracelet });
            };
            i += gap;

            RingCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Ring:" },
                Visible = true
            };
            RingCheckBox.Location = new Point(CheckBoxRightPoint.X - RingCheckBox.Size.Width, ClientArea.Y + i);
            RingCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Ring });
            };
            i += gap;

            ShoesCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Shoes:" },
                Visible = true
            };
            ShoesCheckBox.Location = new Point(CheckBoxRightPoint.X - ShoesCheckBox.Size.Width, ClientArea.Y + i);
            ShoesCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Shoes });
            };
            i += gap;

            BookCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Book:" },
                Visible = true
            };
            BookCheckBox.Location = new Point(CheckBoxRightPoint.X - BookCheckBox.Size.Width, ClientArea.Y + i);
            BookCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Book });
            };
            i += gap;

            PotionCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Potion:" },
                Visible = true
            };
            PotionCheckBox.Location = new Point(CheckBoxRightPoint.X - PotionCheckBox.Size.Width, ClientArea.Y + i);
            PotionCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Consumable });
            };
            i += gap;

            MeatCheckBox = new DXCheckBox
            {
                Parent = this,
                ForeColour = Color.White,
                Label = { Text = "Meat:" },
                Visible = true
            };
            MeatCheckBox.Location = new Point(CheckBoxRightPoint.X - MeatCheckBox.Size.Width, ClientArea.Y + i);
            MeatCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.CompanionPickupToggle { Type = ItemType.Meat });
            };
            i += gap;


            i += gap;
            GradeFilterLabel = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "Item Grade Filter:",
            };
            GradeFilterLabel.Location = new Point(ClientArea.Left + 3, ClientArea.Y + i);
            CheckBoxRightPoint = new Point(GradeFilterLabel.Size.Width, 0);
            i += 22;

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
                CEnvir.Enqueue(new C.CompanionPickupGradeToggle { Grade = Rarity.Common });
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
                CEnvir.Enqueue(new C.CompanionPickupGradeToggle { Grade = Rarity.Superior });
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
                CEnvir.Enqueue(new C.CompanionPickupGradeToggle { Grade = Rarity.Elite });
            };
            i += gap;
        }

        #region Methods
        public void Draw(DXItemCell cell, int index)
        {
            if (InterfaceLibrary == null) return;

            if (cell.Item != null) return;

            Size s = InterfaceLibrary.GetSize(index);
            int x = (cell.Size.Width - s.Width) / 2 + cell.DisplayArea.X;
            int y = (cell.Size.Height - s.Height) / 2 + cell.DisplayArea.Y;

            InterfaceLibrary.Draw(index, x, y, Color.White, false, 0.2F, ImageType.Image);
        }

        public override void Process()
        {
            base.Process();
        }

        public void Refresh()
        {
            GoldCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Gold);
            WeaponCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Weapon);
            ArmourCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Armour);
            HelmetCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Helmet);
            ShieldCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Shield);
            NecklaceCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Necklace);
            BraceletCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Bracelet);
            RingCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Ring);
            ShoesCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Shoes);
            BookCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Book);
            PotionCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Consumable);
            MeatCheckBox.Checked = !GameScene.Game.CompanionForbiddenItems.Contains(ItemType.Meat);

            CommonCheckBox.Checked = !GameScene.Game.CompanionForbiddenGrades.Contains(Rarity.Common);
            EliteCheckBox.Checked = !GameScene.Game.CompanionForbiddenGrades.Contains(Rarity.Elite);
            SuperiorCheckBox.Checked = !GameScene.Game.CompanionForbiddenGrades.Contains(Rarity.Superior);
        }

        protected override void OnBeforeDraw()
        {
            base.OnBeforeDraw();            

            Location = new Point(GameScene.Game.CompanionBox.Location.X + GameScene.Game.CompanionBox.Size.Width + 1, GameScene.Game.CompanionBox.Location.Y);
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                CheckBoxRightPoint = Point.Empty;

                if (TypeFilterLabel != null)
                {
                    if (!TypeFilterLabel.IsDisposed)
                        TypeFilterLabel.Dispose();

                    TypeFilterLabel = null;
                }

                if (GradeFilterLabel != null)
                {
                    if (!GradeFilterLabel.IsDisposed)
                        GradeFilterLabel.Dispose();

                    GradeFilterLabel = null;
                }

                if (WeaponCheckBox != null)
                {
                    if (!WeaponCheckBox.IsDisposed)
                        WeaponCheckBox.Dispose();

                    WeaponCheckBox = null;
                }

                if (ArmourCheckBox != null)
                {
                    if (!ArmourCheckBox.IsDisposed)
                        ArmourCheckBox.Dispose();

                    ArmourCheckBox = null;
                }

                if (HelmetCheckBox != null)
                {
                    if (!HelmetCheckBox.IsDisposed)
                        HelmetCheckBox.Dispose();

                    HelmetCheckBox = null;
                }

                if (ShieldCheckBox != null)
                {
                    if (!ShieldCheckBox.IsDisposed)
                        ShieldCheckBox.Dispose();

                    ShieldCheckBox = null;
                }

                if (NecklaceCheckBox != null)
                {
                    if (!NecklaceCheckBox.IsDisposed)
                        NecklaceCheckBox.Dispose();

                    NecklaceCheckBox = null;
                }

                if (BraceletCheckBox != null)
                {
                    if (!BraceletCheckBox.IsDisposed)
                        BraceletCheckBox.Dispose();

                    BraceletCheckBox = null;
                }

                if (RingCheckBox != null)
                {
                    if (!RingCheckBox.IsDisposed)
                        RingCheckBox.Dispose();

                    RingCheckBox = null;
                }

                if (ShoesCheckBox != null)
                {
                    if (!ShoesCheckBox.IsDisposed)
                        ShoesCheckBox.Dispose();

                    ShoesCheckBox = null;
                }

                if (BookCheckBox != null)
                {
                    if (!BookCheckBox.IsDisposed)
                        BookCheckBox.Dispose();

                    BookCheckBox = null;
                }

                if (PotionCheckBox != null)
                {
                    if (!PotionCheckBox.IsDisposed)
                        PotionCheckBox.Dispose();

                    PotionCheckBox = null;
                }

                if (MeatCheckBox != null)
                {
                    if (!MeatCheckBox.IsDisposed)
                        MeatCheckBox.Dispose();

                    MeatCheckBox = null;
                }

                if (GoldCheckBox != null)
                {
                    if (!GoldCheckBox.IsDisposed)
                        GoldCheckBox.Dispose();

                    GoldCheckBox = null;
                }

                if (CommonCheckBox != null)
                {
                    if (!CommonCheckBox.IsDisposed)
                        CommonCheckBox.Dispose();

                    CommonCheckBox = null;
                }

                if (EliteCheckBox != null)
                {
                    if (!EliteCheckBox.IsDisposed)
                        EliteCheckBox.Dispose();

                    EliteCheckBox = null;
                }

                if (SuperiorCheckBox != null)
                {
                    if (!SuperiorCheckBox.IsDisposed)
                        SuperiorCheckBox.Dispose();

                    SuperiorCheckBox = null;
                }
            }

        }

        #endregion
    }
}
