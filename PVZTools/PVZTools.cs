using ITrainerExtension;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PVZTools
{
    public class CancelFullScreen : ITrainerExtensionButton
    {
        public string Text => "取消全屏模式";

        public string ToolTip => "可用于修复win10系统因不支持全屏而报错的问题";

        public string[] TextLang => new[] { "取消全屏模式", "CancelFullScreen" };

        public string[] ToolTipLang => new[] { "可用于修复win10系统因不支持全屏而报错的问题",
            "Can be used to fix the problem that the Windows 10 system reports an error because it does not support full screen" };

        public void ButtonOnClick()
        {
            RegistryKey software = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey popCap = software.OpenSubKey("PopCap");
            if(popCap != null)
            {
                RegistryKey pvz = popCap.OpenSubKey("PlantsVsZombies", true);
                pvz?.SetValue("ScreenMode", 0, RegistryValueKind.DWord);
                if(Lang.IsChinese)
                    System.Windows.Forms.MessageBox.Show("修改成功", "针对普通版本", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    System.Windows.Forms.MessageBox.Show("Successfully repaired", "For normal version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RegistryKey steamPopCap = software.OpenSubKey("SteamPopCap");
            if(steamPopCap != null)
            {
                RegistryKey pvz = steamPopCap.OpenSubKey("PlantsVsZombies", true);
                pvz?.SetValue("ScreenMode", 0, RegistryValueKind.DWord);
                if(Lang.IsChinese)
                    System.Windows.Forms.MessageBox.Show("修改成功", "针对Steam版本", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    System.Windows.Forms.MessageBox.Show("Successfully repaired", "For Steam version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class OpenTexturedFontEditor : ITrainerExtensionButton
    {
        public string Text => "纹理化字体生成工具";

        public string ToolTip => "程序来源未知(TexturedFontEditor)，配合字体转换器使用";

        public string[] TextLang => new[] { "纹理化字体生成工具", "TexturedFontEditor" };

        public string[] ToolTipLang => new[] { "程序来源未知(TexturedFontEditor)，配合字体转换器使用",
            "Program source unknown, used with font converter together" };

        private TexturedFontEditor.FontEditor Instance;

        public void ButtonOnClick()
        {
            if(Instance == null)
                Instance = new TexturedFontEditor.FontEditor();
            if(Instance.IsDisposed)
                Instance = new TexturedFontEditor.FontEditor();
            Instance.Show();
        }
    }

    public class Openpvz_cnv2_font_convarter : ITrainerExtensionButton
    {
        static Openpvz_cnv2_font_convarter()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            new pvz_cnv2_font_convarter.Form1().Dispose();
        }

        public string Text => "汉化2版字体转换器";

        public string ToolTip => "作者冥谷川恋(pvz_cnv2_font_converter)，配合纹理化字体生成工具使用";

        public string[] TextLang => new[] { "汉化2版字体转换器", "pvz_cnv2_font_converter" };

        public string[] ToolTipLang => new[] { "作者冥谷川恋(pvz_cnv2_font_converter)，配合纹理化字体生成工具使用",
            "programmed by Lazuplis，used with TexturedFontEditor together" };

        private pvz_cnv2_font_convarter.Form1 Instance;

        public void ButtonOnClick()
        {
            if(Instance == null)
                Instance = new pvz_cnv2_font_convarter.Form1();
            if(Instance.IsDisposed)
                Instance = new pvz_cnv2_font_convarter.Form1();
            Instance.Show();
        }
    }
}
