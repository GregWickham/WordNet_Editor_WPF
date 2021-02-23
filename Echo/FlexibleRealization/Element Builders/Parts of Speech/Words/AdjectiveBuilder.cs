﻿using System;
using System.Collections.Generic;
using SimpleNLG;

namespace FlexibleRealization
{
    public class AdjectiveBuilder : WordElementBuilder, IPhraseHead
    {
        /// <summary>This constructor is using during parsing</summary>
        public AdjectiveBuilder(ParseToken token) : base(lexicalCategory.ADJECTIVE, token) { }

        /// <summary>This constructor is used during LightweightCopy().</summary>
        private AdjectiveBuilder(string word) : base(lexicalCategory.ADJECTIVE, word) { }

        /// <summary>This constructor is used by the UI for changing the part of speech of a word in the graph</summary>
        public AdjectiveBuilder() : base(lexicalCategory.ADJECTIVE) { }

        /// <summary>Return true if this AdjectiveBuilder is a head of an AdjectivePhraseBuilder</summary>
        public override bool IsPhraseHead => Parent is AdjectivePhraseBuilder && AssignedRole == ParentElementBuilder.ChildRole.Head;

        /// <summary>Implementation of IPhraseHead : AsPhrase()</summary>
        public override PhraseBuilder AsPhrase() => AsAdjectivePhrase();

        /// <summary>If the parent of this is an AdjectivePhraseBuilder return that parent, else return null</summary>
        internal AdjectivePhraseBuilder ParentAdjectivePhrase => Parent as AdjectivePhraseBuilder;

        /// <summary>If there's a comparative adverb modifying this, return it.  If no such comparative adverb exists, return null.</summary>
        internal AdverbBuilder ComparativeModifier
        {
            get
            {
                if (IsPhraseHead) 
                {
                    foreach (IElementBuilder eachModifier in ParentAdjectivePhrase.Modifiers)
                    {
                        switch (eachModifier)
                        {
                            case AdverbBuilder adverb:
                                if (adverb.Comparative) return adverb;
                                break;
                            case AdverbPhraseBuilder adverbPhrase:
                                AdverbBuilder headAdverb = adverbPhrase.UnaryHead as AdverbBuilder;
                                if (headAdverb != null && headAdverb.Comparative) return headAdverb;
                                break;
                            default: break;
                        }
                    }
                    return null;
                }
                else return null;
            }            
        }

        /// <summary>If necessary, reconfigure the appropriate things so this and <paramref name="aNoun"/> become components of a compound word</summary>
        internal void FormCompoundWith(NounBuilder aNoun)
        {
            if (!IsCompoundedWith(aNoun))
                MoveTo(aNoun.AsCompoundNoun(), ParentElementBuilder.ChildRole.Component);
        }

        /// <summary>Transform this AdjectiveBuilder into an AdjectivePhraseBuilder with this as its head</summary>
        internal AdjectivePhraseBuilder AsAdjectivePhrase()
        {
            AdjectivePhraseBuilder result = new AdjectivePhraseBuilder();
            Parent?.ReplaceChild(this, result);
            result.AddHead(this);
            return result;
        }

        #region Editing

        private protected override HashSet<Type> TypesThatCanBeAdded { get; } = new HashSet<Type>
        {
            typeof(AdverbBuilder),
            typeof(AdverbPhraseBuilder),
            typeof(PrepositionalPhraseBuilder)
        };

        /// <summary>Add <paramref name="node"/> to the tree in which this exists</summary>
        public override IParent Add(IElementTreeNode node)
        {
            IParent modifiedParent;
            switch (node)
            {
                case AdverbBuilder advb:
                    modifiedParent = this.AsAdjectivePhrase();
                    modifiedParent.AddChild(advb);
                    return modifiedParent;
                case AdverbPhraseBuilder apb:
                    modifiedParent = this.AsAdjectivePhrase();
                    modifiedParent.AddChild(apb);
                    return modifiedParent;
                case PrepositionalPhraseBuilder ppb:
                    modifiedParent = this.AsAdjectivePhrase();
                    modifiedParent.AddChild(ppb);
                    return modifiedParent;
                default: return null;
            }
        }

        #endregion Editing

        public override IElementTreeNode CopyLightweight() => new AdjectiveBuilder(WordSource.GetWord());
    }
}
