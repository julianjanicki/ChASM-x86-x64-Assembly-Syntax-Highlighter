using Microsoft.VisualStudio.Language.Intellisense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChASM
{
    internal class CodeCompletion
    {
        internal static ImageSource GetItemIcon(CompletionItemType itemType)
        {
            if (itemType == CompletionItemType.Register)
            {
                return CreateBitmap(Properties.Resources.cube1.GetHbitmap());
            }
            else if (itemType == CompletionItemType.WinAPI)
            {
                return CreateBitmap(Properties.Resources.blue_squares1.GetHbitmap());
            }
            else if (itemType == CompletionItemType.Mnemonic)
            {
                return CreateBitmap(Properties.Resources.cube2.GetHbitmap());
            }
            else if (itemType == CompletionItemType.CodeSample)
            {
                return CreateBitmap(Properties.Resources.arrow1.GetHbitmap());
            }
            else
            {
                return null;
            }
        }

        private static ImageSource CreateBitmap(IntPtr intPtr)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(
                           intPtr,
                           IntPtr.Zero,
                           Int32Rect.Empty,
                           BitmapSizeOptions.FromEmptyOptions());
        }
    }

    public enum CompletionItemType
    {
        Register,
        Mnemonic,
        WinAPI,
        CodeSample
    }
}
