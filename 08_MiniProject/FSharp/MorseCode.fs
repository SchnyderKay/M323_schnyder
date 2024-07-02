module MiniProjectMorseCode

let morseCode =
    dict [
        'a', ".-"
        'b', "-..."
        'c', "-.-."
        'd', "-.."
        'e', "."
        'f', "..-."
        'g', "--."
        'h', "...."
        'i', ".."
        'j', ".---"
        'k', "-.-"
        'l', ".-.."
        'm', "--"
        'n', "-."
        'o', "---"
        'p', ".--."
        'q', "--.-"
        'r', ".-."
        's', "..."
        't', "-"
        'u', "..-"
        'v', "...-"
        'w', ".--"
        'x', "-..-"
        'y', "-.--"
        'z', "--.."
        '1', ".----"
        '2', "..---"
        '3', "...--"
        '4', "....-"
        '5', "....."
        '6', "-...."
        '7', "--..."
        '8', "---.."
        '9', "----."
        '0', "-----"
        ' ', " "        // Add space handling
        '\n', "  "      // Add line break handling (can be adjusted as needed)
    ]

let isValidChar (x: char) =
    ('a' <= x && x <= 'z')
    || ('A' <= x && x <= 'Z')
    || ('0' <= x && x <= '9')
    || (x = ' ')
    || (x = '\n')

let morseEncode (x: char) =
    if morseCode.ContainsKey(x) then morseCode.[x] else ""

let morseCodeString (s: string) =
    s.ToLower().ToCharArray()
    |> Array.filter isValidChar
    |> Array.map morseEncode
    |> String.concat " "
