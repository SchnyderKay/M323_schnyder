module SomeMathTests

open Xunit
open FsCheck
open FsCheck.Xunit
open SomeMathApp

type SomeMathPropertyTests() =

    [<Property>]
    member this.``Addition should be correct`` (a: int, b: int) =
        let someMath = SomeMath()
        if a > 5 then
            Assert.Equal(a - b, someMath.Add(a, b))
        else
            Assert.Equal(a + b, someMath.Add(a, b))
