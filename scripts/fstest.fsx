open System

let mutable ok = 0
let mutable fail = 0
let test (name:string) (actual:unit->'a) (expected) =
    try
        let result = actual()
        if result = expected then 
            printfn "OK -> %s" name
            ok <- ok + 1
            true
        else 
            printfn "FAIL -> %s -> is %A but %A expected" name result expected
            fail <- fail + 1
            false
    with
        | ex -> printfn "FAIL -> %s -> %A" name ex; fail <- fail + 1; false

let summary () = 
    printfn "OK: %i; FAIL: %i" ok fail
    let result = (fail = 0)
    printfn "+---------%s-+" (if result then "--" else "----")
    printfn "| result: %s |" (if result then "OK" else "FAIL")
    printfn "+---------%s-+" (if result then "--" else "----")
    
    result

let reset () =
    ok <- 0
    fail <- 0
