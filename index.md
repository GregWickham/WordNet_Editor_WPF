# WordNet User Interface for WPF

This is a user interface for WordNet, developed on the Windows WPF platform.  It uses a modified version of WordNet for SQL Server, originally created by Michal Měchura.

![Screen shot of the WordNet GUI](/images/Screen_shot_1.jpg)

## Browsing WordNet

The user interface is centered around synsets, not words -- because that's how I perceive WordNet itself.  The typical workflow is to browse the semantic network of synsets until we find a synset of interest; and then browse the word senses linked to that synset.

Before we can start browsing synsets, we first need to get a "toe-hold" into the network of synsets.  When the WordNet Browser initially opens, it shows a tool at the top of the window that allows us to "Find synset from word":

![Find synset from word](/images/Find_synset_from_word_1.jpg)

If we select a part of speech and enter a word in the text box, the browser displays synsets that are linked to a matching word sense:

![Find synset from word - synsets matching word](/images/Find_synset_from_word_2.jpg)

When we select one of the synset glosses from the list, usage examples for that synset are displayed in the right-hand list:

![Find synset from word - usage examples for selected synset](/images/Find_synset_from_word_3.jpg)

If the selected gloss and the usage examples are what we're looking for, we can focus the browser on that synset by double-clicking on its gloss:

![Find synset from word - double click on selected synset](/images/Find_synset_from_word_4.jpg)

By double-clicking on a gloss to focus on a synset, we've established our toe-hold into WordNet's semantic network.  The "Find synset from word" tool collapses, and details are displayed for the synset that we just selected:

![Details of selected synset](/images/Synset_details_1.jpg)
