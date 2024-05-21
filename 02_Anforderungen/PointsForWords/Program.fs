open System

let scoreWord (word: string) =
    word
    |> Seq.sumBy (fun c -> if c <> 'a' then int c - 96 else 0)

let rec getWordsFromUser () =
    Console.Write("Enter a word or 'q' to quit: ")
    let input = Console.ReadLine()
    if input.ToLower() = "q" then
        []
    else
        input :: getWordsFromUser()

let main () =
    let words = getWordsFromUser()
    let scoredWords = List.map (fun w -> (w, scoreWord w)) words
    let sortedWords = List.sortByDescending snd scoredWords
    Console.WriteLine("nSorted words by score:")
    for (w, _) in sortedWords do
        Console.WriteLine(w)
    0

main()
