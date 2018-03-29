// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Base
open Valve
open Tank

let step command =
    Valve.step { elapsed = 0.05<sec> } command

let run stop v =
    let rec runner v vs n =
        let v' = step None v

        match n with
        | s when s = stop -> vs
        | _ -> v' :: runner v' vs (n + 1) 

    runner v [] 0

[<EntryPoint>]
let main argv = 
    let vs = Valve.init |> step (Some Open) |> run 12

    printfn "%A" vs
    0
