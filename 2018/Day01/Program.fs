// Learn more about F# at http://fsharp.org
namespace Aoc
open Aoc.Shared

module day01 = 
    let clean x = x |> Seq.filter (fun (x : string) -> x.Length > 0) |> Seq.map int |> Seq.toArray

    [<EntryPoint>]
    let main argv =
        let input = readLines (Array.head argv) |> Seq.map int |> Seq.toArray
            
        let frequencies = Seq.initInfinite (fun index -> Array.item (index % input.Length) input)

        let mutable state = 0
        let mutable computedValues = Set.empty.Add 0

        let mapper x =
            state <- state + x
            if Set.contains state computedValues then
                true
            else
                computedValues <- computedValues.Add state
                false

        let result = frequencies |> Seq.find mapper

        printfn "Sum is %d" state
        printfn "%d" computedValues.Count
        0 // return an integer exit code
