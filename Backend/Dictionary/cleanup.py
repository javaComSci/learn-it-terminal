import re

# open file and read the lines for dictionary
f = open("dictionary.txt")
lines = f.readlines()

wordDefs = {}

for line in lines:
    # convert to lower case
    line = line.lower()

    # get rid of extraneous lines
    if "synonym" in line or "syn:" in line or "syn." in line:
        continue

    # get rid of empty lines
    if line == "\n":
        continue

    # get rid of noun or verb identifications
    line = re.sub("\(\w*.?,?\s?\w*.?\)", "", line)

    # get rid of examples
    line = re.sub("\([\w+\s]+\.?\)", "", line)

    # split into words and definitions
    wordsWithDefns = line.split("--")
    if len(wordsWithDefns) < 2:
        continue

    # print(wordsWithDefns)

    # clean word
    word = wordsWithDefns[0].strip()

    # clean definition
    definition = wordsWithDefns[1].strip()
    # definition = definition[:definition.find(";")]

    print(word, definition)

    wordDefs[word] = definition


# write cleaned dictionary to new file
with open("dictionary_cleaned.txt", "w") as d:
    print(wordDefs, file=d)