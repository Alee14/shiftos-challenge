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

        public ToolStripSkinRenderer(SkinContext InSkinPreview) : base(new ToolStripSkinColorTable(InSkinPreview))
        {

        }
    }

    public class ToolStripSkinColorTable : ProfessionalColorTable
    {
        private SystemContext CurrentSystem;
        private SkinContext _previewSkin = null;

        public ToolStripSkinColorTable(SystemContext InSystem)
        {
            CurrentSystem = InSystem;
        }

        public ToolStripSkinColorTable(SkinContext InPreviewSkin)
        {
            _previewSkin = InPreviewSkin;
        }

        public SkinContext Skin => (_previewSkin == null) ? CurrentSystem.GetSkinContext() : _previewSkin;
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

        public override Color ImageMarginGradientBegin => Skin.GetSkinData().applauncherbackgroundcolour;

        public override Color ImageMarginGradientMiddle => ImageMarginGradientBegin;

        public override Color ImageMarginGradientEnd => ImageMarginGradientBegin;

        public override Color ImageMarginRevealedGradientBegin => Color.Gray;

        public override Color ImageMarginRevealedGradientMiddle => Color.Gray;

        public override Color ImageMarginRevealedGradientEnd => Color.Gray;

        public override Color MenuStripGradientBegin => (Skin.HasImage("applauncher") ? Color.Transparent : Skin.GetSkinData().applauncherbuttoncolour);

        public override Color MenuStripGradientEnd => MenuStripGradientBegin;

        public override Color MenuItemSelected => Skin.GetSkinData().applaunchermouseovercolour;

        public override Color MenuItemBorder => (Skin.HasImage("applauncher") ? Color.Transparent : MenuItemSelected);

        public override Color MenuBorder => (Skin.HasImage("applauncher") ? Color.Transparent : Skin.GetSkinData().applauncherbackgroundcolour);

        public override Color MenuItemSelectedGradientBegin => (Skin.HasImage("applauncher") || Skin.HasImage("applaunchermouseover") ? Color.Transparent : MenuItemSelected);

        public override Color MenuItemSelectedGradientEnd => MenuItemSelectedGradientBegin;

        public override Color MenuItemPressedGradientBegin => (Skin.HasImage("applauncher") || Skin.HasImage("applauncherclick") ? Color.Transparent : Skin.GetSkinData().applauncherbuttonclickedcolour);

        public override Color MenuItemPressedGradientMiddle => MenuItemPressedGradientBegin;

        public override Color MenuItemPressedGradientEnd => MenuItemPressedGradientBegin;

        public override Color RaftingContainerGradientBegin => Color.FromName("ButtonFace");

        public override Color RaftingContainerGradientEnd => RaftingContainerGradientEnd;

        public override Color SeparatorDark => Skin.GetSkinData().launcheritemcolour;

        public override Color SeparatorLight => SeparatorDark;

        public override Color StatusStripGradientBegin => Color.Gray;

        public override Color StatusStripGradientEnd => Color.Gray;

        public override Color ToolStripBorder => Color.Gray;

        public override Color ToolStripDropDownBackground => Skin.GetSkinData().applauncherbackgroundcolour;

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
