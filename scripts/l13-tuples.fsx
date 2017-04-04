let location = 77.52, 166.40, 21

let longAlt location =
    let long,_,alt = location
    alt,long

printfn "%A" (longAlt location)
printfn "%A" (fst (longAlt location))
printfn "%A" (snd (longAlt location))

let bday time =
    let day,month,year = time
    year,month,day

printfn "%A" (bday (21,1,1970))