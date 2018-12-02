// Learn more about F# at http://fsharp.org
namespace Aoc
open Aoc.Shared

module day02 = 
    let arrayToTuple a =
        match a with
        | [|2|] -> (true, false)
        | [|3|] -> (false, true)
        | [|2; 3|] -> (true, true)
        | _ -> (false, false)

    let folder counts = Seq.fold (fun (sum2, sum3) (count2, count3) -> (sum2 || count2, sum3 || count3)) (false, false) counts
    let folder2 counts = Seq.fold (fun (sum2, sum3) (count2, count3) -> (sum2 + (if count2 then 1 else 0), sum3 + (if count3 then 1 else 0))) (0, 0) counts
    let count (boxcode : string) = 
        seq { 'a'..'z' }
        |> Seq.map (fun letter ->
            boxcode 
            |> Seq.countBy (fun x -> if x = letter then 1 else 0)
            |> Seq.map (fun x -> match x with
                                 | (_, count) -> count)
            |> Seq.filter (fun x -> x = 2 || x = 3)
            |> Seq.distinct
            |> Seq.sort
            |> Seq.toArray
            |> arrayToTuple)
        |> folder

    let part1 filename = 
        readLines filename
        |> Seq.map count
        |> folder2
        |> (fun x -> match x with
                     | (a, b) -> printfn "Sum is :%d" (a*b)
                     | _ -> printfn "blew up")


    let isMatch result = result = 1

    let compareStrings inputs: seq<string> =
        inputs
        |> Seq.filter (fun s -> 
            inputs
            |> Seq.exists (fun elem -> 
                elem
                |> Seq.fold2 (fun state r l -> state + (if r = l then 0 else 1)) 0 s
                |> isMatch))
        

    let part2 filename =
        (readLines filename)
        |> compareStrings
        |> Seq.iter (fun s -> printfn "Matching strings %s" s)

    [<EntryPoint>]
    let main argv =
        part1 (Array.head argv)
        part2 (Array.head argv)
        0 // return an integer exit code
