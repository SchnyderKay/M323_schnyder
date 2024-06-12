module MiniProjectVigenere

open System

let shiftChar (plainChar: char) (keyChar: char) =
    let shift = (int (Char.ToUpper(keyChar)) - int 'A') % 26
    if Char.IsUpper(plainChar) then
        char (((int plainChar - int 'A' + shift) % 26) + int 'A')
    else if Char.IsLower(plainChar) then
        char (((int plainChar - int 'a' + shift) % 26) + int 'a')
    else
        plainChar

let vigenereEncode (plaintext: string) (key: string) =
    let keyLength = key.Length
    plaintext
    |> Seq.mapi (fun i plainChar ->
        if Char.IsLetter(plainChar) then
            let keyChar = key.[i % keyLength]
            shiftChar plainChar keyChar
        else
            plainChar)
    |> Seq.toArray
    |> String




