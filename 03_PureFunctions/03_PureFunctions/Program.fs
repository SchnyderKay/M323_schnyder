open System


// 3.1
let rec listSum list =
    match list with
    | [] -> 0
    | head::tail -> head + listSum tail

printfn "%A" (listSum [3; 2; 7; 8; 4]) // Expected Outcome: 24

// 3.2
let rec listSum3 list =
    match list with
    | [] -> 0
    | head::tail -> head + listSum3 tail

let listAverage list =
    match list with
    | [] -> 0.0
    | _ -> (float (List.sum list)) / (float (List.length list))

printfn "%A" (listAverage [3; 2; 7; 8; 4]) // Expected Outcome: 4.8

// 3.3 
let rec listSortAlphabetically list =
    match list with
    | [] -> []
    | [x] -> [x]
    | _ ->
        let firstFound = List.minBy (fun x -> x) list
        firstFound :: (listSortAlphabetically (List.filter (fun x -> x <> firstFound) list))

printfn "%A" (listSortAlphabetically ["Elf"; "Fünf"; "Eins"; "Zwei"; "Drei"]) // Expected Outcome: ["Drei"; "Eins"; "Elf"; "Fünf"; "Zwei"]

// 3.3 without recursion
let listSortAlphabetically2 list =
    List.sortBy (fun x -> x) list

printfn "%A" (listSortAlphabetically2 ["Elf"; "Fünf"; "Eins"; "Zwei"; "Drei"]) // Expected Outcome: ["Drei"; "Eins"; "Elf"; "Fünf"; "Zwei"]

// 3.4 
type Item = {
    date: DateTime
    priority: int
    title: string
}

let rec listSortObject list =
    match list with
    | [] -> []
    | [x] -> [x]
    | _ ->
        let firstFound = List.minBy (fun x -> (x.date.Ticks, x.priority, x.title)) list
        firstFound :: (listSortObject (List.filter (fun x -> x <> firstFound) list))

let testData = [
    { date = DateTime(2005, 2, 18); priority = 1; title = "Test1" }
    { date = DateTime(2011, 4, 1); priority = 5; title = "Test2" }
    { date = DateTime(2001, 4, 15); priority = 7; title = "Test3" }
    { date = DateTime(1999, 1, 3); priority = 3; title = "Test4" }
    { date = DateTime(1987, 7, 1); priority = 11; title = "Test5" }
]

printfn "%A" (listSortObject testData)

// 3.5
let rec flatArray (list: obj list) : int list =
    List.collect (fun (x: obj) ->
        match x with
        | :? int as i -> [i]
        | :? list<obj> as l -> flatArray l
        | _ -> []
    ) list

let result = flatArray [box 1; box 2; box [box [box [box 3; box []; box 4]]]; box 5; box [box 6]]
printfn "%A" result


