using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace ChASM.EditorClassifiers
{
    internal static class ChASMEditorClassifierClassificationDefinition
    {

#pragma warning disable 169

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ChASMEditorClassifier")]
        private static ClassificationTypeDefinition typeDefinition;

#pragma warning restore 169

    }
}
