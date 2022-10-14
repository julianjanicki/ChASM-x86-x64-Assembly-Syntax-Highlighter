using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChASM
{
    internal class ChASMTagger : ITagger<ChASMTag>
    {
        private IClassifier m_classifier;

        internal ChASMTagger(IClassifier classifier)
        {
            m_classifier = classifier;
        }

        IEnumerable<ITagSpan<ChASMTag>> ITagger<ChASMTag>.GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (SnapshotSpan span in spans)
            {
                foreach (ClassificationSpan classification in m_classifier.GetClassificationSpans(span))
                {
                    var text = classification.Span.GetText().ToLower();

                    foreach (var api in Globalz.WinAPIs.Items)
                    {
                        var indexAPI = text.IndexOf(api.ToLower());
                        var indexCall = text.IndexOf("call");
                        var indexQuote = text.IndexOf("\"");
                        var indexApostrophe = text.IndexOf("\'");

                        if (indexAPI != -1 && indexCall != -1 && indexQuote == -1 && indexApostrophe == -1)
                        {
                            yield return new TagSpan<ChASMTag>(
                                new SnapshotSpan(classification.Span.Start + indexAPI, api.Length),
                                new ChASMTag());
                        }
                    }
                }
            }
        }
#pragma warning disable CS0067
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
#pragma warning restore CS0067
    }
}