// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Valve
open Tank

let run stop v =
    let rec runner v vs n =
        let v' = Valve.step None v

        match n with
        | s when s = stop -> vs
        | _ -> v' :: runner v' vs (n + 1) 

    runner v [] 0

[<EntryPoint>]
let main argv = 
    let vs = Valve.init |> Valve.step (Some Open) |> run 12

    printfn "%A" vs
    0
