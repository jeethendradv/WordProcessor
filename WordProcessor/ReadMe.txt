Below are the steps taken to find the words in a word:
1. the word list is first sorted alphabatically.
2. For each word I am creating a Word object, Word.cs is a rich object class containing operations to search and replace the word.
3. We now iterate each word X in the list and iterate again to find if X contains any word.
4. If we find X contains a word Y, we check to see if none of the child words of X contains Y, 
	If so then we split X based on Y and store it in a list StringsToSearch, and add Y to child words of X.
Here is an example of this step:
	X = catsratcats
	StringsToSearch = [catsratcats]
	Y = rat
	
	now since StringsToSearch contains rat we split StringsToSearch based on rat and the result is below
	StringToSearch = [cats, cats] 
	listOfWords = [rat]

	now during iterations we come accross Y = cats and since StringToSearch contains cats we try to split and the 
	result of this will be an empty array.
	StringToSearch = [] // Empty array indicates that the word X is fully processed and the processed words can we found in listOfWords array.
	listOfWords = [rat, cats]

5. We do step 3 and 4 for each word in the list. 
6. Finally we order the list in descending order of "NumberOfWordsItContains" and get the top words.