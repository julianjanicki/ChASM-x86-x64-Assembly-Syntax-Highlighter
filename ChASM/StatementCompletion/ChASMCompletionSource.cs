using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Operations;

namespace ChASM
{
    internal class ChASMCompletionSource : ICompletionSource
    {
        private ChASMCompletionSourceProvider m_sourceProvider;
        private ITextBuffer m_textBuffer;

        public ChASMCompletionSource(ChASMCompletionSourceProvider sourceProvider, ITextBuffer textBuffer)
        {
            m_sourceProvider = sourceProvider;
            m_textBuffer = textBuffer;
        }

        void ICompletionSource.AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            completionSets.Add(new CompletionSet(
                "Registers",    //the non-localized title of the tab
                "Registers",    //the display title of the tab
                FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer),
                    session),
                Globalz.Registers.Items,
                null));

            completionSets.Add(new CompletionSet(
                "Mnemonics",    //the non-localized title of the tab
                "Mnemonics",    //the display title of the tab
                FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer),
                    session),
                Globalz.Mnemonics.ItemsForCodeCompletion,
                null));

            completionSets.Add(new CompletionSet(
                "WinAPIs",    //the non-localized title of the tab
                "WinAPIs",    //the display title of the tab
                FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer),
                    session),
                Globalz.WinAPIs.ItemsForCodeCompletion,
                null));

            completionSets.Add(new CompletionSet(
                "Code Samples",    //the non-localized title of the tab
                "Code Samples",    //the display title of the tab
                FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer),
                    session),
                Globalz.Specialz.CodeSamples,
                null));
        }

        private ITrackingSpan FindTokenSpanAtPosition(ITrackingPoint point, ICompletionSession session)
        {
            SnapshotPoint currentPoint = (session.TextView.Caret.Position.BufferPosition) - 1;
            ITextStructureNavigator navigator = m_sourceProvider.NavigatorService.GetTextStructureNavigator(m_textBuffer);
            TextExtent extent = navigator.GetExtentOfWord(currentPoint);
            return currentPoint.Snapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeInclusive);
        }

        private bool m_isDisposed;
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                GC.SuppressFinalize(this);
                m_isDisposed = true;
            }
        }
    }
}
