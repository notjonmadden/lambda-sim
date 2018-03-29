module Base

[<Measure>] type sec
[<Measure>] type liter
[<Measure>] type flowrate = liter / sec

type StepInfo =
    { elapsed : float<sec>
    }