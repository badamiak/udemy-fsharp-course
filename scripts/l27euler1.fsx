let divisible (value: int) =
    if value % 3 = 0 || value % 5 = 0 then Some value else None

let folder (state: int) (value: int option) =
    match value with
    | Some i ->state + i
    | None ->  state

let euler1 (maxValueExclusive:int) =
    seq {for i in [1..maxValueExclusive-1] -> divisible i}
    |> Seq.fold folder (0)
    |> printfn "%A"
    
euler1 1000
