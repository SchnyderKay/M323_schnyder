module MiniProjectMain

open System
open FileReader

module MorseCode = MiniProjectMorseCode
module CaesarCode = MiniProjectCaesar
module VigenereCode = MiniProjectVigenere

type InputMethod =
    | FromFile of string
    | FromConsole

type EncodingMethod =
    | Morse
    | Caesar
    | Vigenere of string

let getKey (key: string option) : Result<string, string> =
    match key with
    | Some k when k.Length >= 10 -> Ok k
    | Some _ -> Error "Key must be at least 10 characters long."
    | None -> Error "Key cannot be None."

let encodeText (method: EncodingMethod) (plaintext: string) : string =
    match method with
    | Morse -> MorseCode.morseCodeString plaintext
    | Caesar -> CaesarCode.caesarEncodeString plaintext
    | Vigenere key -> VigenereCode.vigenereEncode plaintext key

let readPlaintext (inputMethod: InputMethod) : Result<string, string> =
    match inputMethod with
    | FromFile filePath -> readFile filePath
    | FromConsole ->
        printfn "Enter the text to encode: "
        Ok (Console.ReadLine())

let determineEncodingMethod (method: string) (key: string option) : Result<EncodingMethod, string> =
    match method.ToLower() with
    | "morse" -> Ok Morse
    | "caesar" -> Ok Caesar
    | "vigenere" ->
        match getKey key with
        | Ok k -> Ok (Vigenere k)
        | Error e -> Error e
    | _ -> Error "Invalid encoding method"

[<EntryPoint>]
let main argv =
    let rec mainLoop () =
        // Read input method
        printfn "Do you want to read the text from a file (f) or enter manually (m)? "
        let inputMethod =
            match Console.ReadLine().ToLower() with
            | "f" ->
                printfn "Enter the file path: "
                FromFile (Console.ReadLine())
            | "m" -> FromConsole
            | _ ->
                printfn "Invalid option. Please enter 'f' for file or 'm' for manual entry."
                mainLoop ()
                |> ignore
                FromConsole  // dummy return to satisfy type requirement, not used

        // Read plaintext
        let plaintextResult = readPlaintext inputMethod

        let plaintext =
            match plaintextResult with
            | Ok text -> text
            | Error errMsg ->
                printfn "Error: %s" errMsg
                mainLoop ()
                |> ignore
                "" // dummy return to satisfy type requirement, not used

        // Read encoding method
        printfn "Enter the encoding method (morse, caesar, or vigenere): "
        let method = Console.ReadLine().ToLower()

        // Determine encoding method and possibly get key
        let encodingMethodResult =
            if method = "vigenere" then
                printfn "Enter the key (minimum length 10): "
                let key = Some (Console.ReadLine())
                determineEncodingMethod method key
            else
                determineEncodingMethod method None

        // Encode text
        let encodedText =
            match encodingMethodResult with
            | Ok m -> encodeText m plaintext
            | Error errMsg ->
                printfn "Error: %s" errMsg
                mainLoop ()
                |> ignore
                "" // dummy return to satisfy type requirement, not used

        printfn "Encoded text: %s" encodedText

        // Continue loop?
        printfn "Do you want to continue (y/n)? "
        let keepRunningInput = Console.ReadLine().ToLower()
        if keepRunningInput = "y" then
            mainLoop ()
        else
            exit 0

    mainLoop ()
