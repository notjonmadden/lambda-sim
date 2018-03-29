module Valve
open Base

type Command
    = Close
    | Open

type Action
    = Idle
    | Closing
    | Opening

type State =
    { position : int
    ; action : Action
    }

let private minPosition = 0
let private maxPosition = 100
let private rate = 11

let private update info state =
    match state with
    | { action = Closing } -> { state with position = state.position - rate |> max minPosition }
    | { action = Opening } -> { state with position = state.position + rate |> min maxPosition }
    | _ -> state

let private transition state =
    match state with
    | { action = Closing } when state.position <= minPosition -> { state with action = Idle }
    | { action = Opening } when maxPosition <= state.position -> { state with action = Idle }
    | _ -> state

let private apply command state =
    match command with
    | Some Close when state.action = Idle -> { state with action = Closing }
    | Some Open  when state.action = Idle -> { state with action = Opening }
    | _ -> state

let step info command =
    transition >> (apply command) >> (update info)

let init =
    { position = 0; action = Idle }