// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Base
open Valve
open Tank

let step command =
    Valve.step { command = command; inFlow = 5.0<flowrate> }

let run stop v t =
    let rec runner v t vs n =
        let v' = step None v
        let t' = Tank.step { flow = v'.outFlow; elapsed = 0.05<sec> } t

        match n with
        | s when s = stop -> vs
        | _ -> (v', t') :: runner v' t' vs (n + 1) 

    runner v t [] 0

[<EntryPoint>]
let main argv = 
    let v = Valve.init |> step (Some Open)
    let t = Tank.init
    let vs = run 25 v t

    vs |> List.map (fun p -> (Valve.show (fst p)), Tank.show (snd p)) |> List.iter (fun p -> printfn "%A" p)
    0
