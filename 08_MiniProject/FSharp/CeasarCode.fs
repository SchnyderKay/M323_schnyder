module MiniProjectCaesar

open System

let caesarEncode (x: char) =
    let lowercase = 'a' <= x && x <= 'z'
    let uppercase = 'A' <= x && x <= 'Z'

    if lowercase then
        char ((((int x - int 'a') + 3) % 26) + int 'a')
    else if uppercase then
        char ((((int x - int 'A') + 3) % 26) + int 'A')
    else
        x

let isValidChar (x: char) =
    'a' <= x && x <= 'z'
    || 'A' <= x && x <= 'Z'
    || '0' <= x && x <= '9'

let caesarEncodeString (s: string):string =
    s.ToCharArray()
    |> Array.filter isValidChar
    |> Array.map caesarEncode
    |> String


