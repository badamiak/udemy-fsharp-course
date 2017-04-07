let timeSpent = [30;83;49;12;74;74;86;82;15;43;24;87;3;49;81]

List.fold (fun s hrs -> s + hrs) 0 timeSpent
    |> printfn "%A"

let euPopulation = [81276000;67063000;65081000]
List.fold ( + ) 0 euPopulation
    |> printfn "%A"