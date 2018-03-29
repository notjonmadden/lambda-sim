module Tank

open Base

type State =
    { volume : float<liter>
    ; inFlowRate : float<flowrate> }

type Action
    = Idle

let update info state =
    let inFlowSinceLastStep = state.inFlowRate * info.elapsed

    { state with volume = state.volume + inFlowSinceLastStep }

let transition state =
    state

let apply command state =
    state

let step info command =
    transition >> (apply command) >> (update info)