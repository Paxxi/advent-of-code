module Tests

open System
open Xunit
open Aoc.day02

[<Fact>]
let ``example1`` () =
    let (twos, threes) = count "abcdef"
    Assert.False(twos);
    Assert.False(threes);

[<Fact>]
let ``example2`` () =
    let (twos, threes) = count "bababc"
    Assert.True(twos);
    Assert.True(threes);

[<Fact>]
let ``example3`` () =
    let (twos, threes) = count "abbcde"
    Assert.True(twos);
    Assert.False(threes);

[<Fact>]
let ``example4`` () =
    let (twos, threes) = count "abcccd"
    Assert.False(twos);
    Assert.True(threes);

[<Fact>]
let ``example5`` () =
    let (twos, threes) = count "aabcdd"
    Assert.True(twos);
    Assert.False(threes);

[<Fact>]
let ``example6`` () =
    let (twos, threes) = count "abcdee"
    Assert.True(twos);
    Assert.False(threes);

[<Fact>]
let ``example7`` () =
    let (twos, threes) = count "ababab"
    Assert.False(twos);
    Assert.True(threes);
