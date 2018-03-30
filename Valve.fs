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
    { position : float
    ; action : Action
    ; outFlow : float<flowrate>
    }

type Input =
    { command : Command option
    ; inFlow : float<flowrate>
    }

let private minPosition = 0.0
let private maxPosition = 100.0
let private rate = 11.0

let private updatePosition state =
    match state with
    | { action = Closing } -> { state with position = state.position - rate |> max minPosition }
    | { action = Opening } -> { state with position = state.position + rate |> min maxPosition }
    | _ -> state

let private updateOutFlow input state =
    { state with outFlow = input.inFlow * (state.position / 100.0) }

let private update input =
    updatePosition >> (updateOutFlow input)

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

let step input =
    transition >> (apply input.command) >> (update input)

let init =
    { position = 0.0
    ; action = Idle
    ; outFlow = 0.0<flowrate>
    }

let show v =
    System.String.Format("Position = {0}", v.position)