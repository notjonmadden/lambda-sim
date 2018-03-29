module Tank

type State =
    { volume : int
    ; inPressure : double }

let step state =
    state