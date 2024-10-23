
var words = File.ReadAllLines("words.txt").Select(w => w.ToLower()).ToList();

var valid = words.Where(ValidWord).Select(MapWord).ToList();

File.WriteAllLines("hexwords.txt", valid);
foreach (var word in valid) {
    Console.WriteLine(word);
}

Console.WriteLine($"{valid.Count}/{words.Count}");

char? MapLetter(char ch) {
    return ch switch {
        >= 'a' and <= 'f' => ch,
        'o' => '0',
        'l' => '1',
        'z' => '2',
        's' => '5',
        'g' => '9',
        _ => null
    };
}

string MapWord(string word) {
    var s = "";
    foreach (char c in word) {
        var ch = MapLetter(c);
        if (ch is null) {
            return "";
        }
        s += ch;
    }
    return s;
}

bool ValidChar(char ch) {
    return MapLetter(ch) is not null;
}

bool ValidWord(string word) {
    return word.All(ValidChar);
}

