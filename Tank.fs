module Tank

open Base

type State =
    { volume : float<liters>
    }

type Input = 
    { elapsed : float<sec>
    ; flow : float<flowrate>
    }

type Action
    = Idle

let private update input state =
    let inFlowSinceLastStep = input.flow * input.elapsed

    { state with volume = state.volume + inFlowSinceLastStep }

let private transition state =
    state

let private apply command state =
    state

let step info =
    transition >> (update info)

let init =
    { volume = 0.0<liters>
    }

let show t =
        System.String.Format("Volume = {0}", t.volume)