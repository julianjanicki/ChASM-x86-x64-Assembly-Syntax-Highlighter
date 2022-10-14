using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace ChASM
{
    internal static class FileAndContentTypeDefinitions
    {
        [Export]
        [Name("masm")]
        [BaseDefinition("text")]
        internal static ContentTypeDefinition hidingContentTypeDefinition = null;

        [Export]
        [FileExtension(".asm")]
        [ContentType("masm")]
        internal static FileExtensionToContentTypeDefinition hiddenFileExtensionDefinition = null;
    }
}
