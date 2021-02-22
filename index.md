# WordNet User Interface for WPF

This is a user interface for WordNet, developed on the Windows WPF platform.  It uses a modified version of WordNet for SQL Server, originally created by Michal Měchura.

![Screen shot of the WordNet GUI](/images/Screen_shot_1.jpg)

## Browsing WordNet

The user interface is centered around synsets, not words -- because that's how I perceive WordNet itself.  The typical workflow is to browse the semantic network of synsets until we find a synset of interest; and then browse the word senses linked to that synset.

Before we can start browsing synsets, we first need to get a "toe-hold" into the network of synsets.  When the WordNet Browser initially opens, it shows a tool at the top of the window that allows us to "Find synset from word":

![Find synset from word](/images/Find_synset_from_word_1.jpg)



