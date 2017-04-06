let floor (x:float) =
    int x

let ceil (x:float) =
    if x % 1.0 > 0.0 then (int x) + 1 else int x

let round (f:float) =
    if f % 1.0 >= 0.5 then
        int f + 1
    else
        int f
let abs (x:float) =
    if x >= 0.0 then x else -x