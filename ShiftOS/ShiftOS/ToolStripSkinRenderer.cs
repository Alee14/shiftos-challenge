using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace ShiftOS
{
    public class ToolStripSkinRenderer : ToolStripProfessionalRenderer
    {
        private SystemContext CurrentSystem = null;

        public ToolStripSkinRenderer(SystemContext InSystem) : base(new ToolStripSkinColorTable(InSystem))
        {
            CurrentSystem = InSystem;
        }
    }

    public class ToolStripSkinColorTable : ProfessionalColorTable
    {
        private SystemContext CurrentSystem;

        public ToolStripSkinColorTable(SystemContext InSystem)
        {
            CurrentSystem = InSystem;
        }

        public override Color ButtonSelectedHighlight => ButtonSelectedGradientMiddle;

        public override Color ButtonSelectedHighlightBorder => ButtonSelectedBorder;

        public override Color ButtonPressedHighlight => ButtonPressedGradientMiddle;

        public override Color ButtonPressedHighlightBorder => ButtonPressedBorder;

        public override Color ButtonCheckedHighlight => ButtonCheckedGradientMiddle;

        public override Color ButtonCheckedHighlightBorder => ButtonCheckedHighlightBorder;

        public override Color ButtonPressedBorder => Color.Gray;

        public override Color ButtonSelectedBorder => Color.Gray;

        public override Color ButtonCheckedGradientBegin => Color.Gray;

        public override Color ButtonCheckedGradientMiddle => Color.Gray;

        public override Color ButtonCheckedGradientEnd => Color.Gray;

        public override Color ButtonSelectedGradientBegin => Color.Gray;

        public override Color ButtonSelectedGradientMiddle => Color.Gray;

        public override Color ButtonSelectedGradientEnd => Color.Gray;

        public override Color ButtonPressedGradientBegin => Color.Gray;

        public override Color ButtonPressedGradientMiddle => Color.Gray;

        public override Color ButtonPressedGradientEnd => Color.Gray;

        public override Color CheckBackground => Color.Gray;

        public override Color CheckSelectedBackground => Color.Gray;

        public override Color CheckPressedBackground => Color.Gray;

        public override Color GripDark => Color.Gray;

        public override Color GripLight => Color.White;

        public override Color ImageMarginGradientBegin => CurrentSystem.GetSkinContext().GetSkinData().applauncherbackgroundcolour;

        public override Color ImageMarginGradientMiddle => ImageMarginGradientBegin;

        public override Color ImageMarginGradientEnd => ImageMarginGradientBegin;

        public override Color ImageMarginRevealedGradientBegin => Color.Gray;

        public override Color ImageMarginRevealedGradientMiddle => Color.Gray;

        public override Color ImageMarginRevealedGradientEnd => Color.Gray;

        public override Color MenuStripGradientBegin => (CurrentSystem.GetSkinContext().HasImage("applauncher") ? Color.Transparent : CurrentSystem.GetSkinContext().GetSkinData().applauncherbuttoncolour);

        public override Color MenuStripGradientEnd => MenuStripGradientBegin;

        public override Color MenuItemSelected => CurrentSystem.GetSkinContext().GetSkinData().applaunchermouseovercolour;

        public override Color MenuItemBorder => (CurrentSystem.GetSkinContext().HasImage("applauncher") ? Color.Transparent : MenuItemSelected);

        public override Color MenuBorder => (CurrentSystem.GetSkinContext().HasImage("applauncher") ? Color.Transparent : CurrentSystem.GetSkinContext().GetSkinData().applauncherbackgroundcolour);

        public override Color MenuItemSelectedGradientBegin => MenuItemSelected;

        public override Color MenuItemSelectedGradientEnd => MenuItemSelectedGradientBegin;

        public override Color MenuItemPressedGradientBegin => (CurrentSystem.GetSkinContext().HasImage("applauncher") ? Color.Transparent : CurrentSystem.GetSkinContext().GetSkinData().applauncherbuttonclickedcolour);

        public override Color MenuItemPressedGradientMiddle => MenuItemPressedGradientBegin;

        public override Color MenuItemPressedGradientEnd => MenuItemPressedGradientBegin;

        public override Color RaftingContainerGradientBegin => Color.FromName("ButtonFace");

        public override Color RaftingContainerGradientEnd => RaftingContainerGradientEnd;

        public override Color SeparatorDark => Color.Black;

        public override Color SeparatorLight => SeparatorDark;

        public override Color StatusStripGradientBegin => Color.Gray;

        public override Color StatusStripGradientEnd => Color.Gray;

        public override Color ToolStripBorder => Color.Gray;

        public override Color ToolStripDropDownBackground => MenuStripGradientBegin;

        public override Color ToolStripGradientBegin => Color.Gray;

        public override Color ToolStripGradientMiddle => Color.Gray;

        public override Color ToolStripGradientEnd => Color.Gray;

        public override Color ToolStripContentPanelGradientBegin => Color.Gray;

        public override Color ToolStripContentPanelGradientEnd => Color.Gray;

        public override Color ToolStripPanelGradientBegin => Color.Gray;

        public override Color ToolStripPanelGradientEnd => Color.Gray;

        public override Color OverflowButtonGradientBegin => Color.Gray;

        public override Color OverflowButtonGradientMiddle => Color.Gray;

        public override Color OverflowButtonGradientEnd => Color.Gray;
    }
}
