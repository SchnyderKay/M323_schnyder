open System


// 2.1
let addToCart cartItems item =
    List.append cartItems [item]

let result211 = addToCart [] "Apple"
let result212 = addToCart ["Apple"] "Banana"
let result213 = addToCart ["Apple"; "Banana"] "Orange"

printfn "%A" result211
printfn "%A" result212
printfn "%A" result213

// 2.2
let firstCharacter (str: string) =
    if str.Length = 0 then
        ""
    else
        str.[0] |> string

let result221 = firstCharacter "Hello"
let result222 = firstCharacter "JavaScript"

printfn "%s" result221
printfn "%s" result222

// 2.3
let multiplyWithRandom (number: int)=
    let random = new Random()
    number *  Convert.ToInt32(random.NextDouble())

let result231 = multiplyWithRandom 5
let result232 = multiplyWithRandom 10

printfn "%d" result231
printfn "%d" result232

// 2.4
let divideNumbers (dividend: int) (divisor: int) =
    if divisor = 0 then
        0
    else
        dividend / divisor

let result241 = divideNumbers 10 2
let result242 = divideNumbers 8 4

printfn "%d" result241
printfn "%d" result242

// 2.5
let printAndReturnString (str: string) =
    printf "%s" str
    str

let result = printAndReturnString "Hello"
printfn "%s" result

