# WordNet User Interface for WPF

This is a user interface for WordNet, developed on the Windows WPF platform.  It uses a modified version of WordNet for SQL Server, originally created by Michal Měchura.

![Screen shot of the WordNet GUI](/images/Screen_shot_1.jpg)

## Browsing WordNet

The user interface is centered around synsets, not words -- because that's how I perceive that WordNet itself is organized.  The typical workflow is:

* Search for a word sense of interest;
* Use the word sense to find a related synset;
* Navigate through the network of synsets, using the relations between them like hyperlinks;
* (optionally) browse the network of word senses linked to a synset.

### Finding a synset from a word

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

If you'd like to find a different, unrelated synset, you can always get back to the "Find synset from word" tool by clicking its expand / collapse button in the menu bar:

![Find synset from word expand / collapse button](/images/Find_synset_from_word_button.jpg)

### Navigating the semantic network of synsets

The single most interesting and valuable thing about WordNet is its rich network of links between synsets; and the browser UI provides a simple and intuitive means of navigating this network of links.

Most -- but not all -- of the lists in the synset navigator contain synsets that are adjacent to the focused synset, through one or more of the relation types defined in WordNet.  In the first two columns of this example, we can see the relations for hypernymy and hyponymy, holonymy and meronymy, types and instances.  These relation types are applicable to all synsets, regardless of the part of speech they represent.

![Synset relations common to all parts of speech](/images/Synset_relations_common_to_all_parts_of_speech.jpg)

The third column contains relations that are unique to a particular part of speech -- in this case, verbs:

![Synset relations for verbs only](/images/Synset_relations_for_verbs_only.jpg)

For relations that link to adjacent synsets, double-clicking on the gloss of a related synset will follow the corresponding link, and focus the synset navigator on the selected adjacent synset.  For example, one of the hyponyms of **"be engaged in a fight; carry on a fight"** is **"make or wage war"**:

![Select hyponym - make or wage war](/images/Synset_navigator_make_or_wage_war.jpg)

Double-clicking on "make or wage war" causes that synset to become the new focus of the synset navigator:

![Synset navigator - change focus by following relation](/images/New_synset_navigator_focus.jpg)

To show word senses linked to the synset focused in the synset navigator, click the "Show wood senses" toggle button:

![Show word senses toggle button](/images/Show_word_senses_button.jpg)

This action opens the word senses navigator.  At the top of this navigator is a list of the word senses related to the focused synset:

![Word senses linked to synset](/images/Word_senses_make_or_wage_war.jpg)

Double-clicking a word sense in this list makes that word sense the focus of the word sense navigator:

![Word sense navigator](/images/Word_sense_navigator_1.jpg)

The word sense navigator is similar to the synset navigator:  Many of its lists contain word senses adjacent to the focused word sense, through relations defined in WordNet.  For example, "warrior" is a noun derived from the verb "war":

![Word sense navigator - warrior](/images/Word_sense_navigator_warrior.jpg)

If we double-click "warrior" in the list of words derived from "war," "warrior" becomes the new focus of the word senses navigator:

![Word sense navigator - warrior focused](/images/Word_sense_navigator_warrior_focused.jpg)






