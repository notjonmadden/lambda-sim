module Base

[<Measure>] type sec
[<Measure>] type liters
[<Measure>] type flowrate = liters / sec

type StepInfo =
    { elapsed : float<sec>
    }