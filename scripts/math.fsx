let floor (x:float) =
    int x

let ceil (x:float) =
    if x % 1.0 > 0.0 then (int x) + 1 else int x

let round (f:float) = //hack to provide round method since System.Math can't be found
    if f % 1.0 >= 0.5 then
        int f + 1
    else
        int f
let abs (x:float) =
    if x >= 0.0 then x else -x

let result (m:string) (x:bool)=
    printfn "%s -> %b" m x
let test = 
    result "floor 2.6 should be 2" ((floor 2.6) = 2)
    result "floor 2.4 should be 2" ((floor 2.4) = 2)
    result "ceil  2.0 should be 2" ((ceil 2.0) = 2)
    result "ceil  2.1 should be 2" ((ceil 2.1) = 2)
    result "round 2.0 should be 2" ((round 2.0) = 2)
    result "round 2.1 should be 2" ((round 2.1) = 2)
    result "round 2.4 should be 2" ((round 2.4) = 2)
    result "round 2.5 should be 3" ((round 2.5) = 3)
    result "round 2.9 should be 3" ((round 2.9) = 3)
    result "abs   2.0 should be 2.0" ((abs 2.0) = 2.0)
    result "abs   -2.0 should be 2.0" ((round -2.0) = 2)
    result "abs   0.0 should be 0.0" ((round 0.0) = 0)
    
    
    

test;;
printfn "DONE"