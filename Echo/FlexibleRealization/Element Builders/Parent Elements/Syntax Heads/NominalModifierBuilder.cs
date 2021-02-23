﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleNLG;

namespace FlexibleRealization
{
    public class NominalModifierBuilder : SyntaxHeadBuilder
    {
        public NominalModifierBuilder() : base() { }

        private StringElement NominalModifier = new StringElement();

        /// <summary>Add the valid ChildRoles for <paramref name="child"/> to <paramref name="listOfRoles"/></summary>
        private protected override void AddValidRolesForChildTo(List<ChildRole> listOfRoles, ElementBuilder child)
        {
            listOfRoles.Add(ChildRole.Head);
            listOfRoles.Add(ChildRole.Modifier);
        }

        #region Initial assignment of children

        private protected override void AssignRoleFor(IElementTreeNode child)
        {
            switch (child)
            {
                case NounBuilder nb:
                    AddChildWithRole(nb, ChildRole.Head);
                    break;
                case AdjectiveBuilder ab:
                    AddChildWithRole(ab, ChildRole.Head);
                    break;
                case AdjectivePhraseBuilder apb:
                    AddChildWithRole(apb, ChildRole.Modifier);
                    break;
                case NominalModifierBuilder nmb:
                    AddChildWithRole(nmb, ChildRole.Modifier);
                    break;
                default: 
                    AddUnassignedChild(child);
                    break;
            }
        }

        #endregion Initial assignment of children

        public override IElementTreeNode CopyLightweight() => new NominalModifierBuilder()
            .LightweightCopyChildrenFrom(this);

        public override NLGElement BuildElement()
        {
            PartOfSpeechBuilder[] orderedPartsOfSpeech = GetElementsOfTypeInSubtree<PartOfSpeechBuilder>()
                .OrderBy(child => child)
                .ToArray();
            StringBuilder stringValue = new StringBuilder();
            for (int childIndex = 0; childIndex < orderedPartsOfSpeech.Length - 1; childIndex++)
            {
                AddPartOfSpeech(orderedPartsOfSpeech[childIndex]);
                stringValue.Append(" ");
            }
            AddPartOfSpeech(orderedPartsOfSpeech.Last());
            NominalModifier.val = stringValue.ToString();
            return NominalModifier;

            void AddPartOfSpeech(PartOfSpeechBuilder partOfSpeech)
            {
                if (partOfSpeech is WordElementBuilder)
                {
                    WordElementBuilder eachWord = (WordElementBuilder)partOfSpeech;
                    stringValue.Append(eachWord.BuildWord().Base);
                }
            }
        }
    }
}
