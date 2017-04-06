let childAges = 2,4

let addChildAges ages =
    let bob, sam = ages
    bob + sam

printfn "%A" (addChildAges childAges)

let addAges bob sam =
    bob + sam

printfn "%A" ((addAges 2) 4)

let area height width =
    let half x =
        0.5*x
    let mul x =
        x * width

    height
    |> half
    |> mul

printfn "%A" (area 4.0 10.0)