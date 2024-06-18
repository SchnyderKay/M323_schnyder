module SomeMathApp

type SomeMath() =
    member this.Add(a: int, b: int): int =
        if a > 5 then
            a - b
        else
            a + b
